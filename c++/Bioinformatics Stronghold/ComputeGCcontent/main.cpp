#include <iostream>
#include <fstream>

/**
 * This program takes input as a file of DNA of FASTA format
 * each DNA strand is labeled: >dna_1234
 * It reads the file and analyzes which strain has the highest
 * and then outputs the FASTA strand (minus the >) and the GC percentage
 */

double CalcGC(std::string dna);

int main()
{
    // input file stream
    std::fstream file("rosalind_gc.txt", std::ios::in);
    // strings to hold fasta and dna input
    std::string FASTA, DNA;
    // variables to hold the highest
    double hiPercent = 0;
    std::string hiFASTA;

    // check the file
    if (file)
    {
        // while file is good
        while (file.good())
        {
            // get the fasta and the dna
            std::getline(file, FASTA);
            std::getline(file, DNA);

            // call method that calculates the GC %
            double gcContent = CalcGC(DNA);

            // check if current gc% is higher than the highest so far
            if (gcContent > hiPercent)
            {
                // if so, then set hi vars to current
                hiFASTA = FASTA;
                hiPercent = gcContent;
            }
        }

    }

    // output the highs.
    // std::string.substr(1) will return a string from second char to end
    std::cout << hiFASTA.substr(1) << std::endl;
    std::cout << hiPercent << std::endl;
    return 0;
}

/**
 * This helper method cacluates the GC content of a given dna string
 */
double CalcGC(std::string dna)
{
    double count = 0;
    // loop through the string checking each
    // char if it is a G or C
    for (int i=0; i<dna.length(); ++i)
    {
        // if so, then add 1 to the count
        if (dna[i] == 'G' || dna[i] == 'C')
            count += 1;
    }

    // return % of # of GC / total length of string * 100
    return 100 * (count / static_cast<double>( dna.length() ));
}