using System;
using System.IO;
using System.Collections.Generic;

namespace BuildHeap
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/BuildHeap/data.txt",
			                          FileMode.Open, FileAccess.Read);

			using (var reader = new StreamReader(file))
			{
				int nodes = int.Parse(reader.ReadLine ());

				string line = reader.ReadLine ();
				int[] tokens = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse)).ToArray ();
			}
		}
	}
}
