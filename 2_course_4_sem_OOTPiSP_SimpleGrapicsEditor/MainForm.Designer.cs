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
            this.ClearButton = new System.Windows.Forms.Button();
            this.CurrentMousePositionTextBox = new System.Windows.Forms.TextBox();
            this.DrawLineButton = new System.Windows.Forms.Button();
            this.DrawRectangleButton = new System.Windows.Forms.Button();
            this.DrawEllipseButton = new System.Windows.Forms.Button();
            this.DrawCircleButton = new System.Windows.Forms.Button();
            this.DrawArcButton = new System.Windows.Forms.Button();
            this.DrawPieButton = new System.Windows.Forms.Button();
            this.DrawStarButton = new System.Windows.Forms.Button();
            this.DrawSquareButton = new System.Windows.Forms.Button();
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
            this.DrawingFieldPictureBox.Size = new System.Drawing.Size(820, 578);
            this.DrawingFieldPictureBox.TabIndex = 0;
            this.DrawingFieldPictureBox.TabStop = false;            
            this.DrawingFieldPictureBox.MouseLeave += new System.EventHandler(this.DrawingFieldPictureBox_MouseLeave);
            this.DrawingFieldPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingFieldPictureBox_MouseMove);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Location = new System.Drawing.Point(832, 535);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 2;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // CurrentMousePositionTextBox
            // 
            this.CurrentMousePositionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentMousePositionTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.CurrentMousePositionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CurrentMousePositionTextBox.Location = new System.Drawing.Point(832, 564);
            this.CurrentMousePositionTextBox.Name = "CurrentMousePositionTextBox";
            this.CurrentMousePositionTextBox.Size = new System.Drawing.Size(75, 14);
            this.CurrentMousePositionTextBox.TabIndex = 3;
            // 
            // DrawLineButton
            // 
            this.DrawLineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawLineButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawLineButton.Image")));
            this.DrawLineButton.Location = new System.Drawing.Point(839, 9);
            this.DrawLineButton.Margin = new System.Windows.Forms.Padding(0);
            this.DrawLineButton.Name = "DrawLineButton";
            this.DrawLineButton.Size = new System.Drawing.Size(30, 30);
            this.DrawLineButton.TabIndex = 4;
            this.DrawLineButton.UseVisualStyleBackColor = true;
            this.DrawLineButton.Click += new System.EventHandler(this.DrawLineButton_Click);
            // 
            // DrawRectangleButton
            // 
            this.DrawRectangleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawRectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawRectangleButton.Image")));
            this.DrawRectangleButton.Location = new System.Drawing.Point(869, 9);
            this.DrawRectangleButton.Margin = new System.Windows.Forms.Padding(0);
            this.DrawRectangleButton.Name = "DrawRectangleButton";
            this.DrawRectangleButton.Size = new System.Drawing.Size(30, 30);
            this.DrawRectangleButton.TabIndex = 5;
            this.DrawRectangleButton.UseVisualStyleBackColor = true;
            this.DrawRectangleButton.Click += new System.EventHandler(this.DrawRectangleButton_Click);
            // 
            // DrawEllipseButton
            // 
            this.DrawEllipseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawEllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawEllipseButton.Image")));
            this.DrawEllipseButton.Location = new System.Drawing.Point(839, 39);
            this.DrawEllipseButton.Margin = new System.Windows.Forms.Padding(0);
            this.DrawEllipseButton.Name = "DrawEllipseButton";
            this.DrawEllipseButton.Size = new System.Drawing.Size(30, 30);
            this.DrawEllipseButton.TabIndex = 6;
            this.DrawEllipseButton.UseVisualStyleBackColor = true;
            this.DrawEllipseButton.Click += new System.EventHandler(this.DrawEllipseButton_Click);
            // 
            // DrawCircleButton
            // 
            this.DrawCircleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawCircleButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawCircleButton.Image")));
            this.DrawCircleButton.Location = new System.Drawing.Point(869, 39);
            this.DrawCircleButton.Margin = new System.Windows.Forms.Padding(0);
            this.DrawCircleButton.Name = "DrawCircleButton";
            this.DrawCircleButton.Size = new System.Drawing.Size(30, 30);
            this.DrawCircleButton.TabIndex = 7;
            this.DrawCircleButton.UseVisualStyleBackColor = true;
            this.DrawCircleButton.Click += new System.EventHandler(this.DrawCircleButton_Click);
            // 
            // DrawArcButton
            // 
            this.DrawArcButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawArcButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawArcButton.Image")));
            this.DrawArcButton.Location = new System.Drawing.Point(839, 69);
            this.DrawArcButton.Margin = new System.Windows.Forms.Padding(0);
            this.DrawArcButton.Name = "DrawArcButton";
            this.DrawArcButton.Size = new System.Drawing.Size(30, 30);
            this.DrawArcButton.TabIndex = 8;
            this.DrawArcButton.UseVisualStyleBackColor = true;
            this.DrawArcButton.Click += new System.EventHandler(this.DrawArcButton_Click);
            // 
            // DrawPieButton
            // 
            this.DrawPieButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawPieButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawPieButton.Image")));
            this.DrawPieButton.Location = new System.Drawing.Point(869, 69);
            this.DrawPieButton.Margin = new System.Windows.Forms.Padding(0);
            this.DrawPieButton.Name = "DrawPieButton";
            this.DrawPieButton.Size = new System.Drawing.Size(30, 30);
            this.DrawPieButton.TabIndex = 9;
            this.DrawPieButton.UseVisualStyleBackColor = true;
            this.DrawPieButton.Click += new System.EventHandler(this.DrawPieButton_Click);
            // 
            // DrawStarButton
            // 
            this.DrawStarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawStarButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawStarButton.Image")));
            this.DrawStarButton.Location = new System.Drawing.Point(839, 99);
            this.DrawStarButton.Name = "DrawStarButton";
            this.DrawStarButton.Size = new System.Drawing.Size(30, 30);
            this.DrawStarButton.TabIndex = 11;
            this.DrawStarButton.UseVisualStyleBackColor = true;
            this.DrawStarButton.Click += new System.EventHandler(this.DrawStarButton_Click);
            // 
            // DrawSquareButton
            // 
            this.DrawSquareButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawSquareButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawSquareButton.Image")));
            this.DrawSquareButton.Location = new System.Drawing.Point(869, 99);
            this.DrawSquareButton.Name = "DrawSquareButton";
            this.DrawSquareButton.Size = new System.Drawing.Size(30, 30);
            this.DrawSquareButton.TabIndex = 12;
            this.DrawSquareButton.UseVisualStyleBackColor = true;
            this.DrawSquareButton.Click += new System.EventHandler(this.DrawSquareButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 578);
            this.Controls.Add(this.DrawSquareButton);
            this.Controls.Add(this.DrawStarButton);
            this.Controls.Add(this.DrawPieButton);
            this.Controls.Add(this.DrawArcButton);
            this.Controls.Add(this.DrawCircleButton);
            this.Controls.Add(this.DrawEllipseButton);
            this.Controls.Add(this.DrawRectangleButton);
            this.Controls.Add(this.DrawLineButton);
            this.Controls.Add(this.CurrentMousePositionTextBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.DrawingFieldPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(320, 230);
            this.Name = "MainForm";
            this.Text = "Simple Graphics Editor";            
            ((System.ComponentModel.ISupportInitialize)(this.DrawingFieldPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DrawingFieldPictureBox;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TextBox CurrentMousePositionTextBox;
        private System.Windows.Forms.Button DrawLineButton;
        private System.Windows.Forms.Button DrawRectangleButton;
        private System.Windows.Forms.Button DrawEllipseButton;
        private System.Windows.Forms.Button DrawCircleButton;
        private System.Windows.Forms.Button DrawArcButton;
        private System.Windows.Forms.Button DrawPieButton;
        private System.Windows.Forms.Button DrawStarButton;
        private System.Windows.Forms.Button DrawSquareButton;
    }
}

