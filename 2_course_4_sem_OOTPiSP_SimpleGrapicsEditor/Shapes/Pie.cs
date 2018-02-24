using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    class Pie : Shape
    {
        protected readonly int width, height;
        protected readonly float startAngle, sweepAngle;

        public Pie(Control control, int x, int y, int width, int height, float startAngle, float sweepAngle,
            float penWidth, Color penColor, DashStyle penDashStyle) : base(control, x, y, penWidth, penColor,
            penDashStyle)
        {
            this.width = width;
            this.height = height;
            this.startAngle = startAngle;
            this.sweepAngle = sweepAngle;
        }

        public override void Draw()
        {
            graphicsPath.StartFigure();
            graphicsPath.AddPie(x, y, width, height, startAngle, sweepAngle);
            graphicsPath.CloseFigure();
            base.Draw();
        }
    }
}
