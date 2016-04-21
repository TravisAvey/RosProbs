#include <iostream>
#include <fstream>
#include <sstream>

void SplitString(std::string &s, int *A);
int GetCount(int *A, int size, int x);
int FindIndex(int *A, int size, int x, bool first);
void insertionSort(int *a, int size);

int main()
{
    // open file
    std::fstream file("data.txt", std::ios::in);

    // variables to hold n = number of arrays, size = size of each array
    int n = 0, size = 0;
    // string to hold each array
    std::string data;

    // if file is opened
    if (file)
    {
        // get the num of arrays and size of each array
        file >> n >> size;

        // loop through the number of arrays
        for (int i=0; i<=n; ++i)
        {
            // get the array
            std::getline(file, data);

            // create new array
            int *A = new int[size];

            // call method to split string and set up array
            SplitString(data, A);

            // sort array
            insertionSort(A, size);

            // vars for hi and most elements
            int hi = -1, most = -1;

            // loop through each element of array
            for (int j=0; j<size; ++j)
            {
                // get the count of element of array[j]
                int x = GetCount(A, size, A[j]);

                // if x is greater than hi
                if (x > hi)
                {
                    // set the hi as new hi count
                    hi = x;
                    // set most as the element with the most elements in array
                    most = A[j];
                }
            }

            // output the most
            std::cout << most << ' ';
        }
    }
    return 0;
}


void SplitString(std::string &s, int *A)
{
    // split out each number and put into the array
    std::stringstream ss(s);
    // string for the token of each item
    std::string token;
    int i = 0;
    // while we can parse out the stringstring into a token, ignoring ' '
    while(std::getline(ss, token, ' '))
        A[i++] = std::stoi(token); // add to array (std::stoi() string to int)

}

/*
 * Method finds the first/last index of an element (x),
 * depending on the boolean value of first.  true means
 * we are looking for the first, false = last.
 */
int FindIndex(int *A, int size, int x, bool first)
{
    // vars to hold lo, hi and the result
    int lo = 0, hi = size - 1, result = -1;

    // while the lo isn't greater than hi (to not go outside of the array)
    while (lo <= hi)
    {
        // set the midpoint of the array
        int mid = (lo + hi) / 2;

        // if the element is at midpoint of array, found
        if(A[mid] == x)
        {
            // set the mid as result
            result = mid;

            // still looking for the first/last index of the element
            if (first)
                hi = mid - 1; // continue searching toward left
            else
                lo = mid + 1;  // continue searchng toward right side
        }
        else if (x < A[mid])
            hi = mid - 1;
        else
            lo = mid + 1;
    }

    // at this point we will have either the first index of the element
    // or the last (depending on the medthod FindFirst() or FindLast()
    // return -1 if not in the array, but wont be an issue.. will be looping
    // through the array and passing each element
    // finding the first and last is O(logn)
    // looping through each element is O(n)
    // total running time O(nlogn)  **not counting the sorting
    return result;
}

/*
 * Method gets the count of elements in the array
 * returns -1 if the count isnt at least size / 2
 */
int GetCount(int *A, int size, int x)
{
    // get the first index of x in array
    int first = FindIndex(A, size, x, true);
    // get the last index of x in array
    int last = FindIndex(A, size, x, false);
    // the count
    int count = last - first + 1;

    // if count is at least n/2, return count
    // else return -1
    if (count > size / 2)
        return count;
    else
        return -1;
}


/*
 * method sorts passed in array
 */
void insertionSort(int *a, int size)
{
    int i, j, key;
    // loop through array starting at 2nd pos
    for(i=1; i<size; i++)
    {
        // set the key to index
        key = a[i];
        // set j to index - 1 (hence we started at 2nd pos)
        j = i-1;

        // iterate through until j is equal to zero (start of array)
        // or the key is less than j
        while(j>=0 && key < a[j])
        {
            // store current into a[j + 1]
            a[j+1] = a[j];
            // decrement
            j--;
        }
        // complete swap (outside of while loop!)
        a[j+1] = key;
    }
}