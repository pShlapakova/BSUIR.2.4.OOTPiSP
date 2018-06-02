namespace ShapePluginBase
{
    using System.Drawing;
    using System.Drawing.Drawing2D;

    /// <summary>
    /// The interface for a drawable geometric figure.
    /// </summary>    
    public interface IShape
    {
        /// <summary>
        /// Gets <see cref="System.Drawing.Drawing2D.GraphicsPath"/> to build geometric
        /// figure for further drawing using <see cref="System.Drawing.Graphics"/>.
        /// </summary>
        GraphicsPath GraphicsPath { get; }

        /// <summary>
        /// Gets <see cref="System.Drawing.Pen"/> used to draw geometric figure
        /// using <see cref="System.Drawing.Graphics"/>.
        /// </summary>
        Pen Pen { get; }

        /// <summary>
        /// Builds the geometric figure using <see cref="System.Drawing.Drawing2D.GraphicsPath"/>.
        /// </summary>
        void CreateShape();        
    }
}
