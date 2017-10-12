using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERform.Models
{
    public interface ISnippet
    {
        string Header { get; set; }
        PEREditor PerEditor { get; }

        void Rename(string newHeader);
    }
}
