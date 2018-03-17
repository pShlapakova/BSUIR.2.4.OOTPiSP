using System.Drawing;
using System.Drawing.Drawing2D;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    public abstract class Shape
    {                
        public GraphicsPath @GraphicsPath { get; }
        public Pen @Pen { get; }

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

        protected Shape()
        {
            GraphicsPath = new GraphicsPath();
            Pen = new Pen(Color.Black, 1F);
        }

        protected Shape(float penWidth, Color penColor, DashStyle penDashStyle) : this()
        {                       
            PenWidth = penWidth;
            PenColor = penColor;
            PenDashStyle = penDashStyle;            
        }

        public abstract void CreateShape();
    }
}
