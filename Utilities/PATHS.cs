using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERform.Utilities
{
    public static class PATHS
    {
        private static string snippetsPath = "Snippets.txt";
        private static string highlightingPath = "HighlightingDefinitions.xshd";


        public static string SnippetsPath { get { return snippetsPath; } }
        public static string HighlightingPath { get { return highlightingPath; } }
    }
}
