using System;
using System.IO;
using System.Collections.Generic;

namespace MendelsFirstLaw
{
	class MainClass
	{
		public static double AAandAA(double AA, double total)
		{
			return (AA / total) * (AA - 1) / (total - 1);
		}
		public static void Main (string[] args)
		{
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Bioinformatic Strongholds/MendelsFirstLaw/data.txt",
			                          FileMode.Open, FileAccess.Read);

			using (var reader = new StreamReader(file))
			{
				string line = reader.ReadLine ();
				double[] tokens = new List<double> (Array.ConvertAll (line.Split (' '), double.Parse)).ToArray ();

				double numAA = tokens [0];
				double numAa = tokens [1];
				double numaa = tokens [2];
				double total = numAA + numAa + numaa;

				double probAA_AA = AAandAA(numAA, total);
				Console.WriteLine (probAA_AA);
			}
		}
	}
}
