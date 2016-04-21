using System;
using System.IO;
using System.Collections;

namespace BinarySearch
{
	class MainClass
	{
		public static int BinarySearch(ArrayList A)
		{
			return -1;
		}
		public static void Main (string[] args)
		{
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Algorithmic Heights/BinarySearch/BinarySearch/data.txt", 
			                           FileMode.Open, FileAccess.Read);

			int aSize, bSize;

			using (var reader = new StreamReader(file)) 
			{
				string line = reader.ReadLine ();
				Console.WriteLine (line);
				aSize = int.Parse (line);

				line = reader.ReadLine ();
				Console.WriteLine (line);
				bSize = int.Parse (line);

				line = reader.ReadLine ();
				Console.WriteLine (line);

				line = reader.ReadLine ();
				Console.WriteLine (line);
			}
		}
	}
}
