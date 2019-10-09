using System;
using System.Linq;

class Solution {
    public int[] solution(int[] A) {
    int N = A.Length;
	int[] counts = new int[(A.Max() + 1)];

	for (int i = 0; i < N; ++i)
	{
		counts[A[i]] += 1;
	}

	int[] answer = new int[N];

	for (int i = 0; i < N; ++i)
	{
		int divisors = 0;

		for (int j = 1; j * j <= A[i]; ++j)
		{
			if (A[i] % j == 0)
			{
				divisors += counts[j];
				if (A[i] / j != j)
				{
					divisors += counts[A[i] / j];
				}
			}
		}

		answer[i] = N - divisors;
	}

	return answer;
    }
}
