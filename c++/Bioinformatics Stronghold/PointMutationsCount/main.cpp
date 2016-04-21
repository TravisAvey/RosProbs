#include <iostream>
#include <fstream>

/**
 * This program will count the Point Mutations of two DNA strands,
 * AKA the Hamming distance.  The input is one single file of 2 DNA
 * strands on two separate lines.
 */

int CountMutations(std::string a, std::string b);

int main()
{
    // input file stream
    std::fstream file("rosalind_hamm.txt", std::ios::in);

    // strings to hold the two DNA strands
    std::string a, b;

    // if the file is opened
    if (file)
    {
        // while we aren't at the end of the file
        while (file.good())
        {
            // get the two DNA strands
            std::getline(file, a);
            std::getline(file, b);

            // output the number of mutations
            std::cout << CountMutations(a, b) << std::endl;
        }
    }

    // done with the file
    file.close();

    return 0;
}

/**
 * Helper method counts mutations of two given strings
 * of DNA.
 */
int CountMutations(std::string a, std::string b)
{
    // init mutation counter
    int mutations = 0;

    // loop through string
    for (int i=0; i<a.length(); ++i)
    {
        // if the current char of a != b, we have a mutations
        if (a[i] != b[i])
            mutations++;
    }

    // return the count of mutations
    return mutations;
}