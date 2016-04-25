using System;
using System.IO;

namespace CountDNA
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			// open file, with access of read only
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Bioinformatic Strongholds/CountDNA/data.txt", 
			                           FileMode.Open, FileAccess.Read);

			// using the reader, open a stream reader on the file
			using (var reader = new StreamReader(file)) 
			{
				// get the line, put into a string
				string line = reader.ReadLine ();
				// init counter variables to 0
				int A = 0, C = 0, G = 0, T = 0;

				// for each char in the string
				foreach (char c in line)
				{
					// increment appropriate DNA
					switch (c) 
					{
					case 'A':
						A++;
						break;
					case 'C':
						C++;
						break;
					case 'G':
						G++;
						break;
					case 'T':
						T++;
						break;
					}
				}

				// write out to console the count of each Nucleotide
				Console.WriteLine ("{0} {1} {2} {3}", A, C, G, T);
			}
		}
	}
}
