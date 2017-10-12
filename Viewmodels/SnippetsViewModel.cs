using PERform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PERform.Viewmodels
{
    class SnippetsViewModel : Notifier
    {
        #region Fields
        private bool dialogIsOpen;
        private Visibility dialogTextBoxVisibility = Visibility.Collapsed;
        private string dialogTextBlockText;
        private string dialogTextBoxText;
        private DialogType? currentDialogType = null;

        public enum DialogType
        {
            Add,
            Rename,
            Delete
        }
        #endregion

        #region Constructor
        public SnippetsViewModel()
        {
            SnippetsManager = new SnippetsManager();
            InitializeCommands();
        }
        #endregion

        #region Properties
        public SnippetsManager SnippetsManager { get; }
        public ISnippet SelectedItem { get; set; }
        public bool DialogIsOpen
        {
            get { return dialogIsOpen; }
            set { SetProperty(ref dialogIsOpen, value); }
        }
        public Visibility DialogTextBoxVisibility
        {
            get { return dialogTextBoxVisibility; }
            set { SetProperty(ref dialogTextBoxVisibility, value); }
        }
        public string DialogTextBlockText
        {
            get { return dialogTextBlockText; }
            private set { SetProperty(ref dialogTextBlockText, value); } 
        }
        public string DialogTextBoxText
        {
            get { return dialogTextBoxText; }
            set { SetProperty(ref dialogTextBoxText, value); }
        }
        #endregion

        #region Commands & Command actions
        public RelayCommand AddSnippetCommand { get; set; }
        public RelayCommand RenameSnippetCommand { get; set; }
        public RelayCommand DeleteSnippetCommand { get; set; }
        public RelayCommand CancelDialogCommand { get; set; }
        public RelayCommand ConfirmDialogCommand { get; set; }

        private void InitializeCommands()
        {
            AddSnippetCommand = new RelayCommand(AddSnippet, IsNotChildNode);
            RenameSnippetCommand = new RelayCommand(RenameSnippet);
            DeleteSnippetCommand = new RelayCommand(DeleteSnippet);
            CancelDialogCommand = new RelayCommand(CancelDialog);
            ConfirmDialogCommand = new RelayCommand(ConfirmDialog);
        }

        private bool IsNotChildNode(object obj)
        {
            if (obj is SnippetChild)
                return false;
            else
                return true;
        }

        private void CancelDialog(object obj)
        {
            ClearDialog();
        }

        private void ConfirmDialog(object obj)
        {
            if (currentDialogType == DialogType.Add)
            {
                SnippetsManager.Add(SelectedItem, DialogTextBoxText);
            }
            else if (currentDialogType == DialogType.Rename)
            {
                SnippetsManager.Rename(SelectedItem, DialogTextBoxText);
            }
            else if (currentDialogType == DialogType.Delete)
            {
                SnippetsManager.Remove(SelectedItem);
            }

            DialogIsOpen = false;
            ClearDialog();
        }

        private void AddSnippet(object obj)
        {
            ShowDialog(DialogType.Add, SelectedItem);
        }

        private void RenameSnippet(object obj)
        {
            ShowDialog(DialogType.Rename, SelectedItem);
        }

        private void DeleteSnippet(object obj)
        {
            ShowDialog(DialogType.Delete, SelectedItem);
        }
        #endregion

        #region Methods
        private void ShowDialog(DialogType dialogType, ISnippet selectedSnippet)
        {
            if (dialogType == DialogType.Add)
            {
                DialogTextBlockText = string.Format("Enter name for new node inside a *{0}* tree", selectedSnippet?.Header);
                DialogTextBoxVisibility = Visibility.Visible;
                DialogIsOpen = true;
            }
            else if (dialogType == DialogType.Rename)
            {
                DialogTextBlockText = string.Format("Enter new name for *{0}* node", selectedSnippet?.Header);
                DialogTextBoxVisibility = Visibility.Visible;
                DialogIsOpen = true;
            }
            else if (dialogType == DialogType.Delete)
            {
                DialogTextBlockText = string.Format("Are you sure you want to delete *{0}* node?\nAll children nodes will be lost as well.", selectedSnippet?.Header);
                DialogTextBoxVisibility = Visibility.Collapsed;
                DialogIsOpen = true;
            }

            currentDialogType = dialogType;
        }

        void ClearDialog()
        {
            DialogTextBlockText = string.Empty;
            DialogTextBoxText = string.Empty;
            DialogTextBoxVisibility = Visibility.Collapsed;
            DialogIsOpen = false;
        }
        #endregion
    }
}
