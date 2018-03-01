using System.Drawing;
using System.Drawing.Drawing2D;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    public class Arc : Shape
    {
        protected readonly int width, height;
        protected readonly float startAngle, sweepAngle;

        public Arc(int x, int y, int width, int height, float startAngle, float sweepAngle,
            float penWidth, Color penColor, DashStyle penDashStyle) : base(x, y, penWidth, penColor,
            penDashStyle)
        {
            this.width = width;
            this.height = height;
            this.startAngle = startAngle;
            this.sweepAngle = sweepAngle;
        }

        public override void CreateShape()
        {
            graphicsPath.StartFigure();
            graphicsPath.AddArc(x, y, width, height, startAngle, sweepAngle);
            graphicsPath.CloseFigure();
        }
    }
}
