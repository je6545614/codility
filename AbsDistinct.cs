using System;
using System.Collections.Generic;

class Solution {
    public int solution(int[] A) {
        HashSet<int> set = new HashSet<int>();
        
        bool isMinValue = false;
        int start = 0;
        if (A[0] == int.MinValue)
        {
            isMinValue = true;
            start = 1;
        }
        
        for (int i = start; i < A.Length; i++)
        {
            set.Add(Math.Abs(A[i]));
        }        
        
        return isMinValue ? set.Count + 1 : set.Count;
    }
}
