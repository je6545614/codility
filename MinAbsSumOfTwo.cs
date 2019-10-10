using System;

class Solution {
    public int solution(int[] A) {
    	Array.Sort(A);
    	int N = A.Length;
    	int i = 0;
    	int j = N - 1;
    	int m = int.MaxValue;
    	while (i <= j)
    	{
    		int tmp = A[i] + A[j];
    		m = Math.Min(m, Math.Abs(tmp));
    		if (tmp <= 0)
    		{
    			i++;
    		}
    		else
    		{
    			j--;
    		}
    	}
    	return m;
    }
}
