#include <iostream>
#include <stdint.h>


/*
    This method is the basic fibonacci sequence, altered so that
    the number of offspring per pair of rabbits is allocated
*/
std::uint32_t Fibonacci(std::uint32_t n, std::uint32_t k)
{
    // base cases
    if (n ==1) return 1;
    else if (n==2) return k;
    
    // f(n) = f(n-1) + f(n-2)
    std::uint32_t first = Fibonacci(n-1, k);
    std::uint32_t second = Fibonacci(n-2, k);
    
    // if greater than 4 months, return first + second ^
    if (n <= 4)
        return first + second;
        
    // else return first + second * number of offspring
    return (first + (second * k));
}

int main()
{
    std::cout << Fibonacci(30, 2) << std::endl;
    return 0;
}