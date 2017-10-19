using PERform.Models.Abstracts;
using PERform.Models.Interfaces;
using PERform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PERform.Models.PRACTICE
{
    class Hexmask : Field, IField, IPRACTICE
    {
        public string Indentation { get; }
        public FieldType FieldType => FieldType.HEXMASK;
        public FieldSize FieldSize { get; }
        public FieldSize? InnerFieldSize { get; }
        public int Offset { get; }
        public Tuple<int, int?> Position { get; }
        public int? Multiplier { get; }
        public string Abbreviation { get; }
        public string Description { get; private set; }
        public List<string> States => null;

        public Hexmask(string lineContainingHexmask)
        {
            var hexmaskPattern = IndentationPattern + FieldTypePattern + FieldSizePattern + InnerFieldSizePattern + OffsetPattern
                + FirstPositionPattern + SecondPositionPattern + MultiplierPattern + AbbreviationPattern + DescriptionPattern;

            Regex regex = new Regex(hexmaskPattern);
            var match = regex.Match(lineContainingHexmask);

            Indentation = match.Groups["INDENTATION"].Value;
            FieldSize = StringToFieldSize(match.Groups["FIELDSIZE"].Value);
            InnerFieldSize = StringToFieldSize(match.Groups["INNERFIELDSIZE"].Value);
            Offset = Convert.ToInt32(match.Groups["MINUS"].Value + Convert.ToInt32(match.Groups["OFFSET"].Value, 16).ToString());
            Position = new Tuple<int, int?>(Convert.ToInt32(match.Groups["FIRSTPOSITION"].Value), Convert.ToInt32(match.Groups["SECONDPOSITION"].Value));
            Multiplier = match.Groups["MULTIPLIER"].Value.ToNullableInt();
            Abbreviation = match.Groups["ABBREVIATION"].Value;
            Description = match.Groups["DESCRIPTION"].Value;

            var lol = GetString();
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public string GetString()
        {
            var fieldTypeString = FieldType.ToString().ToLower() + ".";
            var fieldSizeString = FieldSize.ToString().ToLower();
            if (InnerFieldSize != null && InnerFieldSize != FieldSize.UNDEFINED)
            {
                fieldSizeString += "." + InnerFieldSize.ToString();
            }
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
            positionString += "--" + Position.Item2.ToString() + ".";
            var multiplierString = " " + Multiplier.ToString() + ".";
            var abbreviationString = " \"" + Abbreviation;
            var descriptionString = "," + Description + "\"";

            return Indentation + fieldTypeString + fieldSizeString + offsetString + positionString +
                multiplierString + abbreviationString + descriptionString;
        }
    }
}
