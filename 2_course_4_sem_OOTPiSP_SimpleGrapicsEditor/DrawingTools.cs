using System.Drawing;
using System.Windows.Forms;
using _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor
{
    static class DrawingTools
    {        
        public static void ClearControl(PictureBox pictureBox)
        {
            pictureBox.Image = null;

            // Здесь, в отличие от метода Draw(), проблема стирания не страшна, но для цвета BackColor быстрее будет Image = null
            //Graphics graphics = pictureBox.CreateGraphics();
            //graphics.Clear(pictureBox.BackColor);
        }

        public static void Draw(Shape shape, PictureBox pictureBox)
        {
            Bitmap bitmap;

            bitmap = pictureBox.Image != null
                ? new Bitmap(pictureBox.Image, pictureBox.Width, pictureBox.Height)
                : new Bitmap(pictureBox.Width, pictureBox.Height);

            Graphics graphics = Graphics.FromImage(bitmap);
            shape.CreateShape();
            graphics.DrawPath(shape.GetPen, shape.GetGraphicsPath);

            pictureBox.Image = bitmap;

            // При использовании CreateGraphics() стирается рисунок при перекрывании его другими окнами, при сворачивании, при ресайзе
            //Graphics graphics = control.CreateGraphics();
            //shape.CreateShape();
            //graphics.DrawPath(shape.GetPen, shape.GetGraphicsPath);
        }
    }
}
