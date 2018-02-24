using _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        private ShapeList shapeList = new ShapeList();

        private void MainForm_Load(object sender, EventArgs e)
        {
            shapeList.AddShape(new Line(DrawingFieldPictureBox, 10, 10, 100, 100, 2, Color.Green, DashStyle.Dash));
            shapeList.AddShape(new Circle(DrawingFieldPictureBox, 5, 5, 10, 2, Color.Red, DashStyle.Solid));
            shapeList.AddShape(new Pie(DrawingFieldPictureBox, 100, 100, 30, 50, 0, 90, 2, Color.BlueViolet, DashStyle.DashDot));
            shapeList.AddShape(new Ellipse(DrawingFieldPictureBox, 40, 50, 25, 60, 2, Color.Orange, DashStyle.DashDotDot));
            shapeList.AddShape(new Arc(DrawingFieldPictureBox, 400, 100, 47, 43, 270, 300, 2, Color.Aqua, DashStyle.Dot));
            shapeList.AddShape(new Shapes.Rectangle(DrawingFieldPictureBox, 300, 400, 300, 20, 2, Color.DeepPink, DashStyle.Solid));
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            shapeList.DrawAll();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DrawingTools.ClearControl(DrawingFieldPictureBox);
        }
    }
}
