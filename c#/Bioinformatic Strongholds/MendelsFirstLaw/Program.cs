using System;
using System.IO;
using System.Collections.Generic;

namespace MendelsFirstLaw
{
	class MainClass
	{
		/*
		 * 	Helper method that returns the Probability of picked two
		 * 	that are the same allele
		 */ 
		public static double SameAlleles(double allele, double total)
		{
			return (allele / total) * (allele - 1) / (total - 1);
		}

		/*
		 * 	Helper methat that returns the probabilty of picking two
		 * 	that are of different alleles.  Times 2, because the way
		 * 	the probability tree worked out
		 */ 
		public static double DifferentAlleles(double alleleA, double alleleB, double total)
		{
			return 2 * (alleleA / total) * (alleleB / (total - 1));
		}


		public static void Main (string[] args)
		{
			// open the file containing the test data
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Bioinformatic Strongholds/MendelsFirstLaw/data.txt",
			                          FileMode.Open, FileAccess.Read);

			// use a stream reader on the file
			using (var reader = new StreamReader(file))
			{
				// get the first line, Homozygous dominant, Heterozygous, and Homozygous recessive
				string line = reader.ReadLine ();
				// break alleles into an array
				double[] tokens = new List<double> (Array.ConvertAll (line.Split (' '), double.Parse)).ToArray ();

				// get the alleles
				double numAA = tokens [0];
				double numAa = tokens [1];
				double numaa = tokens [2];
				// total # of alleles (for math!)
				double total = numAA + numAa + numaa;

				// get te probability of each posible outcome:

				double probAA_AA = SameAlleles(numAA, total);

				double probAA_Aa = DifferentAlleles (numAA, numAa, total);

				double probAA_aa = DifferentAlleles (numAA, numaa, total);

				double probAa_Aa = SameAlleles (numAa, total);

				double probAa_aa = DifferentAlleles (numAa, numaa, total);

				double probaa_aa = SameAlleles (numaa, total);

				// the total chance of picking 2 organisms from the
				// pool and having the offspring produce the dominant
				// gene
				double tot = probAA_AA + probAA_Aa + probAA_aa 
					+ probAa_Aa * (0.75) + probAa_aa * (0.5);

				Console.WriteLine ("Total probabilty {0}", tot);
			}
		}
	}
}
