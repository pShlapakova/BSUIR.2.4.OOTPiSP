using System.Drawing;
using System.Windows.Forms;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor
{
    static class DrawingTools
    {        
        public static void ClearControl(Control control)
        {
            Graphics graphics = control.CreateGraphics();
            graphics.Clear(control.BackColor);
        }
    }
}
