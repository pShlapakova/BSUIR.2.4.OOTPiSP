namespace SimpleGrapicsEditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using SimpleGrapicsEditor.Shapes;

    /// <summary>
    /// Used to import Shape plugins.
    /// </summary>
    public class ShapePluginContainer
    {
        /// <summary>
        /// Gets or sets imported shape objects.
        /// </summary>
        [ImportMany]
        public IEnumerable<Lazy<AbstractShape, IShapeData>> ImportedShapes { get; set; }
    }
}
