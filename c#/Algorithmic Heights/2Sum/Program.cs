using System;
using System.IO;
using System.Collections.Generic;

namespace Sum
{
	class MainClass
	{

		public static void FindValues(List<int> A)
		{
			int size = A.Count;

			for (int i=0; i<size; ++i)
			{
				for (int j=0; j<size; ++j)
				{
 					int a = A [i];
					int b = A [j];

					if (a == -b)
					{
						Console.WriteLine ("{0} {1}", i + 1, j + 1);
						return;
					}
				}
			}
			Console.WriteLine (-1);
		}

		public static void Main (string[] args)
		{
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/2Sum/data.txt",
			                          FileMode.Open, FileAccess.Read);

			using (var reader = new StreamReader(file))
			{
				string line = reader.ReadLine ();
				List<int> arrInfo = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse));
				int arrays = arrInfo [0];
				int size = arrInfo [1];

				for (int i=0; i<arrays; ++i)
				{
					string list = reader.ReadLine();
					List<int> tokens = new List<int> (Array.ConvertAll (list.Split (' '), int.Parse));

					FindValues (tokens);


				}
			}
		}
	}
}
