using PERform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PERform.Models.Abstracts;
using System.Text.RegularExpressions;

namespace PERform.Models.PRACTICE
{
    class Setclrfld : Field, IField, IPRACTICE
    {
        public string Indentation { get; }
        public FieldType FieldType => FieldType.SETCLRFLD;
        public FieldSize FieldSize { get; }
        public int Offset { get; }
        public Tuple<int,int?> Position { get; }
        public int OffsetSet { get; }
        public Tuple<int,int?> PositionSet { get; }
        public int OffsetClear { get; }
        public Tuple<int, int?> PositionClear { get; }
        public string Abbreviation { get; }
        public string Description { get; private set; }
        public List<string> States { get; private set; }

        public Setclrfld(string lineContainingSetclrfld)
        {
            var setclrfldpattern = IndentationPattern + FieldTypePattern + FieldSizePattern + OffsetPattern
                + FirstPositionPattern + OffsetSetPattern + PositionSetPattern + OffsetClearPattern + 
                PositionClearPattern + AbbreviationPattern + DescriptionPattern + StatesPattern;

            Regex regex = new Regex(setclrfldpattern);
            var match = regex.Match(lineContainingSetclrfld);

            Indentation = match.Groups["INDENTATION"].Value;
            FieldSize = StringToFieldSize(match.Groups["FIELDSIZE"].Value);
            Offset = Convert.ToInt32(match.Groups["MINUS"].Value + Convert.ToInt32(match.Groups["OFFSET"].Value, 16).ToString());
            Position = new Tuple<int, int?>(Convert.ToInt32(match.Groups["FIRSTPOSITION"].Value), null);
            OffsetSet = Convert.ToInt32(match.Groups["MINUSSET"].Value + Convert.ToInt32(match.Groups["OFFSETSET"].Value, 16).ToString());
            PositionSet = new Tuple<int, int?>(Convert.ToInt32(match.Groups["POSITIONSET"].Value), null);
            OffsetClear = Convert.ToInt32(match.Groups["MINUSCLEAR"].Value + Convert.ToInt32(match.Groups["OFFSETCLEAR"].Value, 16).ToString());
            PositionClear = new Tuple<int, int?>(Convert.ToInt32(match.Groups["POSITIONCLEAR"].Value), null);
            Abbreviation = match.Groups["ABBREVIATION"].Value;
            Description = match.Groups["DESCRIPTION"].Value;
            States = match.Groups["STATES"].Value.Split(',').ToList();
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetStates(List<string> states)
        {
            States = states;
        }

        public string GetString()
        {
            var fieldTypeString = FieldType.ToString().ToLower() + ".";
            var fieldSizeString = FieldSize.ToString().ToLower();
            var offsetString = string.Empty;
            if (Offset < 0)
            {
                offsetString = " -0x" + Math.Abs(Offset).ToString("X");
            }
            else
            {
                offsetString = " 0x" + Offset.ToString("X");
            }
            var positionString = " " + Position.Item1.ToString() + ".";
            var offsetSetString = string.Empty;
            if (OffsetSet < 0)
            {
                offsetSetString = " -0x" + Math.Abs(OffsetSet).ToString("X");
            }
            else
            {
                offsetSetString = " 0x" + OffsetSet.ToString("X");
            }
            var positionSetString = " " + PositionSet.Item1.ToString() + ".";
            var offsetClearString = string.Empty;
            if (OffsetClear < 0)
            {
                offsetClearString = " -0x" + Math.Abs(OffsetClear).ToString("X");
            }
            else
            {
                offsetClearString = " 0x" + OffsetClear.ToString("X");
            }
            var positionClearString = " " + PositionClear.Item1.ToString() + ".";
            var abbreviationString = " \"" + Abbreviation;
            var descriptionString = "," + Description + "\"";
            var statesString = " \"" + string.Join(",", States) + "\"";

            return Indentation + fieldTypeString + fieldSizeString + offsetString + positionString +
                offsetSetString + positionSetString + offsetClearString + positionClearString +
                abbreviationString + descriptionString + statesString;
        }
    }
}
