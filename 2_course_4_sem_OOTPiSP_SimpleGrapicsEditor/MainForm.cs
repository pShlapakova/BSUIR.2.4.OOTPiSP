using _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Rectangle = _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes.Rectangle;
using static _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.DrawingTools;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor
{
    public partial class MainForm : Form
    {
        //private List<Shape> shapeList = new List<Shape>();
            
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

        #region AddShape Buttons

        private void AddLineButton_Click(object sender, EventArgs e)
        {
            Line line = new Line();
            ShapeEditForm shapeEditForm = new ShapeEditForm(line);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                ShapeListBox.Items.Add(line);                
            }            
        }

        private void AddRectangleButton_Click(object sender, EventArgs e)
        {
            Rectangle rectangle = new Rectangle();
            ShapeEditForm shapeEditForm = new ShapeEditForm(rectangle);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                ShapeListBox.Items.Add(rectangle);
            }
        }

        private void AddEllipseButton_Click(object sender, EventArgs e)
        {
            Ellipse ellipse = new Ellipse();
            ShapeEditForm shapeEditForm = new ShapeEditForm(ellipse);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                ShapeListBox.Items.Add(ellipse);
            }
        }

        private void AddCircleButton_Click(object sender, EventArgs e)
        {
            Circle circle = new Circle();
            ShapeEditForm shapeEditForm = new ShapeEditForm(circle);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                ShapeListBox.Items.Add(circle);
            }
        }

        private void AddArcButton_Click(object sender, EventArgs e)
        {
            Arc arc = new Arc();
            ShapeEditForm shapeEditForm = new ShapeEditForm(arc);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                ShapeListBox.Items.Add(arc);
            }
        }

        private void AddPieButton_Click(object sender, EventArgs e)
        {
            Pie pie = new Pie();
            ShapeEditForm shapeEditForm = new ShapeEditForm(pie);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                ShapeListBox.Items.Add(pie);
            }
        }

        private void AddStarButton_Click(object sender, EventArgs e)
        {
            Star star = new Star();
            ShapeEditForm shapeEditForm = new ShapeEditForm(star);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                ShapeListBox.Items.Add(star);
            }
        }

        private void AddSquareButton_Click(object sender, EventArgs e)
        {
            Square square = new Square();
            ShapeEditForm shapeEditForm = new ShapeEditForm(square);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                ShapeListBox.Items.Add(square);
            }
        }

        #endregion

        #region Buttons that working with ShapeListBox

        private void EditShapeButton_Click(object sender, EventArgs e)
        {
            dynamic shape = ShapeListBox.SelectedItem;
            ShapeEditForm shapeEditForm = new ShapeEditForm(shape);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                // To rewrite text
                int index = ShapeListBox.SelectedIndex;
                ShapeListBox.Items.RemoveAt(index);
                ShapeListBox.Items.Insert(index, shape);
            }
        }

        private void DeleteShapeButton_Click(object sender, EventArgs e)
        {
            if (ShapeListBox.SelectedItem != null)
            {
                ShapeListBox.Items.RemoveAt(ShapeListBox.SelectedIndex);
            }
        }

        private void SortListButton_Click(object sender, EventArgs e)
        {
            Shape[] bufShapeArray = new Shape[ShapeListBox.Items.Count];
            ShapeListBox.Items.CopyTo(bufShapeArray, 0);
            ShapeListBox.Items.Clear();
            Array.Sort(bufShapeArray);
            ShapeListBox.Items.AddRange(bufShapeArray);
        }

        private void DrawListButton_Click(object sender, EventArgs e)
        {
            DrawAll(GetShapes(ShapeListBox), DrawingFieldPictureBox);
        }

        #endregion

        private void ClearCanvasButton_Click(object sender, EventArgs e)
        {
            ClearPictureBox(DrawingFieldPictureBox);
        }

        #endregion

        #endregion              
    }
}
