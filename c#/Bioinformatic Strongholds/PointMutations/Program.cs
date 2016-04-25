using System;
using System.IO;

namespace PointMutations
{
	class MainClass
	{
		public static int HammingDistance(string A, string B)
		{
			int len = A.Length;
			int count = 0;
			for (int i=0; i<len; ++i) 
			{
				if (A [i] != B [i])
					count++;
			}

			return count;

		}
		public static void Main (string[] args)
		{
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Bioinformatic Strongholds/PointMutations/data.txt",
			                          FileMode.Open, FileAccess.Read);

			using (var reader = new StreamReader(file)) 
			{
				string a = reader.ReadLine ();
				string b = reader.ReadLine ();
				Console.WriteLine (HammingDistance (a, b));
			}
		}
	}
}
