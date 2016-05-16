using System;
using System.IO;
using System.Collections.Generic;

namespace BuildHeap
{
	class MainClass
	{
		public class MaxHeap
		{
			private int size;
			private int[] mHeap;
			private int pos;

			public MaxHeap(int size)
			{
				this.size = size;
				mHeap = new int[size+1];
				mHeap[0] = int.MaxValue;
				pos = 0;
			}

			public void CreateHeap(int [] A)
			{
				for (int i=0; i<size; ++i)
				{
					Insert (A [i]);
				}
			}

			public void DisplayHeap()
			{
				var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/BuildHeap/output.txt",
				                          FileMode.Open, FileAccess.Write);
				using (var writer = new StreamWriter(file))
				{
					for (int i=1; i<=size; ++i)
						writer.Write("{0} ", mHeap[i]);
				}
				
			}

			private void Insert(int n)
			{
				mHeap [++pos] = n;
				int current = pos;

				while (mHeap[current] > mHeap[Parent(current)])
				{
					Swap (current, Parent (current));
					current = Parent (current);
				}
			}

			private void BubbleUp()
			{

			}

			private void Swap(int i, int j)
			{
				int temp = mHeap [i];
				mHeap [i] = mHeap [j];
				mHeap [j] = temp;
			}

			private int Parent(int i) { return i / 2; }

			private int RightChild(int i) { return 2 * i; }

			private int LeftChild(int i) { return (2 * i) + 1; }
		}
		public static void Main (string[] args)
		{
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/BuildHeap/rosalind_hea.txt",
			                          FileMode.Open, FileAccess.Read);

			using (var reader = new StreamReader(file))
			{
				int nodes = int.Parse(reader.ReadLine ());

				string line = reader.ReadLine ();
				int[] tokens = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse)).ToArray ();

				MaxHeap heap = new MaxHeap (nodes);
				heap.CreateHeap (tokens);
				heap.DisplayHeap ();

			}
		}
	}
}
