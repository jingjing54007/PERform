using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERform.Models
{
    public class FileSelector
    {
        public event EventHandler SelectedFileChanged;

        public string Path { get; private set; }
        public string Name { get; private set; }
        public string[] Lines { get; private set; }

        public void SelectFile()
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "ph files (*.ph)|*.ph|per files (*.per)|*.per"
            };

            if (dialog.ShowDialog() == true)
            {
                Path = dialog.FileName;
                Name = dialog.SafeFileName;
                Lines = File.ReadAllLines(Path);
            }
            else
            {
                Path = string.Empty;
                Name = string.Empty;
            }
            OnSelectedFileChanged();
        }

        private void OnSelectedFileChanged()
        {
            SelectedFileChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
