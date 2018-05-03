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
