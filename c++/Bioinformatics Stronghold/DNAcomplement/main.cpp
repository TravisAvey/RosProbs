#include <iostream>
#include <fstream>
#include <algorithm>

/**
 * This program takes in a file with DNA on one line.
 * It will check each base pair and then change out
 * for its complement.  Finally it will reverse and
 * output the string
 */

void Replace(std::string &dna);

int main()
{
    // file stream for the DNA txt
    std::fstream file("rosalind_revc.txt", std::ios::in);
    // string to hold the DNA data
    std::string DNA;
    // if the file is opened, get the first line
    if (file.good())
        std::getline(file, DNA);
    // close the fiel
    file.close();

    // call method that checks each base pair and changes for complement
    Replace(DNA);

    // use std algorithm library for reverse, to reverse DNA string
    std::reverse(DNA.begin(), DNA.end());

    // output the final string
    std::cout << DNA << std::endl;

    return 0;
}

/**
 * Method that searches through string and replaces
 * the base pair with appropriate complement
 */
void Replace(std::string &dna)
{
    // loop through string
    for (long i=0; i<dna.length(); i++)
    {
        // check the current char & replace with complement
        if (dna[i] == 'C')
            dna[i] = 'G';
        else if (dna[i] == 'G')
            dna[i] = 'C';
        else if (dna[i] == 'A')
            dna[i] = 'T';
        else if (dna[i] == 'T')
            dna[i] = 'A';
    }
}
