namespace Management
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Windows.Forms;
    using ShapePluginBase;

    /// <summary>
    /// Used to serialize and deserialize <see cref="AbstractShape"/> objects.
    /// </summary>
    public static class SerializationManager
    {
        #region Fields

        /// <summary>
        /// Gets list that contains the types that may be present in the object graph. 
        /// </summary>
        private static readonly List<Type> JsonKnownTypes;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes static members of the <see cref="SerializationManager"/> class.
        /// </summary>
        static SerializationManager()
        {
            // We need AbstractType to avoid errors if some of deserialized shapes are not loaded as plugins.
            JsonKnownTypes = new List<Type> { typeof(AbstractShape) };
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs after serialization is finished.
        /// </summary>
        public static event Func<string, string> AfterSerialization;

        /// <summary>
        /// Occurs before deserialization is started.
        /// </summary>
        public static event Func<string, string> BeforeDeserialization;

        #endregion
       
        #region Methods

        #region Public

        /// <summary>
        /// Serializes <paramref name="shapes"/> to the file located at <paramref name="filePath"/>
        /// </summary>
        /// <param name="filePath">The location of file to store serialized objects.</param>
        /// <param name="shapes">The array of objects to be serialized.</param>
        public static void Serialization(string filePath, AbstractShape[] shapes)
        {
            string graph = Serialize(shapes);

            try
            {
                File.WriteAllText(filePath, graph);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, e.TargetSite.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;                
            }
        }
        
        /// <summary>
        /// Deserializes objects from the file located at <paramref name="filePath"/> and returns
        /// array of them.
        /// </summary>
        /// <param name="filePath">The location of the file with serialized objects.</param>
        /// <returns>The array of objects that was deserialized from the file.</returns>
        public static AbstractShape[] Deserialization(string filePath)
        {
            string graph = null;

            try
            {
                graph = File.ReadAllText(filePath);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, e.TargetSite.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
                //return null;
            }

            return Deserialize(graph);
        }

        /// <summary>
        /// Refreshes types allowed for <see cref="DataContractJsonSerializer"/>
        /// depending on currently loaded shape plugins.
        /// </summary>
        /// <param name="importedShapePlugins">The collection of currently loaded shape plugins.</param>
        public static void RefreshJsonKnownTypes(IEnumerable<Lazy<AbstractShape, IShapeData>> importedShapePlugins)
        {
            JsonKnownTypes.Clear();

            JsonKnownTypes.Add(typeof(AbstractShape));

            foreach (Lazy<AbstractShape, IShapeData> shapePlugin in importedShapePlugins)
            {
                JsonKnownTypes.Add(shapePlugin.Value.GetType());
            }
        }

        #endregion

        #region Private

        /// <summary>
        /// Serializes <paramref name="shapes"/> to the <see cref="string"/>.
        /// </summary>
        /// <param name="shapes">The array of objects to be serialized.</param>
        /// <returns>The <see cref="string"/> of serialized objects.</returns>
        private static string Serialize(AbstractShape[] shapes)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(AbstractShape[]), JsonKnownTypes);

            string result = null;
            using (MemoryStream ms = new MemoryStream())
            {
                jsonSerializer.WriteObject(ms, shapes);

                ms.Position = 0;
                byte[] buffer = ms.ToArray();
                result = Encoding.Default.GetString(buffer);
            }

            // Extandable by functional plugins.
            if (AfterSerialization != null)
            {
                result = AfterSerialization(result);
            }

            return result;
        }

        /// <summary>
        /// Deserializes objects from the <see cref="string"/> and returns array of them.
        /// </summary>
        /// <param name="graph">Text of serialized objects.</param>
        /// <returns>The array of objects that was deserialized from the file.</returns>
        private static AbstractShape[] Deserialize(string graph)
        {
            var jsonDeserializer = new DataContractJsonSerializer(typeof(AbstractShape[]), JsonKnownTypes);

            // Extandable by functional plugins.
            if (BeforeDeserialization != null)
            {
                graph = BeforeDeserialization(graph);
            }            
                                    
            AbstractShape[] result = null;            
            using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(graph)))
            {
                result = (AbstractShape[])jsonDeserializer.ReadObject(ms);                
            }

            return result;
        }

        #endregion    

        #endregion        
    }
}
