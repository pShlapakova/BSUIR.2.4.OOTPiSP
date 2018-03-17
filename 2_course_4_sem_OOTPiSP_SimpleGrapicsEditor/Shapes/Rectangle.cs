using System.Drawing;
using System.Drawing.Drawing2D;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    public class Rectangle : Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle() : base() { }

        public Rectangle(int x, int y, int width, int height, float penWidth, Color penColor,
            DashStyle penDashStyle) : base(penWidth, penColor, penDashStyle)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public override void CreateShape()
        {
            GraphicsPath.StartFigure();
            GraphicsPath.AddRectangle(new System.Drawing.Rectangle(X, Y, Width, Height));
            GraphicsPath.CloseFigure();
        }
    }
}
