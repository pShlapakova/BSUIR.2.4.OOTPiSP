namespace SimpleGrapicsEditor
{
    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    using System.IO;
    using System.Reflection;
    using System.Security.Permissions;
    using System.Security.Policy;

    /// <summary>
    /// Used for plugins management.
    /// </summary>
    public static class PluginManager
    {
        #region Fields

        #region Common

        /// <summary>
        /// Contains the strong name of the current executing assembly.
        /// </summary>
        private static readonly StrongName ThisAppStrongName;

        /// <summary>
        /// The catalog with only signature checked plugins.
        /// </summary>
        private static AggregateCatalog aggregateCatalog;

        /// <summary>
        /// Container for imported and exported parts composition.
        /// </summary>
        private static CompositionContainer compositionContainer;

        #endregion

        #region For Shape Plugins

        /// <summary>
        /// The catalog with all available plugins.
        /// </summary>
        private static readonly DirectoryCatalog ShapePluginsDirectoryCatalog;
        
        #endregion

        #region For Functional Plugins

        /// <summary>
        /// The catalog with all available plugins.
        /// </summary>
        private static readonly DirectoryCatalog FunctionalPluginsDirectoryCatalog;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes static members of the <see cref="PluginManager"/> class.
        /// </summary>
        static PluginManager()
        {
            ShapePluginsDirectoryCatalog = new DirectoryCatalog(Directory.GetCurrentDirectory() + @"\..\..\Plugins\ShapePlugins", "*.dll");
            FunctionalPluginsDirectoryCatalog = new DirectoryCatalog(Directory.GetCurrentDirectory() + @"\..\..\Plugins\FunctionalPlugins", "*.dll");

            aggregateCatalog = new AggregateCatalog();
            compositionContainer = new CompositionContainer(aggregateCatalog);

            ThisAppStrongName = GetStrongName(Assembly.GetExecutingAssembly());
        }

        #endregion

        #region Properties        

        #region For Shape Plugins

        /// <summary>
        /// Gets the path observed by the <see cref="System.ComponentModel.Composition.Hosting.DirectoryCatalog"/> object.
        /// </summary>
        public static string ShapePluginsPath => ShapePluginsDirectoryCatalog.Path;

        /// <summary>
        /// Gets the translated absolute path observed by the <see cref="System.ComponentModel.Composition.Hosting.DirectoryCatalog"/> object.
        /// </summary>
        public static string ShapePluginsFullPath => ShapePluginsDirectoryCatalog.FullPath;

        /// <summary>
        /// Gets the search pattern that is passed into the constructor of the
        /// <see cref="System.ComponentModel.Composition.Hosting.DirectoryCatalog"/> object.
        /// </summary>
        public static string ShapePluginsSearchPattern => ShapePluginsDirectoryCatalog.SearchPattern;

        #endregion

        #region For Functional Plugins

        /// <summary>
        /// Gets the path observed by the <see cref="System.ComponentModel.Composition.Hosting.DirectoryCatalog"/> object.
        /// </summary>
        public static string FunctionalPluginsPath => FunctionalPluginsDirectoryCatalog.Path;

        /// <summary>
        /// Gets the translated absolute path observed by the <see cref="System.ComponentModel.Composition.Hosting.DirectoryCatalog"/> object.
        /// </summary>
        public static string FunctionalPluginsFullPath => FunctionalPluginsDirectoryCatalog.FullPath;

        /// <summary>
        /// Gets the search pattern that is passed into the constructor of the
        /// <see cref="System.ComponentModel.Composition.Hosting.DirectoryCatalog"/> object.
        /// </summary>
        public static string FunctionalPluginsSearchPattern => FunctionalPluginsDirectoryCatalog.SearchPattern;

        #endregion

        #endregion

        #region Methods

        #region Public

        /// <summary>
        /// Imports shape plugins to <see cref="PluginContainer"/>.
        /// </summary>
        /// <param name="pluginContainer">Container for plugins of all types.</param>
        /// <param name="afterImportPostProcessing">Refers to method that must be runned after import.</param>        
        public static void ImportPlugins(PluginContainer pluginContainer, Action afterImportPostProcessing)
        {
            AddSignedPlugins(aggregateCatalog, ShapePluginsDirectoryCatalog);
            AddSignedPlugins(aggregateCatalog, FunctionalPluginsDirectoryCatalog);

            compositionContainer.ComposeParts(pluginContainer);

            afterImportPostProcessing();
        }

        /// <summary>
        /// Refreshes shape plugins in the ShapePluginsDirectoryCatalog. Reload them to <see cref="PluginContainer"/>.
        /// </summary>
        /// <param name="pluginContainer">Container for plugins of all types.</param>
        /// <param name="afterRefreshPostProcessing">Refers to method that must be runned after refresh.</param>        
        public static void RefreshPlugins(PluginContainer pluginContainer, Action afterRefreshPostProcessing)
        {
            ShapePluginsDirectoryCatalog.Refresh();
            FunctionalPluginsDirectoryCatalog.Refresh();

            // The next 2 lines allows to add appeared and remove disappeared plugins in the directory.
            // Without them we can only add appeared plugins, but not delete disappeared.
            aggregateCatalog = new AggregateCatalog();
            compositionContainer = new CompositionContainer(aggregateCatalog);

            ImportPlugins(pluginContainer, afterRefreshPostProcessing);
        }

        #endregion

        #region Private

        /// <summary>
        /// Adds signed plugins to this <see cref="AggregateCatalog"/>.
        /// </summary>
        /// <param name="ac">A catalog that will contain signed plugins.</param>
        /// <param name="dc">A catalog with all available plugins.</param>
        private static void AddSignedPlugins(AggregateCatalog ac, DirectoryCatalog dc)
        {
            foreach (string assemblyPath in dc.LoadedFiles)
            {
                StrongName assemblyStrongName = GetStrongName(Assembly.LoadFile(assemblyPath));
                if (assemblyStrongName == null)
                {
                    continue;
                }

                if (assemblyStrongName.PublicKey.Equals(ThisAppStrongName.PublicKey))
                {
                    AssemblyCatalog pluginAc = new AssemblyCatalog(assemblyPath);

                    // if (!aggrCatalog.Catalogs.Contains(newAC)) - not working
                    if (!IsAlreadyLoaded(ac, pluginAc))
                    {
                        ac.Catalogs.Add(pluginAc);

                        // MessageBox.Show(
                        // Assembly.LoadFile(assemblyPath).FullName + ", IsFullyTrusted: " + Assembly.LoadFile(assemblyPath).IsFullyTrusted,
                        // "Info!",
                        // MessageBoxButtons.OK,
                        // MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // MessageBox.Show(
                    // assemblyStrongName.Name + " has incorrect sign!",
                    // "Warning!",
                    // MessageBoxButtons.OK,
                    // MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Returns the strong name of passed assembly if it is has a sign;
        /// otherwise returns null.
        /// </summary>
        /// <param name="assembly">The assembly that strong name the method will return.</param>
        /// <returns>The strong name of passed assembly if it is has a sign;
        /// otherwise returns null.</returns>
        private static StrongName GetStrongName(Assembly assembly)
        {
            AssemblyName assemblyName = assembly.GetName();

            byte[] publicKey = assemblyName.GetPublicKey();
            if (publicKey == null || publicKey.Length == 0)
            {
                // MessageBox.Show($"{assemblyName.Name} is not signed!", "Warning!", MessageBoxButtons.OK);
                return null;
            }

            StrongNamePublicKeyBlob keyBlob = new StrongNamePublicKeyBlob(publicKey);
            return new StrongName(keyBlob, assemblyName.Name, assemblyName.Version);
        }

        /// <summary>
        /// Returns true if <paramref name="aggrCatalog"/> already contains assemblies
        /// from <paramref name="assCatalog"/>; otherwise returns false;
        /// </summary>
        /// <param name="aggrCatalog">The catalog to check for assemblies
        /// from <paramref name="assCatalog"/> to be already contained.</param>
        /// <param name="assCatalog">The catalog with assemblies to be checked for containing
        /// in <paramref name="aggrCatalog"/>.</param>
        /// <returns>true if <paramref name="aggrCatalog"/> already contains assemblies
        /// from <paramref name="assCatalog"/>; otherwise false.</returns>
        private static bool IsAlreadyLoaded(AggregateCatalog aggrCatalog, AssemblyCatalog assCatalog)
        {
            bool isLoaded = false;

            foreach (ComposablePartCatalog baseCatalog in aggrCatalog.Catalogs)
            {
                if (baseCatalog.GetType() == typeof(AssemblyCatalog))
                {
                    if ((baseCatalog as AssemblyCatalog).Assembly.FullName == assCatalog.Assembly.FullName)
                    {
                        isLoaded = true;
                        break;
                    }
                }
            }

            return isLoaded;
        }

        #endregion

        #endregion
    }
}
