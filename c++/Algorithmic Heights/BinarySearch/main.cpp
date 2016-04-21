#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>

int BinarySearch(const std::vector<int> &, int size, int value);
void Split(std::string data, std::vector<int> &vect);
void OutputAnswer(const std::vector<int> &A, const std::vector<int> &B, int a, int b);

int main()
{
    // grabbed sizes from first 2 lines.
    int a = 8146, b = 8654;
    // open file
    std::ifstream file("rosalind_bins.txt", std::ios::in);

    // three variables for the file input
    std::string junk, ordered, search;

    // check if fill is opened
    if (file.good())
    {
        // while file isn't at the end
        while (file.good())
        {
            // was getting a blank for first line
            std::getline(file, junk, '\n');
            // just made first 2 lines junk and physically copied lengths
            std::getline(file, junk, '\n');
            // get the first array, in order
            std::getline(file, ordered, '\n');
            // get the 2nd array to search with
            std::getline(file, search, '\n');
        }

    }
    else
        std::cout << "couldn't open file\n";

    // create 2 vectors<int>
    std::vector<int> A, B;

    // string into int vectors
    Split(ordered, A);
    Split(search, B);

    // call method that will output answer
    OutputAnswer(A, B, a, b);

    return 0;
}

/**
 * Binary Search Method, pass in vector to search, the size of
 * the vector and the value searching
 */
int BinarySearch(const std::vector<int> &A, int size, int value)
{
    int lo = 0, mid, hi = size - 1;
    int position = -1;

    bool found = false;

    while (!found && lo <= hi)
    {
        mid = (lo + hi) / 2;

        if (A[mid] == value)
        {
            found = true;
            position = mid;
        }

        else if (A[mid] > value)
            hi = mid - 1;
        else
            lo = mid + 1;
    }
    if (!found) { return -1; }
    return position + 1;
}

/**
 * Split method, pass in the string and the vector to put data in
 */
void Split(std::string data, std::vector<int> &vect)
{
    // convert string into string stream
    std::stringstream ss(data);
    // string token for temp data before going into vector
    std::string token;

    // while getline() on the stringstream, using token, delimeter ' '
    while (std::getline(ss, token, ' '))
        vect.push_back(std::stoi(token));
        // add to the vector the token, stoi = string to int
}

/**
 * Output answer method, pass in both vectors and the sizes
 */
void OutputAnswer(const std::vector<int> &A, const std::vector<int> &B, int a, int b)
{
    // loop through the array B, calling Binary Search
    for (int i=0; i<b; ++i)
        std::cout << BinarySearch(A, a, B[i]) << " ";
}