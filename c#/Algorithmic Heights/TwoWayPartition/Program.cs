using System;
using System.IO;
using System.Collections.Generic;

/*
 *  This program is the start of the Quick Sort Algorithm
 * 	It starts of with a partition.  Take the first element
 * 	and partition the rest of the array base on that value.
 * 	
 * 	Given array [7, 1, 9, 5, 4, 8]
 * 	The first partition would be: [1, 5, 4, 7, 9, 8]
 * 	
 * 	It places everything less than first ele in front and
 * 	everything greater than it behind it in the array
 */ 
namespace TwoWayPartition
{
	class MainClass
	{
		public static void Partition(int[] A, int size)
		{
			int[] arr = new int[size];

			int i = 0;
			while (i < size)
			{
				if (A [0] >= A [i])
					arr [i++] = A [i];
			}

			while (i < size)
			{
				if (A [0] < A [i])
					arr [i++] = A [i];
			}

			foreach (int a in arr)
				Console.WriteLine ("{0} ", a);
		}

		public static void Main (string[] args)
		{
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/TwoWayPartition/data.txt",
			                          FileMode.Open, FileAccess.Read);

			using (var reader = new StreamReader(file))
			{
				int size = int.Parse(reader.ReadLine ());
				string line = reader.ReadLine ();
				int[] A = new List<int> (Array.ConvertAll(line.Split(' '), int.Parse)).ToArray();

				Partition (A, size);

			}
		}
	}
}
