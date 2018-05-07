namespace PieShapePlugin
{
    using System.ComponentModel.Composition;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.Serialization;
    using ShapePluginBase;

    /// <inheritdoc cref="AbstractShape"/>
    /// <summary>
    /// Defines properties and inherited methods that represents pie characteristics.
    /// </summary>    
    [DataContract]
    [Export(typeof(AbstractShape))]
    [ExportMetadata("Name", "Pie")]
    public class Pie : AbstractShape
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Pie"/> class with default values.
        /// </summary>
        public Pie() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pie"/> class with specified properties.
        /// </summary>
        /// <param name="x">The x-coordinate of the upper-left position of the pie.</param>
        /// <param name="y">The y-coordinate of the upper-left position of the pie.</param>
        /// <param name="width">The width of the pie.</param>
        /// <param name="height">The height of the pie.</param>
        /// <param name="startAngle">The start angle of the pie.</param>
        /// <param name="sweepAngle">The sweep angle of the pie.</param>
        /// <param name="penWidth">The value indicating the width of this <see cref="IShape.Pen"/></param>
        /// <param name="penColor">The value indicating the color of this <see cref="IShape.Pen"/></param>
        /// <param name="penDashStyle">The value indicating the style used for dashed lines drawn with this <see cref="IShape.Pen"/></param>
        public Pie(int x, int y, int width, int height, float startAngle, float sweepAngle, float penWidth, Color penColor, DashStyle penDashStyle) : base(penWidth, penColor, penDashStyle)
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
        /// Gets or sets x-coordinate of upper-left <see cref="Pie"/> position.
        /// </summary>
        [DataMember]
        public int X { get; set; }

        /// <summary>
        /// Gets or sets y-coordinate of upper-left <see cref="Pie"/> position.
        /// </summary>
        [DataMember]
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Pie"/> width.
        /// </summary>
        [DataMember]
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Pie"/> height.
        /// </summary>
        [DataMember]
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Pie"/> start angle.
        /// </summary>
        [DataMember]
        public float StartAngle { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Pie"/> sweep angle.
        /// </summary>
        [DataMember]
        public float SweepAngle { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Defines the implementation of method used to build pie using this <see cref="GraphicsPath"/>.
        /// </summary>
        public override void CreateShape()
        {
            base.CreateShape();
            this.GraphicsPath.StartFigure();
            this.GraphicsPath.AddPie(this.X, this.Y, this.Width, this.Height, this.StartAngle, this.SweepAngle);
            this.GraphicsPath.CloseFigure();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{nameof(Pie)}({this.X},{this.Y}; {this.Width},{this.Height}; {this.StartAngle},{this.SweepAngle}; {this.PenWidth}, {this.PenColor}, {this.PenDashStyle})";
        }

        /// <summary>
        /// Used to make a copy of this <see cref="Pie"/>.
        /// </summary>
        /// <returns>A copy of this <see cref="Pie"/>.</returns>
        public override object Clone()
        {
            return new Pie(
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
