using System.Drawing;
using System.Drawing.Drawing2D;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    public class Line : Shape
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }

        public Line() : base() { }

        public Line(int x1, int y1, int x2, int y2, float penWidth, Color penColor,
            DashStyle penDashStyle) : base(penWidth, penColor, penDashStyle)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public override void CreateShape()
        {                        
            GraphicsPath.StartFigure();
            GraphicsPath.AddLine(X1, Y1, X2, Y2);
            GraphicsPath.CloseFigure();
        }
    }
}
