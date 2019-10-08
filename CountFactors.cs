using System;

class Solution {
    public int solution(int N) {
        
        int i = 1;
        int result = 0;
        if (N <= 0) return 0;
        if (N == 1) return 1;
        int sN = (int) Math.Sqrt(N);
        while (i <= sN) {
            if (N % i == 0) result += 2;
            i++;
        }
        if (sN * sN == N) result--;
        return result;
    }
}
