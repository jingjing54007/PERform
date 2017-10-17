using System;
using System.Collections.Generic;
using System.Linq;
using PERform.Utilities;
using System.Text;
using System.Threading.Tasks;

namespace PERform.Models.Abstracts
{
    public enum FieldType
    {
        UNDETERMINED,
        BITFLD,
        EVENTFLD,
        SETCLRFLD
    }
    public enum FieldSize
    {
        UNDETERMINED,
        BYTE,
        WORD,
        TBYTE,
        LONG,
        QUAD
    }

    abstract partial class Field
    {
        #region Methods
        public int GetLongestStateLength(List<string> states) => states.OrderByDescending(s => s.Length).FirstOrDefault().Length;
        public int GetAbbreviationLength(string abbreviation) => abbreviation.Length;

        public int LowercaseDescription(string fieldDescription)
        {
            int modificationCount = 0;
            var wordsInDescription = fieldDescription.Split(' ');

            for (int i = 0; i < wordsInDescription.Length; i++)
            { 
                //if word contain upper-letter at position different than 1st, skip iteration
                if (wordsInDescription[i].Substring(1).Any(c => char.IsUpper(c)))
                    continue;
                else
                {
                    wordsInDescription[i].Substring(1).ToLower();
                    modificationCount++;
                }
            }

            return modificationCount;
        }

        public int RemoveWhitespacesFromStates(List<string> states)
        {
            int modificationCount = 0;
            foreach (var state in states)
            {
                if (char.IsWhiteSpace(state[0]) || char.IsWhiteSpace(state[state.Length]))
                {
                    state.Trim();
                    modificationCount++;
                }
            }
            return modificationCount;
        }

        public bool CheckIfPositionExceedSize(FieldSize fieldSize, int position)
        {
            switch (fieldSize)
            {
                case FieldSize.BYTE:
                    return position > 7;
                case FieldSize.WORD:
                    return position > 15;
                case FieldSize.TBYTE:
                    return position > 23;
                case FieldSize.LONG:
                    return position > 31;
                case FieldSize.QUAD:
                    return position > 63;
                default:
                    return true;
            }
        }

        public FieldSize GetFieldSize(string line)
        {
            var indexOfFirstDot = line.IndexOf('.');
            var indexOfSpace = line.IndexOf(' ', indexOfFirstDot);
            var length = indexOfSpace - indexOfFirstDot;
            var fieldSizeString = line.Substring(indexOfFirstDot, length).ToLower();

            switch (fieldSizeString)
            {
                case "byte":
                    return FieldSize.BYTE;
                case "word":
                    return FieldSize.WORD;
                case "tbyte":
                    return FieldSize.TBYTE;
                case "long":
                    return FieldSize.LONG;
                case "quad":
                    return FieldSize.QUAD;
                default:
                    return FieldSize.UNDETERMINED;
            }
        }

        public string GetFieldDescription(string line)
        {
            var indexOfFirstComa = line.IndexOf(',');
            var indexOfClosingQuotationMark = line.IndexOf('"', indexOfFirstComa);
            var length = indexOfClosingQuotationMark - indexOfFirstComa;
            var fieldDescriptionString = line.Substring(indexOfFirstComa, length);

            return fieldDescriptionString;
        }

        public List<string> GetFieldStates(string line)
        {
            var indexOfStatesOpenQuotationMark = line.GetNthIndex('"', 3);
            var indexOfStatesClosingQuotationMark = line.IndexOf('"', indexOfStatesOpenQuotationMark);
            var length = indexOfStatesClosingQuotationMark - indexOfStatesOpenQuotationMark;
            var statesString = line.Substring(indexOfStatesOpenQuotationMark, length);

            var statesList = statesString.Split(',').ToList();

            return statesList;
        }
        #endregion
    }
}
