using System;
using System.IO;
using System.Collections.Generic;

/*
 *  This program is the start of the Quick Sort Algorithm
 * 	It starts of with a partition.  Take the first element
 * 	and partition the rest of the array base on that value.
 * 	
 * 	Given array [7, 1, 9, 5, 4, 8]
 * 	The first partition would be: [1, 5, 4, 7, 9, 8]
 * 	
 * 	It places everything less than first ele in front and
 * 	everything greater than it behind it in the array
 */ 
namespace TwoWayPartition
{
	class MainClass
	{
		public static void Partition(int[] A, int lo, int hi)
		{
			int i = lo;
			int j = hi + 1;
			int v = A [0];

			while (true)
			{
				while (Less(A[++i], v))
					if (i == hi)
						break;

				while (Less(v, A[--j]))
				       if (j == lo)
				       	break;

				if (i >= j)
					break;

			//	Exch (A, i, j);
			}

			Exch (A, lo, j);

			foreach (int a in A)
				Console.Write ("{0} ", a);
		}

		private static bool Less(int v, int w)
		{
			return v.CompareTo (w) < 0;
		}

		private static void Exch(int[] a, int i, int j)
		{
			int swap = a [i];
			a [i] = a [j];
			a [j] = swap;
		}

		public static void Main (string[] args)
		{
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/TwoWayPartition/data.txt",
			                          FileMode.Open, FileAccess.Read);

			using (var reader = new StreamReader(file))
			{
				int size = int.Parse(reader.ReadLine ());
				string line = reader.ReadLine ();
				int[] A = new List<int> (Array.ConvertAll(line.Split(' '), int.Parse)).ToArray();

				Partition (A, 0, size-1);

			}
		}
	}
}
