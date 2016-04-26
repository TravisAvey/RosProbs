using System;
using System.IO;
using System.Collections.Generic;

namespace RNAtoProtein
{

	/*
	 * Translate to RNA class
	 */ 
	class TranslateRNA
	{
		// init map of codons
		private Dictionary<string, char> codon = new Dictionary<string, char> ();
		// private string to hold DNA
		private string RNA;

		// public constructor, pass in DNA and it will init the map
		public TranslateRNA(string RNA)
		{
			// assign the dna string
			this.RNA = RNA;
			// init the codon dictionary
			initCodon ();
		}

		/*
		 * 	Method will translate the DNA to RNA
		 */ 
		public string Translate()
		{
			// get the length of the DNA string
			int len = this.RNA.Length;

			// init RNA string
			string RNAstring = "";

			// loop through the DNA string (-3, and by 3 for each codon)
			for (int i=0; i<len-3;i+=3)
			{
				// get the sub string from current index
				string sub = this.RNA.Substring (i, 3);

				// if we have a stop codon, break out of loop
				if (codon [sub] == 'X')
					break;

				// append codon to RNA string
				RNAstring += codon [sub];
			}

			// return the completed RNA -> Protein string
			return RNAstring;
		}

		/*
		 * 	This method will init the dictionary for all the codons
		 */ 
		private void initCodon()
		{
			codon.Add ("UUU", 'F'); codon.Add ("CUU", 'L'); codon.Add ("AUU", 'I'); codon.Add ("GUU", 'V');
			codon.Add ("UUC", 'F'); codon.Add ("CUC", 'L'); codon.Add ("AUC", 'I'); codon.Add ("GUC", 'V');
			codon.Add ("UUA", 'L'); codon.Add ("CUA", 'L'); codon.Add ("AUA", 'I'); codon.Add ("GUA", 'V');
			codon.Add ("UUG", 'L'); codon.Add ("CUG", 'L'); codon.Add ("AUG", 'M'); codon.Add ("GUG", 'V');
			codon.Add ("UCU", 'S'); codon.Add ("CCU", 'P'); codon.Add ("ACU", 'T'); codon.Add ("GCU", 'A');
			codon.Add ("UCC", 'S'); codon.Add ("CCC", 'P'); codon.Add ("ACC", 'T'); codon.Add ("GCC", 'A');
			codon.Add ("UCA", 'S'); codon.Add ("CCA", 'P'); codon.Add ("ACA", 'T'); codon.Add ("GCA", 'A');
			codon.Add ("UCG", 'S'); codon.Add ("CCG", 'P'); codon.Add ("ACG", 'T'); codon.Add ("GCG", 'A');
			codon.Add ("UAU", 'Y'); codon.Add ("CAU", 'H'); codon.Add ("AAU", 'N'); codon.Add ("GAU", 'D');
			codon.Add ("UAC", 'Y'); codon.Add ("CAC", 'H'); codon.Add ("AAC", 'N'); codon.Add ("GAC", 'D');
			codon.Add ("UAA", 'X'); codon.Add ("CAA", 'Q'); codon.Add ("AAA", 'K'); codon.Add ("GAA", 'E');
			codon.Add ("UAG", 'X'); codon.Add ("CAG", 'Q'); codon.Add ("AAG", 'K'); codon.Add ("GAG", 'E');
			codon.Add ("UGU", 'C'); codon.Add ("CGU", 'R'); codon.Add ("AGU", 'S'); codon.Add ("GGU", 'G');
			codon.Add ("UGC", 'C'); codon.Add ("CGC", 'R'); codon.Add ("AGC", 'S'); codon.Add ("GGC", 'G');
			codon.Add ("UGA", 'X'); codon.Add ("CGA", 'R'); codon.Add ("AGA", 'R'); codon.Add ("GGA", 'G');
			codon.Add ("UGG", 'W'); codon.Add ("CGG", 'R'); codon.Add ("AGG", 'R'); codon.Add ("GGG", 'G');

		}
	}
	class MainClass
	{
		public static void Main (string[] args)
		{
			// open the file
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Bioinformatic Strongholds/RNAtoProtein/data.txt",
			                           FileMode.Open, FileAccess.Read);

			// use a stream reader on the file
			using (var reader = new StreamReader(file))
			{
				// get the DNA 
				string RNA = reader.ReadLine ();

				// create a new RNA object, constructor takes RNA string
				TranslateRNA rna = new TranslateRNA (RNA);

				// output the results of the Translated RNA to Protein
				Console.WriteLine(rna.Translate ());

			}
		}
	}
}
