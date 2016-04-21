#include <iostream>
#include <fstream>
#include <algorithm>

/**
 * This program takes in a file named rosalind_dna.txt,
 * reads the DNA that's on one line, then uses the std::count
 * algorithm to count and output the number of each base pairs
 */
int main()
{
    // file stream to read in the DNA, all on one line
    std::fstream file("rosalind_dna.txt", std::ios::in);
    // string to hold the DNA
    std::string DNA;

    // if file is opened and can be read, put the first line into DNA string
    if (file.good())
        std::getline(file, DNA);

    // get the count of each base pair from the string
    // std::count() is from the std algorithm library
    int A = std::count(DNA.begin(), DNA.end(), 'A');
    int C = std::count(DNA.begin(), DNA.end(), 'C');
    int G = std::count(DNA.begin(), DNA.end(), 'G');
    int T = std::count(DNA.begin(), DNA.end(), 'T');

    // printf vs cout, liked it better in this instance
    std::printf("%d %d %d %d\n", A, C, G, T);
    return 0;
}