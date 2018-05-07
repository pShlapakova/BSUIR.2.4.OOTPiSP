namespace ShapePluginBase
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines common properties and methods for geometric figures drawable using <see cref="System.Drawing.Graphics"/>.
    /// </summary>      
    [DataContract]
    public abstract class AbstractShape : IShape, ICloneable
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractShape"/> class with default values.
        /// </summary>
        protected AbstractShape()
        {        
            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractShape"/> class with the specified
        /// <see cref="System.Drawing.Pen.Width"/>, <see cref="System.Drawing.Pen.Color"/>
        /// and <see cref="System.Drawing.Pen.DashStyle"/> properties.
        /// </summary>
        /// <param name="penWidth">A value indicating the width of this <see cref="IShape.Pen"/></param>
        /// <param name="penColor">A color structure that indicates the color of this <see cref="IShape.Pen"/></param>
        /// <param name="penDashStyle">A value indicating the style used for dashed lines drawn with this <see cref="IShape.Pen"/></param>
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
        /// Gets or sets <see cref="GraphicsPath"/> to build geometric figure for further drawing using <see cref="System.Drawing.Graphics"/>.
        /// </summary>        
        public GraphicsPath GraphicsPath { get; protected set; }

        /// <summary>
        /// Gets or sets <see cref="System.Drawing.Pen"/> used to draw geometric figure using <see cref="System.Drawing.Graphics"/>.
        /// </summary>        
        public Pen Pen { get; protected set; }

        /// <summary>
        /// Gets or sets the width of this <see cref="IShape.Pen"/>.
        /// </summary>        
        public float PenWidth
        {
            get => this.Pen.Width;
            set => this.Pen.Width = value;
        }

        /// <summary>
        /// Gets or sets the color of this <see cref="IShape.Pen"/>.
        /// </summary>
        [DataMember]
        public Color PenColor
        {
            get => this.Pen.Color;
            set => this.Pen.Color = value;
        }

        /// <summary>
        /// Gets or sets the style used for dashed lines drawn with this <see cref="IShape.Pen"/>.
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
        /// Defines the implementation of method used to build geometric
        /// figure using this <see cref="GraphicsPath"/>.
        /// </summary>
        public virtual void CreateShape()
        {
            // Delete old figure from path.
            this.GraphicsPath.Reset();
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

        /// <summary>
        /// Used to prepare object for deserialization.
        /// </summary>
        /// <param name="sc"><see cref="StreamingContext"/> parameter that just need for
        /// this method work on deserializing. It is don't used inside method.</param>
        [OnDeserializing]        
        private void DeserializationPreparing(StreamingContext sc)
        {            
            this.Initialize();
        }

        /// <summary>
        /// Initializes necessary members.
        /// </summary>
        private void Initialize()
        {
            this.GraphicsPath = new GraphicsPath();
            this.Pen = this.Pen = new Pen(Color.Black, 1F) { DashStyle = DashStyle.Solid };
        }

        #endregion

        #endregion
    }
}
