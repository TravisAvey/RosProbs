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
		/*
		 * 	The sub routine of Quicksort.  This is a 2 way
		 * 	partition.
		 */ 
		public static void Partition(int[] A, int lo, int hi)
		{
			// variables for positions
			int i = lo;
			int j = hi + 1;
			// var for pivot point
			int v = A [lo];

			while (true)
			{
				// check values for lower than pivot
				while (A[++i] <= v)
					if (i == hi)
						break;

				// checking for values higher than pivot
				while (v < A[--j])
					if (j == lo)
						break;

				// once we are here, i passes j, break out
				if (i >= j)
					break;

				/*
				 * 	From the 2 while loops when we get
				 * 	here, the two values need to be swapped
				 */ 
				Swap (A, i, j);
			}

			// swap the pivot to correct position
			Swap (A, lo, j);

			// save data to file
			PrintToFile (ref A);
		}

		/*
		 * 	helper method to print data to a file for easier
		 * 	answer upload
		 */ 
		private static void PrintToFile(ref int [] A)
		{
			// open a file stream with access of write
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/TwoWayPartition/output.txt",
			                          FileMode.Open, FileAccess.Write);

			// using a stream writer on the file stream
			using (var writer = new StreamWriter(file)) 
			{
				// write each value to the file
				foreach (int a in A)
					writer.Write("{0} ", a);
			}
		}

		/*
		 * 	Helper method to swap 2 values in passed in
		 * 	array.  The values are the indices of array
		 */ 
		private static void Swap(int[] a, int i, int j)
		{
			// perform swap
			int swap = a [i];
			a [i] = a [j];
			a [j] = swap;
		}

		public static void Main (string[] args)
		{
			// open new file stream on file
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/TwoWayPartition/rosalind_par.txt",
			                          FileMode.Open, FileAccess.Read);

			// using a stream reader of the file stream
			using (var reader = new StreamReader(file))
			{
				// get the size of the array
				int size = int.Parse(reader.ReadLine ());
				// get the next line, which is the entire array
				string line = reader.ReadLine ();
				// convert the line into 1st a list, then convert to an array
				int[] A = new List<int> (Array.ConvertAll(line.Split(' '), int.Parse)).ToArray();

				// call sub routine to partition array
				Partition (A, 0, size-1);
			}
		}
	}
}
