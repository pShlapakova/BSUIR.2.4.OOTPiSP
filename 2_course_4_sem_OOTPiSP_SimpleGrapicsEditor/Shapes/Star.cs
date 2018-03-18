using System.Drawing;
using System.Drawing.Drawing2D;
using static System.Math;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    public class Star : Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }

        public Star() : base() { }

        public Star(int x, int y, int radius, float penWidth, Color penColor, DashStyle penDashStyle)
            : base(penWidth, penColor, penDashStyle)
        {
            X = x;
            Y = y;
            Radius = radius;
        }        

        public override void CreateShape()
        {
            Point starCenter = new Point(X + Radius, Y + Radius);
            double currAngle = PI / 2;

            GraphicsPath.StartFigure();

            for (int i = 0; i < 5; i++)
            {
                GraphicsPath.AddLine(GetPointOnCircle(starCenter, Radius, currAngle),
                    GetPointOnCircle(starCenter, Radius, currAngle += 4 * PI / 5));                
            }

            GraphicsPath.CloseFigure();

            Point GetPointOnCircle(Point center, int radius, double angle)
            {
                int x = (int)(center.X + Cos(angle) * radius);
                int y = (int)(center.Y - Sin(angle) * radius);

                return new Point(x, y);
            }
        }

        public override string ToString()
        {
            return $"Star({X},{Y}; {Radius}; {PenWidth}, {PenColor}, {PenDashStyle})";
        }
    }
}
