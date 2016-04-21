#include <iostream>
#include <fstream>

/**
 * This programs reads in two strands of DNA from a file.
 * The first strand is the DNA in question and the second
 * is the motif we are searching.  It will find the motifs
 * and print out the location in the DNA where each motif
 * is.  (Not 0 based, but pos 0 => 1)
 */

void PrintMotifs(std::string a, std::string motif);

int main()
{
    // open the file stream
    std::fstream file("rosalind_subs.txt", std::ios::in);
    // strings to hold the 2 DNA strands
    std::string a, b;
    // if the file is opened
    if (file)
    {
        // while not at the end of file
        while (file.good())
        {
            // get the two DNA strands
            std::getline(file, a);
            std::getline(file, b);
        }
    }
    // close the file
    file.close();

    // helper method to print the motif locations out
    PrintMotifs(a, b);

    return 0;
}

/**
 * Helper method that prints out the locations of the motifs
 */
void PrintMotifs(std::string a, std::string motif)
{
    // get the size of each DNA strand, a is main, b is motif
    auto size = a.length(), len = motif.length();
    // loop through the length of a
    // less the length of b.. will be out
    // of range if we looped through entire len of a
    for (auto i=0; i<size-len; ++i)
    {
        // get the DNA fragment, i -> len of b
        std::string fragment = a.substr(i, len);

        // if the DNA frag in question is same as motif, then output position +1
        if (fragment == motif)
            std::cout << i+1 << ' ';
    }
    std::cout << std::endl;
}
