namespace SimpleGrapicsEditor
{
    using System;    
    using System.Linq;    
    using System.Text;
    using System.Windows.Forms;    
    using FunctionalPluginBase;
    using Management;
    using ShapePluginBase;
    
    /// <summary>
    /// Main window of the software.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields
        
        /// <summary>
        /// Used for interaction with file system.
        /// </summary>
        private readonly FileManager fileManager;
       
        /// <summary>
        /// Used to store imported plugins of all types.
        /// </summary>
        private readonly PluginContainer pluginContainer = PluginContainer.GetInstance;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class and sets some
        /// necessary parameters inside.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
            
            this.fileManager = new FileManager(this.ShapeListBox);
            
            this.saveToolStripMenuItem.Enabled = false;

            PluginManager.ImportPlugins(this.pluginContainer, this.ImportPluginsPostProcessing);
        }

        #endregion

        #region Methods subscribed to Events

        #region MainForm

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            this.fileManager.Exit(out bool stopClosing);

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

        #region MenuStrip

        private void NewToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.fileManager.New(out bool successfully);
            if (successfully)
            {
                this.DisableSaving();
            }
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            StringBuilder additionalSupportedFormats = new StringBuilder();
            foreach (Lazy<IFunctionalPlugin, IFunctionalPluginData> plugin in this.pluginContainer.ImportedFunctionalPlugins)
            {
                additionalSupportedFormats.Append(plugin.Value.SupportedFormats);
                additionalSupportedFormats.Append('|');
            }

            if (additionalSupportedFormats.Length > 0)
            {
                additionalSupportedFormats.Remove(additionalSupportedFormats.Length - 1, 1);
            }            

            this.fileManager.Open(out bool successfully, additionalSupportedFormats.ToString());
            if (successfully)
            {
                this.DisableSaving();
            }
        }

        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.fileManager.Save(out bool successfully);
            if (successfully)
            {
                this.DisableSaving();
            }
        }

        private void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.fileManager.SaveAs(out bool successfully);
            if (successfully)
            {
                this.DisableSaving();
            }
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReloadPluginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PluginManager.RefreshPlugins(this.pluginContainer, this.RefreshPluginsPostProcessing);
        }

        #endregion

        #region Buttons        

        private void AddShapeButton_Click(object sender, EventArgs e)
        {
            if (this.ImportedShapesComboBox.SelectedIndex >= 0)
            {
                foreach (Lazy<AbstractShape, IShapeData> shape in this.pluginContainer.ImportedShapePlugins)
                {
                    if (shape.Metadata.Name == this.ImportedShapesComboBox.SelectedItem.ToString())
                    {                        
                        dynamic shapeToAdd = shape.Value.Clone();
                        ShapeEditForm f = new ShapeEditForm(shapeToAdd);
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            this.ShapeListBox.Items.Add(shapeToAdd);
                            this.EnableSaving();                            
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
                }
            }
        }

        private void DeleteShapeButtonClick(object sender, EventArgs e)
        {
            if (this.ShapeListBox.SelectedItem != null)
            {
                this.ShapeListBox.Items.RemoveAt(this.ShapeListBox.SelectedIndex);
                this.EnableSaving();                
            }
        }

        private void DrawListButtonClick(object sender, EventArgs e)
        {
            DrawingManager.DrawAll(DrawingManager.GetShapes(this.ShapeListBox), this.DrawingFieldPictureBox);            
        }

        #endregion

        private void ClearCanvasButtonClick(object sender, EventArgs e)
        {
            DrawingManager.ClearPictureBox(this.DrawingFieldPictureBox);
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
            this.fileManager.ThereIsChanges = false;
        }

        /// <summary>
        /// Makes Save (not SaveAs) buttons enabled.
        /// </summary>
        private void EnableSaving()
        {
            this.saveToolStripMenuItem.Enabled = true;
            this.fileManager.ThereIsChanges = true;
        }

        /// <summary>
        /// Make necessary work after <see cref="AbstractShape"/> objects was imported.
        /// </summary>
        private void ImportPluginsPostProcessing()
        {
            this.AddShapeNamesToComboBox();
            this.SetNonEmptyItemInComboBox();
            //this.AddTypesToJsonKnownTypes();            
            SerializationManager.RefreshJsonKnownTypes(this.pluginContainer.ImportedShapePlugins);

            this.AddShapePluginsToMenu();

            this.AddFunctionalPluginsToMenu();

            this.SubscribeToFunctionalPlugins();
        }

        private void SubscribeToFunctionalPlugins()
        {
            foreach (var functionalPlugin in this.pluginContainer.ImportedFunctionalPlugins)
            {
                SerializationManager.BeforeDeserialization += functionalPlugin.Value.BeforeDeserialization;
            }
        }

        private void UnsubscribeFromFunctionalPlugins()
        {
            
        }

        private void AddShapePluginsToMenu()
        {
            if (this.pluginContainer.ImportedShapePlugins.Any())
            {
                var pluginsShapes = new ToolStripMenuItem("Shapes") { Name = "Shapes" };

                this.pluginsToolStripMenuItem.DropDownItems.Add(pluginsShapes);                

                foreach (Lazy<AbstractShape, IShapeData> shape in this.pluginContainer.ImportedShapePlugins)
                {
                    var concreteShape = new ToolStripMenuItem(shape.Metadata.Name) { Name = shape.Metadata.Name };

                    pluginsShapes.DropDownItems.Add(concreteShape);
                }

                // test.Checked = true;
            }
        }

        private void AddFunctionalPluginsToMenu()
        {
            if (this.pluginContainer.ImportedFunctionalPlugins.Any())
            {
                var pluginsFunctional = new ToolStripMenuItem("Functional") { Name = "Functional" };

                this.pluginsToolStripMenuItem.DropDownItems.Add(pluginsFunctional);

                foreach (Lazy<IFunctionalPlugin, IFunctionalPluginData> funcPlugin in this.pluginContainer.ImportedFunctionalPlugins)
                {
                    var concretePlugin = new ToolStripMenuItem(funcPlugin.Metadata.Name) { Name = funcPlugin.Metadata.Name };

                    pluginsFunctional.DropDownItems.Add(concretePlugin);
                }

                // test.Checked = true;
            }
        }

        /// <summary>
        /// Adds names of imported <see cref="AbstractShape"/> objects to ComboBox.
        /// </summary>
        private void AddShapeNamesToComboBox()
        {
            foreach (Lazy<AbstractShape, IShapeData> shape in this.pluginContainer.ImportedShapePlugins)
            {
                this.ImportedShapesComboBox.Items.Add(shape.Metadata.Name);                
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
            this.ClearMenu();
            this.UnsubscribeFromFunctionalPlugins();

            // ImportedShapesComboBox.SelectedIndex automatically sets to -1
            // after clearing all its items.
            this.AddShapeNamesToComboBox();

            // If not make sorting, shape plugins that was disables and then enabled
            // will be at the end of drow down list.
            this.SortImportedShapesComboBox();            
            SerializationManager.RefreshJsonKnownTypes(this.pluginContainer.ImportedShapePlugins);
            this.SetNonEmptyItemInComboBox();

            this.AddShapePluginsToMenu();
            this.AddFunctionalPluginsToMenu();

            this.SubscribeToFunctionalPlugins();
        }

        private void ClearMenu()
        {
            while (this.pluginsToolStripMenuItem.DropDownItems.Count > 2)
            {
                this.pluginsToolStripMenuItem.DropDownItems.RemoveAt(2);
            }            
        }

        private void ClearImportedShapesComboBox()
        {
            this.ImportedShapesComboBox.Items.Clear();
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

        private void DeleteAllButton_Click(object sender, EventArgs e)
        {
            if (this.ShapeListBox.Items.Count > 0)
            {
                this.ShapeListBox.Items.Clear();
                this.EnableSaving();
            }
        }
    }
}
