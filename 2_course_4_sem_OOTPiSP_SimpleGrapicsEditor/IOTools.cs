namespace _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Windows.Forms;
    using _2_course_4_sem_OOTPiSP_SimpleGrapicsEditor.Shapes;

    public class IoTools
    {
        #region Constructors

        public IoTools(ListBox shapeListBox)
        {
            this.ShapeListBox = shapeListBox;
        }

        #endregion

        #region Properties

        public ListBox ShapeListBox { get; }

        private string OpenedFilePath { get; set; } = string.Empty;

        public bool ThereIsChanges { get; set; } = false;

        #endregion

        #region Fields

        private readonly IEnumerable<Type> jsonKnownTypes = new List<Type> {
            typeof(Shape),
            typeof(Arc),
            typeof(Circle),
            typeof(Ellipse),
            typeof(Line),
            typeof(Pie),
            typeof(Shapes.Rectangle),
            typeof(Square),
            typeof(Star) };

        #endregion

        #region Methods

        #region Public IO methods

        public void New(out bool successfully)
        {
            successfully = false;

            if (this.ThereIsChanges)
            {
                this.SaveProposal(out successfully);
                if (successfully)
                {
                    this.Clearing();
                }
            }
            else
            {
                this.Clearing();
                successfully = true;
            }
        }

        public void Open(out bool successfully)
        {
            successfully = false;

            if (this.ThereIsChanges)
            {
                this.SaveProposal(out successfully);
                if (successfully)
                {
                    // Clearing();
                    Opening();
                }
            }
            else
            {
                // Clearing();
                Opening();
                successfully = true;
            }            
        }

        public void Save(out bool successfully)
        {
            Saving(out successfully);
        }

        public void SaveAs(out bool successfully)
        {
            SavingAs(out successfully);
        }

        public void Exit(out bool stopClosing)
        {
            stopClosing = false;

            if (this.ThereIsChanges)
            {
                this.SaveProposal(out bool finishedSuccessfully);
                if (!finishedSuccessfully)
                {
                    stopClosing = true;
                }
            }
        }

        #endregion

        #region Private IO methods (utils)

        private void Opening()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
                                                {
                                                    Filter = "JSON file|*.json",
                                                    Title = "Open"
                                                };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.Clearing();
                this.Deserialization(openFileDialog.FileName);
                this.OpenedFilePath = Path.GetFullPath(openFileDialog.FileName);
            }
        }

        private void Saving(out bool finishedSuccessfully)
        {
            if (this.OpenedFilePath == string.Empty)
            {
                this.SavingAs(out finishedSuccessfully);
                return;
            }

            finishedSuccessfully = false;

            try
            {
                this.Serialization(this.OpenedFilePath);
                finishedSuccessfully = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SavingAs(out bool finishedSuccessfully)
        {
            finishedSuccessfully = false;

            SaveFileDialog saveFile = new SaveFileDialog
                                          {
                                              Filter = "JSON file|*.json",
                                              Title = "Save As"
                                          };

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                this.Serialization(saveFile.FileName);
                finishedSuccessfully = true;
                this.OpenedFilePath = Path.GetFullPath(saveFile.FileName);
            }
        }

        private void SaveProposal(out bool finishedSuccessfully)
        {
            finishedSuccessfully = false;

            DialogResult saveProposal = MessageBox.Show(
                this.OpenedFilePath != string.Empty ? $"Save {Path.GetFileName(this.OpenedFilePath)} file?" : "Save file?",
                "Save",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
            if (saveProposal == DialogResult.Yes)
            {
                if (this.OpenedFilePath != string.Empty)
                {
                    this.Save(out finishedSuccessfully);
                }
                else
                {
                    this.SaveAs(out finishedSuccessfully);
                }
            }
            else if (saveProposal == DialogResult.No)
            {
                finishedSuccessfully = true;
            }

            // else (DialogResult.Cancel (Cancel Button or Exit Button)) - nothing to do                       
        }

        private void Clearing()
        {
            this.OpenedFilePath = string.Empty;
            this.ThereIsChanges = false;
            this.ShapeListBox.Items.Clear();
        }

        #endregion

        #region Private Serialization/Deserialization methods

        private void Serialization(string filePath)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(Shape[]), this.jsonKnownTypes);

            using (FileStream fs = new FileStream(Path.GetFullPath(filePath), FileMode.OpenOrCreate))
            {
                Shape[] buffer = new Shape[this.ShapeListBox.Items.Count];
                this.ShapeListBox.Items.CopyTo(buffer, 0);
                jsonSerializer.WriteObject(fs, buffer);
            }
        }

        private void Deserialization(string filePath)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(Shape[]), this.jsonKnownTypes);

            using (FileStream fs = new FileStream(Path.GetFullPath(filePath), FileMode.OpenOrCreate))
            {
                Shape[] buffer = (Shape[])jsonSerializer.ReadObject(fs);
                this.ShapeListBox.Items.AddRange(buffer);
            }
        }

        #endregion

        #endregion                                                                                                        
    }
}
