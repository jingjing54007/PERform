using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERform.Models.Abstracts
{
    public enum FieldType
    {
        BITFLD,
        EVENTFLD,
        SETCLRFLD
    }
    public enum FieldSize
    {
        BYTE,
        WORD,
        TBYTE,
        LONG,
        QUAD
    }

    abstract partial class Field
    {
        #region Properties
        public FieldType FieldType { get; }
        public FieldSize FieldSize { get; }
        public int Offset { get; }
        public int Position { get; }
        public string Abbreviation { get; }
        public string Description { get; }
        public List<string> States { get; }
        #endregion

        #region Methods
        public int GetLongestStateLength() => States.OrderByDescending(s => s.Length).FirstOrDefault().Length;
        public int GetAbbreviationLength() => Abbreviation.Length;

        public int LowercaseDescription()
        {
            //call private methods and return amount of modified words in "public string Description { get; }" to sum up for statistics
            return 0;
        }

        public int RemoveWhitespacesFromStates()
        {
            //call private methods and return amount of modified states in "public List<string> States { get; }" to sum up for statistics
            return 0;
        }

        public bool CheckIfPositionDoesNotExceedSize()
        {
            switch (FieldSize)
            {
                case FieldSize.BYTE:
                    return Position > 7;
                case FieldSize.WORD:
                    return Position > 15;
                case FieldSize.TBYTE:
                    return Position > 23;
                case FieldSize.LONG:
                    return Position > 31;
                case FieldSize.QUAD:
                    return Position > 63;
                default:
                    return false;
            }
        }
        #endregion
    }
}
