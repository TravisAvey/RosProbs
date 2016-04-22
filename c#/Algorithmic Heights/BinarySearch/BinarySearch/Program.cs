using System;
using System.IO;
using System.Collections.Generic;

namespace BinarySearch
{
	class MainClass
	{
		/*
		 * 	Binary Search Method.  Pass in sorted list, size of list
		 *  and the value being searched for.  It will return the index
		 *  + 1 of the value if found, else it will return -1
		 */ 
		public static int BinarySearch(List<int> A, int size, int val)
		{
			// initially set the lo and hi
			int lo = 0, hi = size - 1;

			// while lo is atleast still less than hi
			while (lo <= hi) {
				// calculate the mid point
				int mid = (lo + hi) / 2;

				// if the mid is less than val, then we search the upper half of array
				if (A [mid] < val)
					lo = mid + 1;
				// if the mid is greater, then we search the lower half
				else if (A [mid] > val)
					hi = mid - 1;
				// else found it, return the mid (+1)
				else
					return mid + 1;
			}
			// if we get to this point, it is not in the array; return -1
			return -1;
		}

		public static void Main (string[] args)
		{
			// open a file stream to the file.. had to do entire file location
			// set flags to Open and Read only
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/BinarySearch/BinarySearch/data.txt", 
			                           FileMode.Open, FileAccess.Read);

			// variables for size and generic Lists to hold the data
			int aSize, bSize;
			List<int> A;
			List<int> B;

			// using the reader as a stream reader on the file we just opened
			using (var reader = new StreamReader(file)) 
			{
				// get the first line
				string line = reader.ReadLine ();
				// parse it to an int, for the size of A 
				aSize = int.Parse (line);

				// get next line
				line = reader.ReadLine ();
				// parse to int, the size of B
				bSize = int.Parse (line);

				// get next line
				line = reader.ReadLine ();
				// init A to a new int List. Parse the line as ints and split up on ' ' and convert to array
				A = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse));

				line = reader.ReadLine ();
				B = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse));
			}

			// loop through each item in B
			foreach (int i in B) 
			{
				// write out to console the results of the Binary Search
				Console.Write ("{0} ", BinarySearch (A, aSize, i));
			}
		}
	}
}
