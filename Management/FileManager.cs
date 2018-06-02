namespace Management
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using ShapePluginBase;

    /// <summary>
    /// Used to manage files.
    /// </summary>
    public class FileManager
    {
        //private static FileManager instance;

        //private FileManager()
        //{
        //}

        //public static FileManager GetInstance => instance ?? (instance = new FileManager());

        //public void Initialize(ListBox listBox)
        //{
        //    instance.shapeListBox = listBox;
        //}

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileManager"/> class.
        /// </summary>
        /// <param name="shapeListBox">The <see cref="ListBox"/> object to bind with the class instance.</param>
        public FileManager(ListBox shapeListBox)
        {
            this.shapeListBox = shapeListBox;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the <see cref="ListBox"/> object on the <see cref="Form"/>
        /// that binded with this class instance.
        /// </summary>
        private readonly ListBox shapeListBox;

        /// <summary>
        /// Gets the location of file currenty loaded.
        /// </summary>
        public string OpenedFilePath { get; private set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether there were any changes in <see cref="ListBox"/> objects.
        /// </summary>
        public bool ThereIsChanges { get; set; } = false;

        ///// <summary>
        ///// Gets or sets a value indicating whether user can or not save changes to the file.
        ///// </summary>
        //public bool RestrictSaving { get; set; } = false;

        #endregion        

        #region Methods

        #region Public

        /// <summary>
        /// Creates a new file to store <see cref="AbstractShape"/> objects.
        /// </summary>
        /// <param name="successfully">Indicating whether creating the file
        /// was successful or not.</param>
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

        /// <summary>
        /// Opens an existing file with <see cref="AbstractShape"/> objects.
        /// </summary>
        /// <param name="successfully">Indicating whether opening the file
        /// was successful or not.</param>
        /// <param name="additionalSupportedFormats">Patterns of additional
        /// supported formats.</param>
        public void Open(out bool successfully, string additionalSupportedFormats)
        {
            successfully = false;

            if (this.ThereIsChanges)
            {
                this.SaveProposal(out successfully);
                if (successfully)
                {
                    // Clearing();
                    this.Opening(additionalSupportedFormats);
                }
            }
            else
            {
                // Clearing();
                this.Opening(additionalSupportedFormats);
                successfully = true;
            }
        }

        /// <summary>
        /// Saves changes to the currently opened file for storing <see cref="AbstractShape"/> objects.
        /// </summary>
        /// <param name="successfully">Indicating whether saving changes to the file
        /// was successful or not.</param>
        public void Save(out bool successfully)
        {
            this.Saving(out successfully);
        }

        /// <summary>
        /// Creates a new file to store <see cref="AbstractShape"/> objects and saves current objects list to this file.
        /// </summary>
        /// <param name="successfully">Indicating whether creating a new file and saving objects to it
        /// was successful or not.</param>
        public void SaveAs(out bool successfully)
        {
            this.SavingAs(out successfully);
        }

        /// <summary>
        /// Used to call before exiting from the application.
        /// </summary>
        /// <param name="stopClosing">Indicating whether propose to save changes before
        /// exiting or not.</param>
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

        #region Private (Utils)

        /// <summary>
        /// Performs opening the file for <see cref="Open"/> method.
        /// </summary>
        /// <param name="additionalSupportedFormats">Pattern of additional
        /// supported formats.</param>
        private void Opening(string additionalSupportedFormats)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {                
                Filter = "JSON file|*.json" + (additionalSupportedFormats.Length > 0 ? '|' + additionalSupportedFormats : string.Empty),
                Title = "Open"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.Clearing();

                this.shapeListBox.Items.AddRange(SerializationManager.Deserialization(openFileDialog.FileName));                
                
                this.OpenedFilePath = Path.GetFullPath(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// Performs saving changes to the currently loaded file for <see cref="Save"/> method.
        /// </summary>
        /// <param name="finishedSuccessfully">Indicating whether opening the file
        /// was successful or not.</param>
        private void Saving(out bool finishedSuccessfully)
        {
            if (this.OpenedFilePath == string.Empty)
            {
                this.SavingAs(out finishedSuccessfully);
                return;
            }

            finishedSuccessfully = false;

            if (!this.OpenedFilePath.EndsWith(".json") && !this.OpenedFilePath.EndsWith(".JSON"))
            {                
                return;                
            }
            
            try
            {

                AbstractShape[] buffer = new AbstractShape[this.shapeListBox.Items.Count];
                this.shapeListBox.Items.CopyTo(buffer, 0);
                SerializationManager.Serialization(this.OpenedFilePath, buffer);
                //this.Serialization(this.OpenedFilePath);


                finishedSuccessfully = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Performs creating a new file and saving objects to it for <see cref="SaveAs"/> method.
        /// </summary>
        /// <param name="finishedSuccessfully">Indicating whether creating a new file and saving objects to it
        /// was successful or not.</param>
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

                AbstractShape[] buffer = new AbstractShape[this.shapeListBox.Items.Count];
                this.shapeListBox.Items.CopyTo(buffer, 0);
                SerializationManager.Serialization(saveFile.FileName, buffer);                

                finishedSuccessfully = true;
                this.OpenedFilePath = Path.GetFullPath(saveFile.FileName);
            }
        }

        /// <summary>
        /// Used to proposal saving changes of objects list before doing another operation.
        /// </summary>
        /// <param name="finishedSuccessfully">Indicating whether saving proposal
        /// was finished succesfully or not.</param>
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

        /// <summary>
        /// Prepares application for the new file.
        /// </summary>
        private void Clearing()
        {
            this.OpenedFilePath = string.Empty;
            this.ThereIsChanges = false;
            this.shapeListBox.Items.Clear();
        }

        #endregion        

        #endregion
    }
}
