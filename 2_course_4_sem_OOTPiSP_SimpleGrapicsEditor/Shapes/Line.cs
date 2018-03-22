﻿namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.Serialization;

    /// <inheritdoc cref="Shape"/>
    /// <summary>
    /// Defines properties and inherited methods that represents
    /// line characteristics.
    /// </summary>
    [DataContract]
    public class Line : Shape
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class with default values.
        /// </summary>
        public Line() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class with specified properties.
        /// </summary>
        /// <param name="x1">The first x-coordinate of the line.</param>
        /// <param name="y1">The first y-coordinate of the line.</param>
        /// <param name="x2">The second x-coordinate of the line.</param>
        /// <param name="y2">The second y-coordinate of the line.</param>
        /// <param name="penWidth">The value indicating the width of this <see cref="Shapes.Pen"/></param>
        /// <param name="penColor">The value indicating the color of this <see cref="Shapes.Pen"/></param>
        /// <param name="penDashStyle">The value indicating the style used for dashed lines drawn with this <see cref="Shapes.Pen"/></param>
        public Line(int x1, int y1, int x2, int y2, float penWidth, Color penColor, DashStyle penDashStyle) : base(penWidth, penColor, penDashStyle)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets first x-coordinate of <see cref="Line"/>.
        /// </summary>
        [DataMember]
        public int X1 { get; set; }

        /// <summary>
        /// Gets or sets first y-coordinate of <see cref="Line"/>.
        /// </summary>
        [DataMember]
        public int Y1 { get; set; }


        /// <summary>
        /// Gets or sets second x-coordinate of <see cref="Line"/>.
        /// </summary>
        [DataMember]
        public int X2 { get; set; }

        /// <summary>
        /// Gets or sets second y-coordinate of <see cref="Line"/>.
        /// </summary>
        [DataMember]
        public int Y2 { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Defines the implementation of method used to build line using this <see cref="GraphicsPath"/>.
        /// </summary>
        public override void CreateShape()
        {
            base.CreateShape();
            this.GraphicsPath.StartFigure();
            this.GraphicsPath.AddLine(this.X1, this.Y1, this.X2, this.Y2);
            this.GraphicsPath.CloseFigure();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Line({this.X1},{this.Y1}; {this.X2},{this.Y2}; {this.PenWidth}, {this.PenColor}, {this.PenDashStyle})";
        }

        #endregion                        
    }
}
