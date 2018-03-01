using System.Drawing;
using System.Windows.Forms;
using _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor
{
    static class DrawingTools
    {        
        public static void ClearControl(Control control)
        {
            Graphics graphics = control.CreateGraphics();
            graphics.Clear(control.BackColor);
        }

        public static void Draw(Shape shape, Control control)
        {
            Graphics graphics = control.CreateGraphics();
            shape.CreateShape();
            graphics.DrawPath(shape.GetPen, shape.GetGraphicsPath);
        }
    }
}
