using System.Drawing;
using System.Drawing.Drawing2D;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    public class Line : Shape
    {
        protected readonly int x2, y2;

        public Line(int x1, int y1, int x2, int y2, float penWidth, Color penColor,
            DashStyle penDashStyle) : base(x1, y1, penWidth, penColor, penDashStyle)
        {
            this.x2 = x2;
            this.y2 = y2;
        }

        public override void CreateShape()
        {
            graphicsPath.StartFigure();
            graphicsPath.AddLine(x, y, x2, y2);
            graphicsPath.CloseFigure();
        }
    }
}
