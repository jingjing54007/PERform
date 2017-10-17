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

            var bitfldPattern = @"\s*bitfld.(byte|word|tbyte|long|quad)\s*\d+";
            var eventfldPattern = @"\s*eventfld.(byte|word|tbyte|long|quad)\s*\d+";
            var setclrfldPattern = @"\s*setclrfld.(byte|word|tbyte|long|quad)\s*\d+";

            foreach (var programLine in programLines)
            {
                if (Regex.IsMatch(programLine, bitfldPattern))
                {
                    Lines.Add(new Bitfld(programLine));
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
                if (line.GetType() == typeof(Bitfld))
                {
                    var bitfld = line as Bitfld;
                    bitfld.SetDescription(bitfld.LowercaseDescription(bitfld.Description).Item1);
                }
            }
            UpdateLinesRawString();
            return 0;
        }
        
        private void UpdateLinesRawString()
        {
            for (int i = 0; i < Lines.Count; i++)
            {
                if (Lines[i].GetType() == typeof(Bitfld))
                {
                    var bitfld = Lines[i] as Bitfld;
                    LinesRawString[i] = bitfld.GetString(bitfld);
                }
                else
                {
                    var undefined = Lines[i] as UNDEFINED;
                    LinesRawString[i] = undefined.GetString();
                }
            }
        }
    }
}
