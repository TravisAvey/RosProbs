using System;
using System.IO;
using System.Collections.Generic;

namespace InsertionSort
{
	class MainClass
	{
		public static int InsertionSort(List<int> A, int size)
		{
			return 0;
		}
		public static void Main (string[] args)
		{
			// /home/travis/GitHub/RosProbs/c#/Algorithmic Heights/InsertionSort/InsertionSort
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/InsertionSort/InsertionSort/data.txt", 
			                           FileMode.Open, FileAccess.Read);
			int size;
			List<int> A;

			using (var reader = new StreamReader(file)) 
			{
				string line = reader.ReadLine ();
				size = int.Parse (line);

				line = reader.ReadLine ();
				A = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse));
			}

			Console.WriteLine ("array size: {0}", size);
			foreach (int i in A)
				Console.Write ("{0} ", i);
		}
	}
}
