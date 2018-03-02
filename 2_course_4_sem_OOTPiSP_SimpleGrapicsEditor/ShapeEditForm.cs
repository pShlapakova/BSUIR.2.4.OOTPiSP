using _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor
{
    public partial class ShapeEditForm : Form
    {
        private Shape shape;

        #region Constant Values

        private const int LabelLeftMargin = 10;
        private const int InteractiveControlLeftMargin = 120;
        private const int ControlsIndent = 30;
        private const int NumericUpDownWidth = 60;

        private const int InteractiveControlRightMargin = 30;
        private const int ButtonBottomMargin = 45;

        #endregion

        #region ShapeEditForm Fields Values

        private int penWidth = 1;
        private Color penColor = Color.Black;
        private DashStyle penDashStyle = DashStyle.Solid;
        private int locationX = 0;
        private int locationY = 0;
        private int radius = 0;
        private int length = 0;
        private int locationX2 = 0;
        private int locationY2 = 0;
        private int width = 0;
        private int height = 0;
        private float startAngle = 0;
        private float sweepAngle = 0;

        #endregion

        #region Common Controls

        Label PenWidthLabel = new Label();
        NumericUpDown PenWidthNumericUpDown = new NumericUpDown();

        Label PenColorLabel = new Label();
        Button PenColorButton = new Button();
        ColorDialog PenColorDialog = new ColorDialog();

        Label PenDashStyleLabel = new Label();
        ComboBox PenDashStyleComboBox = new ComboBox();

        Label LocationLabel = new Label();
        NumericUpDown LocationXNumericUpDown = new NumericUpDown();
        NumericUpDown LocationYNumericUpDown = new NumericUpDown();

        Button DrawButton = new Button();

        #endregion

        #region Controls Adding

        #region Common

        private void PenWidthLabelAdd()
        {            
            PenWidthLabel.Location = new Point(LabelLeftMargin, 10);
            PenWidthLabel.AutoSize = true;
            PenWidthLabel.Text = "Pen Width:";
            Controls.Add(PenWidthLabel);
        }

        private void PenWidthNumericUpDownAdd()
        {            
            PenWidthNumericUpDown.Location = new Point(InteractiveControlLeftMargin, PenWidthLabel.Location.Y);
            PenWidthNumericUpDown.Size = new Size(NumericUpDownWidth, 14);
            PenWidthNumericUpDown.Value = penWidth;
            PenWidthNumericUpDown.Minimum = 1;
            PenWidthNumericUpDown.Maximum = 10;
            Controls.Add(PenWidthNumericUpDown);

            PenWidthNumericUpDown.ValueChanged += (sender, args) => penWidth = (int)PenWidthNumericUpDown.Value;
        }

        private void PenColorLabelAdd()
        {            
            PenColorLabel.Location = new Point(LabelLeftMargin, PenWidthLabel.Location.Y + ControlsIndent);
            PenColorLabel.AutoSize = true;
            PenColorLabel.Text = "Pen Color:";
            Controls.Add(PenColorLabel);
        }

        private void PenColorButtonAdd()
        {            
            PenColorButton.Location = new Point(InteractiveControlLeftMargin, PenColorLabel.Location.Y);
            PenColorButton.BackColor = Color.Black;
            PenColorButton.Text = "";
            Controls.Add(PenColorButton);
        }

        private void PenColorDialogAdd()
        {            
            PenColorDialog.Color = penColor;
            PenColorDialog.AllowFullOpen = false;

            PenColorButton.Click += (sender, args) =>
            {
                if (PenColorDialog.ShowDialog() == DialogResult.OK)
                {
                    penColor = PenColorDialog.Color;
                    PenColorButton.BackColor = penColor;
                }
            };
        }

        private void PenDashStyleLabelAdd()
        {            
            PenDashStyleLabel.Location = new Point(LabelLeftMargin, PenColorLabel.Location.Y + ControlsIndent);
            PenDashStyleLabel.AutoSize = true;
            PenDashStyleLabel.Text = "Pen Dash Style:";
            Controls.Add(PenDashStyleLabel);
        }

        private void PenDashStyleComboBoxAdd()
        {            
            PenDashStyleComboBox.Location = new Point(InteractiveControlLeftMargin, PenDashStyleLabel.Location.Y);
            PenDashStyleComboBox.Items.Add(DashStyle.Solid);
            PenDashStyleComboBox.Items.Add(DashStyle.Dash);
            PenDashStyleComboBox.Items.Add(DashStyle.Dot);
            PenDashStyleComboBox.Items.Add(DashStyle.DashDot);
            PenDashStyleComboBox.Items.Add(DashStyle.DashDotDot);
            PenDashStyleComboBox.SelectedItem = penDashStyle;
            Controls.Add(PenDashStyleComboBox);

            PenDashStyleComboBox.SelectedIndexChanged +=
                (sender, args) => penDashStyle = (DashStyle)PenDashStyleComboBox.SelectedItem;
        }

        private void LocationLabelAdd()
        {            
            LocationLabel.Location = new Point(LabelLeftMargin, PenDashStyleLabel.Location.Y + ControlsIndent);
            LocationLabel.AutoSize = true;
            LocationLabel.Text = "Location (x, y):";
            Controls.Add(LocationLabel);
        }

        private void LocationXNumericUpDownAdd()
        {            
            LocationXNumericUpDown.Location = new Point(InteractiveControlLeftMargin, LocationLabel.Location.Y);
            LocationXNumericUpDown.Size = new Size(NumericUpDownWidth, 14);
            LocationXNumericUpDown.Value = locationX;
            LocationXNumericUpDown.Maximum = 10000;
            Controls.Add(LocationXNumericUpDown);

            LocationXNumericUpDown.ValueChanged += (sender, args) => locationX = (int)LocationXNumericUpDown.Value;
        }

        private void LocationYNumericUpDownAdd()
        {            
            LocationYNumericUpDown.Location = new Point(InteractiveControlLeftMargin + LocationXNumericUpDown.Size.Width, LocationLabel.Location.Y);
            LocationYNumericUpDown.Size = new Size(NumericUpDownWidth, 14);
            LocationYNumericUpDown.Value = locationY;
            LocationYNumericUpDown.Maximum = 10000;
            Controls.Add(LocationYNumericUpDown);

            LocationYNumericUpDown.ValueChanged += (sender, args) => locationY = (int)LocationYNumericUpDown.Value;
        }

        #endregion

        #region Different

        private void Location2AllAdd()
        {
            #region Location2

            Label Location2Label = new Label();
            Location2Label.Location = new Point(LabelLeftMargin, LocationLabel.Location.Y + ControlsIndent);
            Location2Label.AutoSize = true;
            Location2Label.Text = "Location 2 (x, y):";
            Controls.Add(Location2Label);

            NumericUpDown Location2XNumericUpDown = new NumericUpDown();
            Location2XNumericUpDown.Location = new Point(InteractiveControlLeftMargin, Location2Label.Location.Y);
            Location2XNumericUpDown.Size = new Size(NumericUpDownWidth, 14);
            Location2XNumericUpDown.Value = locationX2;
            Location2XNumericUpDown.Maximum = 10000;
            Controls.Add(Location2XNumericUpDown);

            Location2XNumericUpDown.ValueChanged += (sender, args) => locationX2 = (int)Location2XNumericUpDown.Value;

            NumericUpDown Location2YNumericUpDown = new NumericUpDown();
            Location2YNumericUpDown.Location = new Point(InteractiveControlLeftMargin + Location2XNumericUpDown.Size.Width, Location2Label.Location.Y);
            Location2YNumericUpDown.Size = new Size(NumericUpDownWidth, 14);
            Location2YNumericUpDown.Value = locationY2;
            Location2YNumericUpDown.Maximum = 10000;
            Controls.Add(Location2YNumericUpDown);

            Location2YNumericUpDown.ValueChanged += (sender, args) => locationY2 = (int)Location2YNumericUpDown.Value;

            #endregion            

            DrawButton.Location = new Point(this.Size.Width / 2 - DrawButton.Size.Width / 2, Location2Label.Location.Y + ControlsIndent);
            DrawButton.Text = "Draw";
            Controls.Add(DrawButton);

            this.Size = new Size(this.Size.Width, DrawButton.Location.Y + DrawButton.Size.Height + ButtonBottomMargin);
        }

        private void RadiusAllAdd()
        {
            #region Radius

            Label RadiusLabel = new Label();
            RadiusLabel.Location = new Point(LabelLeftMargin, LocationLabel.Location.Y + ControlsIndent);
            RadiusLabel.AutoSize = true;
            RadiusLabel.Text = "Radius:";
            Controls.Add(RadiusLabel);

            NumericUpDown RadiusNumericUpDown = new NumericUpDown();
            RadiusNumericUpDown.Location = new Point(InteractiveControlLeftMargin, RadiusLabel.Location.Y);
            RadiusNumericUpDown.Size = new Size(NumericUpDownWidth, 14);
            RadiusNumericUpDown.Value = radius;
            RadiusNumericUpDown.Maximum = 10000;
            Controls.Add(RadiusNumericUpDown);

            RadiusNumericUpDown.ValueChanged += (sender, args) => radius = (int)RadiusNumericUpDown.Value;

            #endregion

            DrawButton.Location = new Point(this.Size.Width / 2 - DrawButton.Size.Width / 2, RadiusLabel.Location.Y + ControlsIndent);
            DrawButton.Text = "Draw";
            Controls.Add(DrawButton);

            this.Size = new Size(this.Size.Width, DrawButton.Location.Y + DrawButton.Size.Height + ButtonBottomMargin);
        }

        private void LengthAllAdd()
        {
            #region Length

            Label LengthLabel = new Label();
            LengthLabel.Location = new Point(LabelLeftMargin, LocationLabel.Location.Y + ControlsIndent);
            LengthLabel.AutoSize = true;
            LengthLabel.Text = "Length:";
            Controls.Add(LengthLabel);

            NumericUpDown LengthNumericUpDown = new NumericUpDown();
            LengthNumericUpDown.Location = new Point(InteractiveControlLeftMargin, LengthLabel.Location.Y);
            LengthNumericUpDown.Size = new Size(NumericUpDownWidth, 14);
            LengthNumericUpDown.Value = length;
            LengthNumericUpDown.Maximum = 10000;
            Controls.Add(LengthNumericUpDown);

            LengthNumericUpDown.ValueChanged += (sender, args) => length = (int)LengthNumericUpDown.Value;

            #endregion

            DrawButton.Location = new Point(this.Size.Width / 2 - DrawButton.Size.Width / 2, LengthLabel.Location.Y + ControlsIndent);
            DrawButton.Text = "Draw";
            Controls.Add(DrawButton);

            this.Size = new Size(this.Size.Width, DrawButton.Location.Y + DrawButton.Size.Height + ButtonBottomMargin);
        }

        private void WidthHeightAllAdd()
        {
            #region WidthHeight

            Label WidthHeightLabel = new Label();
            WidthHeightLabel.Location = new Point(LabelLeftMargin, LocationLabel.Location.Y + ControlsIndent);
            WidthHeightLabel.AutoSize = true;
            WidthHeightLabel.Text = "Width, Height (x, y):";
            Controls.Add(WidthHeightLabel);

            NumericUpDown WidthNumericUpDown = new NumericUpDown();
            WidthNumericUpDown.Location = new Point(InteractiveControlLeftMargin, WidthHeightLabel.Location.Y);
            WidthNumericUpDown.Size = new Size(NumericUpDownWidth, 14);
            WidthNumericUpDown.Value = width;
            WidthNumericUpDown.Maximum = 10000;
            Controls.Add(WidthNumericUpDown);

            WidthNumericUpDown.ValueChanged += (sender, args) => width = (int)WidthNumericUpDown.Value;

            NumericUpDown HeightNumericUpDown = new NumericUpDown();
            HeightNumericUpDown.Location = new Point(InteractiveControlLeftMargin + WidthNumericUpDown.Size.Width, WidthHeightLabel.Location.Y);
            HeightNumericUpDown.Size = new Size(NumericUpDownWidth, 14);
            HeightNumericUpDown.Value = height;
            HeightNumericUpDown.Maximum = 10000;
            Controls.Add(HeightNumericUpDown);

            HeightNumericUpDown.ValueChanged += (sender, args) => height = (int)HeightNumericUpDown.Value;

            #endregion

            DrawButton.Location = new Point(this.Size.Width / 2 - DrawButton.Size.Width / 2, WidthHeightLabel.Location.Y + ControlsIndent);
            DrawButton.Text = "Draw";
            Controls.Add(DrawButton);

            this.Size = new Size(this.Size.Width, DrawButton.Location.Y + DrawButton.Size.Height + ButtonBottomMargin);
        }

        private void WidthHeightStartAngleSweepAngleAllAdd()
        {
            #region WidthHeight

            Label WidthHeightLabel = new Label();
            WidthHeightLabel.Location = new Point(LabelLeftMargin, LocationLabel.Location.Y + ControlsIndent);
            WidthHeightLabel.AutoSize = true;
            WidthHeightLabel.Text = "Width, Height (x, y):";
            Controls.Add(WidthHeightLabel);

            NumericUpDown WidthNumericUpDown = new NumericUpDown();
            WidthNumericUpDown.Location = new Point(InteractiveControlLeftMargin, WidthHeightLabel.Location.Y);
            WidthNumericUpDown.Size = new Size(NumericUpDownWidth, 14);
            WidthNumericUpDown.Value = width;
            WidthNumericUpDown.Maximum = 10000;
            Controls.Add(WidthNumericUpDown);

            WidthNumericUpDown.ValueChanged += (sender, args) => width = (int)WidthNumericUpDown.Value;

            NumericUpDown HeightNumericUpDown = new NumericUpDown();
            HeightNumericUpDown.Location = new Point(InteractiveControlLeftMargin + WidthNumericUpDown.Size.Width, WidthHeightLabel.Location.Y);
            HeightNumericUpDown.Size = new Size(NumericUpDownWidth, 14);
            HeightNumericUpDown.Value = height;
            HeightNumericUpDown.Maximum = 10000;
            Controls.Add(HeightNumericUpDown);

            HeightNumericUpDown.ValueChanged += (sender, args) => height = (int)HeightNumericUpDown.Value;

            #endregion

            #region StartAngleSweepAngle

            Label StartAngleLabel = new Label();
            StartAngleLabel.Location = new Point(LabelLeftMargin, WidthHeightLabel.Location.Y + ControlsIndent);
            StartAngleLabel.AutoSize = true;
            StartAngleLabel.Text = "Start Angle:";
            Controls.Add(StartAngleLabel);

            NumericUpDown StartAngleNumericUpDown = new NumericUpDown();
            StartAngleNumericUpDown.Location = new Point(InteractiveControlLeftMargin, StartAngleLabel.Location.Y);
            StartAngleNumericUpDown.Size = new Size(NumericUpDownWidth, 14);
            StartAngleNumericUpDown.Value = (decimal)startAngle;
            StartAngleNumericUpDown.Maximum = 10000;
            Controls.Add(StartAngleNumericUpDown);

            StartAngleNumericUpDown.ValueChanged += (sender, args) => startAngle = (int)StartAngleNumericUpDown.Value;

            Label SweepAngleLabel = new Label();
            SweepAngleLabel.Location = new Point(LabelLeftMargin, StartAngleLabel.Location.Y + ControlsIndent);
            SweepAngleLabel.AutoSize = true;
            SweepAngleLabel.Text = "Sweep Angle:";
            Controls.Add(SweepAngleLabel);

            NumericUpDown SweepAngleNumericUpDown = new NumericUpDown();
            SweepAngleNumericUpDown.Location = new Point(InteractiveControlLeftMargin, SweepAngleLabel.Location.Y);
            SweepAngleNumericUpDown.Size = new Size(NumericUpDownWidth, 14);
            SweepAngleNumericUpDown.Value = (decimal)sweepAngle;
            SweepAngleNumericUpDown.Maximum = 10000;
            Controls.Add(SweepAngleNumericUpDown);

            SweepAngleNumericUpDown.ValueChanged += (sender, args) => sweepAngle = (int)SweepAngleNumericUpDown.Value;

            #endregion

            DrawButton.Location = new Point(this.Size.Width / 2 - DrawButton.Size.Width / 2, SweepAngleLabel.Location.Y + ControlsIndent);
            DrawButton.Text = "Draw";
            Controls.Add(DrawButton);

            this.Size = new Size(this.Size.Width, DrawButton.Location.Y + DrawButton.Size.Height + ButtonBottomMargin);
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
            this.Size = new Size(PenDashStyleComboBox.Location.X + PenDashStyleComboBox.Size.Width + InteractiveControlRightMargin, this.Size.Height);
        }

        public ShapeEditForm(PictureBox drawingFieldPictureBox, out Line tempLine) : this()
        {
            Location2AllAdd();

            DrawButton.Click += (sender, args) =>
            {
                Line nline = new Line(locationX, locationY, locationX2, locationY2, penWidth,
                    penColor, penDashStyle);
                shape = nline;
                DrawingTools.Draw(nline, drawingFieldPictureBox);

                this.Close();
            };
            tempLine = shape as Line;            
        }

        public ShapeEditForm(PictureBox drawingFieldPictureBox, out Circle tempCircle) : this()
        {
            RadiusAllAdd();

            DrawButton.Click += (sender, args) =>
            {
                Circle ncircle = new Circle(locationX, locationY, radius, penWidth, penColor,
                    penDashStyle);
                shape = ncircle;                
                DrawingTools.Draw(ncircle, drawingFieldPictureBox);
                this.Close();
            };
            tempCircle = shape as Circle;
        }

        public ShapeEditForm(PictureBox drawingFieldPictureBox, out Star tempStar) : this()
        {
            RadiusAllAdd();

            DrawButton.Click += (sender, args) =>
            {
                Star nstar = new Star(locationX, locationY, radius, penWidth, penColor,
                    penDashStyle);
                shape = nstar;                
                DrawingTools.Draw(nstar, drawingFieldPictureBox);
                this.Close();
            };
            tempStar = shape as Star;
        }

        public ShapeEditForm(PictureBox drawingFieldPictureBox, out Square tempSquare) : this()
        {
            LengthAllAdd();

            DrawButton.Click += (sender, args) =>
            {
                Square nsquare = new Square(locationX, locationY, length, penWidth, penColor,
                    penDashStyle);
                shape = nsquare;                
                DrawingTools.Draw(nsquare, drawingFieldPictureBox);
                this.Close();
            };
            tempSquare = shape as Square;
        }

        public ShapeEditForm(PictureBox drawingFieldPictureBox, out Shapes.Rectangle tempRectangle) : this()
        {
            WidthHeightAllAdd();

            DrawButton.Click += (sender, args) =>
            {
                Shapes.Rectangle nrectangle = new Shapes.Rectangle(locationX, locationY, width,
                    height, penWidth, penColor, penDashStyle);
                shape = nrectangle;
                DrawingTools.Draw(nrectangle, drawingFieldPictureBox);
                this.Close();
            };
            tempRectangle = shape as Shapes.Rectangle;
        }

        public ShapeEditForm(PictureBox drawingFieldPictureBox, out Ellipse tempEllipse) : this()
        {
            WidthHeightAllAdd();

            DrawButton.Click += (sender, args) =>
            {
                Ellipse nellipse = new Ellipse(locationX, locationY, width, height, penWidth,
                    penColor, penDashStyle);
                shape = nellipse;
                //shape.Draw();
                DrawingTools.Draw(nellipse, drawingFieldPictureBox);
                this.Close();
            };
            tempEllipse = shape as Ellipse;
        }

        public ShapeEditForm(PictureBox drawingFieldPictureBox, out Arc tempArc) : this()
        {
            WidthHeightStartAngleSweepAngleAllAdd();

            DrawButton.Click += (sender, args) =>
            {
                Arc narc = new Arc(locationX, locationY, width, height, startAngle, sweepAngle,
                    penWidth, penColor, penDashStyle);
                shape = narc;
                //shape.Draw();
                DrawingTools.Draw(narc, drawingFieldPictureBox);
                this.Close();
            };
            tempArc = shape as Arc;
        }

        public ShapeEditForm(PictureBox drawingFieldPictureBox, out Pie tempPie) : this()
        {
            WidthHeightStartAngleSweepAngleAllAdd();

            DrawButton.Click += (sender, args) =>
            {
                Pie npie = new Pie(locationX, locationY, width, height, startAngle, sweepAngle,
                    penWidth, penColor, penDashStyle);
                shape = npie;
                DrawingTools.Draw(npie, drawingFieldPictureBox);
                this.Close();
            };
            tempPie = shape as Pie;
        }
    }
}
