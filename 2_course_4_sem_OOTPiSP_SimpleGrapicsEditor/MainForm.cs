using _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes;
using System;
using System.Windows.Forms;
using Rectangle = _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes.Rectangle;

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

        #region Cursor Position Printing

        private void DrawingFieldPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            CurrentMousePositionTextBox.Text = $"{MousePosition.X - Location.X - 8}, {MousePosition.Y - Location.Y - 27}";
        }
            
        private void DrawingFieldPictureBox_MouseLeave(object sender, EventArgs e) => CurrentMousePositionTextBox.Clear();

        #endregion

        #endregion

        #region Buttons

        #region DrawSomething Buttons

        private void DrawLineButton_Click(object sender, EventArgs e)
        {            
            ShapeEditForm shapeEditForm = new ShapeEditForm(out Line line);
            shapeEditForm.ShowDialog();
            DrawingTools.Draw(line, DrawingFieldPictureBox);            
        }

        private void DrawRectangleButton_Click(object sender, EventArgs e)
        {            
            ShapeEditForm shapeEditForm = new ShapeEditForm(out Rectangle rectangle);
            shapeEditForm.ShowDialog();
            DrawingTools.Draw(rectangle, DrawingFieldPictureBox);
        }

        private void DrawEllipseButton_Click(object sender, EventArgs e)
        {            
            ShapeEditForm shapeEditForm = new ShapeEditForm(out Ellipse ellipse);
            shapeEditForm.ShowDialog();
            DrawingTools.Draw(ellipse, DrawingFieldPictureBox);
        }

        private void DrawCircleButton_Click(object sender, EventArgs e)
        {            
            ShapeEditForm shapeEditForm = new ShapeEditForm(out Circle circle);
            shapeEditForm.ShowDialog();
            DrawingTools.Draw(circle, DrawingFieldPictureBox);
        }

        private void DrawArcButton_Click(object sender, EventArgs e)
        {            
            ShapeEditForm shapeEditForm = new ShapeEditForm(out Arc arc);
            shapeEditForm.ShowDialog();
            DrawingTools.Draw(arc, DrawingFieldPictureBox);
        }

        private void DrawPieButton_Click(object sender, EventArgs e)
        {            
            ShapeEditForm shapeEditForm = new ShapeEditForm(out Pie pie);
            shapeEditForm.ShowDialog();
            DrawingTools.Draw(pie, DrawingFieldPictureBox);
        }

        private void DrawStarButton_Click(object sender, EventArgs e)
        {            
            ShapeEditForm shapeEditForm = new ShapeEditForm(out Star star);
            shapeEditForm.ShowDialog();
            DrawingTools.Draw(star, DrawingFieldPictureBox);
        }

        private void DrawSquareButton_Click(object sender, EventArgs e)
        {            
            ShapeEditForm shapeEditForm = new ShapeEditForm(out Square square);
            shapeEditForm.ShowDialog();
            DrawingTools.Draw(square, DrawingFieldPictureBox);
        }

        #endregion

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DrawingTools.ClearPictureBox(DrawingFieldPictureBox);            
        }

        #endregion

        #endregion
    }
}
