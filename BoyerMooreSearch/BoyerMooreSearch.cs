using System;
using System.Collections.Generic;

namespace BoyerMooreSearch
{
	class Program
	{
		static int NO_OF_CHARS = 256;

		public static int[] BoyerMooreSearch(string haystack, string needle)
		{
			List<int> occurencePosition = new List<int>();

			// get the lengths
			int haystackLength = haystack.Length;
			int needleLength = needle.Length;


			int[] badMatchTable = new int[NO_OF_CHARS];

			/* Fill the bad character array by calling
			the preprocessing function for given pattern */
			// this is the most important step for this algorithm
			BadCharHeuristic(needle, needleLength, ref badMatchTable);

			int scanPosition = 0;
			while (scanPosition <= (haystackLength - needleLength))
			{
				int last = needleLength - 1;

				while (last >= 0 && needle[last] == haystack[scanPosition + last])
					--last;

				if (last < 0)
				{
					occurencePosition.Add(scanPosition + 1);
					scanPosition += (scanPosition + needleLength < haystackLength) ? needleLength - badMatchTable[haystack[scanPosition + needleLength]] : 1;
				}
				else
				{
					scanPosition += Math.Max(1, last - badMatchTable[haystack[scanPosition + last]]);
				}
			}

			return occurencePosition.ToArray();
		}

		// The preprocessing function for Boyer Moore's bad character Match
		private static void BadCharHeuristic(string needle, int needleLength, ref int[] badMatchTable)
		{
			int i;

			// initialize the badMatchTable to -1
			for (i = 0; i < 256; i++)
				badMatchTable[i] = -1;

			// fill the bad match table with the value of the last occurence of the character
			// eg: if the string has more than 1 occurence of a character fill the occurence 
			// position with the last value
			for (i = 0; i < needleLength; i++)
				badMatchTable[(int)needle[i]] = i;
		}


	}


}
