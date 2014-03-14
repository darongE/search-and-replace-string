using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP
{
    // This is an implementation of the Knutt Morris Pratt algorithm
    // to search for a pattern on a text string

    // I also added a method to replace all the occurences of a pattern
    // for another string 

    public class KnuttMorrisPratt
    {
        private int[] calculateOverlaps(String pattern)
        {
            int m = pattern.Length;
            int[] overlaps_arr = new int[m];

            if (m > 0)
            {
                overlaps_arr[0] = 0; // the first element doesn't have any suffix

                char c;
                int overlap;
                for (int j = 1; j < m; j++)
                {
                    c = pattern[j];
                    overlap = overlaps_arr[j - 1]; //get the previous overlap

                    while (pattern[overlap] != c && overlap != 0)
                    {
                        overlap = overlaps_arr[overlap - 1];
                    }

                    if (pattern[overlap] == c)
                        overlaps_arr[j] = overlap + 1;
                    else
                        overlaps_arr[j] = 0;
                }

                Console.WriteLine(String.Join(",", overlaps_arr));
            }
            return overlaps_arr;
        }

        private int[] calculateReplacements(String text, String pattern, int[] overlaps)
        {
            List<int> replacementsIdxs = new List<int>();

            int i = 0; // index for the text
            int j = 0; // index for the pattern
            int k = 0;

            int m = pattern.Length;
            int n = text.Length;
            while (n - k >= m)
            {
                while (j < m && text[i] == pattern[j]) // while searching for a pattern
                {
                    i++; j++;
                }

                if (j == m)
                {
                    replacementsIdxs.Add(k); // add the index of the beginning of the sucessfull matching with the pattern
                }

                if (j > 0 && overlaps[j - 1] > 0)
                {
                    k = i - overlaps[j - 1]; // re update the index representing the beginning of the comparison
                }
                else
                {
                    if (i == k)
                    {
                        i++;
                    }
                    k = i ;
                }

                if (j > 0)
                {
                    j = overlaps[j - 1];
                }

            }

            return replacementsIdxs.ToArray();
        }


        private String createStringWithReplacement(String originalStr, String replacement, int[] replacementsIdxs)
        {
            String new_str = "";

            int n = originalStr.Length;
            int m = replacement.Length;

            int i = 0;
            while (i < n)
            {
                if (replacementsIdxs.Contains(i))
                {
                    new_str += replacement;
                    i += m;
                }
                else
                {
                    new_str += originalStr[i];
                    i++;
                }
            }

            return new_str;
        }

        // this is the method to be called to replace the string
        public String replacePatternInString(String text, String pattern, String replacement)
        {
            int[] overlaps = calculateOverlaps(pattern);
            int[] replacementsIdxs = calculateReplacements(text, pattern, overlaps);

            return createStringWithReplacement(text, replacement, replacementsIdxs);
        }

    }
}