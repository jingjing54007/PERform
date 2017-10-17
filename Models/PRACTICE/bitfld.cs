using PERform.Models.Abstracts;
using PERform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERform.Models.PRACTICE
{
    class Bitfld : Field, IField, IPRACTICE
    {
        public FieldType FieldType => FieldType.BITFLD;
        public FieldSize FieldSize { get; }
        public int Offset { get; }
        public int Position { get; }
        public int FieldRange { get; }
        public string Abbreviation { get; }
        public string Description { get; private set; }
        public List<string> States { get; private set; }

        public Bitfld(string lineContainingBitfld)
        {
            FieldSize = GetSize(lineContainingBitfld);
            Offset = GetOffset(lineContainingBitfld);
            Abbreviation = GetAbbreviation(lineContainingBitfld);
            Description = GetDescription(lineContainingBitfld);
            States = GetStates(lineContainingBitfld);
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetStates(List<string> states)
        {
            States = states;
        }
    }
}
