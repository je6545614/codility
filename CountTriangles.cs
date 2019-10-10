using System;
using System.Linq;
using System.Collections.Generic;

class Solution {
    public int solution(int[] AA) {
        List<int> A = AA.OfType<int>().ToList();
        int len = A.Count;
    	A.Sort();
    	int s;
    	int ss;
    	int l;
    	int h;
    	int m;
    	long cnt = 0L;
    	for (int i = 0; i < len - 2; ++i)
    	{
    		ss = i + 2;
    		for (int j = i + 1; j < len - 1; ++j)
    		{
    			l = ss;
    			h = len - 1;
    			s = -1;
    			while (l <= h)
    			{
    				m = l + (h - l) / 2;
    				if (A[m] >= A[i] + A[j])
    				{
    					h = m - 1;
    				}
    				else
    				{
    					s = m;
    					l = m + 1;
    				}
    			}
    			if (-1 != s)
    			{
    				ss = s;
    				cnt += s - j;
    			}
    		}
    	}
    	return (int)cnt;
    }
}
