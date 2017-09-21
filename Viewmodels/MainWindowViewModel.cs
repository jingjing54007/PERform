using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using PERform.Models;
using PERform.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PERform.Viewmodels
{
    public class MainWindowViewModel : Notifier
    {
        private ContentControl pageContent;
        private string textBoxText;
        private FileSelector fileSelector;

        public MainWindowViewModel()
        {
            PageContent = new HomeView();
            fileSelector = new FileSelector();

            InitializeCommands();
        }

        public ContentControl PageContent
        {
            get { return pageContent; }
            set { SetProperty(ref pageContent, value); }
        }

        public string TextBoxText
        {
            get { return textBoxText; }
            set { SetProperty(ref textBoxText, value); }
        }

        public RelayCommand PageOpen { get; set; }
        public RelayCommand MouseDown { get; set; }



        private void InitializeCommands()
        {
            PageOpen = new RelayCommand(Open);
            MouseDown = new RelayCommand(SelectFile);
        }

        private void SelectFile(object obj)
        {
            fileSelector.SelectFile();
            TextBoxText = fileSelector.Name;
        }

        private void Open(object obj)
        {
            var parameter = (string)obj;

            if (parameter == "Modifier")
            {
                PageContent = new ModifierView();
            }
            else if (parameter == "Home")
            {
                PageContent = new HomeView();
            }
            else if (parameter == "AboutDEV")
            {
                PageContent = new AboutDEVView();
            }

            DrawerHost.CloseDrawerCommand.Execute(null, null);
        }
    }
}
