using PERform.Models.Abstracts;
using PERform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using PERform.Utilities;

namespace PERform.Models.PRACTICE
{
    class Bitfld : Field, IField, IPRACTICE
    {
        public string Indentation { get; }
        public FieldType FieldType { get; }
        public FieldSize FieldSize { get; }
        public int Offset { get; }
        public Tuple<int,int?> Position { get; }
        public string Abbreviation { get; }
        public string Description { get; private set; }
        public List<string> States { get; private set; }


        public Bitfld(string lineContainingBitfld)
        {
            var bitfldPattern = IndentationPattern + FieldTypePattern + FieldSizePattern + OffsetPattern
                + FirstPositionPattern + SecondPositionPattern + AbbreviationPattern + DescriptionPattern + StatesPattern;

            Regex regex = new Regex(bitfldPattern);
            var match = regex.Match(lineContainingBitfld);

            Indentation = match.Groups["INDENTATION"].Value;
            if (match.Groups["FIELDTYPE"].Value.ToLower() == "bitfld")
                FieldType = FieldType.BITFLD;
            else
                FieldType = FieldType.RBITFLD;
            FieldSize = StringToFieldSize(match.Groups["FIELDSIZE"].Value);
            Offset = Convert.ToInt32(match.Groups["MINUS"].Value + Convert.ToInt32(match.Groups["OFFSET"].Value, 16).ToString());
            Position = new Tuple<int, int?>(Convert.ToInt32(match.Groups["FIRSTPOSITION"].Value), match.Groups["SECONDPOSITION"].Value.ToNullableInt());
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
            if (Position.Item2 != null)
            {
                positionString += "--" + Position.Item2.ToString() + ".";
            }
            var abbreviationString = " \"" + Abbreviation;
            var descriptionString = "," + Description + "\"";
            var statesString = " \"" + string.Join(",", States) + "\"";

            return Indentation + fieldTypeString + fieldSizeString + offsetString + positionString +
                abbreviationString + descriptionString + statesString;
        }
    }
}
