using PERform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PERform.Models.Abstracts;

namespace PERform.Models.PRACTICE
{
    class setclrfld : Field, IField
    {
        public FieldType FieldType => FieldType.SETCLRFLD;
        public FieldSize FieldSize { get; }
        public int Offset { get; }
        public int Position { get; }
        public int FieldRange { get; }
        public string Abbreviation { get; }
        public string Description { get; private set; }
        public List<string> States { get; private set; }

        public void SetDescription(string description)
        {
            throw new NotImplementedException();
        }

        public void SetStates(List<string> states)
        {
            throw new NotImplementedException();
        }
    }
}
