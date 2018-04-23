namespace SimpleGrapicsEditor.Shapes
{
    using System.ComponentModel.Composition;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.Serialization;

    /// <inheritdoc cref="AbstractShape"/>
    /// <summary>
    /// Defines properties and inherited methods that represents
    /// square characteristics.
    /// </summary>
    [DataContract]
    [Export(typeof(AbstractShape))]
    [ExportMetadata("Name", "Square")]
    public class Square : AbstractShape
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class with default values.
        /// </summary>
        public Square() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class with specified properties.
        /// </summary>
        /// <param name="x">The x-coordinate of the upper-left position of the square.</param>
        /// <param name="y">The y-coordinate of the upper-left position of the square.</param>
        /// <param name="side">The side of the square side.</param>
        /// <param name="penWidth">The value indicating the width of this <see cref="Shapes.Pen"/></param>
        /// <param name="penColor">The value indicating the color of this <see cref="Shapes.Pen"/></param>
        /// <param name="penDashStyle">The value indicating the style used for dashed lines drawn with this <see cref="Shapes.Pen"/></param>
        public Square(int x, int y, int side, float penWidth, Color penColor, DashStyle penDashStyle) : base(penWidth, penColor, penDashStyle)
        {
            this.X = x;
            this.Y = y;
            this.Side = side;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets x-coordinate of upper-left <see cref="Square"/> position.
        /// </summary>
        [DataMember]
        public int X { get; set; }

        /// <summary>
        /// Gets or sets y-coordinate of upper-left <see cref="Square"/> position.
        /// </summary>
        [DataMember]
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets side of <see cref="Square"/>.
        /// </summary>
        [DataMember]
        public int Side { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Defines the implementation of method used to build square using this <see cref="GraphicsPath"/>.
        /// </summary>
        public override void CreateShape()
        {
            base.CreateShape();
            this.GraphicsPath.StartFigure();
            this.GraphicsPath.AddRectangle(new System.Drawing.Rectangle(this.X, this.Y, this.Side, this.Side));
            this.GraphicsPath.CloseFigure();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Square({this.X},{this.Y}; {this.Side}; {this.PenWidth}, {this.PenColor}, {this.PenDashStyle})";
        }

        /// <summary>
        /// Used to make a copy of this <see cref="Square"/>.
        /// </summary>
        /// <returns>A copy of this <see cref="Square"/>.</returns>
        public override object Clone()
        {
            return new Square(
                this.X,
                this.Y,
                this.Side,
                this.PenWidth,
                this.PenColor,
                this.PenDashStyle);
        }

        #endregion                               
    }
}
