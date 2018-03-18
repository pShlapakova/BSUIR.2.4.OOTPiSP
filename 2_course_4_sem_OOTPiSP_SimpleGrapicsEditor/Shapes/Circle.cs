using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    public class Circle : Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }                        

        public Circle() : base() { }

        public Circle(int x, int y, int radius, float penWidth, Color penColor,
            DashStyle penDashStyle) : base(penWidth, penColor, penDashStyle)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public override void CreateShape()
        {
            GraphicsPath.StartFigure();
            GraphicsPath.AddEllipse(X, Y, Radius * 2, Radius * 2);
            GraphicsPath.CloseFigure();
        }

        public override string ToString()
        {
            return $"Circle({X},{Y}; {Radius}; {PenWidth}, {PenColor}, {PenDashStyle})";
        }
    }
}
