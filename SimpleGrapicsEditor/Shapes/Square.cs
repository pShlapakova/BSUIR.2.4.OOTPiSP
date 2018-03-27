namespace SimpleGrapicsEditor.Shapes
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.Serialization;

    /// <inheritdoc cref="Shape"/>
    /// <summary>
    /// Defines properties and inherited methods that represents
    /// square characteristics.
    /// </summary>
    [DataContract]
    public class Square : Shape
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
        /// <param name="length">The length of the square side.</param>
        /// <param name="penWidth">The value indicating the width of this <see cref="Shapes.Pen"/></param>
        /// <param name="penColor">The value indicating the color of this <see cref="Shapes.Pen"/></param>
        /// <param name="penDashStyle">The value indicating the style used for dashed lines drawn with this <see cref="Shapes.Pen"/></param>
        public Square(int x, int y, int length, float penWidth, Color penColor, DashStyle penDashStyle) : base(penWidth, penColor, penDashStyle)
        {
            this.X = x;
            this.Y = y;
            this.Length = length;
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
        /// Gets or sets length of <see cref="Square"/>.
        /// </summary>
        [DataMember]
        public int Length { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Defines the implementation of method used to build square using this <see cref="GraphicsPath"/>.
        /// </summary>
        public override void CreateShape()
        {
            base.CreateShape();
            this.GraphicsPath.StartFigure();
            this.GraphicsPath.AddRectangle(new System.Drawing.Rectangle(this.X, this.Y, this.Length, this.Length));
            this.GraphicsPath.CloseFigure();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Square({this.X},{this.Y}; {this.Length}; {this.PenWidth}, {this.PenColor}, {this.PenDashStyle})";
        }

        #endregion                               
    }
}
