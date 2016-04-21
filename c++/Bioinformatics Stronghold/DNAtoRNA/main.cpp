#include <iostream>
#include <algorithm>
#include <fstream>

/**
 * This programs takes in a file of DNA (on one line)
 * and replaces all occurrences of T's with U's and outputs
 * the new string to the console
 */
int main()
{
    // file stream of the dna
    std::fstream file("rosalind_rna.txt", std::ios::in);
    // string variable to hold DNA data
    std::string DNA;

    // if file is good and opened, get the first line
    if (file.good())
        std::getline(file, DNA);
    file.close();

    // using std algorithm replace(), replace all T's with U's
    std::replace(DNA.begin(), DNA.end(), 'T', 'U');
    // output the modified string to console
    std::cout << DNA << std::endl;

    return 0;
}