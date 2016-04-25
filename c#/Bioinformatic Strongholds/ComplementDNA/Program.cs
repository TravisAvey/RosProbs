using System;
using System.IO;

namespace ComplementDNA
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// open file with read only access
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Bioinformatic Strongholds/ComplementDNA/data.txt",
			                          FileMode.Open, FileAccess.Read);

			// using a stream reader on the opened file
			using (var reader = new StreamReader(file)) 
			{
				// get the line of DNA -> string
				string line = reader.ReadLine ();
				// get the complement DNA
				Complement (line);
			}
		}

		/*
		 * 	This method gets the complement DNA strand.
		 * 	A <=> T, G <=> C
		 */ 
		public static void Complement(string DNA)
		{
			// complement string
			string comp = "";
			// for each of the chars in the string
			foreach (char c in DNA) 
			{
				// do the complement
				if (c == 'A')
					comp += 'T';
				else if (c == 'T')
					comp += 'A';
				else if (c == 'G')
					comp += 'C';
				else if (c == 'C')
					comp += 'G';
			}
			// write out the reversed DNA strand
			Console.WriteLine (Reverse(comp));

		}

		/*
		 * 	This method Reverses a string
		 */ 
		private static string Reverse(string s)
		{
			// make the string into a char array
			char[] arr = s.ToCharArray ();
			// reverse the char array
			Array.Reverse (arr);
			// return the reversed char array as a string
			return new String (arr);
		}
	}
}
