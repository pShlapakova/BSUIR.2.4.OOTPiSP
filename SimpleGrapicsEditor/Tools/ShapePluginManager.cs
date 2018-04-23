namespace SimpleGrapicsEditor
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;    
    using System.IO;
    using System.Reflection;    
    using System.Security.Permissions;
    using System.Security.Policy;
    using System.Windows.Forms;

    /// <summary>
    /// Used for plugins management.
    /// </summary>
    public static class ShapePluginManager
    {
        #region Fields

        /// <summary>
        /// The catalog with all available plugins.
        /// </summary>
        private static readonly DirectoryCatalog DirectoryCatalog;

        ///// <summary>
        ///// The catalog with only signature checked plugins.
        ///// </summary>
        //private static readonly AggregateCatalog AggregateCatalog;
        
        ///// <summary>
        ///// Container for imported and exported parts composition.
        ///// </summary>
        //private static readonly CompositionContainer Container;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes static members of the <see cref="ShapePluginManager"/> class.
        /// </summary>
        static ShapePluginManager()
        {
            DirectoryCatalog = new DirectoryCatalog(Directory.GetCurrentDirectory() + @"\..\..\ShapePlugins", "*.dll");
            
            //Container = new CompositionContainer(DirectoryCatalog);          
        }

        #endregion

        #region DirectoryCatalog Properties

        /// <summary>
        /// Gets the collection of files currently loaded in the DirectoryCatalog.
        /// </summary>
        public static ReadOnlyCollection<string> LoadedFiles => DirectoryCatalog.LoadedFiles;

        /// <summary>
        /// Gets the path observed by the <see cref="System.ComponentModel.Composition.Hosting.DirectoryCatalog"/> object.
        /// </summary>
        public static string Path => DirectoryCatalog.Path;

        /// <summary>
        /// Gets the translated absolute path observed by the <see cref="System.ComponentModel.Composition.Hosting.DirectoryCatalog"/> object.
        /// </summary>
        public static string FullPath => DirectoryCatalog.FullPath;

        /// <summary>
        /// Gets the search pattern that is passed into the constructor of the
        /// <see cref="System.ComponentModel.Composition.Hosting.DirectoryCatalog"/> object.
        /// </summary>
        public static string SearchPattern => DirectoryCatalog.SearchPattern;

        #endregion

        #region Methods

        /// <summary>
        /// Imports shape plugins to <see cref="ShapePluginContainer"/>.
        /// </summary>
        /// <param name="shapePluginContainer">Container for shape plugins.</param>
        /// <param name="afterImportPostProcessing">Refers to method that must be runned after import.</param>
        public static void ImportPlugins(ShapePluginContainer shapePluginContainer, Action afterImportPostProcessing)
        {
            AggregateCatalog ac = GetCheckedPlugins(DirectoryCatalog);
            CompositionContainer cc = new CompositionContainer(ac);

            cc.ComposeParts(shapePluginContainer);

            afterImportPostProcessing();


            //Container.ComposeParts(shapePluginContainer);

            //afterImportPostProcessing();S

            //AggregateCatalog DirectoryCatalog = new AggregateCatalog();
            //DirectoryCatalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory() + @"\..\..\ShapePlugins", "*.dll"));
            //CompositionContainer Container = new CompositionContainer(DirectoryCatalog);
        }

        ///// <summary>
        ///// Refreshes shape plugins in the DirectoryCatalog. Reload them to <see cref="ShapePluginContainer"/>.
        ///// </summary>
        ///// <param name="shapePluginContainer">Container for shape plugins.</param>
        ///// <param name="afterRefreshPostProcessing">Refers to method that must be runned after refresh.</param>        
        //public static void RefreshPlugins(ShapePluginContainer shapePluginContainer, Action afterRefreshPostProcessing)
        //{
        //    DirectoryCatalog.Refresh();            

        //    AggregateCatalog ac = GetCheckedPlugins(DirectoryCatalog);
        //    CompositionContainer cc = new CompositionContainer(ac);

        //    cc.ComposeParts(shapePluginContainer);

        //    afterRefreshPostProcessing();            
        //}        

        private static AggregateCatalog GetCheckedPlugins(DirectoryCatalog directoryCatalog)
        {
            AggregateCatalog aggregateCatalog = new AggregateCatalog();

            foreach (string assemblyPath in directoryCatalog.LoadedFiles)
            {
                StrongName assemblyStrongName = GetStrongName(Assembly.LoadFile(assemblyPath));
                if (assemblyStrongName == null)
                {
                    continue;
                }

                StrongName applicationStrongName = GetStrongName(Assembly.GetExecutingAssembly());

                if (assemblyStrongName.PublicKey.Equals(applicationStrongName.PublicKey))                
                {
                    aggregateCatalog.Catalogs.Add(new AssemblyCatalog(assemblyPath));
                    MessageBox.Show(
                        Assembly.LoadFile(assemblyPath).FullName + ", IsFullyTrusted: " + Assembly.LoadFile(assemblyPath).IsFullyTrusted,
                        "Info!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        assemblyStrongName.Name + " has incorrect sign!",
                        "Warning!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }

            return aggregateCatalog;
        }

        public static StrongName GetStrongName(Assembly assembly)
        {
            AssemblyName assemblyName = assembly.GetName();

            byte[] publicKey = assemblyName.GetPublicKey();
            if (publicKey == null || publicKey.Length == 0)
            {
                MessageBox.Show($"{assemblyName.Name} is not signed!", "Warning!", MessageBoxButtons.OK);
                return null;
            }

            StrongNamePublicKeyBlob keyBlob = new StrongNamePublicKeyBlob(publicKey);
            return new StrongName(keyBlob, assemblyName.Name, assemblyName.Version);            
        }        
        #endregion
    }
}
