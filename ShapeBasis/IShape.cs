namespace SimpleGrapicsEditor.Shapes
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
        /// Gets or sets the width of this <see cref="IShape.Pen"/>.
        /// </summary>
        float PenWidth { get; set; }

        /// <summary>
        /// Gets or sets the color of this <see cref="IShape.Pen"/>.
        /// </summary>
        Color PenColor { get; set; }

        /// <summary>
        /// Gets or sets the style used for dashed lines drawn with this <see cref="IShape.Pen"/>.
        /// </summary>
        DashStyle PenDashStyle { get; set; }

        /// <summary>
        /// Builds the geometric figure using <see cref="System.Drawing.Drawing2D.GraphicsPath"/>.
        /// </summary>
        void CreateShape();        
    }
}
