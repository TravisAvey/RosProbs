#include <iostream>
#include <fstream>
#include <sstream>

void Split(std::string data, int *A);
int InsertionSort(int *A, int size);

int main()
{
    // input file, with ios flag set to in
    std::fstream file("rosalind_ins.txt", std::ios::in);
    // strings to hold the size and array
    std::string size, arr;

    // if the file can be opened
    if (file.good())
    {
        // get the size and array from the file
        std::getline(file, size);
        std::getline(file, arr);
    }

    // convert string to int using stoi()
    int s = std::stoi(size);
    // create a dynamically allocated array with the s
    int *a = new int[s];
    // call Split on the string and convert to int array
    Split(arr, a);

    std::cout << "============\n";
    std::cout << InsertionSort(a, s) << std::endl;
    std::cout << "============\n";

    return 0;
}

/**
 * Method Split, converts a string into an int []
 * param: data string input of array sep by a ' '
 * param: A, pointer to an array
 */
void Split(std::string data, int *A)
{
    // convert the string into a string stream
    std::stringstream ss(data);
    // token to hold the items
    std::string token;

    int i = 0;
    // use getline, stringstream, token to hold, empty space delimeter
    // for each token extracted, add to A[] converting the token to an int
    while(std::getline(ss, token, ' '))
        A[i++] = std::stoi(token);

}

/**
 * Method Insertion Sort returns the count of swaps conducted on the array
 * Params: A - pointer to an array, size - the size of the array
 */
int InsertionSort(int *A, int size)
{
    // variables: count to return, and key to hold the current array index
    int count = 0, key;
    // loop through array, starting at second array index
    for (int i=1; i<size; i++)
    {
        // store current index in key
        key = A[i];
        // k variable, 1 less than current
        int k = i-1;

        // while k is atleast 0 and the current is less than array of k index
        while (k >= 0 && key < A[k])
        {
            // swap the next array item, with array of k (i-1)
            std::swap(A[k + 1], A[k]);
            // decrement k
            k--;
            // we swapped, increment counter
            count++;
        }
    }
    // return the count
    return count;

}