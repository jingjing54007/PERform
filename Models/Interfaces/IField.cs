using PERform.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERform.Models.Interfaces
{
    public interface IField
    {
        #region Properties
        string Indentation { get; }
        FieldType FieldType { get; }
        FieldSize FieldSize { get; }
        int Offset { get; }
        Tuple<int,int?> Position { get; }
        string Abbreviation { get; }
        string Description { get; }
        List<string> States { get; }
        #endregion

        #region Methods
        void SetDescription(string description);
        string GetString();
        Tuple<string, int> LowercaseDescription(string fieldDescription);
        #endregion
    }
}
