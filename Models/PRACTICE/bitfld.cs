using PERform.Models.Abstracts;
using PERform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERform.Models.PRACTICE
{
    class bitfld : Field, IField
    {
        public FieldType FieldType => FieldType.BITFLD;
        public FieldSize FieldSize { get; }
        public int Offset { get; }
        public int Position { get; }
        public string Abbreviation { get; }
        public string Description { get; private set; }
        public List<string> States { get; private set; }

        public bitfld(string lineContainingBitfld)
        {
            FieldSize = GetFieldSize(lineContainingBitfld);
            // TODO Offset, Position, Abbreviation
            Description = GetFieldDescription(lineContainingBitfld);
            States = GetFieldStates(lineContainingBitfld);
        }
    }
}
