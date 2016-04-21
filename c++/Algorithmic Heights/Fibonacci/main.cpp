#include <iostream>


uint32_t Fibonacci(uint32_t n)
{
    // create new array to hold fibonacci
    uint32_t *arr = new uint32_t[n];
    // set first 2 fibonacci numbers
    arr[0] = 0;
    arr[1] = 1;

    // loop through array, setting each fibonacci number
    for(int i=2;i<=n;++i)
        arr[i] = arr[i -1] + arr[i -2];

    // store final fib number
    uint32_t final = arr[n];
    // delete dynamically created array
    //delete [] arr;
    // return the number
    return final;
}

int main()
{

    int fib = Fibonacci(24);
    std::cout << fib << std::endl;

    return 0;
}