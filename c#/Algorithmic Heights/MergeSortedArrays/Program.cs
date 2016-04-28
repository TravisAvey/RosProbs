using System;
using System.IO;
using System.Collections.Generic;

namespace MergeSortedArrays
{
	class MainClass
	{
		public static void Merge(int[] A, int[] B, int a, int b)
		{
			// counter variables
			int i = 0;
			int j = 0;
			int k = 0;

			// array to hold merged array
			int [] C = new int[a+b];

			// while we are less than a and b indices
			while (i < a && j < b)
			{
				// if the A ele is <= to B, add to C
				if (A [i] <= B [j])
					C [k++] = A [i++];
				else
					// else, the Bs to C
					C [k++] = B [j++];
			}

			if (i < a)
			{
				// fill out the rest of the array
				for (int m=i; m<a; ++m)
					C [k++] = A [m];
			}
			else
			{
				// fill out the rest of the array
				for (int m=j; m<b; ++m)
					C [k++] = B [m];
			}

			foreach (int x in C)
				Console.Write ("{0} ", x);
		}

		public static void Main (string[] args)
		{
			// open the file
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/MergeSortedArrays/data.txt",
			                           FileMode.Open, FileAccess.Read);

			// using a stream reader on the opened file
			using (var reader = new StreamReader(file))
			{
				// get the size of first array, parse to int
				int aSize = int.Parse(reader.ReadLine ());
				// get the next line, array
				string arr = reader.ReadLine ();
				// convert to an array, parsing on ' ' and parse to int
				int[] A = new List<int> (Array.ConvertAll (arr.Split (' '), int.Parse)).ToArray();
				// repeat above on 2nd array
				int bSize = int.Parse (reader.ReadLine ());
				arr = reader.ReadLine ();
				int[] B = new List<int> (Array.ConvertAll (arr.Split (' '), int.Parse)).ToArray();

				// call Merge on the sorted arrays
				Merge (A, B, aSize, bSize);
			}
		}
	}
}
