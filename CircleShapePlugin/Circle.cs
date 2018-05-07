namespace CircleShapePlugin
{
    using System.ComponentModel.Composition;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.Serialization;
    using ShapePluginBase;

    /// <inheritdoc cref="AbstractShape"/>
    /// <summary>
    /// Defines properties and inherited methods that represents
    /// circle characteristics.
    /// </summary>    
    [DataContract]
    [Export(typeof(AbstractShape))]
    [ExportMetadata("Name", "Circle")]
    public class Circle : AbstractShape
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class with default values.
        /// </summary>
        public Circle() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class with specified properties.
        /// </summary>
        /// <param name="x">The x-coordinate of the upper-left position of the circle.</param>
        /// <param name="y">The y-coordinate of the upper-left position of the circle.</param>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="penWidth">The value indicating the width of this <see cref="IShape.Pen"/></param>
        /// <param name="penColor">The value indicating the color of this <see cref="IShape.Pen"/></param>
        /// <param name="penDashStyle">The value indicating the style used for dashed lines drawn with this <see cref="IShape.Pen"/></param>
        public Circle(int x, int y, int radius, float penWidth, Color penColor, DashStyle penDashStyle) : base(penWidth, penColor, penDashStyle)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets x-coordinate of upper-left <see cref="Circle"/> position.
        /// </summary>
        [DataMember]
        public int X { get; set; }

        /// <summary>
        /// Gets or sets y-coordinate of upper-left <see cref="Circle"/> position.
        /// </summary>
        [DataMember]
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets radius of <see cref="Circle"/>.
        /// </summary>
        [DataMember]
        public int Radius { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Defines the implementation of method used to build circle using this <see cref="GraphicsPath"/>.
        /// </summary>
        public override void CreateShape()
        {
            base.CreateShape();
            this.GraphicsPath.StartFigure();
            this.GraphicsPath.AddEllipse(this.X, this.Y, this.Radius * 2, this.Radius * 2);
            this.GraphicsPath.CloseFigure();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{nameof(Circle)}({this.X},{this.Y}; {this.Radius}; {this.PenWidth}, {this.PenColor}, {this.PenDashStyle})";
        }

        /// <summary>
        /// Used to make a copy of this <see cref="Circle"/>.
        /// </summary>
        /// <returns>A copy of this <see cref="Circle"/>.</returns>
        public override object Clone()
        {
            return new Circle(
                this.X,
                this.Y,
                this.Radius,
                this.PenWidth,
                this.PenColor,
                this.PenDashStyle);
        }

        #endregion    
    }
}
