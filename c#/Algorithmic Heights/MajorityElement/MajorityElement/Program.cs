using System;
using System.IO;
using System.Collections.Generic;

namespace MajorityElement
{
	class MajEle
	{
		/*
		 * 	Insertion Sort
		 */ 
		public static void InsertionSort(List<int> A, int size)
		{
			int i, j, key;

			// loop through each element, starting at 2nd
			for (i=1; i<size; ++i) 
			{
				// set the current element
				key = A [i];
				// set j as prev i index
				j = i - 1;

				// store current j'th ele into A[j+1], while
				// j is greater than 0 and the current is less than
				// A[j]
				while (j >= 0 && key < A[j])
					A [j + 1] = A [j--];

				// complete the swap
				A [j + 1] = key;
			}
		}

		/*
		 * 	Method gets the count of the of the element (x) of
		 * 	list
		 */ 
		public static int GetCount(List<int> A, int size, int x)
		{
			// gets the index of first element
			int first = FindIndex (A, size, x, true);
			// gets the index of last element
			int last = FindIndex (A, size, x, false);
			// count of the number of elements
			int count = last - first + 1;

			// we only want the count that is at least size / 2
			if (count > size / 2)
				return count;
			else
				return -1;
		}

		/*
		 * 	This method finds the index (first or last) of the value (x)
		 * 	in the List
		 */ 
		private static int FindIndex(List<int> A, int size, int x, bool first)
		{
			// variables
			int lo = 0, hi = size - 1, result = -1;

			// while the lo is less than or equal to hi
			while (lo <= hi)
			{
				// get the current mid point
				int mid = (lo + hi) / 2;

				// if the midpoint is the value
				if (A [mid] == x) 
				{
					// set the result
					result = mid;

					// if we are looking for first, search first 1/2
					if (first)
						hi = mid - 1;
					// else we are looking for last, search last 1/2
					else
						lo = mid + 1;

				}
				// if x is less, search first half; else search last 1/2
				else if (x < A [mid])
					hi = mid - 1;
				else
					lo = mid + 1;
			}
			// return the result, which will be either the first or last index of the value
			return result;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			// new file string for file: mode open, and read access only
			FileStream file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/MajorityElement/MajorityElement/data.txt",
			                                  FileMode.Open, FileAccess.Read);
			// vars to hold number of arrays and size of each
			int arrays, size;

			// using the stream reader on the opened file
			using (var reader = new StreamReader(file)) 
			{
				// string to get the first line
				string line = reader.ReadLine ();

				// break up first line into an List, parsing into an int
				List<int> tokens = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse));
				// num of arrays is first
				arrays = tokens [0];
				// size of each array is second
				size = tokens [1];


				// while we can read a line from the reader
				while ((line = reader.ReadLine()) != null)
				{
					// each line is a List; parse each number separator is ' '
					List<int> A = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse));

					// sort the array
					MajEle.InsertionSort (A, size);

					// 2 variables to hold the highest and which has the most
					int hi = -1, most = -1;

					// loop through each element in the current List
					for (int i=0; i<size; ++i) 
					{
						// get the count of current element
						int x = MajEle.GetCount (A, size, A [i]);

						// if x is greater than prev hi
						if (x > hi) 
						{
							// new hi && new most
							hi = x;
							most = A [i];
						}
					}
					// output the majority element in each List
					Console.Write ("{0} ", most);

				}
			}
		}
	}
}
