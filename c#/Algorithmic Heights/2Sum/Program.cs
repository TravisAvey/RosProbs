using System;
using System.IO;
using System.Collections.Generic;

namespace Sum
{
	class MainClass
	{

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

		}

		public static int BinarySearch(int [] A, int size, int val)
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

		static void FindValues (int size, int[] tokens, Dictionary<int, int> values)
		{
			for (int i = 0; i < size; ++i) 
			{
				int n = BinarySearch (tokens, size, -tokens [i]);

				if (n == -1) 
				{
					Console.WriteLine (-1);
					return;
				}
				int a = values [tokens [i]];
				int b = values [tokens [n-1]];
				Console.WriteLine("{0} {1}",a, b);
			}

		}


		public static void Main (string[] args)
		{
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/2Sum/data.txt",
			                          FileMode.Open, FileAccess.Read);

			using (var reader = new StreamReader(file))
			{
				string line = reader.ReadLine ();
				List<int> arrInfo = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse));
				int arrays = arrInfo [0];
				int size = arrInfo [1];
				int[] tokens;
				Dictionary<int, int> values;

				for (int i=0; i<arrays; ++i)
				{
					string list = reader.ReadLine();
					tokens = new List<int>(Array.ConvertAll (list.Split (' '), int.Parse)).ToArray();
					values = new Dictionary<int, int> ();

					int n = 1;
					foreach (int val in tokens)
						values [val] = n++;

					// sort array
					Merge merge = new Merge (tokens, size);
					merge.MergeSort ();


					FindValues (size, tokens, values);


				}
			}
		}
	}
}
