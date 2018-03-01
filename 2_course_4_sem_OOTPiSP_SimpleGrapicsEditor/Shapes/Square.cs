using System.Drawing;
using System.Drawing.Drawing2D;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    public class Square : Rectangle
    {
        protected readonly int length;

        public Square(int x, int y, int length, float penWidth, Color penColor, DashStyle penDashStyle) : base(x, y,
            length, length, penWidth, penColor, penDashStyle)
        {
            this.length = length;
        }
    }
}
