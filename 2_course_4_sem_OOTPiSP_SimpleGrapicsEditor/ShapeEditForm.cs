using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes;
using Rectangle = _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes.Rectangle;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor
{
    public partial class ShapeEditForm : Form
    {
        private Shape _shape;

        #region Constant Values

        private const int LabelLeftMargin = 10;
        private const int InteractiveControlLeftMargin = 120;
        private const int ControlsIndent = 30;
        private const int NumericUpDownWidth = 60;

        private const int InteractiveControlRightMargin = 30;
        private const int ButtonBottomMargin = 45;

        #endregion

        #region ShapeEditForm Fields Values

        private int _penWidth = 1;
        private Color _penColor = Color.Black;
        private DashStyle _penDashStyle = DashStyle.Solid;
        private int _locationX;
        private int _locationY;
        private int _radius;
        private int _length;
        private int _locationX2;
        private int _locationY2;
        private int _width;
        private int _height;
        private float _startAngle;
        private float _sweepAngle;

        #endregion

        #region Common Controls

        private readonly Label _penWidthLabel = new Label();
        private readonly NumericUpDown _penWidthNumericUpDown = new NumericUpDown();

        private readonly Label _penColorLabel = new Label();
        private readonly Button _penColorButton = new Button();
        private readonly ColorDialog _penColorDialog = new ColorDialog();

        private readonly Label _penDashStyleLabel = new Label();
        private readonly ComboBox _penDashStyleComboBox = new ComboBox();

        private readonly Label _locationLabel = new Label();
        private readonly NumericUpDown _locationXNumericUpDown = new NumericUpDown();
        private readonly NumericUpDown _locationYNumericUpDown = new NumericUpDown();

        private readonly Button _drawButton = new Button();

        #endregion

        #region Controls Adding

        #region Common

        private void PenWidthLabelAdd()
        {            
            _penWidthLabel.Location = new Point(LabelLeftMargin, 10);
            _penWidthLabel.AutoSize = true;
            _penWidthLabel.Text = "Pen Width:";
            Controls.Add(_penWidthLabel);
        }

        private void PenWidthNumericUpDownAdd()
        {            
            _penWidthNumericUpDown.Location = new Point(InteractiveControlLeftMargin, _penWidthLabel.Location.Y);
            _penWidthNumericUpDown.Size = new Size(NumericUpDownWidth, 14);
            _penWidthNumericUpDown.Value = _penWidth;
            _penWidthNumericUpDown.Minimum = 1;
            _penWidthNumericUpDown.Maximum = 10;
            Controls.Add(_penWidthNumericUpDown);

            _penWidthNumericUpDown.ValueChanged += (sender, args) => _penWidth = (int)_penWidthNumericUpDown.Value;
        }

        private void PenColorLabelAdd()
        {            
            _penColorLabel.Location = new Point(LabelLeftMargin, _penWidthLabel.Location.Y + ControlsIndent);
            _penColorLabel.AutoSize = true;
            _penColorLabel.Text = "Pen Color:";
            Controls.Add(_penColorLabel);
        }

        private void PenColorButtonAdd()
        {            
            _penColorButton.Location = new Point(InteractiveControlLeftMargin, _penColorLabel.Location.Y);
            _penColorButton.BackColor = Color.Black;
            _penColorButton.Text = "";
            Controls.Add(_penColorButton);
        }

        private void PenColorDialogAdd()
        {            
            _penColorDialog.Color = _penColor;
            _penColorDialog.AllowFullOpen = false;

            _penColorButton.Click += (sender, args) =>
            {
                if (_penColorDialog.ShowDialog() == DialogResult.OK)
                {
                    _penColor = _penColorDialog.Color;
                    _penColorButton.BackColor = _penColor;
                }
            };
        }

        private void PenDashStyleLabelAdd()
        {            
            _penDashStyleLabel.Location = new Point(LabelLeftMargin, _penColorLabel.Location.Y + ControlsIndent);
            _penDashStyleLabel.AutoSize = true;
            _penDashStyleLabel.Text = "Pen Dash Style:";
            Controls.Add(_penDashStyleLabel);
        }

        private void PenDashStyleComboBoxAdd()
        {            
            _penDashStyleComboBox.Location = new Point(InteractiveControlLeftMargin, _penDashStyleLabel.Location.Y);
            _penDashStyleComboBox.Items.Add(DashStyle.Solid);
            _penDashStyleComboBox.Items.Add(DashStyle.Dash);
            _penDashStyleComboBox.Items.Add(DashStyle.Dot);
            _penDashStyleComboBox.Items.Add(DashStyle.DashDot);
            _penDashStyleComboBox.Items.Add(DashStyle.DashDotDot);
            _penDashStyleComboBox.SelectedItem = _penDashStyle;
            Controls.Add(_penDashStyleComboBox);

            _penDashStyleComboBox.SelectedIndexChanged +=
                (sender, args) => _penDashStyle = (DashStyle)_penDashStyleComboBox.SelectedItem;
        }

        private void LocationLabelAdd()
        {            
            _locationLabel.Location = new Point(LabelLeftMargin, _penDashStyleLabel.Location.Y + ControlsIndent);
            _locationLabel.AutoSize = true;
            _locationLabel.Text = "Location (x, y):";
            Controls.Add(_locationLabel);
        }

        private void LocationXNumericUpDownAdd()
        {            
            _locationXNumericUpDown.Location = new Point(InteractiveControlLeftMargin, _locationLabel.Location.Y);
            _locationXNumericUpDown.Size = new Size(NumericUpDownWidth, 14);
            _locationXNumericUpDown.Value = _locationX;
            _locationXNumericUpDown.Maximum = 10000;
            Controls.Add(_locationXNumericUpDown);

            _locationXNumericUpDown.ValueChanged += (sender, args) => _locationX = (int)_locationXNumericUpDown.Value;
        }

        private void LocationYNumericUpDownAdd()
        {            
            _locationYNumericUpDown.Location = new Point(InteractiveControlLeftMargin + _locationXNumericUpDown.Size.Width, _locationLabel.Location.Y);
            _locationYNumericUpDown.Size = new Size(NumericUpDownWidth, 14);
            _locationYNumericUpDown.Value = _locationY;
            _locationYNumericUpDown.Maximum = 10000;
            Controls.Add(_locationYNumericUpDown);

            _locationYNumericUpDown.ValueChanged += (sender, args) => _locationY = (int)_locationYNumericUpDown.Value;
        }

        #endregion

        #region Different

        private void Location2AllAdd()
        {
            #region Location2

            Label location2Label = new Label
            {
                Location = new Point(LabelLeftMargin, _locationLabel.Location.Y + ControlsIndent),
                AutoSize = true,
                Text = "Location 2 (x, y):"
            };
            Controls.Add(location2Label);

            NumericUpDown location2XNumericUpDown = new NumericUpDown
            {
                Location = new Point(InteractiveControlLeftMargin, location2Label.Location.Y),
                Size = new Size(NumericUpDownWidth, 14),
                Value = _locationX2,
                Maximum = 10000
            };
            Controls.Add(location2XNumericUpDown);

            location2XNumericUpDown.ValueChanged += (sender, args) => _locationX2 = (int)location2XNumericUpDown.Value;

            NumericUpDown location2YNumericUpDown = new NumericUpDown
            {
                Location = new Point(InteractiveControlLeftMargin + location2XNumericUpDown.Size.Width, location2Label.Location.Y),
                Size = new Size(NumericUpDownWidth, 14),
                Value = _locationY2,
                Maximum = 10000
            };
            Controls.Add(location2YNumericUpDown);

            location2YNumericUpDown.ValueChanged += (sender, args) => _locationY2 = (int)location2YNumericUpDown.Value;

            #endregion            

            _drawButton.Location = new Point(Size.Width / 2 - _drawButton.Size.Width / 2, location2Label.Location.Y + ControlsIndent);
            _drawButton.Text = "Draw";
            Controls.Add(_drawButton);

            Size = new Size(Size.Width, _drawButton.Location.Y + _drawButton.Size.Height + ButtonBottomMargin);
        }

        private void RadiusAllAdd()
        {
            #region Radius

            Label radiusLabel = new Label
            {
                Location = new Point(LabelLeftMargin, _locationLabel.Location.Y + ControlsIndent),
                AutoSize = true,
                Text = "Radius:"
            };
            Controls.Add(radiusLabel);

            NumericUpDown radiusNumericUpDown = new NumericUpDown
            {
                Location = new Point(InteractiveControlLeftMargin, radiusLabel.Location.Y),
                Size = new Size(NumericUpDownWidth, 14),
                Value = _radius,
                Maximum = 10000
            };
            Controls.Add(radiusNumericUpDown);

            radiusNumericUpDown.ValueChanged += (sender, args) => _radius = (int)radiusNumericUpDown.Value;

            #endregion

            _drawButton.Location = new Point(Size.Width / 2 - _drawButton.Size.Width / 2, radiusLabel.Location.Y + ControlsIndent);
            _drawButton.Text = "Draw";
            Controls.Add(_drawButton);

            Size = new Size(Size.Width, _drawButton.Location.Y + _drawButton.Size.Height + ButtonBottomMargin);
        }

        private void LengthAllAdd()
        {
            #region Length

            Label lengthLabel = new Label
            {
                Location = new Point(LabelLeftMargin, _locationLabel.Location.Y + ControlsIndent),
                AutoSize = true,
                Text = "Length:"
            };
            Controls.Add(lengthLabel);

            NumericUpDown lengthNumericUpDown = new NumericUpDown
            {
                Location = new Point(InteractiveControlLeftMargin, lengthLabel.Location.Y),
                Size = new Size(NumericUpDownWidth, 14),
                Value = _length,
                Maximum = 10000
            };
            Controls.Add(lengthNumericUpDown);

            lengthNumericUpDown.ValueChanged += (sender, args) => _length = (int)lengthNumericUpDown.Value;

            #endregion

            _drawButton.Location = new Point(Size.Width / 2 - _drawButton.Size.Width / 2, lengthLabel.Location.Y + ControlsIndent);
            _drawButton.Text = "Draw";
            Controls.Add(_drawButton);

            Size = new Size(Size.Width, _drawButton.Location.Y + _drawButton.Size.Height + ButtonBottomMargin);
        }

        private void WidthHeightAllAdd()
        {
            #region WidthHeight

            Label widthHeightLabel = new Label
            {
                Location = new Point(LabelLeftMargin, _locationLabel.Location.Y + ControlsIndent),
                AutoSize = true,
                Text = "Width, Height (x, y):"
            };
            Controls.Add(widthHeightLabel);

            NumericUpDown widthNumericUpDown = new NumericUpDown
            {
                Location = new Point(InteractiveControlLeftMargin, widthHeightLabel.Location.Y),
                Size = new Size(NumericUpDownWidth, 14),
                Value = _width,
                Maximum = 10000
            };
            Controls.Add(widthNumericUpDown);

            widthNumericUpDown.ValueChanged += (sender, args) => _width = (int)widthNumericUpDown.Value;

            NumericUpDown heightNumericUpDown = new NumericUpDown
            {
                Location = new Point(InteractiveControlLeftMargin + widthNumericUpDown.Size.Width, widthHeightLabel.Location.Y),
                Size = new Size(NumericUpDownWidth, 14),
                Value = _height,
                Maximum = 10000
            };
            Controls.Add(heightNumericUpDown);

            heightNumericUpDown.ValueChanged += (sender, args) => _height = (int)heightNumericUpDown.Value;

            #endregion

            _drawButton.Location = new Point(Size.Width / 2 - _drawButton.Size.Width / 2, widthHeightLabel.Location.Y + ControlsIndent);
            _drawButton.Text = "Draw";
            Controls.Add(_drawButton);

            Size = new Size(Size.Width, _drawButton.Location.Y + _drawButton.Size.Height + ButtonBottomMargin);
        }

        private void WidthHeightStartAngleSweepAngleAllAdd()
        {
            #region WidthHeight

            Label widthHeightLabel = new Label
            {
                Location = new Point(LabelLeftMargin, _locationLabel.Location.Y + ControlsIndent),
                AutoSize = true,
                Text = "Width, Height (x, y):"
            };
            Controls.Add(widthHeightLabel);

            NumericUpDown widthNumericUpDown = new NumericUpDown
            {
                Location = new Point(InteractiveControlLeftMargin, widthHeightLabel.Location.Y),
                Size = new Size(NumericUpDownWidth, 14),
                Value = _width,
                Maximum = 10000
            };
            Controls.Add(widthNumericUpDown);

            widthNumericUpDown.ValueChanged += (sender, args) => _width = (int)widthNumericUpDown.Value;

            NumericUpDown heightNumericUpDown = new NumericUpDown
            {
                Location = new Point(InteractiveControlLeftMargin + widthNumericUpDown.Size.Width, widthHeightLabel.Location.Y),
                Size = new Size(NumericUpDownWidth, 14),
                Value = _height,
                Maximum = 10000
            };
            Controls.Add(heightNumericUpDown);

            heightNumericUpDown.ValueChanged += (sender, args) => _height = (int)heightNumericUpDown.Value;

            #endregion

            #region StartAngleSweepAngle

            Label startAngleLabel = new Label
            {
                Location = new Point(LabelLeftMargin, widthHeightLabel.Location.Y + ControlsIndent),
                AutoSize = true,
                Text = "Start Angle:"
            };
            Controls.Add(startAngleLabel);

            NumericUpDown startAngleNumericUpDown = new NumericUpDown
            {
                Location = new Point(InteractiveControlLeftMargin, startAngleLabel.Location.Y),
                Size = new Size(NumericUpDownWidth, 14),
                Value = (decimal)_startAngle,
                Maximum = 10000
            };
            Controls.Add(startAngleNumericUpDown);

            startAngleNumericUpDown.ValueChanged += (sender, args) => _startAngle = (int)startAngleNumericUpDown.Value;

            Label sweepAngleLabel = new Label
            {
                Location = new Point(LabelLeftMargin, startAngleLabel.Location.Y + ControlsIndent),
                AutoSize = true,
                Text = "Sweep Angle:"
            };
            Controls.Add(sweepAngleLabel);

            NumericUpDown sweepAngleNumericUpDown = new NumericUpDown
            {
                Location = new Point(InteractiveControlLeftMargin, sweepAngleLabel.Location.Y),
                Size = new Size(NumericUpDownWidth, 14),
                Value = (decimal)_sweepAngle,
                Maximum = 10000
            };
            Controls.Add(sweepAngleNumericUpDown);

            sweepAngleNumericUpDown.ValueChanged += (sender, args) => _sweepAngle = (int)sweepAngleNumericUpDown.Value;

            #endregion

            _drawButton.Location = new Point(Size.Width / 2 - _drawButton.Size.Width / 2, sweepAngleLabel.Location.Y + ControlsIndent);
            _drawButton.Text = "Draw";
            Controls.Add(_drawButton);

            Size = new Size(Size.Width, _drawButton.Location.Y + _drawButton.Size.Height + ButtonBottomMargin);
        }

        #endregion

        #endregion

        private ShapeEditForm()
        {
            InitializeComponent();

            #region Common Controls Configuration

            PenWidthLabelAdd();
            PenWidthNumericUpDownAdd();

            PenColorLabelAdd();
            PenColorButtonAdd();
            PenColorDialogAdd();

            PenDashStyleLabelAdd();
            PenDashStyleComboBoxAdd();

            LocationLabelAdd();
            LocationXNumericUpDownAdd();
            LocationYNumericUpDownAdd();

            #endregion

            // ShapeEditForm Width Configuration
            Size = new Size(_penDashStyleComboBox.Location.X + _penDashStyleComboBox.Size.Width + InteractiveControlRightMargin, Size.Height);
        }

        public ShapeEditForm(PictureBox drawingFieldPictureBox, out Line tempLine) : this()
        {
            Location2AllAdd();

            _drawButton.Click += (sender, args) =>
            {
                Line nline = new Line(_locationX, _locationY, _locationX2, _locationY2, _penWidth,
                    _penColor, _penDashStyle);
                _shape = nline;
                DrawingTools.Draw(nline, drawingFieldPictureBox);

                Close();
            };
            tempLine = _shape as Line;            
        }

        public ShapeEditForm(PictureBox drawingFieldPictureBox, out Circle tempCircle) : this()
        {
            RadiusAllAdd();

            _drawButton.Click += (sender, args) =>
            {
                Circle ncircle = new Circle(_locationX, _locationY, _radius, _penWidth, _penColor,
                    _penDashStyle);
                _shape = ncircle;                
                DrawingTools.Draw(ncircle, drawingFieldPictureBox);
                Close();
            };
            tempCircle = _shape as Circle;
        }

        public ShapeEditForm(PictureBox drawingFieldPictureBox, out Star tempStar) : this()
        {
            RadiusAllAdd();

            _drawButton.Click += (sender, args) =>
            {
                Star nstar = new Star(_locationX, _locationY, _radius, _penWidth, _penColor,
                    _penDashStyle);
                _shape = nstar;                
                DrawingTools.Draw(nstar, drawingFieldPictureBox);
                Close();
            };
            tempStar = _shape as Star;
        }

        public ShapeEditForm(PictureBox drawingFieldPictureBox, out Square tempSquare) : this()
        {
            LengthAllAdd();

            _drawButton.Click += (sender, args) =>
            {
                Square nsquare = new Square(_locationX, _locationY, _length, _penWidth, _penColor,
                    _penDashStyle);
                _shape = nsquare;                
                DrawingTools.Draw(nsquare, drawingFieldPictureBox);
                Close();
            };
            tempSquare = _shape as Square;
        }

        public ShapeEditForm(PictureBox drawingFieldPictureBox, out Rectangle tempRectangle) : this()
        {
            WidthHeightAllAdd();

            _drawButton.Click += (sender, args) =>
            {
                Rectangle nrectangle = new Rectangle(_locationX, _locationY, _width,
                    _height, _penWidth, _penColor, _penDashStyle);
                _shape = nrectangle;
                DrawingTools.Draw(nrectangle, drawingFieldPictureBox);
                Close();
            };
            tempRectangle = _shape as Rectangle;
        }

        public ShapeEditForm(PictureBox drawingFieldPictureBox, out Ellipse tempEllipse) : this()
        {
            WidthHeightAllAdd();

            _drawButton.Click += (sender, args) =>
            {
                Ellipse nellipse = new Ellipse(_locationX, _locationY, _width, _height, _penWidth,
                    _penColor, _penDashStyle);
                _shape = nellipse;
                //_shape.Draw();
                DrawingTools.Draw(nellipse, drawingFieldPictureBox);
                Close();
            };
            tempEllipse = _shape as Ellipse;
        }

        public ShapeEditForm(PictureBox drawingFieldPictureBox, out Arc tempArc) : this()
        {
            WidthHeightStartAngleSweepAngleAllAdd();

            _drawButton.Click += (sender, args) =>
            {
                Arc narc = new Arc(_locationX, _locationY, _width, _height, _startAngle, _sweepAngle,
                    _penWidth, _penColor, _penDashStyle);
                _shape = narc;
                //_shape.Draw();
                DrawingTools.Draw(narc, drawingFieldPictureBox);
                Close();
            };
            tempArc = _shape as Arc;
        }

        public ShapeEditForm(PictureBox drawingFieldPictureBox, out Pie tempPie) : this()
        {
            WidthHeightStartAngleSweepAngleAllAdd();

            _drawButton.Click += (sender, args) =>
            {
                Pie npie = new Pie(_locationX, _locationY, _width, _height, _startAngle, _sweepAngle,
                    _penWidth, _penColor, _penDashStyle);
                _shape = npie;
                DrawingTools.Draw(npie, drawingFieldPictureBox);
                Close();
            };
            tempPie = _shape as Pie;
        }
    }
}
