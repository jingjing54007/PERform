using PERform.Models.Abstracts;
using PERform.Models.Interfaces;
using PERform.Models.PRACTICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PERform.Models
{
    public class Program
    {

        public Program(string[] programLines)
        {
            Lines = new List<IPRACTICE>();
            LinesRawString = programLines;

            //var groupPattern = @"\s*(r|w)?group.(byte|word|tbyte|long|quad)\s*-?\d+";
            var linePattern = @"\s*line.(byte|word|tbyte|long|quad)\s*-?\d+";
            var bitfldPattern = @"\s*(r)?bitfld.(byte|word|tbyte|long|quad)\s*-?\d+";
            var eventfldPattern = @"\s*eventfld.(byte|word|tbyte|long|quad)\s*-?\d+";
            var setclrfldPattern = @"\s*setclrfld.(byte|word|tbyte|long|quad)\s*-?\d+";
            var hexmaskPattern = @"\s*hexmask.(byte|word|tbyte|long|quad)(\.byte|\.word|\.tbyte|\.long|\.quad)?\s*-?\d+";

            foreach (var programLine in programLines)
            {
                if (Regex.IsMatch(programLine, linePattern))
                {
                    Lines.Add(new Line(programLine));
                }
                else if (Regex.IsMatch(programLine, bitfldPattern))
                {
                    Lines.Add(new Bitfld(programLine));
                }
                else if (Regex.IsMatch(programLine, eventfldPattern))
                {
                    Lines.Add(new Eventfld(programLine));
                }
                else if (Regex.IsMatch(programLine, setclrfldPattern))
                {
                    Lines.Add(new Setclrfld(programLine));
                }
                else if (Regex.IsMatch(programLine, hexmaskPattern))
                {
                    Lines.Add(new Hexmask(programLine));
                }
                else
                {
                    Lines.Add(new UNDEFINED(programLine));
                }
            }
        }

        public List<IPRACTICE> Lines { get; }
        public string[] LinesRawString { get; private set; }

        public int LowercaseFields()
        {
            foreach (var line in Lines)
            {
                if (line.GetType().GetInterfaces().Contains(typeof(IField)))
                {
                    var field = line as IField;
                    field.SetDescription(field.LowercaseDescription(field.Description).Item1);
                }
            }
            UpdateLinesRawString();
            return 0;
        }

        public int RemoveWhitespaces()
        {
            foreach (var line in Lines)
            {
                if (line.GetType() == typeof(Bitfld))
                {
                    var bitfld = line as Bitfld;
                    bitfld.SetStates(bitfld.RemoveWhitespacesFromStates(bitfld.States).Item1);
                }
                else if (line.GetType() == typeof(Eventfld))
                {
                    var eventfld = line as Eventfld;
                    eventfld.SetStates(eventfld.RemoveWhitespacesFromStates(eventfld.States).Item1);
                }
                else if (line.GetType() == typeof(Setclrfld))
                {
                    var setclrfld = line as Setclrfld;
                    setclrfld.SetStates(setclrfld.RemoveWhitespacesFromStates(setclrfld.States).Item1);
                }
            }
            UpdateLinesRawString();
            return 0;
        }
        
        private void UpdateLinesRawString()
        {
            for (int i = 0; i < Lines.Count; i++)
            {
                if (Lines[i].GetType().GetInterfaces().Contains(typeof(IField)))
                {
                    LinesRawString[i] = (Lines[i] as IField).GetString();
                }
                else if (Lines[i].GetType() == typeof(Line))
                {
                    LinesRawString[i] = (Lines[i] as Line).GetString();
                }
                else
                {
                    LinesRawString[i] = (Lines[i] as UNDEFINED).GetString();
                }
            }
        }
    }
}
