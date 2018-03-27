namespace SimpleGrapicsEditor
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;    
    using System.Windows.Forms;
    using SimpleGrapicsEditor.Properties;
    using SimpleGrapicsEditor.Shapes;
    using Rectangle = Shapes.Rectangle;

    /// <summary>
    /// Contains controls for editing characteristics of the <see cref="Shape"/>-inherited
    /// geometric figures.
    /// </summary>
    public partial class ShapeEditForm : Form
    {
        #region Constants

        /// <summary>
        /// String added to the end of <see cref="Label"/> controls names.
        /// </summary>
        private const string LabelPostfix = "Label";

        /// <summary>
        /// String added to the end of <see cref="Button"/> controls names.
        /// </summary>
        private const string ButtonPostfix = "Button";

        /// <summary>
        /// String added to the end of <see cref="NumericUpDown"/> controls names.
        /// </summary>
        private const string NumericUpDownPostfix = "NumericUpDown";

        /// <summary>
        /// String added to the end of <see cref="ComboBox"/> controls names.
        /// </summary>
        private const string ComboBoxPostfix = "ComboBox";

        #endregion

        #region Constuctors
                       
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEditForm"/> class with <see cref="Line"/> object passed.
        /// </summary>
        /// <param name="line"><see cref="Line"/> object to be edit.</param>
        public ShapeEditForm(Line line) : this()
        {
            this.AddCommonControls((int)line.PenWidth, line.PenColor, line.PenDashStyle);
                        
            this.AddLabel(Resources.X1);
            this.AddNumericUpDown(Resources.X1, line.X1, 0, 5000);
            this.AddLabel(nameof(line.Y1));
            this.AddNumericUpDown(nameof(line.Y1), line.Y1, 0, 5000);
            this.AddLabel(nameof(line.X2));
            this.AddNumericUpDown(nameof(line.X2), line.X2, 0, 5000);
            this.AddLabel(nameof(line.Y2));
            this.AddNumericUpDown(nameof(line.Y2), line.Y2, 0, 5000);

            this.AddButton.Click += (sender, args) =>
            {
                try
                {
                    line.PenWidth = (float)(this.TableLayoutPanel.Controls[nameof(line.PenWidth) + NumericUpDownPostfix] as NumericUpDown).Value;
                    line.PenColor = (this.TableLayoutPanel.Controls[nameof(line.PenColor) + ButtonPostfix] as Button).BackColor;
                    line.PenDashStyle = (DashStyle)(this.TableLayoutPanel.Controls[nameof(line.PenDashStyle) + ComboBoxPostfix] as ComboBox).SelectedItem;
                    line.X1 = (int)(this.TableLayoutPanel.Controls[nameof(line.X1) + NumericUpDownPostfix] as NumericUpDown).Value;
                    line.Y1 = (int)(this.TableLayoutPanel.Controls[nameof(line.Y1) + NumericUpDownPostfix] as NumericUpDown).Value;
                    line.X2 = (int)(this.TableLayoutPanel.Controls[nameof(line.X2) + NumericUpDownPostfix] as NumericUpDown).Value;
                    line.Y2 = (int)(this.TableLayoutPanel.Controls[nameof(line.Y2) + NumericUpDownPostfix] as NumericUpDown).Value;
                }
                catch (NullReferenceException e)
                {
                    MessageBox.Show(e.Message, "NullReferenceException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEditForm"/> class with <see cref="Rectangle"/> object passed.
        /// </summary>
        /// <param name="rectangle"><see cref="Rectangle"/> object to be edit.</param>
        public ShapeEditForm(Rectangle rectangle) : this()
        {
            this.AddCommonControls((int)rectangle.PenWidth, rectangle.PenColor, rectangle.PenDashStyle);

            this.AddLabel("X");
            this.AddNumericUpDown("X", rectangle.X, 0, 5000);
            this.AddLabel("Y");
            this.AddNumericUpDown("Y", rectangle.Y, 0, 5000);
            this.AddLabel("Width");
            this.AddNumericUpDown("Width", rectangle.Width, 0, 5000);
            this.AddLabel("Height");
            this.AddNumericUpDown("Height", rectangle.Height, 0, 5000);

            this.AddButton.Click += (sender, args) =>
            {
                try
                {
                    rectangle.PenWidth = (float)(this.TableLayoutPanel.Controls["PenWidthNumericUpDown"] as NumericUpDown).Value;
                    rectangle.PenColor = (this.TableLayoutPanel.Controls["PenColorButton"] as Button).BackColor;
                    rectangle.PenDashStyle = (DashStyle)(this.TableLayoutPanel.Controls["PenDashStyleComboBox"] as ComboBox).SelectedItem;
                    rectangle.X = (int)(this.TableLayoutPanel.Controls["XNumericUpDown"] as NumericUpDown).Value;
                    rectangle.Y = (int)(this.TableLayoutPanel.Controls["YNumericUpDown"] as NumericUpDown).Value;
                    rectangle.Width = (int)(this.TableLayoutPanel.Controls["WidthNumericUpDown"] as NumericUpDown).Value;
                    rectangle.Height = (int)(this.TableLayoutPanel.Controls["HeightNumericUpDown"] as NumericUpDown).Value;
                }
                catch (NullReferenceException e)
                {
                    MessageBox.Show(e.Message, "NullReferenceException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEditForm"/> class with <see cref="Ellipse"/> object passed.
        /// </summary>
        /// <param name="ellipse"><see cref="Ellipse"/> object to be edit.</param>
        public ShapeEditForm(Ellipse ellipse) : this()
        {
            this.AddCommonControls((int)ellipse.PenWidth, ellipse.PenColor, ellipse.PenDashStyle);

            this.AddLabel("X");
            this.AddNumericUpDown("X", ellipse.X, 0, 5000);
            this.AddLabel("Y");
            this.AddNumericUpDown("Y", ellipse.Y, 0, 5000);
            this.AddLabel("Width");
            this.AddNumericUpDown("Width", ellipse.Width, 0, 5000);
            this.AddLabel("Height");
            this.AddNumericUpDown("Height", ellipse.Height, 0, 5000);

            this.AddButton.Click += (sender, args) =>
            {
                try
                {
                    ellipse.PenWidth = (float)(this.TableLayoutPanel.Controls["PenWidthNumericUpDown"] as NumericUpDown).Value;
                    ellipse.PenColor = (this.TableLayoutPanel.Controls["PenColorButton"] as Button).BackColor;
                    ellipse.PenDashStyle = (DashStyle)(this.TableLayoutPanel.Controls["PenDashStyleComboBox"] as ComboBox).SelectedItem;
                    ellipse.X = (int)(this.TableLayoutPanel.Controls["XNumericUpDown"] as NumericUpDown).Value;
                    ellipse.Y = (int)(this.TableLayoutPanel.Controls["YNumericUpDown"] as NumericUpDown).Value;
                    ellipse.Width = (int)(this.TableLayoutPanel.Controls["WidthNumericUpDown"] as NumericUpDown).Value;
                    ellipse.Height = (int)(this.TableLayoutPanel.Controls["HeightNumericUpDown"] as NumericUpDown).Value;
                }
                catch (NullReferenceException e)
                {
                    MessageBox.Show(e.Message, "NullReferenceException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEditForm"/> class with <see cref="Circle"/> object passed.
        /// </summary>
        /// <param name="circle"><see cref="Circle"/> object to be edit.</param>
        public ShapeEditForm(Circle circle) : this()
        {
            this.AddCommonControls((int)circle.PenWidth, circle.PenColor, circle.PenDashStyle);

            this.AddLabel("X");
            this.AddNumericUpDown("X", circle.X, 0, 5000);
            this.AddLabel("Y");
            this.AddNumericUpDown("Y", circle.Y, 0, 5000);
            this.AddLabel("Radius");
            this.AddNumericUpDown("Radius", circle.Radius, 0, 5000);

            this.AddButton.Click += (sender, args) =>
            {
                try
                {
                    circle.PenWidth = (float)(this.TableLayoutPanel.Controls["PenWidthNumericUpDown"] as NumericUpDown).Value;
                    circle.PenColor = (this.TableLayoutPanel.Controls["PenColorButton"] as Button).BackColor;
                    circle.PenDashStyle = (DashStyle)(this.TableLayoutPanel.Controls["PenDashStyleComboBox"] as ComboBox).SelectedItem;
                    circle.X = (int)(this.TableLayoutPanel.Controls["XNumericUpDown"] as NumericUpDown).Value;
                    circle.Y = (int)(this.TableLayoutPanel.Controls["YNumericUpDown"] as NumericUpDown).Value;
                    circle.Radius = (int)(this.TableLayoutPanel.Controls["RadiusNumericUpDown"] as NumericUpDown).Value;
                }
                catch (NullReferenceException e)
                {
                    MessageBox.Show(e.Message, "NullReferenceException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEditForm"/> class with <see cref="Square"/> object passed.
        /// </summary>
        /// <param name="square"><see cref="Square"/> object to be edit.</param>
        public ShapeEditForm(Square square) : this()
        {
            this.AddCommonControls((int)square.PenWidth, square.PenColor, square.PenDashStyle);

            this.AddLabel("X");
            this.AddNumericUpDown("X", square.X, 0, 5000);
            this.AddLabel("Y");
            this.AddNumericUpDown("Y", square.Y, 0, 5000);
            this.AddLabel("Length");
            this.AddNumericUpDown("Length", square.Length, 0, 5000);

            this.AddButton.Click += (sender, args) =>
            {
                try
                {
                    square.PenWidth = (float)(this.TableLayoutPanel.Controls["PenWidthNumericUpDown"] as NumericUpDown).Value;
                    square.PenColor = (this.TableLayoutPanel.Controls["PenColorButton"] as Button).BackColor;
                    square.PenDashStyle = (DashStyle)(this.TableLayoutPanel.Controls["PenDashStyleComboBox"] as ComboBox).SelectedItem;
                    square.X = (int)(this.TableLayoutPanel.Controls["XNumericUpDown"] as NumericUpDown).Value;
                    square.Y = (int)(this.TableLayoutPanel.Controls["YNumericUpDown"] as NumericUpDown).Value;
                    square.Length = (int)(this.TableLayoutPanel.Controls["LengthNumericUpDown"] as NumericUpDown).Value;
                }
                catch (NullReferenceException e)
                {
                    MessageBox.Show(e.Message, "NullReferenceException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEditForm"/> class with <see cref="Star"/> object passed.
        /// </summary>
        /// <param name="star"><see cref="Star"/> object to be edit.</param>
        public ShapeEditForm(Star star) : this()
        {
            this.AddCommonControls((int)star.PenWidth, star.PenColor, star.PenDashStyle);

            this.AddLabel("X");
            this.AddNumericUpDown("X", star.X, 0, 5000);
            this.AddLabel("Y");
            this.AddNumericUpDown("Y", star.Y, 0, 5000);
            this.AddLabel("Radius");
            this.AddNumericUpDown("Radius", star.Radius, 0, 5000);

            this.AddButton.Click += (sender, args) =>
            {
                try
                {
                    star.PenWidth = (float)(this.TableLayoutPanel.Controls["PenWidthNumericUpDown"] as NumericUpDown).Value;
                    star.PenColor = (this.TableLayoutPanel.Controls["PenColorButton"] as Button).BackColor;
                    star.PenDashStyle = (DashStyle)(this.TableLayoutPanel.Controls["PenDashStyleComboBox"] as ComboBox).SelectedItem;
                    star.X = (int)(this.TableLayoutPanel.Controls["XNumericUpDown"] as NumericUpDown).Value;
                    star.Y = (int)(this.TableLayoutPanel.Controls["YNumericUpDown"] as NumericUpDown).Value;
                    star.Radius = (int)(this.TableLayoutPanel.Controls["RadiusNumericUpDown"] as NumericUpDown).Value;
                }
                catch (NullReferenceException e)
                {
                    MessageBox.Show(e.Message, "NullReferenceException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEditForm"/> class with <see cref="Arc"/> object passed.
        /// </summary>
        /// <param name="arc"><see cref="Arc"/> object to be edit.</param>
        public ShapeEditForm(Arc arc) : this()
        {
            this.AddCommonControls((int)arc.PenWidth, arc.PenColor, arc.PenDashStyle);

            this.AddLabel("X");
            this.AddNumericUpDown("X", arc.X, 0, 5000);
            this.AddLabel("Y");
            this.AddNumericUpDown("Y", arc.Y, 0, 5000);
            this.AddLabel("Width");
            this.AddNumericUpDown("Width", arc.Width, 0, 5000);
            this.AddLabel("Height");
            this.AddNumericUpDown("Height", arc.Height, 0, 5000);
            this.AddLabel("StartAngle");
            this.AddNumericUpDown("StartAngle", (int)arc.StartAngle, 0, 5000);
            this.AddLabel("SweepAngle");
            this.AddNumericUpDown("SweepAngle", (int)arc.SweepAngle, 0, 5000);

            this.AddButton.Click += (sender, args) =>
            {
                try
                {
                    arc.PenWidth = (float)(this.TableLayoutPanel.Controls["PenWidthNumericUpDown"] as NumericUpDown).Value;
                    arc.PenColor = (this.TableLayoutPanel.Controls["PenColorButton"] as Button).BackColor;
                    arc.PenDashStyle = (DashStyle)(this.TableLayoutPanel.Controls["PenDashStyleComboBox"] as ComboBox).SelectedItem;
                    arc.X = (int)(this.TableLayoutPanel.Controls["XNumericUpDown"] as NumericUpDown).Value;
                    arc.Y = (int)(this.TableLayoutPanel.Controls["YNumericUpDown"] as NumericUpDown).Value;
                    arc.Width = (int)(this.TableLayoutPanel.Controls["WidthNumericUpDown"] as NumericUpDown).Value;
                    arc.Height = (int)(this.TableLayoutPanel.Controls["HeightNumericUpDown"] as NumericUpDown).Value;
                    arc.StartAngle = (float)(this.TableLayoutPanel.Controls["StartAngleNumericUpDown"] as NumericUpDown).Value;
                    arc.SweepAngle = (float)(this.TableLayoutPanel.Controls["SweepAngleNumericUpDown"] as NumericUpDown).Value;
                }
                catch (NullReferenceException e)
                {
                    MessageBox.Show(e.Message, "NullReferenceException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeEditForm"/> class with <see cref="Pie"/> object passed.
        /// </summary>
        /// <param name="pie"><see cref="Pie"/> object to be edit.</param>
        public ShapeEditForm(Pie pie) : this()
        {
            this.AddCommonControls((int)pie.PenWidth, pie.PenColor, pie.PenDashStyle);

            this.AddLabel("X");
            this.AddNumericUpDown("X", pie.X, 0, 5000);
            this.AddLabel("Y");
            this.AddNumericUpDown("Y", pie.Y, 0, 5000);
            this.AddLabel("Width");
            this.AddNumericUpDown("Width", pie.Width, 0, 5000);
            this.AddLabel("Height");
            this.AddNumericUpDown("Height", pie.Height, 0, 5000);
            this.AddLabel("StartAngle");
            this.AddNumericUpDown("StartAngle", (int)pie.StartAngle, 0, 5000);
            this.AddLabel("SweepAngle");
            this.AddNumericUpDown("SweepAngle", (int)pie.SweepAngle, 0, 5000);

            this.AddButton.Click += (sender, args) =>
            {
                try
                {
                    pie.PenWidth = (float)(this.TableLayoutPanel.Controls["PenWidthNumericUpDown"] as NumericUpDown).Value;
                    pie.PenColor = (this.TableLayoutPanel.Controls["PenColorButton"] as Button).BackColor;
                    pie.PenDashStyle = (DashStyle)(this.TableLayoutPanel.Controls["PenDashStyleComboBox"] as ComboBox).SelectedItem;
                    pie.X = (int)(this.TableLayoutPanel.Controls["XNumericUpDown"] as NumericUpDown).Value;
                    pie.Y = (int)(this.TableLayoutPanel.Controls["YNumericUpDown"] as NumericUpDown).Value;
                    pie.Width = (int)(this.TableLayoutPanel.Controls["WidthNumericUpDown"] as NumericUpDown).Value;
                    pie.Height = (int)(this.TableLayoutPanel.Controls["HeightNumericUpDown"] as NumericUpDown).Value;
                    pie.StartAngle = (float)(this.TableLayoutPanel.Controls["StartAngleNumericUpDown"] as NumericUpDown).Value;
                    pie.SweepAngle = (float)(this.TableLayoutPanel.Controls["SweepAngleNumericUpDown"] as NumericUpDown).Value;
                }
                catch (NullReferenceException e)
                {
                    MessageBox.Show(e.Message, "NullReferenceException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="ShapeEditForm"/> class from being created as it should
        /// be called with <see cref="Shape"/>-inherited geometric figure passed. Contains the component initialization.
        /// </summary>
        private ShapeEditForm()
        {
            this.InitializeComponent();

            this.CancelButton = this.CancelBtn;
        }

        #endregion

        #region Controls Adding Methods

        /// <summary>
        /// Adding new <see cref="Label"/> to this <see cref="TableLayoutPanel"/>.
        /// </summary>
        /// <param name="name">The string that will be used as the name and the text of the new <see cref="Label"/>.</param>
        private void AddLabel(string name)
        {
            Label label = new Label()
            {
                Name = name + LabelPostfix,
                Text = name + ':'               
            };            

            this.TableLayoutPanel.Controls.Add(label);
        }

        /// <summary>
        /// Adding new <see cref="NumericUpDown"/> to this <see cref="TableLayoutPanel"/>.
        /// </summary>
        /// <param name="name">The string that will be used as the name of the new <see cref="NumericUpDown"/>.</param>
        /// <param name="value">The value assigned to the spin box.</param>
        /// <param name="min">The minimum allowed value for the spin box.</param>
        /// <param name="max">The maximum allowed value for the spin box.</param>
        private void AddNumericUpDown(string name, int value, int min, int max)
        {
            NumericUpDown numericUpDown = new NumericUpDown()
            {
                Name = name + NumericUpDownPostfix,                
                Minimum = min,
                Maximum = max
            };
            numericUpDown.Value = value;

            this.TableLayoutPanel.Controls.Add(numericUpDown);
        }

        /// <summary>
        /// Adding new <see cref="Button"/> to this <see cref="TableLayoutPanel"/> for chosing color
        /// of the drawable figure.
        /// </summary>
        /// <param name="name">The string that will be used as the name of the <see cref="Button"/>.</param>
        /// <param name="color">The background color of the <see cref="Button"/> and the color of drawable figure.</param>
        private void AddColorButtonAndDialog(string name, Color color)
        {
            Button button = new Button()
            {
                Name = name + ButtonPostfix,
                Text = string.Empty,
                BackColor = color
            };

            this.TableLayoutPanel.Controls.Add(button);

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

        /// <summary>
        /// Adding new <see cref="Button"/> to this <see cref="TableLayoutPanel"/> for chosing dash style
        /// of the drawable figure.
        /// </summary>
        /// <param name="name">The string that will be used as the name of the <see cref="ComboBox"/>.</param>
        /// <param name="dashStyle">The dash style of drawable figure.</param>
        private void AddDashStyleComboBox(string name, DashStyle dashStyle)
        {
            ComboBox comboBox = new ComboBox()
            {                                
                Name = name + ComboBoxPostfix, 
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            
            comboBox.Items.Add(DashStyle.Dash);            
            comboBox.Items.Add(DashStyle.DashDot);
            comboBox.Items.Add(DashStyle.DashDotDot);
            comboBox.Items.Add(DashStyle.Dot);
            comboBox.Items.Add(DashStyle.Solid);
            comboBox.SelectedItem = dashStyle;

            this.TableLayoutPanel.Controls.Add(comboBox);
        }

        /// <summary>
        /// Adds controls to the form that are used to edit any <see cref="Shape"/>-inherited object.
        /// </summary>
        /// <param name="penWidth">The value of Pen.Width that will be added to the corresponding NumericUpDown Control.</param>
        /// <param name="penColor">The value of Pen.Color that will be added to the corresponding NumericUpDown Control.</param>
        /// <param name="penDashStyle">The value of Pen.DashStyle that will be added to the corresponding NumericUpDown Control.</param>
        private void AddCommonControls(int penWidth, Color penColor, DashStyle penDashStyle)
        {
            this.AddLabel("PenWidth");
            this.AddNumericUpDown("PenWidth", penWidth, 1, 30);
            this.AddLabel("PenColor");
            this.AddColorButtonAndDialog("PenColor", penColor);
            this.AddLabel("PenDashStyle");
            this.AddDashStyleComboBox("PenDashStyle", penDashStyle);
        }

        #endregion        
    }
}
