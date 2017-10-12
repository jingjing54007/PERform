using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERform.Models
{
    public class SnippetParent : Notifier, ISnippet
    {
        #region Fields
        string header;
        #endregion

        #region Constructor
        public SnippetParent()
        {
            Childrens = new ObservableCollection<SnippetChild>();
        }
        #endregion

        #region Properties
        public string Header
        {
            get { return header; }
            set { SetProperty(ref header, value); }
        }
        public PEREditor PerEditor { get; }
        public ObservableCollection<SnippetChild> Childrens { get; }
        #endregion

        #region Methods
        public void Rename(string newHeader)
        {
            Header = newHeader;
        }
        #endregion

    }
}
