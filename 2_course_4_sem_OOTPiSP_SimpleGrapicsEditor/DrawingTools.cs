using System;
using System.Drawing;
using System.Windows.Forms;
using _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor
{
    static class DrawingTools
    {
        public static void ClearPictureBox(PictureBox pictureBox)
        {
            pictureBox.Image = null;

            // Здесь, в отличие от метода Draw(), проблема стирания не страшна, но для цвета BackColor наверное быстрее будет Image = null
            //Graphics graphics = pictureBox.CreateGraphics();
            //graphics.Clear(pictureBox.BackColor);
        }

        /*
        public static void ClearControl(Control control)
        {
            try
            {
                if (!(control is PictureBox))
                {
                    throw new Exception("Control has not an 'Image' field");
                }

                ((PictureBox)control).Image = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + ' ' + e.StackTrace, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (control is PictureBox)
                {
                    MessageBox.Show("Успешно", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Неудача", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        */

        public static void Draw(Shape shape, PictureBox pictureBox)
        {
            const int bmpWidth = 3000, bmpHeight = 3000;

            Bitmap bitmap = pictureBox.Image != null
                ? new Bitmap(pictureBox.Image, pictureBox.Image.Width, pictureBox.Image.Height)
                : new Bitmap(bmpWidth, bmpHeight);            

            Graphics graphics = Graphics.FromImage(bitmap);
            shape.CreateShape();
            graphics.DrawPath(shape.Pen, shape.GraphicsPath);

            pictureBox.Image = bitmap;

            // При использовании CreateGraphics() стирается рисунок при перекрывании его другими окнами, при сворачивании, при ресайзе
            //Graphics graphics = control.CreateGraphics();
            //shape.CreateShape();
            //graphics.DrawPath(shape.GetPen, shape.GetGraphicsPath);
        }
    }
}
