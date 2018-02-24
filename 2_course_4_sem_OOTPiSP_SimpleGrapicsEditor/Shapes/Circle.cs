using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    class Circle : Ellipse
    {
        public Circle(Control control, int x, int y, int radius, float penWidth, Color penColor,
            DashStyle penDashStyle) : base(control, x, y, 2 * radius, 2 * radius, penWidth, penColor, penDashStyle) { }
    }
}
