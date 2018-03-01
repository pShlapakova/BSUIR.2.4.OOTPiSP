using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    public class Star : Shape
    {
        protected readonly int radius;

        public Star(int x, int y, int radius, float penWidth, Color penColor, DashStyle penDashStyle) : base(x, y,
            penWidth, penColor, penDashStyle)
        {
            this.radius = radius;
        }

        private Point GetPositionInCircle(Point center, int radius, double angle)
        {
            int resultX = (int) (center.X + Math.Cos(angle) * radius);
            int resultY = (int) (center.Y - Math.Sin(angle) * radius);

            return new Point(resultX, resultY);            
        }

        public override void CreateShape()
        {
            Point center = new Point(x + radius, y + radius);

            double startAngle = Math.PI / 2;
            double currAngle = startAngle;

            graphicsPath.StartFigure();

            for (int i = 0; i < 5; i++)
            {
                graphicsPath.AddLine(GetPositionInCircle(center, radius, currAngle),
                    GetPositionInCircle(center, radius, currAngle + 4 * Math.PI / 5));
                currAngle += 4 * Math.PI / 5;
            }

            graphicsPath.CloseFigure();
        }
    }
}
