using System;
using System.IO;
using System.Collections.Generic;

namespace BuildHeap
{

	class MainClass
	{
		///<summary>
		/// Binary Heap Class: Max Heap
		/// </summary>
		public class MaxHeap
		{
			// private variables
			private int size;
			private int[] mHeap;
			private int pos;

			/// <summary>
			/// Initializes a new instance of the MaxHeap class.
			/// </summary>
			/// <param name="size">size of the array to heap.</param>
			public MaxHeap(int size)
			{
				// sedt the size
				this.size = size;
				// init heap array
				mHeap = new int[size+1];
				// set the 0 index to max int value
				mHeap[0] = int.MaxValue;
				// set the position to 0
				pos = 0;
			}

			/// <summary>
			/// Creates the Heap
			/// </summary>
			/// <param name="A">A array to heapify.</param>
			public void CreateHeap(int [] A)
			{
				// For each item in the array, Insert into Heap
				for (int i=0; i<size; ++i)
					Insert (A [i]);
			}

			/// <summary>
			/// Method to Display the Heap to a file
			/// </summary>
			public void DisplayHeap()
			{
				// open the file to write to
				var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/BuildHeap/output.txt",
				                          FileMode.Open, FileAccess.Write);

				// using a stream writer on the file
				using (var writer = new StreamWriter(file))
				{
					// for each item in the heap, print to the open file
					for (int i=1; i<=size; ++i)
						writer.Write("{0} ", mHeap[i]);
				}
				
			}

			/// <summary>
			/// Helper method that inserts the int at correct place in heap
			/// </summary>
			/// <param name="n">n, int to place into heap.</param>
			private void Insert(int n)
			{
				// initially set the element into heap
				mHeap [++pos] = n;
				// set current position
				int current = pos;

				// while the current is greater than the current's parent
				while (mHeap[current] > mHeap[Parent(current)])
				{
					// swap the current with its parent
					Swap (current, Parent (current));
					// set the current as parent
					current = Parent (current);
				}
			}

			/// <summary>
			/// Helper method to swap the two values
			/// </summary>
			/// <param name="i">i first pos.</param>
			/// <param name="j">j second pos.</param>
			private void Swap(int i, int j)
			{
				// complete the swap
				int temp = mHeap [i];
				mHeap [i] = mHeap [j];
				mHeap [j] = temp;
			}

			/// <summary>
			/// Gets the Parent of passed in index
			/// </summary>
			/// <param name="i">The index.</param>
			private int Parent(int i) { return i / 2; }

			/// <summary>
			/// Gets the right child of passed in index
			/// </summary>
			/// <param name="i">The index.</param>
			private int RightChild(int i) { return 2 * i; }

			/// <summary>
			/// Gets the left child of passed in index
			/// </summary>
			/// <param name="i">The index.</param>
			private int LeftChild(int i) { return (2 * i) + 1; }
		}


		public static void Main (string[] args)
		{
			// opens a file to read
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/BuildHeap/rosalind_hea.txt",
			                          FileMode.Open, FileAccess.Read);

			// use a stream reader on the file
			using (var reader = new StreamReader(file))
			{
				// get the number of nodes for the heap
				int nodes = int.Parse(reader.ReadLine ());

				// get the array in string
				string line = reader.ReadLine ();
				// parse the string into the array
				int[] tokens = new List<int> (Array.ConvertAll (line.Split (' '), int.Parse)).ToArray ();

				// create the MaxHeap object, passing in # of nodes
				MaxHeap heap = new MaxHeap (nodes);
				// create the heap with the array
				heap.CreateHeap (tokens);
				// display the heap
				heap.DisplayHeap ();
			}
		}
	}
}
