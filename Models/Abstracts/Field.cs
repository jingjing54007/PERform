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
        UNDEFINED,
        BITFLD,
        RBITFLD,
        EVENTFLD,
        SETCLRFLD,
        HEXMASK,
        LINE,
        GROUP
    }
    public enum FieldSize
    {
        UNDEFINED,
        BYTE,
        WORD,
        TBYTE,
        LONG,
        QUAD
    }

    abstract partial class Field
    {
        #region Properties
        public string IndentationPattern => @"(?<INDENTATION>\s*)";
        public string FieldTypePattern => @"(?<FIELDTYPE>\w+)\.";
        public string FieldSizePattern => @"(?<FIELDSIZE>\w+)";
        public string InnerFieldSizePattern => @"(\.(?<INNERFIELDSIZE>\w+))?";
        public string OffsetPattern => @"\s+(?<MINUS>-?)?(?<OFFSET>(0x|0X)[a-fA-F0-9]+)";
        public string OffsetSetPattern => @"\s+(?<MINUSSET>-?)?(?<OFFSETSET>(0x|0X)[a-fA-F0-9]+)";
        public string OffsetClearPattern => @"\s+(?<MINUSCLEAR>-?)?(?<OFFSETCLEAR>(0x|0X)[a-fA-F0-9]+)";
        public string FirstPositionPattern => @"\s+(?<FIRSTPOSITION>\d+)\.";
        public string SecondPositionPattern => @"(--(?<SECONDPOSITION>\d+).)?";
        public string PositionSetPattern => @"\s+(?<POSITIONSET>\d+)\.";
        public string PositionClearPattern => @"\s+(?<POSITIONCLEAR>\d+)\.";
        public string MultiplierPattern => @"(\s+(?<MULTIPLIER>\d+)\.)?";
        public string AbbreviationPattern => "\\s+\"(?<ABBREVIATION>[^,].+?),";
        public string DescriptionPattern => "(?<DESCRIPTION>.+?)\"";
        public string StatesPattern => "\\s+\"(?<STATES>.+)\"";
        #endregion

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
            for (int i = 0; i < states.Count; i++)
            {
                var stateArray = states[i].ToCharArray();
                if (char.IsWhiteSpace(stateArray[0]) || char.IsWhiteSpace(stateArray[stateArray.Length - 1]))
                {
                    states[i] = states[i].Trim();
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

        public FieldSize StringToFieldSize(string line)
        {
            switch (line.ToLower())
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
                    return FieldSize.UNDEFINED;
            }
        }

        public string GetString(IField field)
        {
            var returnString = string.Empty;

            if (field.GetType() == typeof(Bitfld) || field.GetType() == typeof(Eventfld))
            {
                returnString += field.Indentation + field.FieldType.ToString().ToLower() + "." + field.FieldSize.ToString().ToLower() +
                     " 0x" + field.Offset.ToString("X") + " " + field.Position.Item1.ToString() + ".";

                if (field.Position.Item2 != null)
                {
                    returnString += "--" + field.Position.Item2.ToString() + ".";
                }

                returnString += " \"" + field.Abbreviation + "," +
                     field.Description + "\" \"" + string.Join(",", field.States) + "\"";
            }

            return returnString;
        }
        #endregion
    }
}
