#include <iostream>
#include <fstream>
#include <map>

/**
 * This program will take a strand of RNA and code it for a string
 * protein, using letters for each codon (M instead of met).  Then
 * it will output the results
 */

void InitMap(std::map<std::string, char> &a);
std::string GetProtein(std::map<std::string, char> &a, std::string);

int main()
{
    // file stream
    std::fstream file("rosalind_prot.txt", std::ios::in);
    // string to hold the RNA
    std::string rna;
    // if file is open, get the RNA from the file
    if (file)
        std::getline(file, rna);
    // close the file
    file.close();

    // create a map to hold the Amino Acid codons to letter
    std::map<std::string, char> AA;
    // helper method to init amino acid map
    InitMap(AA);

    // output the rsults of the string protein from the RNA
    std::cout << GetProtein(AA, rna) << std::endl;

    return 0;
}

/**
 * Helper method that gets the protein sequence from the passed in
 * rna sequence and the amino acid map
 */
std::string GetProtein(std::map<std::string, char> &a, std::string rna)
{
    std::string protein;
    for (unsigned i=0; i<rna.length(); i+=3)
    {
        // get the codon using strng.substr()
        std::string codon = rna.substr(i, 3);

        // if the codon is x, it is a stop
        if (a[codon] == 'x')
            break;

        // add the corresponding letter of the codon from the amino acid map
        protein += a[codon];
    }

    return protein;
}

/**
 * Helper method that sets up the amino acid map
 * x = stop
 */
void InitMap(std::map<std::string, char> &a)
{
    a["UUC"] = 'F', a["UUU"] = 'F', a["UUA"] = 'L',
    a["UUG"] = 'L', a["UCU"] = 'S', a["UCC"] = 'S',
    a["UCA"] = 'S', a["UCG"] = 'S', a["UAU"] = 'Y',
    a["UAC"] = 'Y', a["UGU"] = 'C', a["UGC"] = 'C',
    a["UGG"] = 'W', a["CUU"] = 'L', a["CUC"] = 'L',
    a["CUA"] = 'L', a["CUG"] = 'L', a["CCU"] = 'P',
    a["CCC"] = 'P', a["CCA"] = 'P', a["CCG"] = 'P',
    a["CAU"] = 'H', a["CAC"] = 'H', a["CAA"] = 'Q',
    a["CAG"] = 'Q', a["CGU"] = 'R', a["CGC"] = 'R',
    a["CGA"] = 'R', a["CGG"] = 'R', a["AUU"] = 'I',
    a["AUC"] = 'I', a["AUA"] = 'I', a["AUG"] = 'M',
    a["ACU"] = 'T', a["ACC"] = 'T', a["ACA"] = 'T',
    a["ACG"] = 'T', a["AAU"] = 'N', a["AAC"] = 'N',
    a["AAC"] = 'N', a["AAA"] = 'K', a["AAG"] = 'K',
    a["AGU"] = 'S', a["AGC"] = 'S', a["AGA"] = 'R',
    a["AGG"] = 'R', a["GUU"] = 'V', a["GUC"] = 'V',
    a["GUA"] = 'V', a["GUG"] = 'V', a["GCU"] = 'A',
    a["GCC"] = 'A', a["GCA"] = 'A', a["GCG"] = 'A',
    a["GAU"] = 'D', a["GAC"] = 'D', a["GAA"] = 'E',
    a["GAG"] = 'E', a["GGU"] = 'G', a["GGC"] = 'G',
    a["GGA"] = 'G', a["GGG"] = 'G', a["UAA"] = 'x',
    a["UAG"] = 'x', a["UGA"] = 'x';
}
