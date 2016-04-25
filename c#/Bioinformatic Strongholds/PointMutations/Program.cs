using System;
using System.IO;

namespace PointMutations
{
	class MainClass
	{
		// this method returns the hamming distance in two DNA strands
		public static int HammingDistance(string A, string B)
		{
			// get the length of the DNA strand (a=b)
			int len = A.Length;
			// init counter
			int count = 0;
			// loop through each char
			for (int i=0; i<len; ++i) 
			{
				// if the current DNA nucleotide are different
				// increment counter
				if (A [i] != B [i])
					count++;
			}

			// return counter
			return count;

		}
		public static void Main (string[] args)
		{
			// open file with read access
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Bioinformatic Strongholds/PointMutations/data.txt",
			                          FileMode.Open, FileAccess.Read);

			// using a stream reader on the file
			using (var reader = new StreamReader(file)) 
			{
				// get the two DNA strands
				string a = reader.ReadLine ();
				string b = reader.ReadLine ();
				// output the Hamming Distance on the 2 DNA strands
				Console.WriteLine (HammingDistance (a, b));
			}
		}
	}
}
