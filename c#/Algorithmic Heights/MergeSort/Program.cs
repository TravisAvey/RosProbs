using System;
using System.IO;

namespace MergeSort
{
	class Merge
	{
		int [] A;
		int size;

		public Merge(int[] A, int size)
		{
			this.A = A;
			this.size = size;
		}

		public void MergeSort()
		{
			mSort (0, size - 1);
		}

		private void mSort(int lo, int hi)
		{
			if (lo < hi)
			{
				int mid = (lo + hi) / 2;
				mSort (lo, mid);
				mSort (mid + 1, hi);
				merge (lo, mid, hi);

			}
			return;
		}

		private void merge(int lo, int mid, int hi)
		{
			int[] b = new int[size];
			for (int n = 0; n < size; ++n)
				b [n] = A [n];

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
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/MergeSort/data.txt",
			                          FileMode.Open, FileAccess.Read);


			using (var reader = new StreamReader(file))
			{
				int n = int.Parse (reader.ReadLine ());

				int[] a = new int[n];
				string line = reader.ReadLine ();
				a = Array.ConvertAll (line.Split (' '), int.Parse);

				Merge merge = new Merge (a, n);
				merge.MergeSort ();
				merge.Print ();
			}
		}
	}
}
