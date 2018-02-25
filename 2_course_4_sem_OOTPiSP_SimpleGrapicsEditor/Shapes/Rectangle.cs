using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    public class Rectangle : Shape
    {
        protected readonly int width, height;

        public Rectangle(Control control, int x, int y, int width, int height, float penWidth, Color penColor,
            DashStyle penDashStyle) : base(control, x, y, penWidth, penColor, penDashStyle)
        {
            this.width = width;
            this.height = height;
        }

        public override void Draw()
        {
            graphicsPath.StartFigure();
            
            graphicsPath.AddRectangle(new System.Drawing.Rectangle(x, y, width, height));
            graphicsPath.CloseFigure();
            base.Draw();
        }
    }
}
