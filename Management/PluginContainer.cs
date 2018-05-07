namespace SimpleGrapicsEditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using SimpleGrapicsEditor.Shapes;

    /// <summary>
    /// Used to import Shape plugins.
    /// </summary>
    public class PluginContainer
    {
        /// <summary>
        /// The instance of <see cref="PluginContainer"/>
        /// </summary>
        private static PluginContainer instance;

        /// <summary>
        /// Prevents a default instance of the <see cref="PluginContainer"/> class from being created.
        /// </summary>
        private PluginContainer()
        {
        }

        /// <summary>
        /// Gets the instance of the <see cref="PluginContainer"/> class.
        /// </summary>
        public static PluginContainer GetInstance => instance ?? (instance = new PluginContainer());        

        /// <summary>
        /// Gets or sets imported shape objects.
        /// </summary>
        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<Lazy<AbstractShape, IShapeData>> ImportedShapePlugins { get; set; }

        /// <summary>
        /// Gets or sets imported functional plugins objects.
        /// </summary>
        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<Lazy<IFunctionalPlugin, IFunctionalPluginData>> ImportedFunctionalPlugins { get; set; }
    }
}
