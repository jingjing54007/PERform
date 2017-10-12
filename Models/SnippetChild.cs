using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PERform.Models
{
    public class SnippetChild : Notifier, ISnippet
    {
        #region Fields
        string header;
        #endregion

        #region Constructor
        public SnippetChild()
        {
            PerEditor = new PEREditor()
            {
                ShowLineNumbers = true,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Margin = new Thickness(10)
            };
        }
        #endregion

        #region Properties
        public string Header
        {
            get { return header; }
            set { SetProperty(ref header, value); }
        }
        public PEREditor PerEditor { get; }
        #endregion

        #region Methods
        public void Rename(string newHeader)
        {
            Header = newHeader;
        }
        #endregion

    }
}
