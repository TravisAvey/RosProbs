using System;
using System.IO;
using System.Collections.Generic;

namespace MendelsFirstLaw
{
	class MainClass
	{
		public static double SameAlleles(double allele, double total)
		{
			return (allele / total) * (allele - 1) / (total - 1);
		}

		public static double DifferentAlleles(double alleleA, double alleleB, double total)
		{
			return 2 * (alleleA / total) * (alleleB / (total - 1));
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

				double probAA_AA = SameAlleles(numAA, total);
				Console.WriteLine ("Probability of AA and AA {0}", probAA_AA);

				double probAA_Aa = DifferentAlleles (numAA, numAa, total);
				Console.WriteLine ("Probability of AA and Aa {0}", probAA_Aa);

				double probAA_aa = DifferentAlleles (numAA, numaa, total);
				Console.WriteLine ("Probability of AA and aa {0}", probAA_aa);

				double probAa_Aa = SameAlleles (numAa, total);
				Console.WriteLine ("Probability of Aa and Aa {0}", probAa_Aa);

				double probAa_aa = DifferentAlleles (numAa, numaa, total);
				Console.WriteLine ("Probability of AA and aa {0}", probAa_aa);

				double probaa_aa = SameAlleles (numaa, total);
				Console.WriteLine ("Probability of aa and aa {0}", probaa_aa);

				double tot = probAA_AA + probAA_Aa + probAA_aa + probAa_Aa + probAa_aa + probaa_aa;
				Console.WriteLine ("Total probabilty {0}", tot);
			}
		}
	}
}
