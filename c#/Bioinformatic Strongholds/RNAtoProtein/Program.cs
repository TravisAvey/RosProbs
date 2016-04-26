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
		private string DNA;

		// public constructor, pass in DNA and it will init the map
		public TranslateRNA(string DNA)
		{
			this.DNA = DNA;
			initCodon ();
		}

		/*
		 * 	Method will translate the DNA to RNA
		 */ 
		public string Translate()
		{
			int len = this.DNA.Length;
			string RNAstring = "";
			for (int i=0; i<len-3;i+=3)
			{
				string sub = this.DNA.Substring (i, 3);

				if (codon [sub] == 'X')
					break;

				RNAstring += codon [sub];
			}

			return RNAstring;
		}

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
			var file = new FileStream (@"/home/travis/GitHub/RosProbs/c#/Bioinformatic Strongholds/RNAtoProtein/data.txt",
			                           FileMode.Open, FileAccess.Read);

			using (var reader = new StreamReader(file))
			{
				string DNA = reader.ReadLine ();

				TranslateRNA rna = new TranslateRNA (DNA);
				Console.WriteLine(rna.Translate ());

			}
		}
	}
}
