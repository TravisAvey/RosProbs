using System;
using System.IO;
using System.Collections.Generic;

namespace InsertionSort
{
	class MainClass
	{
		/*
		 * 	Insertion Sort O(n^2)
		 * 	Like cards in your hand, sort them
		 */ 
		public static int InsertionSort(List<int> A, int size)
		{
			// init a count
			int count = 0;

			// loop through List, starting at 2nd
			for (int i=1; i<size; ++i) 
			{
				// get the current
				int key = A [i];
				// set k to one less than i
				int k = i - 1;

				// while k is greater than 0 and the key is less than A[K]
				while (k >= 0 && key < A[k]) 
				{
					// swap
					int temp = A [k + 1];
					A [k + 1] = A [k];
					A [k] = temp;

					// decrement k
					k--;
					// increment counter
					count++;
				}
			}
			// return the number of swaps
			return count;
		}
		public static void Main (string[] args)
		{

			// open file stream, open mode and read only access
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/InsertionSort/InsertionSort/data.txt", 
			                           FileMode.Open, FileAccess.Read);

			// variables to hold the size and declare List
			int size;
			List<int> A;

			// using a stream reader on the prev opened file
			using (var reader = new StreamReader(file)) 
			{
				// get the first line, it's the size
				string line = reader.ReadLine ();
				size = int.Parse (line);

				// second line is the List
				line = reader.ReadLine ();
				// convert to an array: split on each ' ', and parse each datum to an int
				A = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse));
			}

			// output the nummber of swaps in an insertion sort.  12 in this instance
			Console.WriteLine ("{0}", InsertionSort (A, size));
		}
	}
}
