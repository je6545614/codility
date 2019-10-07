using System;

class Solution {
    public int solution(int[] A) {
        
        int maxEndingPrevious = A[0];
        int maxEndingHere = A[0];
        int maxSoFar = A[0];
 
        for(int i = 1; i < A.Length; i++){
            maxEndingHere = Math.Max(A[i], maxEndingPrevious + A[i]); 
            maxEndingPrevious = maxEndingHere;
            maxSoFar = Math.Max(maxSoFar, maxEndingHere); 
        }
        
        return maxSoFar;
    }
}
