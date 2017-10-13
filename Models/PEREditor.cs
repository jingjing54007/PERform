using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;

namespace PERform.Models
{
    public class PEREditor : TextEditor
    {
        public PEREditor()
        {
            InitializeEditor();
        }

        private void InitializeEditor()
        {
            HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            ShowLineNumbers = true;
            SyntaxHighlighting = null;
            using (var reader = new XmlTextReader("AppData/HighlightingDefinitions.xshd"))
            {
                var definition = HighlightingLoader.Load(reader, HighlightingManager.Instance);
                SyntaxHighlighting = definition;
            }
        }
    }
}
