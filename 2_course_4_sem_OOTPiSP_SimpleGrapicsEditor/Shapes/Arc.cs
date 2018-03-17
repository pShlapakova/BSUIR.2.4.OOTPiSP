using System.Drawing;
using System.Drawing.Drawing2D;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    public class Arc : Shape
    {        
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float StartAngle { get; set; }
        public float SweepAngle { get; set; }

        public Arc() : base() { }

        public Arc(int x, int y, int width, int height, float startAngle, float sweepAngle,
            float penWidth, Color penColor, DashStyle penDashStyle) : base(penWidth, penColor,
            penDashStyle)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            StartAngle = startAngle;
            SweepAngle = sweepAngle;
        }

        public override void CreateShape()
        {
            GraphicsPath.StartFigure();
            GraphicsPath.AddArc(X, Y, Width, Height, StartAngle, SweepAngle);
            GraphicsPath.CloseFigure();
        }
    }
}
