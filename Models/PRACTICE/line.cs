using PERform.Models.Abstracts;
using PERform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PERform.Models.PRACTICE
{
    class Line : Field, IPRACTICE
    {
        #region Properties
        public string Indentation { get; }
        public FieldType FieldType => FieldType.LINE;
        public FieldSize FieldSize { get; }
        public int Offset { get; }
        public string Abbreviation { get; }
        public string Description { get; private set; }
        #endregion

        public Line(string lineContainingLine)
        {
            var linePattern = IndentationPattern + FieldTypePattern + FieldSizePattern + OffsetPattern
                + AbbreviationPattern + DescriptionPattern;

            Regex regex = new Regex(linePattern);
            var match = regex.Match(lineContainingLine);

            Indentation = match.Groups["INDENTATION"].Value;
            FieldSize = StringToFieldSize(match.Groups["FIELDSIZE"].Value);
            Offset = Convert.ToInt32(match.Groups["MINUS"].Value + Convert.ToInt32(match.Groups["OFFSET"].Value, 16).ToString());
            Abbreviation = match.Groups["ABBREVIATION"].Value;
            Description = match.Groups["DESCRIPTION"].Value;

            var lol = GetString();
        }

        #region Methods
        void SetDescription(string description)
        {
            Description = description;
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
            var abbreviationString = " \"" + Abbreviation;
            var descriptionString = "," + Description + "\"";

            return Indentation + fieldTypeString + fieldSizeString + offsetString + abbreviationString + descriptionString;
        }
        #endregion
    }
}
