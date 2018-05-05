﻿namespace SimpleGrapicsEditor.Tools
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using SimpleGrapicsEditor.Shapes;

    /// <summary>
    /// Defines methods for drawing <see cref="AbstractShape"/>-inherited geometric figures
    /// and general working with <see cref="AbstractShape"/> collections.
    /// </summary>
    public static class DrawingManager
    {
        /// <summary>
        /// Clears the entire PictureBox drawing surface.
        /// </summary>
        /// <param name="pictureBox">Drawing surface.</param>
        public static void ClearPictureBox(PictureBox pictureBox)
        {
            pictureBox.Image = null;                        
        }

        /// <summary>
        /// Draws <see cref="AbstractShape"/>-inherited geometric figure
        /// on <see cref="PictureBox"/> as <see cref="Bitmap"/> image. Previous drawings aren't deleting.
        /// </summary>
        /// <param name="shape">Geometric figure object.</param>
        /// <param name="pictureBox">Drawing surface.</param>
        public static void Draw(AbstractShape shape, PictureBox pictureBox)
        {
            const int BmpWidth = 3000;
            const int BmpHeight = 3000;

            Bitmap bitmap = pictureBox.Image != null
                ? new Bitmap(pictureBox.Image, pictureBox.Image.Width, pictureBox.Image.Height)
                : new Bitmap(BmpWidth, BmpHeight);

            Graphics graphics = Graphics.FromImage(bitmap);
            shape.CreateShape();
            graphics.DrawPath(shape.Pen, shape.GraphicsPath);

            pictureBox.Image = bitmap;

            // При использовании CreateGraphics() стирается рисунок при перекрывании его другими окнами, при сворачивании, при ресайзе
            // Graphics graphics = control.CreateGraphics();
            // shape.CreateShape();
            // graphics.DrawPath(shape.GetPen, shape.GetGraphicsPath);
        }

        /// <summary>
        /// Draws list of <see cref="AbstractShape"/>-inherited geometric figures using <see cref="Draw"/> method.
        /// </summary>
        /// <param name="shapeList">The list of geometric figures objects.</param>
        /// <param name="pictureBox">Drawing surface.</param>
        public static void DrawAll(IEnumerable<AbstractShape> shapeList, PictureBox pictureBox)
        {
            foreach (AbstractShape shape in shapeList)
            {
                Draw(shape, pictureBox);
            }
        }

        /// <summary>
        /// Returns collection of <see cref="AbstractShape"/>-inherited geometric figures.        
        /// </summary>
        /// <param name="shapeListBox">ListBox that contains <see cref="ListBox.ObjectCollection"/>
        /// of <see cref="AbstractShape"/>-inherited geometric figures.</param>
        /// <returns>Collection of <see cref="AbstractShape"/>-inherited geometric figures. </returns>
        public static IEnumerable<AbstractShape> GetShapes(ListBox shapeListBox)
        {
            foreach (AbstractShape shape in shapeListBox.Items)
            {
                yield return shape;
            }
        }        
    }
}