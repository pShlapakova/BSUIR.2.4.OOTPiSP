using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    public abstract class Shape
    {
        //protected Control control;
        protected Graphics graphics;
        protected GraphicsPath graphicsPath = new GraphicsPath();
        protected Pen pen = new Pen(Color.Black, 1);

        protected readonly int x, y;        

        protected Shape(Control control, int x, int y, float penWidth, Color penColor, DashStyle penDashStyle)
        {
            //this.control = control;
            graphics = control.CreateGraphics();

            pen.Width = penWidth;
            pen.Color = penColor;
            pen.DashStyle = penDashStyle;

            this.x = x;
            this.y = y;
        }

        public GraphicsPath GetGraphicsPath
        {
            get { return graphicsPath; }
        }

        public Pen GetPen
        {
            get { return pen; }
        }

        public virtual void CreateShape()
        {

        }

        public virtual void Draw()
        {
            graphics.DrawPath(pen, graphicsPath);
        }
    }
}
