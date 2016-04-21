using System;
using System.Collections;

namespace Fibonacci
{
	class MainClass
	{
		// fibonacci method, uses an array list vs recursion
		private static int fib(int n)
		{
			// create an ArrayList
			var nums = new ArrayList ();
			// add first 2 in the sequence: 0,1
			nums.Add(0);
			nums.Add(1);

			// starting from the 3rd element: F(n) = F(n-1) + F(n-2)
			for (int i=2; i<=n; ++i) 
				nums.Add ((int) nums [i - 1] + (int) nums [i - 2]);

			// return the nth fibonacci number
			return (int) nums[n];
		}

		public static void Main (string[] args)
		{
			// loop through to check correct fibonacci sequence
			for (int i=3; i<11; ++i)
				Console.WriteLine (fib(i));
		}
	}
}
