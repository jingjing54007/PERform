using System;
using System.Collections.Generic;
using System.Linq;
using PERform.Utilities;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using PERform.Models.Interfaces;
using PERform.Models.PRACTICE;

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

        public Tuple<string,int> LowercaseDescription(string fieldDescription)
        {
            int modificationCount = 0;
            var wordsInDescription = fieldDescription.Split(' ');

            for (int i = 1; i < wordsInDescription.Length; i++)
            { 
                //if word contain upper-letter at position different than 1st, skip iteration
                if (wordsInDescription[i].Substring(1).Any(c => char.IsUpper(c)))
                    continue;
                else
                {
                    wordsInDescription[i] = wordsInDescription[i].ToLower();
                    modificationCount++;
                }
            }
            var lowercasedDescription = string.Join(" ", wordsInDescription);

            return new Tuple<string, int>(lowercasedDescription, modificationCount);
        }

        public Tuple<List<string>,int> RemoveWhitespacesFromStates(List<string> states)
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
            return new Tuple<List<string>, int>(states, modificationCount);
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

        public FieldSize GetSize(string line)
        {
            var indexOfFirstDot = line.IndexOf('.') + 1;
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

        public int GetOffset(string line)
        {
            var indexOfFirstNumber = line.IndexOfAny("0123456789".ToCharArray());
            var indexOfSpace = line.IndexOf(' ', indexOfFirstNumber);
            var length = indexOfSpace - indexOfFirstNumber;
            var offset = Convert.ToInt32(line.Substring(indexOfFirstNumber, length), 16);

            return offset;
        }

        public Tuple<int,int?> GetPosition(string line)
        {
            Regex.Match(line, @"(\d+\.)(--\d+\d)?");

            return null;
        }

        public string GetAbbreviation(string line)
        {
            var indexOfFirstQuotationMark = line.IndexOf('"') + 1;
            var indexOfFirstComa = line.IndexOf(",", indexOfFirstQuotationMark);
            var length = indexOfFirstComa - indexOfFirstQuotationMark;
            var abbreviation = line.Substring(indexOfFirstQuotationMark, length);

            return abbreviation;
        }

        public string GetDescription(string line)
        {
            var indexOfFirstComa = line.IndexOf(',') + 1;
            var indexOfClosingQuotationMark = line.IndexOf('"', indexOfFirstComa);
            var length = indexOfClosingQuotationMark - indexOfFirstComa;
            var description = line.Substring(indexOfFirstComa, length);

            return description;
        }

        public List<string> GetStates(string line)
        {
            var indexOfStatesOpenQuotationMark = line.GetNthIndex('"', 3) + 1;
            var indexOfStatesClosingQuotationMark = line.IndexOf('"', indexOfStatesOpenQuotationMark);
            var length = indexOfStatesClosingQuotationMark - indexOfStatesOpenQuotationMark;
            var statesString = line.Substring(indexOfStatesOpenQuotationMark, length);

            var statesList = statesString.Split(',').ToList();

            return statesList;
        }

        public string GetString(IField field)
        {
            var returnString = string.Empty;

            if (field.GetType() == typeof(Bitfld))
            {
                returnString = field.FieldType.ToString() + "." + field.FieldSize.ToString() + " 0x" + field.Offset.ToString("X")
                    + " " + field.Position.ToString() + ". \"" + field.Abbreviation + "," + field.Description + "\" \"" +
                    string.Join(",", field.States) + "\"";
            }

            return returnString;
        }
        #endregion
    }
}
