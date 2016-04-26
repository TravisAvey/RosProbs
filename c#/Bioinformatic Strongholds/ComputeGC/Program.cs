using System;
using System.IO;

namespace ComputeGC
{
	class MainClass
	{
		/*
		 * 	Method calculates GC of the given DNA string
		 */ 
		private static double calcGC(string dna)
		{
			// init a counter and the number of DNA nucleotides
			int count = 0;
			int len = dna.Length;

			// loop through DNA, check if G or C, add to count if so
			for (int i=0; i<len; ++i)
				if (dna [i] == 'G' || dna [i] == 'C')
					count++;

			// return the % of GC content
			return ( (double) count ) / len * (100.0);
		}

		public static void Main (string[] args)
		{
			// open file containing the FASTA DNA information
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Bioinformatic Strongholds/ComputeGC/data.txt",
			                          FileMode.Open, FileAccess.Read);

			// using a stream reader on the file
			using (var reader = new StreamReader(file))
			{
				// init variables to hold the most GC content
				double most = 0;
				string mFasta = "";

				// while the reader still has lines to read
				while (reader.Peek() > 0)
				{
					// get the FASTA and DNA
					string fasta = reader.ReadLine ();
					string dna = reader.ReadLine ();
					dna += reader.ReadLine ();

					// the FASTA has a > at first char, remove it
					fasta = fasta.Substring (1);

					// get the gc content %
					double gcConent = calcGC (dna);

					// if current is more than the most
					if (gcConent > most)
					{
						// save the most GC content % and name
						most = gcConent;
						mFasta = fasta;
					}
				}

				// output the title and GC % of the most of given DNA strings
				Console.WriteLine (mFasta);
				Console.WriteLine (most);
			}


		}
	}
}
