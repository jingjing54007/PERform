using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERform.Models
{
    public class Snippet : Notifier
    {
        #region Fields
        private string header;
        #endregion

        #region Constructor
        public Snippet(string header, bool isParent)
        {
            Header = header;
            IsParent = isParent;
            Snippets = new ObservableCollection<Snippet>();
            CreationDate = DateTime.Now;
            LastEditedDate = DateTime.Now;
            if (IsParent)
            {
                var parentText = string.Format("Creation date:\t {0}\nLast edited on:\t {1}", CreationDate.ToString(), LastEditedDate.ToString());
                PerEditor = new PEREditor()
                {
                    IsReadOnly = true,
                    Text = parentText,
                    IsEnabled = false
                };
            }
            else
            {
                PerEditor = new PEREditor();
                Snippets = null;
            }
        }
        #endregion

        #region Properties
        public PEREditor PerEditor { get; }
        public ObservableCollection<Snippet> Snippets { get; }
        public bool IsParent { get; }
        public DateTime CreationDate { get; }
        public DateTime LastEditedDate { get; private set; }

        public string Header
        {
            get { return header; }
            set { SetProperty(ref header, value); }
        }
        #endregion

        #region Methods
        public void Rename(string newHeader)
        {
            Header = newHeader;
        }
        #endregion
    }
}
