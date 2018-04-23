namespace SimpleGrapicsEditor.Shapes
{
    using System;
    using System.ComponentModel.Composition;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.Serialization;

    /// <inheritdoc cref="AbstractShape"/>
    /// <summary>
    /// Defines properties and inherited methods that represents
    /// arc characteristics.
    /// </summary>
    [DataContract]
    [Export(typeof(AbstractShape))]
    [ExportMetadata("Name", "Star")]
    public class Star : AbstractShape
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Star"/> class with default values.
        /// </summary>
        public Star() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Star"/> class with specified properties.
        /// </summary>
        /// <param name="x">The x-coordinate of the upper-left position of the star.</param>
        /// <param name="y">The y-coordinate of the upper-left position of the star.</param>
        /// <param name="radius">The radius of the star.</param>
        /// <param name="penWidth">The value indicating the width of this <see cref="Shapes.Pen"/></param>
        /// <param name="penColor">The value indicating the color of this <see cref="Shapes.Pen"/></param>
        /// <param name="penDashStyle">The value indicating the style used for dashed lines drawn with this <see cref="Shapes.Pen"/></param>
        public Star(int x, int y, int radius, float penWidth, Color penColor, DashStyle penDashStyle) : base(penWidth, penColor, penDashStyle)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets x-coordinate of upper-left <see cref="Star"/> position.
        /// </summary>
        [DataMember]
        public int X { get; set; }

        /// <summary>
        /// Gets or sets y-coordinate of upper-left <see cref="Star"/> position.
        /// </summary>
        [DataMember]
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets radius of <see cref="Star"/>.
        /// </summary>
        [DataMember]
        public int Radius { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Defines the implementation of method used to build star using this <see cref="GraphicsPath"/>.
        /// </summary>
        public override void CreateShape()
        {
            base.CreateShape();

            Point starCenter = new Point(this.X + this.Radius, this.Y + this.Radius);
            double currAngle = Math.PI / 2;

            this.GraphicsPath.StartFigure();

            for (int i = 0; i < 5; i++)
            {
                this.GraphicsPath.AddLine(
                    GetPointOnCircle(starCenter, this.Radius, currAngle),
                    GetPointOnCircle(starCenter, this.Radius, currAngle += 4 * Math.PI / 5));
            }

            this.GraphicsPath.CloseFigure();

            Point GetPointOnCircle(Point center, int radius, double angle)
            {
                int x = (int)(center.X + (Math.Cos(angle) * radius));
                int y = (int)(center.Y - (Math.Sin(angle) * radius));

                return new Point(x, y);
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Star({this.X},{this.Y}; {this.Radius}; {this.PenWidth}, {this.PenColor}, {this.PenDashStyle})";
        }

        /// <summary>
        /// Used to make a copy of this <see cref="Star"/>.
        /// </summary>
        /// <returns>A copy of this <see cref="Star"/>.</returns>
        public override object Clone()
        {
            return new Star(
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
