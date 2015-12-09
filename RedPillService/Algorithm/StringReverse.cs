using System;
using System.Collections;
using System.Collections.Generic;

namespace RedPillService.Algorithm
{
    public static class StringExtension
    {
        public static string ReverseWords(this string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentNullException("Passed string is empty");
            else
            {
                string reverseString = string.Empty;
                string word = string.Empty;

                var chars = str.ToCharArray();
                List<ArrayList> words = new List<ArrayList>();
                ArrayList addedChars = new ArrayList();
                Char[] reversedChars = new Char[chars.Length];
                int i = 1;
                foreach (char c in chars)
                {
                    if (c != ' ')
                    {
                        addedChars.Add(c);
                    }
                    else
                    {
                        words.Add(new ArrayList(addedChars));
                        addedChars.Clear();
                    }
                    if (i == str.Length)
                    {
                        words.Add(new ArrayList(addedChars));
                        addedChars.Clear();
                    }
                    i++;
                }
                foreach (ArrayList a in words)
                {
                    for (int counter = a.Count - 1; counter >= 0; counter--)
                    {
                        reverseString += a[counter];
                    }
                    if (reverseString.Length < str.Length)
                        reverseString += " ";
                }
                return reverseString;
            }
        }
    }
}