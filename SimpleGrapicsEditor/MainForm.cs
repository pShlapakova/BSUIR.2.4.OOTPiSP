namespace SimpleGrapicsEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using SimpleGrapicsEditor.Shapes;
    using SimpleGrapicsEditor.Tools;    

    /// <summary>
    /// Main window of the software.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields

        /// <summary>
        /// Used for interaction with file system.
        /// </summary>
        private readonly IoTools ioTools;

        /// <summary>
        /// Used for importing Shape plugins.
        /// </summary>
        private readonly ShapePluginContainer shapePluginContainer = new ShapePluginContainer();

        #endregion

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
            
            ShapePluginManager.ImportPlugins(this.shapePluginContainer, this.ImportPluginsPostProcessing);

            if (this.shapePluginContainer.ImportedShapes.Any())
            {
                var pluginsShapes = new ToolStripMenuItem("Shapes") { Name = "Shapes" };


                this.pluginsToolStripMenuItem.DropDownItems.Add(pluginsShapes);

                foreach (Lazy<AbstractShape, IShapeData> shape in this.shapePluginContainer.ImportedShapes)
                {
                    var concreteShape = new ToolStripMenuItem(shape.Metadata.Name) { Name = shape.Metadata.Name };

                    pluginsShapes.DropDownItems.Add(concreteShape);
                }

                // test.Checked = true;
            }

            

            

        }

        #endregion
                        
        #region Methods subscribed to Events

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

        //private void RefreshPluginsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ShapePluginManager.RefreshPlugins(this.shapePluginContainer, this.RefreshPluginsPostProcessing);            
        //}

        #endregion

        #region Buttons        

        private void AddShapeButton_Click(object sender, EventArgs e)
        {
            if (this.ImportedShapesComboBox.SelectedIndex >= 0)
            {
                foreach (Lazy<AbstractShape, IShapeData> shape in this.shapePluginContainer.ImportedShapes)
                {
                    if (shape.Metadata.Name == this.ImportedShapesComboBox.SelectedItem.ToString())
                    {                        
                        dynamic shapeToAdd = shape.Value.Clone();
                        ShapeEditForm f = new ShapeEditForm(shapeToAdd);
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            this.ShapeListBox.Items.Add(shapeToAdd);
                            this.EnableSaving();
                            this.ioTools.ThereIsChanges = true;
                        }
                    }
                }
            }
        }

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

            AbstractShape[] bufShapeArray = new AbstractShape[this.ShapeListBox.Items.Count];
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
                foreach (AbstractShape shape in shapeListBox.Items)
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
        
        #region Methods

        /// <summary>
        /// Makes Save (not SaveAs) buttons disabled.
        /// </summary>
        private void DisableSaving()
        {
            this.saveToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Makes Save (not SaveAs) buttons enabled.
        /// </summary>
        private void EnableSaving()
        {
            this.saveToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Make necessary work after <see cref="AbstractShape"/> objects was imported.
        /// </summary>
        private void ImportPluginsPostProcessing()
        {
            this.AddShapeNamesToComboBox();
            this.AddTypesToJsonKnownTypes();
            this.SetNonEmptyItemInComboBox();
        }

        /// <summary>
        /// Adds names of imported <see cref="AbstractShape"/> objects to ComboBox.
        /// </summary>
        private void AddShapeNamesToComboBox()
        {
            foreach (Lazy<AbstractShape, IShapeData> shape in this.shapePluginContainer.ImportedShapes)
            {
                this.ImportedShapesComboBox.Items.Add(shape.Metadata.Name);                
            }            
        }

        /// <summary>
        /// Add types of imported <see cref="AbstractShape"/> objects to list of
        /// deserializer's known types.
        /// </summary>
        private void AddTypesToJsonKnownTypes()
        {
            foreach (Lazy<AbstractShape, IShapeData> shape in this.shapePluginContainer.ImportedShapes)
            {
                this.ioTools.JsonKnownTypesList.Add(shape.Value.GetType());
            }
        }

        /// <summary>
        /// If at least one <see cref="AbstractShape"/> object was imported,
        /// set SelectedIndex of <see cref="MainForm.ImportedShapesComboBox"/> to 0.
        /// </summary>
        private void SetNonEmptyItemInComboBox()
        {
            if (this.ImportedShapesComboBox.Items.Count > 0)
            {
                this.ImportedShapesComboBox.SelectedIndex = 0;
            }
        }

        private void RefreshPluginsPostProcessing()
        {
            this.ClearImportedShapesComboBox();
            this.ClearJsonKnownTypes();
            // ImportedShapesComboBox.SelectedIndex automatically sets to -1
            // after clearing all its items.


            this.AddShapeNamesToComboBox();

            // If not make sorting, shape plugins that was disables and then enabled
            // will be at the end of drow down list.
            this.SortImportedShapesComboBox();
            this.AddTypesToJsonKnownTypes();
            this.SetNonEmptyItemInComboBox();
        }

        private void ClearImportedShapesComboBox()
        {
            this.ImportedShapesComboBox.Items.Clear();
        }

        private void ClearJsonKnownTypes()
        {            
            // Delete all known types amongest AbstractShape Type.                        
            this.ioTools.JsonKnownTypesList.Clear();
            this.ioTools.JsonKnownTypesList.Add(typeof(AbstractShape));
        }

        private void SortImportedShapesComboBox()
        {
            string[] buffer = new string[this.ImportedShapesComboBox.Items.Count];

            // Use FOR, because ComboBox.Items.CopyTo(...) co-variant array conversion
            // may cause run-time exception on write operation.
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = this.ImportedShapesComboBox.Items[i].ToString();
            }

            Array.Sort(buffer);

            this.ImportedShapesComboBox.Items.Clear();

            // Use FOR, because ComboBox.Items.AddRange(...) co-variant array conversion
            // may cause run-time exception on write operation.
            foreach (string item in buffer)
            {
                this.ImportedShapesComboBox.Items.Add(item);
            }            
        }

        #endregion

    }
}
