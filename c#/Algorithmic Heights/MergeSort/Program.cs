using System;
using System.IO;

namespace MergeSort
{
	/*
	 * 	Merge Sort class
	 */ 
	class Merge
	{
		// private variables: array and size of array
		int [] A;
		int size;

		// public constructor, pass in array to sort and its size
		public Merge(int[] A, int size)
		{
			// set private variables
			this.A = A;
			this.size = size;
		}

		// public interface to Merge Sort the array
		public void MergeSort()
		{
			// call private method to Merge Sort (-1 on size or off by one)
			mSort (0, size - 1);
		}

		/*
		 * 	The divide and conquer part.
		 * 	Recursively call itself, to break
		 * 	the problem up into smaller and smaller
		 * 	pieces.  Then call the merge sub routine
		 * 	on the smaller parts
		 */ 
		private void mSort(int lo, int hi)
		{
			// if lo is still less than hi (base case when higher)
			if (lo < hi)
			{
				// calc the current mid point
				int mid = (lo + hi) / 2;
				// break the problem up: first half / second half
				mSort (lo, mid);
				mSort (mid + 1, hi);
				// call sub routine to merge the small pieces together
				merge (lo, mid, hi);

			}
			return;
		}

		/*
		 * 	Sub routine merge, params: lo, mid, hi of
		 * 	current 'smaller' piece
		 */ 
		private void merge(int lo, int mid, int hi)
		{
			// create new array for temp
			int[] b = new int[size];
			// copy array over
			for (int n = 0; n < size; ++n)
				b [n] = A [n];

			// counter variables
			int i = lo;
			int j = mid + 1;
			int k = lo;

			// while the lo is less than mid point
			// and mid+1 is less than hi point
			while(i <= mid && j <= hi)
			{
				// if the b[i] is less than the b[j]
				// that means, the i-th element is
				// to be copied over to that i pos
				// else they are out of order,
				// copy the jth pos
				if (b[i] <= b[j])
					A[k++] = b[i++];
				else
					A[k++] = b[j++];
			}

			// copy b -> A, in correct order
			// after the other elements are already
			// copied over from above while loop
			while (i <= mid)
				A[k++] = b[i++];
			while (j <= hi)
				A[k++] = b[j++];
		}

		/*
		 * 	Public method to Print current array.
		 * 	Will need to change to print to a file
		 * 	if the array is large
		 */ 
		public void Print()
		{
			foreach (int n in A)
				Console.Write ("{0} ", n);
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			// open file stream, mode : open, access : read
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/MergeSort/data.txt",
			                          FileMode.Open, FileAccess.Read);


			// using a stream reader on the open file
			using (var reader = new StreamReader(file))
			{
				// get the size of the un sorted array
				int n = int.Parse (reader.ReadLine ());

				// create an array with the size
				int[] a = new int[n];

				// get the next line (the array)
				string line = reader.ReadLine ();

				// convert the string, splitting on ' ', parse to int, into an array
				a = Array.ConvertAll (line.Split (' '), int.Parse);

				// create new object of Merge
				Merge merge = new Merge (a, n);
				// call method to Merge Sort
				merge.MergeSort ();
				// print out sorted array
				merge.Print ();
			}
		}
	}
}
