using System.Drawing;
using System.Windows.Forms;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes
{
    static class Test
    {
        public static void DrawIt(Shape shape, PictureBox pictureBox)
        {
            Graphics graphics = pictureBox.CreateGraphics();            
            shape.CreateShape();
            graphics.DrawPath(shape.GetPen, shape.GetGraphicsPath);
        }
    }
}
