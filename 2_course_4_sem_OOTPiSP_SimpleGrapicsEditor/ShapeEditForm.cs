using _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Rectangle = _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes.Rectangle;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor
{
    public partial class ShapeEditForm : Form
    {         
        #region Constuctors

        private ShapeEditForm()
        {
            InitializeComponent();

            CancelButton = CancelBtn;
        }
                        
        public ShapeEditForm(Line line) : this()
        {
            AddCommonControls((int)line.PenWidth, line.PenColor, line.PenDashStyle);

            AddLabel("X1");
            AddNumericUpDown("X1", line.X1, 0, 5000);
            AddLabel("Y1");
            AddNumericUpDown("Y1", line.Y1, 0, 5000);
            AddLabel("X2");
            AddNumericUpDown("X2", line.X2, 0, 5000);
            AddLabel("Y2");
            AddNumericUpDown("Y2", line.Y2, 0, 5000);

            AddButton.Click += (sender, args) =>
            {
                line.PenWidth = (float)(TableLayoutPanel.Controls["PenWidthNumericUpDown"] as NumericUpDown).Value;
                line.PenColor = (TableLayoutPanel.Controls["PenColorButton"] as Button).BackColor;
                line.PenDashStyle = (DashStyle)(TableLayoutPanel.Controls["PenDashStyleComboBox"] as ComboBox).SelectedItem;
                line.X1 = (int)(TableLayoutPanel.Controls["X1NumericUpDown"] as NumericUpDown).Value;
                line.Y1 = (int)(TableLayoutPanel.Controls["Y1NumericUpDown"] as NumericUpDown).Value;
                line.X2 = (int)(TableLayoutPanel.Controls["X2NumericUpDown"] as NumericUpDown).Value;
                line.Y2 = (int)(TableLayoutPanel.Controls["Y2NumericUpDown"] as NumericUpDown).Value;
                DialogResult = DialogResult.OK;
                Close();
            };
        }

        public ShapeEditForm(Rectangle rectangle) : this()
        {
            AddCommonControls((int)rectangle.PenWidth, rectangle.PenColor, rectangle.PenDashStyle);

            AddLabel("X");
            AddNumericUpDown("X", rectangle.X, 0, 5000);
            AddLabel("Y");
            AddNumericUpDown("Y", rectangle.Y, 0, 5000);
            AddLabel("Width");
            AddNumericUpDown("Width", rectangle.Width, 0, 5000);
            AddLabel("Height");
            AddNumericUpDown("Height", rectangle.Height, 0, 5000);

            AddButton.Click += (sender, args) =>
            {
                rectangle.PenWidth = (float)(TableLayoutPanel.Controls["PenWidthNumericUpDown"] as NumericUpDown).Value;
                rectangle.PenColor = (TableLayoutPanel.Controls["PenColorButton"] as Button).BackColor;
                rectangle.PenDashStyle = (DashStyle)(TableLayoutPanel.Controls["PenDashStyleComboBox"] as ComboBox).SelectedItem;
                rectangle.X = (int)(TableLayoutPanel.Controls["XNumericUpDown"] as NumericUpDown).Value;
                rectangle.Y = (int)(TableLayoutPanel.Controls["YNumericUpDown"] as NumericUpDown).Value;
                rectangle.Width = (int)(TableLayoutPanel.Controls["WidthNumericUpDown"] as NumericUpDown).Value;
                rectangle.Height = (int)(TableLayoutPanel.Controls["HeightNumericUpDown"] as NumericUpDown).Value;
                DialogResult = DialogResult.OK;
                Close();
            };
        }

        public ShapeEditForm(Ellipse ellipse) : this()
        {
            AddCommonControls((int)ellipse.PenWidth, ellipse.PenColor, ellipse.PenDashStyle);

            AddLabel("X");
            AddNumericUpDown("X", ellipse.X, 0, 5000);
            AddLabel("Y");
            AddNumericUpDown("Y", ellipse.Y, 0, 5000);
            AddLabel("Width");
            AddNumericUpDown("Width", ellipse.Width, 0, 5000);
            AddLabel("Height");
            AddNumericUpDown("Height", ellipse.Height, 0, 5000);

            AddButton.Click += (sender, args) =>
            {
                ellipse.PenWidth = (float)(TableLayoutPanel.Controls["PenWidthNumericUpDown"] as NumericUpDown).Value;
                ellipse.PenColor = (TableLayoutPanel.Controls["PenColorButton"] as Button).BackColor;
                ellipse.PenDashStyle = (DashStyle)(TableLayoutPanel.Controls["PenDashStyleComboBox"] as ComboBox).SelectedItem;
                ellipse.X = (int)(TableLayoutPanel.Controls["XNumericUpDown"] as NumericUpDown).Value;
                ellipse.Y = (int)(TableLayoutPanel.Controls["YNumericUpDown"] as NumericUpDown).Value;
                ellipse.Width = (int)(TableLayoutPanel.Controls["WidthNumericUpDown"] as NumericUpDown).Value;
                ellipse.Height = (int)(TableLayoutPanel.Controls["HeightNumericUpDown"] as NumericUpDown).Value;
                DialogResult = DialogResult.OK;
                Close();
            };
        }

        public ShapeEditForm(Circle circle) : this()
        {
            AddCommonControls((int)circle.PenWidth, circle.PenColor, circle.PenDashStyle);

            AddLabel("X");
            AddNumericUpDown("X", circle.X, 0, 5000);
            AddLabel("Y");
            AddNumericUpDown("Y", circle.Y, 0, 5000);
            AddLabel("Radius");
            AddNumericUpDown("Radius", circle.Radius, 0, 5000);            

            AddButton.Click += (sender, args) =>
            {
                circle.PenWidth = (float)(TableLayoutPanel.Controls["PenWidthNumericUpDown"] as NumericUpDown).Value;
                circle.PenColor = (TableLayoutPanel.Controls["PenColorButton"] as Button).BackColor;
                circle.PenDashStyle = (DashStyle)(TableLayoutPanel.Controls["PenDashStyleComboBox"] as ComboBox).SelectedItem;
                circle.X = (int)(TableLayoutPanel.Controls["XNumericUpDown"] as NumericUpDown).Value;
                circle.Y = (int)(TableLayoutPanel.Controls["YNumericUpDown"] as NumericUpDown).Value;
                circle.Radius = (int)(TableLayoutPanel.Controls["RadiusNumericUpDown"] as NumericUpDown).Value;
                DialogResult = DialogResult.OK;
                Close();
            };
        }

        public ShapeEditForm(Square square) : this()
        {
            AddCommonControls((int)square.PenWidth, square.PenColor, square.PenDashStyle);

            AddLabel("X");
            AddNumericUpDown("X", square.X, 0, 5000);
            AddLabel("Y");
            AddNumericUpDown("Y", square.Y, 0, 5000);
            AddLabel("Length");
            AddNumericUpDown("Length", square.Length, 0, 5000);

            AddButton.Click += (sender, args) =>
            {
                square.PenWidth = (float)(TableLayoutPanel.Controls["PenWidthNumericUpDown"] as NumericUpDown).Value;
                square.PenColor = (TableLayoutPanel.Controls["PenColorButton"] as Button).BackColor;
                square.PenDashStyle = (DashStyle)(TableLayoutPanel.Controls["PenDashStyleComboBox"] as ComboBox).SelectedItem;
                square.X = (int)(TableLayoutPanel.Controls["XNumericUpDown"] as NumericUpDown).Value;
                square.Y = (int)(TableLayoutPanel.Controls["YNumericUpDown"] as NumericUpDown).Value;
                square.Length = (int)(TableLayoutPanel.Controls["LengthNumericUpDown"] as NumericUpDown).Value;
                DialogResult = DialogResult.OK;
                Close();
            };
        }

        public ShapeEditForm(Star star) : this()
        {
            AddCommonControls((int)star.PenWidth, star.PenColor, star.PenDashStyle);

            AddLabel("X");
            AddNumericUpDown("X", star.X, 0, 5000);
            AddLabel("Y");
            AddNumericUpDown("Y", star.Y, 0, 5000);
            AddLabel("Radius");
            AddNumericUpDown("Radius", star.Radius, 0, 5000);

            AddButton.Click += (sender, args) =>
            {
                star.PenWidth = (float)(TableLayoutPanel.Controls["PenWidthNumericUpDown"] as NumericUpDown).Value;
                star.PenColor = (TableLayoutPanel.Controls["PenColorButton"] as Button).BackColor;
                star.PenDashStyle = (DashStyle)(TableLayoutPanel.Controls["PenDashStyleComboBox"] as ComboBox).SelectedItem;
                star.X = (int)(TableLayoutPanel.Controls["XNumericUpDown"] as NumericUpDown).Value;
                star.Y = (int)(TableLayoutPanel.Controls["YNumericUpDown"] as NumericUpDown).Value;
                star.Radius = (int)(TableLayoutPanel.Controls["RadiusNumericUpDown"] as NumericUpDown).Value;
                DialogResult = DialogResult.OK;
                Close();
            };
        }

        public ShapeEditForm(Arc arc) : this()
        {
            AddCommonControls((int)arc.PenWidth, arc.PenColor, arc.PenDashStyle);

            AddLabel("X");
            AddNumericUpDown("X", arc.X, 0, 5000);
            AddLabel("Y");
            AddNumericUpDown("Y", arc.Y, 0, 5000);
            AddLabel("Width");
            AddNumericUpDown("Width", arc.Width, 0, 5000);
            AddLabel("Height");
            AddNumericUpDown("Height", arc.Height, 0, 5000);
            AddLabel("StartAngle");
            AddNumericUpDown("StartAngle", (int)arc.StartAngle, 0, 5000);
            AddLabel("SweepAngle");
            AddNumericUpDown("SweepAngle", (int)arc.SweepAngle, 0, 5000);

            AddButton.Click += (sender, args) =>
            {
                arc.PenWidth = (float)(TableLayoutPanel.Controls["PenWidthNumericUpDown"] as NumericUpDown).Value;
                arc.PenColor = (TableLayoutPanel.Controls["PenColorButton"] as Button).BackColor;
                arc.PenDashStyle = (DashStyle)(TableLayoutPanel.Controls["PenDashStyleComboBox"] as ComboBox).SelectedItem;
                arc.X = (int)(TableLayoutPanel.Controls["XNumericUpDown"] as NumericUpDown).Value;
                arc.Y = (int)(TableLayoutPanel.Controls["YNumericUpDown"] as NumericUpDown).Value;
                arc.Width = (int)(TableLayoutPanel.Controls["WidthNumericUpDown"] as NumericUpDown).Value;
                arc.Height = (int)(TableLayoutPanel.Controls["HeightNumericUpDown"] as NumericUpDown).Value;
                arc.StartAngle = (float)(TableLayoutPanel.Controls["StartAngleNumericUpDown"] as NumericUpDown).Value;
                arc.SweepAngle = (float)(TableLayoutPanel.Controls["SweepAngleNumericUpDown"] as NumericUpDown).Value;
                DialogResult = DialogResult.OK;
                Close();
            };
        }

        public ShapeEditForm(Pie pie) : this()
        {
            AddCommonControls((int)pie.PenWidth, pie.PenColor, pie.PenDashStyle);

            AddLabel("X");
            AddNumericUpDown("X", pie.X, 0, 5000);
            AddLabel("Y");
            AddNumericUpDown("Y", pie.Y, 0, 5000);
            AddLabel("Width");
            AddNumericUpDown("Width", pie.Width, 0, 5000);
            AddLabel("Height");
            AddNumericUpDown("Height", pie.Height, 0, 5000);
            AddLabel("StartAngle");
            AddNumericUpDown("StartAngle", (int)pie.StartAngle, 0, 5000);
            AddLabel("SweepAngle");
            AddNumericUpDown("SweepAngle", (int)pie.SweepAngle, 0, 5000);

            AddButton.Click += (sender, args) =>
            {
                pie.PenWidth = (float)(TableLayoutPanel.Controls["PenWidthNumericUpDown"] as NumericUpDown).Value;
                pie.PenColor = (TableLayoutPanel.Controls["PenColorButton"] as Button).BackColor;
                pie.PenDashStyle = (DashStyle)(TableLayoutPanel.Controls["PenDashStyleComboBox"] as ComboBox).SelectedItem;
                pie.X = (int)(TableLayoutPanel.Controls["XNumericUpDown"] as NumericUpDown).Value;
                pie.Y = (int)(TableLayoutPanel.Controls["YNumericUpDown"] as NumericUpDown).Value;
                pie.Width = (int)(TableLayoutPanel.Controls["WidthNumericUpDown"] as NumericUpDown).Value;
                pie.Height = (int)(TableLayoutPanel.Controls["HeightNumericUpDown"] as NumericUpDown).Value;
                pie.StartAngle = (float)(TableLayoutPanel.Controls["StartAngleNumericUpDown"] as NumericUpDown).Value;
                pie.SweepAngle = (float)(TableLayoutPanel.Controls["SweepAngleNumericUpDown"] as NumericUpDown).Value;
                DialogResult = DialogResult.OK;
                Close();
            };
        }

        #endregion

        #region Controls Adding Methods

        private void AddLabel(string name)
        {
            Label label = new Label()
            {
                Name = name + "Label",
                Text = name + ":"                
            };            

            TableLayoutPanel.Controls.Add(label);
        }

        private void AddNumericUpDown(string name, int value, int min, int max)
        {
            NumericUpDown numericUpDown = new NumericUpDown()
            {
                Name = name + "NumericUpDown",
                Value = value,
                Minimum = min,
                Maximum = max
            };

            TableLayoutPanel.Controls.Add(numericUpDown);
        }

        private void AddColorButtonAndDialog(string name, Color color)
        {
            Button button = new Button()
            {
                Name = name + "Button",
                Text = "",
                BackColor = color
            };

            TableLayoutPanel.Controls.Add(button);

            ColorDialog colorDialog = new ColorDialog()
            {
                Color = button.BackColor,
                AllowFullOpen = false
            };

            button.Click += (sender, args) =>
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    button.BackColor = colorDialog.Color;
                }
            };
        }

        private void AddDashStyleComboBox(string name, DashStyle dashStyle)
        {
            ComboBox comboBox = new ComboBox()
            {                                
                Name = name + "ComboBox", 
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            
            comboBox.Items.Add(DashStyle.Dash);            
            comboBox.Items.Add(DashStyle.DashDot);
            comboBox.Items.Add(DashStyle.DashDotDot);
            comboBox.Items.Add(DashStyle.Dot);
            comboBox.Items.Add(DashStyle.Solid);
            comboBox.SelectedItem = dashStyle;

            TableLayoutPanel.Controls.Add(comboBox);
        }

        private void AddCommonControls(int penWidth, Color penColor, DashStyle penDashStyle)
        {
            AddLabel("PenWidth");
            AddNumericUpDown("PenWidth", penWidth, 1, 30);
            AddLabel("PenColor");
            AddColorButtonAndDialog("PenColor", penColor);
            AddLabel("PenDashStyle");
            AddDashStyleComboBox("PenDashStyle", penDashStyle);
        }

        #endregion    
    }
}
