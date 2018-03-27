namespace SimpleGrapicsEditor
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;
    using SimpleGrapicsEditor.Shapes;
	using SimpleGrapicsEditor.Tools;
    using Rectangle = Shapes.Rectangle;

    /// <summary>
    /// Main window of the software.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class and sets some
        /// necessary parameters inside.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();

            this.ioTools = new IoTools(this.ShapeListBox);

            this.saveToolStripMenuItem.Enabled = false;

            this.ShapeListBox.ContextMenuStrip = this.ShapeListBoxContextMenuStrip;
            this.ClearShapeListToolStripMenuItem.Click += this.ClearShapeListToolStripMenuItemClick;
        }

        #endregion
                        
        #region Events

        #region MainForm

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            this.ioTools.Exit(out bool stopClosing);

            e.Cancel = stopClosing;
        }

        #endregion

        #region DrawingFieldPictureBox

        #region Cursor Position Printing

        private void DrawingFieldPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            this.CurrentMousePositionTextBox.Text = $"{MousePosition.X - this.Location.X - 8}, {MousePosition.Y - this.Location.Y - 54}";
        }
            
        private void DrawingFieldPictureBoxMouseLeave(object sender, EventArgs e) => this.CurrentMousePositionTextBox.Clear();

        #endregion

        #endregion

        #region ShapeListBoxContextMenuStrip

        private void ClearShapeListToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (this.ShapeListBox.Items.Count > 0)
            {
                this.ShapeListBox.Items.Clear();
                this.EnableSaving();
                this.ioTools.ThereIsChanges = true;
            }

        }

        #endregion

        #region MenuStrip

        private void NewToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.ioTools.New(out bool successfully);
            if (successfully)
            {
                this.DisableSaving();
            }
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.ioTools.Open(out bool successfully);
            if (successfully)
            {
                this.DisableSaving();
            }
        }

        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.ioTools.Save(out bool successfully);
            if (successfully)
            {
                this.DisableSaving();
            }
        }

        private void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.ioTools.SaveAs(out bool successfully);
            if (successfully)
            {
                this.DisableSaving();
            }
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Buttons

        #region AddShape Buttons

        private void AddLineButtonClick(object sender, EventArgs e)
        {
            Line line = new Line();
            ShapeEditForm shapeEditForm = new ShapeEditForm(line);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                this.ShapeListBox.Items.Add(line);                
                this.EnableSaving();
                this.ioTools.ThereIsChanges = true;
            }            
        }

        private void AddRectangleButtonClick(object sender, EventArgs e)
        {
            Rectangle rectangle = new Rectangle();
            ShapeEditForm shapeEditForm = new ShapeEditForm(rectangle);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                this.ShapeListBox.Items.Add(rectangle);
                this.EnableSaving();
                this.ioTools.ThereIsChanges = true;
            }
        }

        private void AddEllipseButtonClick(object sender, EventArgs e)
        {
            Ellipse ellipse = new Ellipse();
            ShapeEditForm shapeEditForm = new ShapeEditForm(ellipse);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                this.ShapeListBox.Items.Add(ellipse);
                this.EnableSaving();
                this.ioTools.ThereIsChanges = true;
            }
        }

        private void AddCircleButtonClick(object sender, EventArgs e)
        {
            Circle circle = new Circle();
            ShapeEditForm shapeEditForm = new ShapeEditForm(circle);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                this.ShapeListBox.Items.Add(circle);
                this.EnableSaving();
                this.ioTools.ThereIsChanges = true;
            }
        }

        private void AddArcButtonClick(object sender, EventArgs e)
        {
            Arc arc = new Arc();
            ShapeEditForm shapeEditForm = new ShapeEditForm(arc);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                this.ShapeListBox.Items.Add(arc);
                this.EnableSaving();
                this.ioTools.ThereIsChanges = true;
            }
        }

        private void AddPieButtonClick(object sender, EventArgs e)
        {
            Pie pie = new Pie();
            ShapeEditForm shapeEditForm = new ShapeEditForm(pie);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                this.ShapeListBox.Items.Add(pie);
                this.EnableSaving();
                this.ioTools.ThereIsChanges = true;
            }
        }

        private void AddStarButtonClick(object sender, EventArgs e)
        {
            Star star = new Star();
            ShapeEditForm shapeEditForm = new ShapeEditForm(star);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                this.ShapeListBox.Items.Add(star);
                this.EnableSaving();
                this.ioTools.ThereIsChanges = true;
            }
        }

        private void AddSquareButtonClick(object sender, EventArgs e)
        {
            Square square = new Square();
            ShapeEditForm shapeEditForm = new ShapeEditForm(square);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                this.ShapeListBox.Items.Add(square);
                this.EnableSaving();
                this.ioTools.ThereIsChanges = true;
            }
        }

        #endregion

        #region Buttons that working with ShapeListBox

        private void EditShapeButtonClick(object sender, EventArgs e)
        {
            string strForComparing = this.ShapeListBox.SelectedItem.ToString();
            dynamic shape = this.ShapeListBox.SelectedItem;
            ShapeEditForm shapeEditForm = new ShapeEditForm(shape);
            if (shapeEditForm.ShowDialog() == DialogResult.OK)
            {
                // To rewrite text
                int index = this.ShapeListBox.SelectedIndex;
                this.ShapeListBox.Items.RemoveAt(index);
                this.ShapeListBox.Items.Insert(index, shape);

                if (strForComparing != shape.ToString())
                {
                    this.EnableSaving();
                    this.ioTools.ThereIsChanges = true;
                }
            }
        }

        private void DeleteShapeButtonClick(object sender, EventArgs e)
        {
            if (this.ShapeListBox.SelectedItem != null)
            {
                this.ShapeListBox.Items.RemoveAt(this.ShapeListBox.SelectedIndex);
                this.EnableSaving();
                this.ioTools.ThereIsChanges = true;
            }
        }

        private void SortListButtonClick(object sender, EventArgs e)
        {
            string strToCompare = ListToString(this.ShapeListBox);

            Shape[] bufShapeArray = new Shape[this.ShapeListBox.Items.Count];
            this.ShapeListBox.Items.CopyTo(bufShapeArray, 0);
            this.ShapeListBox.Items.Clear();
            Array.Sort(bufShapeArray);
            this.ShapeListBox.Items.AddRange(bufShapeArray);

            if (strToCompare != ListToString(this.ShapeListBox))
            {
                this.EnableSaving();
                this.ioTools.ThereIsChanges = true;
            }

            string ListToString(ListBox shapeListBox)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Shape shape in shapeListBox.Items)
                {
                    sb.Append(shape.ToString());
                }

                return sb.ToString();
            }
        }


        private void DrawListButtonClick(object sender, EventArgs e)
        {
            DrawingTools.DrawAll(DrawingTools.GetShapes(this.ShapeListBox), this.DrawingFieldPictureBox);
        }

        #endregion

        private void ClearCanvasButtonClick(object sender, EventArgs e)
        {
            DrawingTools.ClearPictureBox(this.DrawingFieldPictureBox);
        }

        #endregion

        #endregion

        #region Fields

        /// <summary>
        /// Used for interactio with file system.
        /// </summary>
        private readonly IoTools ioTools;

        #endregion

        #region Methods

        private void DisableSaving()
        {
            this.saveToolStripMenuItem.Enabled = false;
        }

        private void EnableSaving()
        {
            this.saveToolStripMenuItem.Enabled = true;
        }

        #endregion
    }
}
