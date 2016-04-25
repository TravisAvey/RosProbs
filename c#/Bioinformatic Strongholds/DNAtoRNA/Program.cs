using System;
using System.IO;

namespace DNAtoRNA
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// open file stream with read only
			FileStream file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Bioinformatic Strongholds/DNAtoRNA/data.txt", 
			                                  FileMode.Open, FileAccess.Read);

			// use the stream reader on the file
			using (var reader = new StreamReader(file)) 
			{
				// get the line of DNA
				string line = reader.ReadLine ();
				// string to hold result
				string result = "";

				// for each character in the string
				foreach (char c in line) 
				{
					// if the char is a 'T', replace with 'U', else append normal char
					if (c == 'T')
						result += 'U';
					else
						result += c;
				}

				// write out both to visualize the results
				Console.WriteLine (line);
				Console.WriteLine (result);
			}
		}
	}
}
