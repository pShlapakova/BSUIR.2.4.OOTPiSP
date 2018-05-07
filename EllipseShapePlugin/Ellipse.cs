namespace EllipseShapePlugin
{
    using System.ComponentModel.Composition;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.Serialization;
    using ShapePluginBase;

    /// <inheritdoc cref="AbstractShape"/>
    /// <summary>
    /// Defines properties and inherited methods that represents
    /// ellipse characteristics.
    /// </summary>    
    [DataContract]
    [Export(typeof(AbstractShape))]
    [ExportMetadata("Name", "Ellipse")]
    public class Ellipse : AbstractShape
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Ellipse"/> class with default values.
        /// </summary>
        public Ellipse() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ellipse"/> class with specified properties.
        /// </summary>
        /// <param name="x">The x-coordinate of the upper-left position of the ellipse.</param>
        /// <param name="y">The y-coordinate of the upper-left position of the ellipse.</param>
        /// <param name="width">The width of the ellipse.</param>
        /// <param name="height">The height of the ellipse.</param>
        /// <param name="penWidth">The value indicating the width of this <see cref="IShape.Pen"/></param>
        /// <param name="penColor">The value indicating the color of this <see cref="IShape.Pen"/></param>
        /// <param name="penDashStyle">The value indicating the style used for dashed lines drawn with this <see cref="IShape.Pen"/></param>
        public Ellipse(int x, int y, int width, int height, float penWidth, Color penColor, DashStyle penDashStyle) : base(penWidth, penColor, penDashStyle)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets x-coordinate of upper-left <see cref="Ellipse"/> position.
        /// </summary>
        [DataMember]
        public int X { get; set; }

        /// <summary>
        /// Gets or sets y-coordinate of upper-left <see cref="Ellipse"/> position.
        /// </summary>
        [DataMember]
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets width of <see cref="Ellipse"/>.
        /// </summary>
        [DataMember]
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets height of <see cref="Ellipse"/>.
        /// </summary>
        [DataMember]
        public int Height { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Defines the implementation of method used to build ellipse using this <see cref="GraphicsPath"/>.
        /// </summary>
        public override void CreateShape()
        {
            base.CreateShape();
            this.GraphicsPath.StartFigure();
            this.GraphicsPath.AddEllipse(this.X, this.Y, this.Width, this.Height);
            this.GraphicsPath.CloseFigure();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{nameof(Ellipse)}({this.X},{this.Y}; {this.Width},{this.Height}; {this.PenWidth}, {this.PenColor}, {this.PenDashStyle})";
        }

        /// <summary>
        /// Used to make a copy of this <see cref="Ellipse"/>.
        /// </summary>
        /// <returns>A copy of this <see cref="Ellipse"/>.</returns>
        public override object Clone()
        {
            return new Ellipse(
                this.X,
                this.Y,
                this.Width,
                this.Height,
                this.PenWidth,
                this.PenColor,
                this.PenDashStyle);
        }

        #endregion                        
    }
}
