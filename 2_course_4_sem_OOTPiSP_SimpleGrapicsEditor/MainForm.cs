using _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();            
        }

        #region События

        #region DrawingFieldPictureBox

        #region Mouse Position Printing

        private void DrawingFieldPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            CurrentMousePositionTextBox.Text = $"{MousePosition.X}, {MousePosition.Y}";
        }

        private void DrawingFieldPictureBox_MouseLeave(object sender, EventArgs e)
        {
            CurrentMousePositionTextBox.Clear();
        }

        #endregion

        #endregion

        #region DrawSomething Buttons

        private void DrawLineButton_Click(object sender, EventArgs e)
        {
            Line line;
            ShapeEditForm shapeEditForm = new ShapeEditForm(DrawingFieldPictureBox, out line);
            shapeEditForm.ShowDialog();
        }

        private void DrawRectangleButton_Click(object sender, EventArgs e)
        {
            Shapes.Rectangle rectangle;
            ShapeEditForm shapeEditForm = new ShapeEditForm(DrawingFieldPictureBox, out rectangle);
            shapeEditForm.ShowDialog();
        }

        private void DrawEllipseButton_Click(object sender, EventArgs e)
        {
            Ellipse ellipse;
            ShapeEditForm shapeEditForm = new ShapeEditForm(DrawingFieldPictureBox, out ellipse);
            shapeEditForm.ShowDialog();
        }

        private void DrawCircleButton_Click(object sender, EventArgs e)
        {
            Circle circle;
            ShapeEditForm shapeEditForm = new ShapeEditForm(DrawingFieldPictureBox, out circle);
            shapeEditForm.ShowDialog();
        }

        private void DrawArcButton_Click(object sender, EventArgs e)
        {
            Arc arc;
            ShapeEditForm shapeEditForm = new ShapeEditForm(DrawingFieldPictureBox, out arc);
            shapeEditForm.ShowDialog();
        }

        private void DrawPieButton_Click(object sender, EventArgs e)
        {
            Pie pie;
            ShapeEditForm shapeEditForm = new ShapeEditForm(DrawingFieldPictureBox, out pie);
            shapeEditForm.ShowDialog();
        }

        private void DrawStarButton_Click(object sender, EventArgs e)
        {
            Star star;
            ShapeEditForm shapeEditForm = new ShapeEditForm(DrawingFieldPictureBox, out star);
            shapeEditForm.ShowDialog();
        }

        private void DrawSquareButton_Click(object sender, EventArgs e)
        {
            Square square;
            ShapeEditForm shapeEditForm = new ShapeEditForm(DrawingFieldPictureBox, out square);
            shapeEditForm.ShowDialog();
        }

        #endregion

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DrawingTools.ClearControl(DrawingFieldPictureBox);
        }

        #endregion

        // Как насчёт того, чтобы добавлять все фигуры не только на холст, но и в список. И по собыию перерисовывать все их?

    }
}
