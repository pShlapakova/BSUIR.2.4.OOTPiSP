using System.Drawing;
using System.Drawing.Drawing2D;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    public class Circle : Ellipse
    {
        public Circle(int x, int y, int radius, float penWidth, Color penColor,
            DashStyle penDashStyle) : base(x, y, 2 * radius, 2 * radius, penWidth, penColor, penDashStyle) { }
    }
}
