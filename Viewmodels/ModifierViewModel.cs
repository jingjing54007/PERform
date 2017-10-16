using PERform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERform.Viewmodels
{
    public class ModifierViewModel : Notifier
    {
        #region Fields
        private FileSelector fileSelector;
        private PEREditor perEditor;
        private bool uppercaseLinesIsChecked;
        private bool lowercaseFieldsIsChecked;
        #endregion

        #region Constructor
        public ModifierViewModel(FileSelector fileSelector)
        {
            this.fileSelector = fileSelector;
            this.fileSelector.SelectedFileChanged += FileSelector_SelectedFileChanged;

            PerEditor = new PEREditor();
            PerEditor.LoadTextFromFile(fileSelector.Path);

            InitializeCommands();
        }
        #endregion

        #region Properties
        public PEREditor PerEditor
        {
            get { return perEditor; }
            private set { SetProperty(ref perEditor, value); }
        }

        public bool UppercaseLinesIsChecked
        {
            get { return uppercaseLinesIsChecked; }
            set { SetProperty(ref uppercaseLinesIsChecked, value); }
        }
        public bool LowercaseFieldsIsChecked
        {
            get { return lowercaseFieldsIsChecked; }
            set { SetProperty(ref lowercaseFieldsIsChecked, value); }
        }
        #endregion

        #region Commands
        public RelayCommand ExecuteCommand { get; set; }

        private void InitializeCommands()
        {
            ExecuteCommand = new RelayCommand(ExecuteModifications);
        }
        #endregion

        #region Methods
        private void FileSelector_SelectedFileChanged(object sender, EventArgs e)
        {
            PerEditor.LoadTextFromFile(fileSelector?.Path);

            UppercaseLinesIsChecked = false;
            LowercaseFieldsIsChecked = false;
        }

        private void ExecuteModifications(object obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
