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
		public static void Partition(int[] A, int l, int r)
		{
			int p = A [l];
			int i = l + 1;

			for (int j=i; j<r; ++j)
			{
				if (A[j] < p)
				{
					Swap (A, j, i);
					i++;
				}
			}

			Swap (A, l, i-1);

			PrintToFile (ref A);
		}

		private static void PrintToFile(ref int [] A)
		{
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/TwoWayPartition/output.txt",
			                          FileMode.Open, FileAccess.Write);
			using (var writer = new StreamWriter(file)) 
			{
				foreach (int a in A)
					writer.Write("{0} ", a);
			}
		}
		private static void Swap(int[] a, int i, int j)
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
