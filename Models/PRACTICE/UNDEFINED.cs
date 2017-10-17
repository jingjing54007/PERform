using PERform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERform.Models.PRACTICE
{
    class UNDEFINED : IPRACTICE
    {
        public UNDEFINED(string line)
        {
            Line = line;
        }

        private string Line { get; }

        public string GetString()
        {
            return Line;
        }
    }
}
