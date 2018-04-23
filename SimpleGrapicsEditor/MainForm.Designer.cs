namespace SimpleGrapicsEditor
{
    using System.ComponentModel;
    using System.Windows.Forms;

    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.DrawingFieldPictureBox = new System.Windows.Forms.PictureBox();
            this.ClearCanvasButton = new System.Windows.Forms.Button();
            this.CurrentMousePositionTextBox = new System.Windows.Forms.TextBox();
            this.ShapeListBox = new System.Windows.Forms.ListBox();
            this.EditShapeButton = new System.Windows.Forms.Button();
            this.SortListButton = new System.Windows.Forms.Button();
            this.DrawListButton = new System.Windows.Forms.Button();
            this.DeleteShapeButton = new System.Windows.Forms.Button();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShapeListBoxContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ClearShapeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportedShapesComboBox = new System.Windows.Forms.ComboBox();
            this.AddShapeButton = new System.Windows.Forms.Button();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingFieldPictureBox)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.ShapeListBoxContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // DrawingFieldPictureBox
            // 
            this.DrawingFieldPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawingFieldPictureBox.BackColor = System.Drawing.Color.White;
            this.DrawingFieldPictureBox.Location = new System.Drawing.Point(0, 27);
            this.DrawingFieldPictureBox.MinimumSize = new System.Drawing.Size(200, 150);
            this.DrawingFieldPictureBox.Name = "DrawingFieldPictureBox";
            this.DrawingFieldPictureBox.Size = new System.Drawing.Size(665, 551);
            this.DrawingFieldPictureBox.TabIndex = 0;
            this.DrawingFieldPictureBox.TabStop = false;
            this.DrawingFieldPictureBox.MouseLeave += new System.EventHandler(this.DrawingFieldPictureBoxMouseLeave);
            this.DrawingFieldPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingFieldPictureBoxMouseMove);
            // 
            // ClearCanvasButton
            // 
            this.ClearCanvasButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearCanvasButton.Location = new System.Drawing.Point(839, 549);
            this.ClearCanvasButton.Name = "ClearCanvasButton";
            this.ClearCanvasButton.Size = new System.Drawing.Size(75, 23);
            this.ClearCanvasButton.TabIndex = 2;
            this.ClearCanvasButton.Text = "Clear";
            this.ClearCanvasButton.UseVisualStyleBackColor = true;
            this.ClearCanvasButton.Click += new System.EventHandler(this.ClearCanvasButtonClick);
            // 
            // CurrentMousePositionTextBox
            // 
            this.CurrentMousePositionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentMousePositionTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.CurrentMousePositionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CurrentMousePositionTextBox.Location = new System.Drawing.Point(677, 554);
            this.CurrentMousePositionTextBox.Name = "CurrentMousePositionTextBox";
            this.CurrentMousePositionTextBox.Size = new System.Drawing.Size(75, 14);
            this.CurrentMousePositionTextBox.TabIndex = 3;
            // 
            // ShapeListBox
            // 
            this.ShapeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShapeListBox.FormattingEnabled = true;
            this.ShapeListBox.HorizontalScrollbar = true;
            this.ShapeListBox.Location = new System.Drawing.Point(677, 92);
            this.ShapeListBox.Name = "ShapeListBox";
            this.ShapeListBox.Size = new System.Drawing.Size(230, 420);
            this.ShapeListBox.TabIndex = 13;
            // 
            // EditShapeButton
            // 
            this.EditShapeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditShapeButton.Location = new System.Drawing.Point(677, 520);
            this.EditShapeButton.Name = "EditShapeButton";
            this.EditShapeButton.Size = new System.Drawing.Size(75, 23);
            this.EditShapeButton.TabIndex = 14;
            this.EditShapeButton.Text = "Edit";
            this.EditShapeButton.UseVisualStyleBackColor = true;
            this.EditShapeButton.Click += new System.EventHandler(this.EditShapeButtonClick);
            // 
            // SortListButton
            // 
            this.SortListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SortListButton.Location = new System.Drawing.Point(839, 520);
            this.SortListButton.Name = "SortListButton";
            this.SortListButton.Size = new System.Drawing.Size(75, 23);
            this.SortListButton.TabIndex = 16;
            this.SortListButton.Text = "Sort";
            this.SortListButton.UseVisualStyleBackColor = true;
            this.SortListButton.Click += new System.EventHandler(this.SortListButtonClick);
            // 
            // DrawListButton
            // 
            this.DrawListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawListButton.Location = new System.Drawing.Point(758, 549);
            this.DrawListButton.Name = "DrawListButton";
            this.DrawListButton.Size = new System.Drawing.Size(75, 23);
            this.DrawListButton.TabIndex = 17;
            this.DrawListButton.Text = "Draw";
            this.DrawListButton.UseVisualStyleBackColor = true;
            this.DrawListButton.Click += new System.EventHandler(this.DrawListButtonClick);
            // 
            // DeleteShapeButton
            // 
            this.DeleteShapeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteShapeButton.Location = new System.Drawing.Point(758, 520);
            this.DeleteShapeButton.Name = "DeleteShapeButton";
            this.DeleteShapeButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteShapeButton.TabIndex = 18;
            this.DeleteShapeButton.Text = "Delete";
            this.DeleteShapeButton.UseVisualStyleBackColor = true;
            this.DeleteShapeButton.Click += new System.EventHandler(this.DeleteShapeButtonClick);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.pluginsToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(919, 24);
            this.MenuStrip.TabIndex = 19;
            this.MenuStrip.Text = "menuStrip1";            
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItemClick);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(137, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // ShapeListBoxContextMenuStrip
            // 
            this.ShapeListBoxContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearShapeListToolStripMenuItem});
            this.ShapeListBoxContextMenuStrip.Name = "ShapeListBoxContextMenuStrip";
            this.ShapeListBoxContextMenuStrip.Size = new System.Drawing.Size(100, 26);
            // 
            // ClearShapeListToolStripMenuItem
            // 
            this.ClearShapeListToolStripMenuItem.Name = "ClearShapeListToolStripMenuItem";
            this.ClearShapeListToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.ClearShapeListToolStripMenuItem.Text = "Clear";
            // 
            // ImportedShapesComboBox
            // 
            this.ImportedShapesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ImportedShapesComboBox.FormattingEnabled = true;
            this.ImportedShapesComboBox.Location = new System.Drawing.Point(677, 27);
            this.ImportedShapesComboBox.Name = "ImportedShapesComboBox";
            this.ImportedShapesComboBox.Size = new System.Drawing.Size(230, 21);
            this.ImportedShapesComboBox.TabIndex = 20;
            // 
            // AddShapeButton
            // 
            this.AddShapeButton.Location = new System.Drawing.Point(758, 59);
            this.AddShapeButton.Name = "AddShapeButton";
            this.AddShapeButton.Size = new System.Drawing.Size(75, 23);
            this.AddShapeButton.TabIndex = 21;
            this.AddShapeButton.Text = "Add";
            this.AddShapeButton.UseVisualStyleBackColor = true;
            this.AddShapeButton.Click += new System.EventHandler(this.AddShapeButton_Click);
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.pluginsToolStripMenuItem.Text = "Plugins";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 578);
            this.Controls.Add(this.AddShapeButton);
            this.Controls.Add(this.ImportedShapesComboBox);
            this.Controls.Add(this.DeleteShapeButton);
            this.Controls.Add(this.DrawListButton);
            this.Controls.Add(this.SortListButton);
            this.Controls.Add(this.EditShapeButton);
            this.Controls.Add(this.ShapeListBox);
            this.Controls.Add(this.CurrentMousePositionTextBox);
            this.Controls.Add(this.ClearCanvasButton);
            this.Controls.Add(this.DrawingFieldPictureBox);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(640, 460);
            this.Name = "MainForm";
            this.Text = "Simple Graphics Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DrawingFieldPictureBox)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ShapeListBoxContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox DrawingFieldPictureBox;
        private Button ClearCanvasButton;
        private TextBox CurrentMousePositionTextBox;
        private ListBox ShapeListBox;
        private Button EditShapeButton;
        private Button SortListButton;
        private Button DrawListButton;
        private Button DeleteShapeButton;
        private MenuStrip MenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ContextMenuStrip ShapeListBoxContextMenuStrip;
        private ToolStripMenuItem ClearShapeListToolStripMenuItem;
        private ComboBox ImportedShapesComboBox;
        private Button AddShapeButton;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem pluginsToolStripMenuItem;
    }
}

