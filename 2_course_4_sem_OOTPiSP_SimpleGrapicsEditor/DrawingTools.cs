using _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor
{
    static class DrawingTools
    {
        /// <summary>
        /// Returns PictureBox to its initial state.
        /// </summary>
        /// <param name="pictureBox"></param>
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

        // Когда добавлю функцию редактирования фигур и рисование списка,
        // проверить, что с GraphicsPath. (ведь путь будет сохраняться старый)

        /// <summary>
        /// Draws Shape on PictureBox as Bitmap image. Previous drawings aren't deleting.
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="pictureBox"></param>
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

        /// <summary>
        /// Draws List of Shapes using Draw() method in loop.
        /// </summary>
        /// <param name="shapeList"></param>
        /// <param name="pictureBox"></param>
        public static void DrawAll(IEnumerable<Shape> shapeList, PictureBox pictureBox)
        {
            foreach (Shape shape in shapeList)
            {
                Draw(shape, pictureBox);
            }
        }

        /// <summary>
        /// Returns collection of Shapes as IEnumerable<Shape>. (ShapeListBox.Items has ObjectCollection
        /// type that aren't IEnumerable)
        /// </summary>
        /// <param name="shapeListBox"></param>
        /// <returns></returns>
        public static IEnumerable<Shape> GetShapes(ListBox shapeListBox)
        {
            foreach (Shape shape in shapeListBox.Items)
            {
                yield return shape;
            }
        }
    }
}
