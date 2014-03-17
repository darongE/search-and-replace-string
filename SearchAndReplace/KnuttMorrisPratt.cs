using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndReplaceNS
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

            int m = pattern.Length;
            int n = text.Length;
            for(i = 0; i < n && m > 0; i++)
            {
                while (j > 0 && text[i] != pattern[j]) // while searching for a match, update with overlap
                    j = overlaps[j];
               
                if (text[i] == pattern[j])
                    j++;

                if (j == m)
                {
                    replacementsIdxs.Add(i - m + 1); // add the index of the beginning of the sucessfull matching with the pattern
                    j = 0; // set the j to zero to avoid patterns inside patterns
                }
            }

            return replacementsIdxs.ToArray();
        }


        private String createStringWithReplacement(String originalStr, String pattern, String replacement, int[] replacementsIdxs)
        {
            String new_str = "";

            int n = originalStr.Length;
            int m = pattern.Length;
            int w = replacement.Length;

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

            return createStringWithReplacement(text, pattern, replacement, replacementsIdxs);
        }

    }
}