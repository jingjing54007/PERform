using PERform.Models;
using PERform.Models.PRACTICE;
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
        private bool uppercaseLinesIsChecked, lowercaseFieldsIsChecked, oldNewIfIsChecked, oldNewSVNIsChecked;
        private bool checkboxIsEnabled;
        #endregion

        #region Constructor
        public ModifierViewModel(FileSelector fileSelector)
        {
            this.fileSelector = fileSelector;
            this.fileSelector.SelectedFileChanged += FileSelector_SelectedFileChanged;

            PerEditor = new PEREditor() { IsReadOnly = true };
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
        public bool OldNewIfIsChecked
        {
            get { return oldNewIfIsChecked; }
            set { SetProperty(ref oldNewIfIsChecked, value); }
        }
        public bool OldNewSVNIsChecked
        {
            get { return oldNewSVNIsChecked; }
            set { SetProperty(ref oldNewSVNIsChecked, value); }
        }
        public bool CheckBoxIsEnabled
        {
            set { SetProperty(ref checkboxIsEnabled, value); }
        }
        public Program Program { get; private set; }
        #endregion

        #region Commands
        public RelayCommand ModifyCommand { get; set; }

        private void InitializeCommands()
        {
            ModifyCommand = new RelayCommand(Modify, IsAnyCheckboxCheckedAndFileSelected);
        }

        private bool IsAnyCheckboxCheckedAndFileSelected(object obj)
        {
            return IsAnyCheckboxChecked(obj) && IsFileSelected(obj);
        }

        private bool IsAnyCheckboxChecked(object obj)
        {
            return UppercaseLinesIsChecked || LowercaseFieldsIsChecked || OldNewIfIsChecked || OldNewSVNIsChecked;
        }

        private bool IsFileSelected(object obj)
        {
            return !(fileSelector.Path == null || String.Equals(fileSelector?.Path, string.Empty));
        }
        #endregion

        #region Methods
        private void FileSelector_SelectedFileChanged(object sender, EventArgs e)
        {
            if (!String.Equals(fileSelector?.Path, string.Empty))
            {
                PerEditor.LoadTextFromFile(fileSelector.Path);
                Program = new Program(fileSelector.Lines);
                CheckBoxIsEnabled = true;
            }
            else
            {
                PerEditor.Clear();
                Program = null;
                UppercaseLinesIsChecked = false;
                LowercaseFieldsIsChecked = false;
                OldNewIfIsChecked = false;
                OldNewSVNIsChecked = false;
                CheckBoxIsEnabled = false;
            }
        }

        private void Modify(object obj)
        {
            if (LowercaseFieldsIsChecked)
                Program.LowercaseFields();

            PerEditor.Text = string.Join(Environment.NewLine, Program.LinesRawString);
        }
        #endregion
    }
}
