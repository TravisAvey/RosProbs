using System;
using System.IO;
using System.Collections.Generic;

namespace MotifDNA
{
	class MainClass
	{
		/*
		 *	This method will find the motifs from the given motif string
		 *	on the given dna string.  It will return a List<int> of those
		 *	indices.
		 */ 
		private static List<int> FindMotifs(string dna, string motif)
		{
			// create a list to hold the results
			List<int> results = new List<int> ();

			// store the lengths of the strings
			int dnaLen = dna.Length;
			int motLen = motif.Length;

			// loop through each DNA nucleotide
			for (int i=0; i<dnaLen - motLen; ++i)
			{
				// if the next motif-length dna matches the motif, add to list
				if (dna.Substring (i, motLen) == motif)
					results.Add (i + 1);
			}

			// return the list of results
			return results;
		}

		public static void Main (string[] args)
		{
			// open the file with read only access
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Bioinformatic Strongholds/MotifDNA/data.txt",
			                          FileMode.Open, FileAccess.Read);

			// using a strem reader on the file
			using (var reader = new StreamReader(file))
			{
				// get the first and second line, DNA and motif
				string DNA = reader.ReadLine ();
				string motif = reader.ReadLine ();

				// get the list of motifs from the DNA
				List<int> motifs = FindMotifs (DNA, motif);

				// print out the index of each motif
				foreach (int i in motifs)
					Console.Write ("{0} ", i);

			}
		}
	}
}
