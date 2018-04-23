namespace SimpleGrapicsEditor.Shapes
{
    using System.ComponentModel.Composition;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.Serialization;

    /// <inheritdoc cref="AbstractShape"/>
    /// <summary>
    /// Defines properties and inherited methods that represents arc characteristics.
    /// </summary>
    [DataContract]
    [Export(typeof(AbstractShape))]
    [ExportMetadata("Name", "Arc")]
    public class Arc : AbstractShape
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Arc"/> class with default values.
        /// </summary>
        public Arc() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Arc"/> class with specified properties.
        /// </summary>
        /// <param name="x">The x-coordinate of the upper-left position of the arc.</param>
        /// <param name="y">The y-coordinate of the upper-left position of the arc.</param>
        /// <param name="width">The width of the arc.</param>
        /// <param name="height">The height of the arc.</param>
        /// <param name="startAngle">The start angle of the arc.</param>
        /// <param name="sweepAngle">The sweep angle of the arc.</param>
        /// <param name="penWidth">The value indicating the width of this <see cref="Shapes.Pen"/></param>
        /// <param name="penColor">The value indicating the color of this <see cref="Shapes.Pen"/></param>
        /// <param name="penDashStyle">The value indicating the style used for dashed lines drawn with this <see cref="Shapes.Pen"/></param>
        public Arc(int x, int y, int width, int height, float startAngle, float sweepAngle, float penWidth, Color penColor, DashStyle penDashStyle) : base(penWidth, penColor, penDashStyle)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.StartAngle = startAngle;
            this.SweepAngle = sweepAngle;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets x-coordinate of upper-left <see cref="Arc"/> position.
        /// </summary>
        [DataMember]
        public int X { get; set; }

        /// <summary>
        /// Gets or sets y-coordinate of upper-left <see cref="Arc"/> position.
        /// </summary>
        [DataMember]
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Arc"/> width.
        /// </summary>
        [DataMember]
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Arc"/> height.
        /// </summary>
        [DataMember]
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Arc"/> start angle.
        /// </summary>
        [DataMember]
        public float StartAngle { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Arc"/> sweep angle.
        /// </summary>
        [DataMember]
        public float SweepAngle { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Defines the implementation of method used to build arc using this <see cref="GraphicsPath"/>.
        /// </summary>
        public override void CreateShape()
        {
            base.CreateShape();
            this.GraphicsPath.StartFigure();
            this.GraphicsPath.AddArc(this.X, this.Y, this.Width, this.Height, this.StartAngle, this.SweepAngle);
            this.GraphicsPath.CloseFigure();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Arc({this.X},{this.Y}; {this.Width},{this.Height}; {this.StartAngle},{this.SweepAngle}; {this.PenWidth}, {this.PenColor}, {this.PenDashStyle})";
        }

        /// <summary>
        /// Used to make a copy of this <see cref="Arc"/>.
        /// </summary>
        /// <returns>A copy of this <see cref="Arc"/>.</returns>
        public override object Clone()
        {
            return new Arc(
                this.X,
                this.Y,
                this.Width,
                this.Height,
                this.StartAngle,
                this.SweepAngle,
                this.PenWidth,
                this.PenColor,
                this.PenDashStyle);
        }

        #endregion
    }
}
