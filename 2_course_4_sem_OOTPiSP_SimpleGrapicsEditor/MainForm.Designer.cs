namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.DrawingFieldPictureBox = new System.Windows.Forms.PictureBox();
            this.ClearCanvasButton = new System.Windows.Forms.Button();
            this.CurrentMousePositionTextBox = new System.Windows.Forms.TextBox();
            this.AddLineButton = new System.Windows.Forms.Button();
            this.AddRectangleButton = new System.Windows.Forms.Button();
            this.AddEllipseButton = new System.Windows.Forms.Button();
            this.AddCircleButton = new System.Windows.Forms.Button();
            this.AddArcButton = new System.Windows.Forms.Button();
            this.AddPieButton = new System.Windows.Forms.Button();
            this.AddStarButton = new System.Windows.Forms.Button();
            this.AddSquareButton = new System.Windows.Forms.Button();
            this.ShapeListBox = new System.Windows.Forms.ListBox();
            this.EditShapeButton = new System.Windows.Forms.Button();
            this.SortListButton = new System.Windows.Forms.Button();
            this.DrawListButton = new System.Windows.Forms.Button();
            this.DeleteShapeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingFieldPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawingFieldPictureBox
            // 
            this.DrawingFieldPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawingFieldPictureBox.BackColor = System.Drawing.Color.White;
            this.DrawingFieldPictureBox.Location = new System.Drawing.Point(0, 0);
            this.DrawingFieldPictureBox.MinimumSize = new System.Drawing.Size(200, 150);
            this.DrawingFieldPictureBox.Name = "DrawingFieldPictureBox";
            this.DrawingFieldPictureBox.Size = new System.Drawing.Size(665, 578);
            this.DrawingFieldPictureBox.TabIndex = 0;
            this.DrawingFieldPictureBox.TabStop = false;
            this.DrawingFieldPictureBox.MouseLeave += new System.EventHandler(this.DrawingFieldPictureBox_MouseLeave);
            this.DrawingFieldPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingFieldPictureBox_MouseMove);
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
            this.ClearCanvasButton.Click += new System.EventHandler(this.ClearCanvasButton_Click);
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
            // AddLineButton
            // 
            this.AddLineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddLineButton.Image = ((System.Drawing.Image)(resources.GetObject("AddLineButton.Image")));
            this.AddLineButton.Location = new System.Drawing.Point(677, 9);
            this.AddLineButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddLineButton.Name = "AddLineButton";
            this.AddLineButton.Size = new System.Drawing.Size(30, 30);
            this.AddLineButton.TabIndex = 4;
            this.AddLineButton.UseVisualStyleBackColor = true;
            this.AddLineButton.Click += new System.EventHandler(this.AddLineButton_Click);
            // 
            // AddRectangleButton
            // 
            this.AddRectangleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddRectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("AddRectangleButton.Image")));
            this.AddRectangleButton.Location = new System.Drawing.Point(717, 9);
            this.AddRectangleButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddRectangleButton.Name = "AddRectangleButton";
            this.AddRectangleButton.Size = new System.Drawing.Size(30, 30);
            this.AddRectangleButton.TabIndex = 5;
            this.AddRectangleButton.UseVisualStyleBackColor = true;
            this.AddRectangleButton.Click += new System.EventHandler(this.AddRectangleButton_Click);
            // 
            // AddEllipseButton
            // 
            this.AddEllipseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddEllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("AddEllipseButton.Image")));
            this.AddEllipseButton.Location = new System.Drawing.Point(797, 9);
            this.AddEllipseButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddEllipseButton.Name = "AddEllipseButton";
            this.AddEllipseButton.Size = new System.Drawing.Size(30, 30);
            this.AddEllipseButton.TabIndex = 6;
            this.AddEllipseButton.UseVisualStyleBackColor = true;
            this.AddEllipseButton.Click += new System.EventHandler(this.AddEllipseButton_Click);
            // 
            // AddCircleButton
            // 
            this.AddCircleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddCircleButton.Image = ((System.Drawing.Image)(resources.GetObject("AddCircleButton.Image")));
            this.AddCircleButton.Location = new System.Drawing.Point(837, 9);
            this.AddCircleButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddCircleButton.Name = "AddCircleButton";
            this.AddCircleButton.Size = new System.Drawing.Size(30, 30);
            this.AddCircleButton.TabIndex = 7;
            this.AddCircleButton.UseVisualStyleBackColor = true;
            this.AddCircleButton.Click += new System.EventHandler(this.AddCircleButton_Click);
            // 
            // AddArcButton
            // 
            this.AddArcButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddArcButton.Image = ((System.Drawing.Image)(resources.GetObject("AddArcButton.Image")));
            this.AddArcButton.Location = new System.Drawing.Point(677, 49);
            this.AddArcButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddArcButton.Name = "AddArcButton";
            this.AddArcButton.Size = new System.Drawing.Size(30, 30);
            this.AddArcButton.TabIndex = 8;
            this.AddArcButton.UseVisualStyleBackColor = true;
            this.AddArcButton.Click += new System.EventHandler(this.AddArcButton_Click);
            // 
            // AddPieButton
            // 
            this.AddPieButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddPieButton.Image = ((System.Drawing.Image)(resources.GetObject("AddPieButton.Image")));
            this.AddPieButton.Location = new System.Drawing.Point(717, 49);
            this.AddPieButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddPieButton.Name = "AddPieButton";
            this.AddPieButton.Size = new System.Drawing.Size(30, 30);
            this.AddPieButton.TabIndex = 9;
            this.AddPieButton.UseVisualStyleBackColor = true;
            this.AddPieButton.Click += new System.EventHandler(this.AddPieButton_Click);
            // 
            // AddStarButton
            // 
            this.AddStarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddStarButton.Image = ((System.Drawing.Image)(resources.GetObject("AddStarButton.Image")));
            this.AddStarButton.Location = new System.Drawing.Point(877, 9);
            this.AddStarButton.Name = "AddStarButton";
            this.AddStarButton.Size = new System.Drawing.Size(30, 30);
            this.AddStarButton.TabIndex = 11;
            this.AddStarButton.UseVisualStyleBackColor = true;
            this.AddStarButton.Click += new System.EventHandler(this.AddStarButton_Click);
            // 
            // AddSquareButton
            // 
            this.AddSquareButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddSquareButton.Image = ((System.Drawing.Image)(resources.GetObject("AddSquareButton.Image")));
            this.AddSquareButton.Location = new System.Drawing.Point(757, 9);
            this.AddSquareButton.Name = "AddSquareButton";
            this.AddSquareButton.Size = new System.Drawing.Size(30, 30);
            this.AddSquareButton.TabIndex = 12;
            this.AddSquareButton.UseVisualStyleBackColor = true;
            this.AddSquareButton.Click += new System.EventHandler(this.AddSquareButton_Click);
            // 
            // ShapeListBox
            // 
            this.ShapeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShapeListBox.FormattingEnabled = true;
            this.ShapeListBox.HorizontalScrollbar = true;
            this.ShapeListBox.Location = new System.Drawing.Point(677, 91);
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
            this.EditShapeButton.Click += new System.EventHandler(this.EditShapeButton_Click);
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
            this.SortListButton.Click += new System.EventHandler(this.SortListButton_Click);
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
            this.DrawListButton.Click += new System.EventHandler(this.DrawListButton_Click);
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
            this.DeleteShapeButton.Click += new System.EventHandler(this.DeleteShapeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 578);
            this.Controls.Add(this.DeleteShapeButton);
            this.Controls.Add(this.DrawListButton);
            this.Controls.Add(this.SortListButton);
            this.Controls.Add(this.EditShapeButton);
            this.Controls.Add(this.ShapeListBox);
            this.Controls.Add(this.AddSquareButton);
            this.Controls.Add(this.AddStarButton);
            this.Controls.Add(this.AddPieButton);
            this.Controls.Add(this.AddArcButton);
            this.Controls.Add(this.AddCircleButton);
            this.Controls.Add(this.AddEllipseButton);
            this.Controls.Add(this.AddRectangleButton);
            this.Controls.Add(this.AddLineButton);
            this.Controls.Add(this.CurrentMousePositionTextBox);
            this.Controls.Add(this.ClearCanvasButton);
            this.Controls.Add(this.DrawingFieldPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 460);
            this.Name = "MainForm";
            this.Text = "Simple Graphics Editor";
            ((System.ComponentModel.ISupportInitialize)(this.DrawingFieldPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DrawingFieldPictureBox;
        private System.Windows.Forms.Button ClearCanvasButton;
        private System.Windows.Forms.TextBox CurrentMousePositionTextBox;
        private System.Windows.Forms.Button AddLineButton;
        private System.Windows.Forms.Button AddRectangleButton;
        private System.Windows.Forms.Button AddEllipseButton;
        private System.Windows.Forms.Button AddCircleButton;
        private System.Windows.Forms.Button AddArcButton;
        private System.Windows.Forms.Button AddPieButton;
        private System.Windows.Forms.Button AddStarButton;
        private System.Windows.Forms.Button AddSquareButton;
        private System.Windows.Forms.ListBox ShapeListBox;
        private System.Windows.Forms.Button EditShapeButton;
        private System.Windows.Forms.Button SortListButton;
        private System.Windows.Forms.Button DrawListButton;
        private System.Windows.Forms.Button DeleteShapeButton;
    }
}

