using Newtonsoft.Json;
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
        [JsonConstructor] public SnippetChild(string PerEditorText = "")
        {
            PerEditor = new PEREditor()
            {
                ShowLineNumbers = true,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Margin = new Thickness(10),
                Text = PerEditorText
            };
        }
        #endregion

        #region Properties
        public string Header
        {
            get { return header; }
            set { SetProperty(ref header, value); }
        }
        public string PerEditorText
        {
            get { return PerEditor.Text; }
        }
        [JsonIgnore] public PEREditor PerEditor { get; }
        #endregion

        #region Methods
        public void Rename(string newHeader)
        {
            Header = newHeader;
        }
        #endregion

    }
}
