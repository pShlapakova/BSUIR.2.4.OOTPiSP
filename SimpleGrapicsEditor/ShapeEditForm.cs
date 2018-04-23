namespace SimpleGrapicsEditor
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;    
    using System.Reflection;
    using System.Windows.Forms;    
    using SimpleGrapicsEditor.Shapes;    

    /// <summary>
    /// Contains controls for editing characteristics of the <see cref="AbstractShape"/>-inherited
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
        /// Initializes a new instance of the <see cref="ShapeEditForm"/> class with <see cref="AbstractShape"/>
        /// object passed.
        /// </summary>
        /// <param name="shape"><see cref="AbstractShape"/> object to be edited.</param>
        /// <exception cref="System.NullReferenceException">Thrown when necessary
        /// <see cref="System.Windows.Forms.Control"/> cannot be found on the
        /// <see cref="System.Windows.Forms.TableLayoutPanel"/>.</exception>
        public ShapeEditForm(AbstractShape shape) : this()
        {
            // Boundaries for NumericUpDown Controls.
            const int MinValue = 0,
                      MaxValue = 5000;

            // Adds Controls for Width, Color and DashStyle values of Pen.
            this.AddCommonControls((int)shape.PenWidth, shape.PenColor, shape.PenDashStyle);            

            // Used for getting properties of Shape (using Reflection).
            Type shapeType = shape.GetType();

            // Adding nesessary Controls for Shape's properties.
            foreach (PropertyInfo pi in shapeType.GetProperties())
            {
                if (AreValid(pi.Name, pi.PropertyType))
                {                    
                    this.AddLabel(pi.Name);

                    // PropertyInfo.GetValue(object) takes Object, so we must correctly unbox it's value.                    
                    if (pi.PropertyType == typeof(int))
                    {
                        this.AddNumericUpDown(pi.Name, (int)pi.GetValue(shape), MinValue, MaxValue);
                    }
                    else // if (pi.PropertyType == typeof(float))
                    {
                        this.AddNumericUpDown(pi.Name, (int)(float)pi.GetValue(shape), MinValue, MaxValue);
                    }                    
                }                                
            }

            this.AddButton.Click += (sender, args) =>
            {
                try
                {
                    shape.PenWidth = (float)(this.TableLayoutPanel.Controls[nameof(shape.PenWidth) + NumericUpDownPostfix] as NumericUpDown).Value;
                    shape.PenColor = (this.TableLayoutPanel.Controls[nameof(shape.PenColor) + ButtonPostfix] as Button).BackColor;
                    shape.PenDashStyle = (DashStyle)(this.TableLayoutPanel.Controls[nameof(shape.PenDashStyle) + ComboBoxPostfix] as ComboBox).SelectedItem;

                    foreach (PropertyInfo pi in shapeType.GetProperties())
                    {
                        if (AreValid(pi.Name, pi.PropertyType))
                        {                            
                            pi.SetValue(shape, (int)(this.TableLayoutPanel.Controls[pi.Name + NumericUpDownPostfix] as NumericUpDown).Value);
                        }                            
                    }

                }
                catch (NullReferenceException e)
                {
                    MessageBox.Show(e.Message, e.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            // Used for checking properties' names and types.
            bool AreValid(string name, Type type)
            {
                return name != "PenWidth"
                    && name != "PenColor"
                    && name != "PenDashStyle"
                    && (type == typeof(int) || type == typeof(float));
            }
        }
        
        /// <summary>
        /// Prevents a default instance of the <see cref="ShapeEditForm"/> class from being created as it should
        /// be called with <see cref="AbstractShape"/>-inherited geometric figure passed. Contains the component initialization.
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
        /// Adds controls to the form that are used to edit any <see cref="AbstractShape"/>-inherited object.
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
