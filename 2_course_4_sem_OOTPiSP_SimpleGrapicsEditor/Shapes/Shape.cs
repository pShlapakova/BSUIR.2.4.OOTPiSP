using System.Drawing;
using System.Drawing.Drawing2D;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    public abstract class Shape
    {                
        protected GraphicsPath graphicsPath = new GraphicsPath();
        protected Pen pen = new Pen(Color.Black, 1);

        protected readonly int x, y;        

        protected Shape(int x, int y, float penWidth, Color penColor, DashStyle penDashStyle)
        {           
            this.x = x;
            this.y = y;

            pen.Width = penWidth;
            pen.Color = penColor;
            pen.DashStyle = penDashStyle;
        }

        public GraphicsPath GetGraphicsPath
        {
            get { return graphicsPath; }
        }

        public Pen GetPen
        {
            get { return pen; }
        }

        public abstract void CreateShape();

    }
}
