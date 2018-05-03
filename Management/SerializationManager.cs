namespace SimpleGrapicsEditor.Tools
{    
    using System;
    using System.Collections.Generic;    
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Windows.Forms;    
    using SimpleGrapicsEditor.Shapes;    

    #region Delegates

    /// <summary>
    /// Used as type for <see cref="SerializationManager.BeforeSerialization"/>
    /// and <see cref="SerializationManager.AfterSerialization"/> events.
    /// </summary>
    /// <param name="graph">The location of the file that contains
    /// serialized objects.</param>
    /// <returns>Processed string.</returns>
    public delegate string SerializationDelegate(string graph);

    /// <summary>
    /// Used as type for <see cref="SerializationManager.BeforeDeserialization"/>
    /// and <see cref="SerializationManager.AfterDeserialization"/> events.
    /// </summary>
    /// <param name="graph">The location of the file that contains
    /// serialized objects.</param>
    /// <returns>Processed string.</returns>
    public delegate string DeserializationDelegate(string graph);

    #endregion

    /// <summary>
    /// Used to serialize and deserialize <see cref="AbstractShape"/> objects.
    /// </summary>
    public static class SerializationManager
    {
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
        public static event SerializationDelegate AfterSerialization;

        /// <summary>
        /// Occurs before deserialization is started.
        /// </summary>
        public static event DeserializationDelegate BeforeDeserialization;

        #endregion

        #region Properties

        /// <summary>
        /// Gets list that contains the types that may be present in the object graph. 
        /// </summary>
        public static List<Type> JsonKnownTypes { get; }

        #endregion

        #region Methods
        
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

        public static string Serialize(AbstractShape[] shapes)
        {                        
            var jsonSerializer = new DataContractJsonSerializer(typeof(AbstractShape[]), JsonKnownTypes);

            string result = null;
            using (MemoryStream ms = new MemoryStream())
            {
                jsonSerializer.WriteObject(ms, shapes);

                ms.Position = 0;
                byte[] buffer = ms.ToArray();
                result = System.Text.Encoding.Default.GetString(buffer);
            }

            // Extandable byfunctional plugins.
            if (AfterSerialization != null)
            {
                result = AfterSerialization(result);
            }            

            return result;
        }

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

        public static AbstractShape[] Deserialize(string graph)
        {
            var jsonDeserializer = new DataContractJsonSerializer(typeof(AbstractShape[]), JsonKnownTypes);

            // Extandable by functional plugins.
            if (BeforeDeserialization != null)
            {
                graph = BeforeDeserialization(graph);
            }            
                                    
            AbstractShape[] result = null;            
            using (MemoryStream ms = new MemoryStream(System.Text.Encoding.Default.GetBytes(graph)))
            {
                result = (AbstractShape[])jsonDeserializer.ReadObject(ms);
            }

            return result;
        }

        #endregion        
    }
}
