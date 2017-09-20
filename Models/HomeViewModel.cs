using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PERform.Models;

namespace PERform.Models
{
    class HomeViewModel : INotifyPropertyChanged
    {
        #region Fields
        #endregion

        #region Constructor
        public HomeViewModel()
        {
            InitializeCommands();
        }
        #endregion

        #region Properties
        public RelayCommand ClickButtonCommand { get; set; }
        #endregion

        #region Commands
        private void InitializeCommands()
        {
            ClickButtonCommand = new RelayCommand(clikcButton);
        }

        private void clikcButton(object obj)
        {
            throw new NotImplementedException();
            OnPropertyChange()
        }
        #endregion
    }
}
