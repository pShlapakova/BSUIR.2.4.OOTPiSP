using System.Drawing;
using System.Drawing.Drawing2D;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    public class Square : Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Length { get; set; }        

        public Square() : base() { }

        public Square(int x, int y, int length, float penWidth, Color penColor, DashStyle penDashStyle)
            : base(penWidth, penColor, penDashStyle)
        {
            X = x;
            Y = y;
            Length = length;
        }

        public override void CreateShape()
        {
            GraphicsPath.StartFigure();
            GraphicsPath.AddRectangle(new System.Drawing.Rectangle(X, Y, Length, Length));
            GraphicsPath.CloseFigure();
        }

        public override string ToString()
        {
            return $"Square({X},{Y}; {Length}; {PenWidth}, {PenColor}, {PenDashStyle})";
        }
    }
}
