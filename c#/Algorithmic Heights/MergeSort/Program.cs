using System;
using System.IO;

namespace MergeSort
{
	class Merge
	{
		int [] A;
		int [] b;
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
			}
		}
	}
}
