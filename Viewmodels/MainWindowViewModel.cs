using MaterialDesignThemes.Wpf;
using PERform.Models;
using PERform.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PERform.Viewmodels
{
    public class MainWindowViewModel : Notifier
    {
        private ContentControl pageContent;

        public MainWindowViewModel()
        {
            InitializeCommands();
        }

        public ContentControl PageContent
        {
            get { return pageContent; }
            set
            {
                pageContent = value;
                OnPropertyChanged("PageContent");
            }
        }

        public RelayCommand PageOpen { get; set; }



        private void InitializeCommands()
        {
            PageOpen = new RelayCommand(Open);
        }

        private void Open(object obj)
        {
            var parameter = (string)obj;

            if (parameter == "Modifier")
            {
                PageContent = new ModifierView();
            }

            DrawerHost.CloseDrawerCommand.Execute(null, null);
        }
    }
}
