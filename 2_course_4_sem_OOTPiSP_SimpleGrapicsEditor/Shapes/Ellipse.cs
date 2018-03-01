using System.Drawing;
using System.Drawing.Drawing2D;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    public class Ellipse : Shape
    {
        protected readonly int width, height;

        public Ellipse(int x, int y, int width, int height, float penWidth, Color penColor,
            DashStyle penDashStyle) : base(x, y, penWidth, penColor, penDashStyle)
        {
            this.width = width;
            this.height = height;
        }

        public override void CreateShape()
        {
            graphicsPath.StartFigure();
            graphicsPath.AddEllipse(x, y, width, height);
            graphicsPath.CloseFigure();
        }
    }
}
