using System;
using static System.Math;

class Solution {
    public int solution(int[] A) {
        
        int maxProfit = 0;
        int maxSlice = 0;
        
        for (int i = 1; i < A.Length; i++) {
            maxProfit = Math.Max(0, maxProfit + (A[i] - A[i - 1]));
            maxSlice = Math.Max(maxSlice, maxProfit);
        }
        
        if (maxSlice < 0) {
            maxSlice = 0;
        }
        
        return maxSlice;
    }
}
