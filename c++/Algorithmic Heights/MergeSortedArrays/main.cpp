#include <iostream>
#include <fstream>
#include <sstream>


void SplitString(std::string, int *arr);
void Merge(int *A, int *B, int a, int b);
void PrintToFile(int *A, int size);

int main()
{
    // open file
    std::fstream file("rosalind_mer.txt", std::ios::in);

    // variables to hold values in strings
    std::string arrA, arrB, aSize, bSize;
    
    // if file is opened
    if (file)
    {
        // get each line and store in the strings
        std::getline(file, aSize);
        std::getline(file, arrA);
        std::getline(file, bSize);
        std::getline(file, arrB);
    }
    
    // close the file, done..
    file.close();

    // convert the sizes to ints
    int a = std::stoi(aSize);
    int b = std::stoi(bSize);

    // create new arrays with corresponding sizes
    int *A = new int[a];
    int *B = new int[b];
    
    // split the strings and add values to arrays
    SplitString(arrA, A);
    SplitString(arrB, B);

    // merge the sorted arrays
    Merge(A, B, a, b);
    
    return 0;
}

/*
    Method that splits the strings into integers
    and adds those values to the passed in array
*/
void SplitString(std::string s, int *arr)
{
    // stringstring for the passed in string
    std::stringstream ss(s);
    // string to hold the tokens
    std::string token;

    int i=0;
    // while we can get the token from the stream, add to array
    while (std::getline(ss, token, ' '))
        arr[i++] = std::stoi(token);
}

/*
    Method to merge 2 sorted arrays into 1 array
*/
void Merge(int *A, int *B, int a, int b)
{
    // variables for counters
    int i = 0, j = 0, k = 0;

    // create new array to hold the merged data set
    int *C = new int[a+b];

    // while i is less than a's size and j less than b's size
    while (i < a && j < b)
    {
        // if A's element is less than or equal to B's element
        if (A[i] <= B[j])
            C[k++] = A[i++];  // add to C
        else
            C[k++] = B[j++]; // else, B[j] is greater
    }
    
    // fill out rest of array, in order
    if (i < a)
    {
        for (int p = i; p < a; ++p)
            C[k++] = A[p];
    }
    else
    {
        for (int p = j; p < b; ++p)
            C[k++] = B[p];
    }

    // call print method
    PrintToFile(C, a+b);
    
    // delete dynamically allocated array
    delete [] C;
}

/*
    Method that prints all the data to a file
*/
void PrintToFile(int *A, int size)
{
    // open output file, use out flag and truncate flag
    std::ofstream outFile("out.txt", std::ios::out | std::ios::trunc);
    
    // loop through array and output to file
    for (int i=0; i<size; ++i)
        outFile << A[i] << ' ';
        
    // close file
    outFile.close();
}
