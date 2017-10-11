using ICSharpCode.AvalonEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
        }
    }
}
