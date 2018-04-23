namespace SimpleGrapicsEditor.Shapes
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines common properties and methods for geometric figures drawable using <see cref="System.Drawing.Graphics"/>.
    /// </summary>    
    [DataContract]
    public abstract class AbstractShape : IShape, IComparable<AbstractShape>, ICloneable
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractShape"/> class with default values.
        /// </summary>
        protected AbstractShape()
        {        
            this.GraphicsPath = new GraphicsPath();
            this.Pen = new Pen(Color.Black, 1F) { DashStyle = DashStyle.Solid };
        }        

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractShape"/> class with the specified
        /// <see cref="System.Drawing.Pen.Width"/>, <see cref="System.Drawing.Pen.Color"/>
        /// and <see cref="System.Drawing.Pen.DashStyle"/> properties.
        /// </summary>
        /// <param name="penWidth">A value indicating the width of this <see cref="Shapes.Pen"/></param>
        /// <param name="penColor">A color structure that indicates the color of this <see cref="Shapes.Pen"/></param>
        /// <param name="penDashStyle">A value indicating the style used for dashed lines drawn with this <see cref="Shapes.Pen"/></param>
        protected AbstractShape(float penWidth, Color penColor, DashStyle penDashStyle)
            : this()
        {
            this.PenWidth = penWidth;
            this.PenColor = penColor;
            this.PenDashStyle = penDashStyle;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets <see cref="GraphicsPath"/> to build geometric figure for further drawing using <see cref="System.Drawing.Graphics"/>.
        /// </summary>
        public GraphicsPath GraphicsPath { get; private set; }

        /// <summary>
        /// Gets <see cref="System.Drawing.Pen"/> used to draw geometric figure using <see cref="System.Drawing.Graphics"/>.
        /// </summary>
        public Pen Pen { get; private set; }

        /// <summary>
        /// Gets or sets the width of this <see cref="Shapes.Pen"/>.
        /// </summary>
        [DataMember]
        public float PenWidth
        {
            get => this.Pen.Width;
            set => this.Pen.Width = value;
        }

        /// <summary>
        /// Gets or sets the color of this <see cref="Shapes.Pen"/>.
        /// </summary>
        [DataMember]
        public Color PenColor
        {
            get => this.Pen.Color;
            set => this.Pen.Color = value;
        }

        /// <summary>
        /// Gets or sets the style used for dashed lines drawn with this <see cref="Shapes.Pen"/>.
        /// </summary>
        [DataMember]
        public DashStyle PenDashStyle
        {
            get => this.Pen.DashStyle;
            set => this.Pen.DashStyle = value;
        }

        #endregion

        #region Methods

        #region Public

        /// <summary>
        /// Compares two instances of the <see cref="AbstractShape"/> and inherited classes as strings
        /// containing geometric figure's name and its properties.
        /// </summary>
        /// <param name="shape">A <see cref="AbstractShape"/> class instance with which this
        /// instance is compared.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.</returns>
        /// <inheritdoc cref="IComparable.CompareTo"/>
        public int CompareTo(AbstractShape shape)
        {
            return this.ToString().CompareTo(shape.ToString());
        }

        /// <summary>
        /// Defines the implementation of method used to build geometric
        /// figure using this <see cref="GraphicsPath"/>.
        /// </summary>
        public virtual void CreateShape()
        {
            // To prevent NullReferenceException caused by deserialization.
            //if (GraphicsPath == null)
            //{
            //    GraphicsPath = new GraphicsPath();                
            //}

            // Delete old figure from path
            GraphicsPath.Reset();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public abstract override string ToString();

        /// <summary>
        /// Used to make a copy of this shape.
        /// </summary>
        /// <returns>A copy of this shape.</returns>
        public abstract object Clone();

        #endregion

        #region Private

        // I had to made this method, because deserializer not using constructor.

        /// <summary>
        /// Used to prepare object for deserialization.
        /// </summary>
        /// <param name="sc"><see cref="StreamingContext"/> parameter that just need for
        /// this method work on deserializing. It is don't used inside method.</param>
        [OnDeserializing]        
        private void DeserializationPreparing(StreamingContext sc)
        {
            this.GraphicsPath = new GraphicsPath();
            this.Pen = this.Pen = new Pen(Color.Black, 1F) { DashStyle = DashStyle.Solid };
        }
        
        #endregion

        #endregion
    }
}
