using System;

namespace PERform.Utilities
{
    public static class ExtensionMethods
    {

        /// <summary>
        /// Returns index of N-th occurance of character in input string
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="character">Character to search for</param>
        /// <param name="n">Which occurance index</param>
        /// <returns>Index of N-th occurance</returns>
        public static int GetNthIndex(this string input, char character, int n)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == character)
                {
                    count++;
                    if (count == n)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}
