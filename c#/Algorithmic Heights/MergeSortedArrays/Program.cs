using System;
using System.IO;
using System.Collections.Generic;

namespace MergeSortedArrays
{
	class MainClass
	{
		public static void Merge(List<int> A, int sizeA, List<int> B, int sizeB)
		{
			int i = 0, j = 0, k = 0;

			List<int> C = new List<int> ();
			C.Capacity = sizeA + sizeB;

			while (i < sizeA && j < sizeB)
			{
				if (A [i] <= B [j])
					C [k++] = A [i++];
				else
					C [k++] = B [j++];
			}

			if (i < sizeA)
			{
				for (int m=i; m<sizeA; ++m)
					C [k++] = A [m];
			}
			else
			{
				for (int m=j; m<sizeB; ++m)
					C [k++] = B [m];
			}

			foreach (int x in C)
				Console.Write ("{0} ", x);
		}

		public static void Main (string[] args)
		{
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/MergeSortedArrays/data.txt",
			                           FileMode.Open, FileAccess.Read);

			using (var reader = new StreamReader(file))
			{
				int aSize = int.Parse(reader.ReadLine ());
				string arr = reader.ReadLine ();
				List<int> A = new List<int> (Array.ConvertAll (arr.Split (' '), int.Parse));
				int bSize = int.Parse (reader.ReadLine ());
				arr = reader.ReadLine ();
				List<int> B = new List<int> (Array.ConvertAll (arr.Split (' '), int.Parse));



				Merge (A, aSize, B, bSize);
			}
		}
	}
}
