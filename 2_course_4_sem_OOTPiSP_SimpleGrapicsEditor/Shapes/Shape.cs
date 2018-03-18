using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    public abstract class Shape : IComparable<Shape>
    {        
        public GraphicsPath @GraphicsPath { get; } = new GraphicsPath();
        public Pen @Pen { get; } = new Pen(Color.Black, 1F) { DashStyle = DashStyle.Solid };

        public float PenWidth
        {
            get { return Pen.Width; }

            set { Pen.Width = value; }
        }

        public Color PenColor
        {
            get { return Pen.Color; }

            set { Pen.Color = value; }
        }

        public DashStyle PenDashStyle
        {
            get { return Pen.DashStyle; }

            set { Pen.DashStyle = value; }
        }

        protected Shape() { }        

        protected Shape(float penWidth, Color penColor, DashStyle penDashStyle) : this()
        {                       
            PenWidth = penWidth;
            PenColor = penColor;
            PenDashStyle = penDashStyle;            
        }

        public int CompareTo(Shape shape)
        {
            return ToString().CompareTo(shape.ToString());
        }

        public abstract void CreateShape();

        public abstract override string ToString();        
    }
}
