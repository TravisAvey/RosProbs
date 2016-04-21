#include <iostream>
#include <fstream>
#include <cstring>

class MergeSort
{
private:
    unsigned int len;
    int *A;
    int *b;
    
    /*
        Method that merges the arrays into one array, sorted
    */
    void Merge(int lo, int mid, int hi)
    {
        // copy array 
        std::memcpy(b + lo, A + lo, (hi - lo + 1) * sizeof(int));

        // counter variables
        int i = lo;
        int j = mid + 1;
        int k = lo;

        // while the lo is less than mid point
        // and mid+1 is less than hi point
        while(i <= mid && j <= hi)
        {
            // if the b[i] is less than the b[j]
            // that means, the i-th element is
            // to be copied over to that i pos
            // else they are out of order,
            // copy the jth pos
            if (b[i] <= b[j])
                A[k++] = b[i++];
            else
                A[k++] = b[j++];
        }

        // copy b -> A, in correct order
        // after the other elements are already
        // copied over from above while loop
        while (i <= mid)
            A[k++] = b[i++];
        while (j <= hi)
            A[k++] = b[j++];
    }
    
    /*
        Main method of MergeSort,
        call itself recursively to 
        merge and sort the array
        "Divide and Conquer"
    */
    void mSort(int lo, int hi)
    {
        // if the lo is less than the hi,
        // we conduct the Merge Sort,
        // else we return
        if (lo < hi)
        {
            int mid = (hi + lo) / 2;
            mSort(lo, mid);
            mSort(mid + 1, hi);
            Merge(lo, mid, hi);
        }
        return;
    }
    
public:
    /*
        Constructor.  Pass in array to be sorted
        and the size of array
    */
    MergeSort(int *arr, unsigned int size)
    {
        // assign private variables
        len = size;
        A = new int[len];
        b = new int[len];
        
        // copy array
        for (int i=0; i<len; ++i)
            A[i] = arr[i];
    }
    
    // destructor to free up dynamically allocated memory
    ~MergeSort()
    {
        delete [] A;
        delete [] b;
    }
    
    // public interface to merge and sort
    void Sort()
    {
        mSort(0, len-1);
    }
    
    // method to print the array to file
    void PrintToFile()
    {
        std::fstream file("output.txt", std::ios::out);
        
        for (int i=0; i<len; ++i)
            file << A[i] << ' ';
    }
};

int main()
{
    // file that contains the unsorted data
    std::fstream file("rosalind_ms.txt", std::ios::in);
    
    // if file is open
    if (file)
    {
        
        // get the size of the array
        unsigned int size;
        file >> size;
        
        // create dynamically allocated array
        int *arr = new int[size];
        
        // variables to fill array
        int i  = 0;
        int a = 0;
        
        // while we can get data, append to array
        while (file >> a)
            arr[i++] = a;
            
        // Create MergeSort object
        MergeSort mSort(arr, size);
        
        // call sort
        mSort.Sort();
        
        // print the sorted array to file
        mSort.PrintToFile();

    }  
    
    // close file
    file.close();
    // delete dynamically created array
    delete [] arr;
    
    return 0;
}
