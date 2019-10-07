using System;

class Solution {
    public int solution(int A, int B, int K) {
    
        int result = 0;

        if (A%K == 0) {
          result = ((B-A)/K)+1;
        } else {
          result = (B/K - ((A/K)+1))+1;
        }

        return result;
    }
}
