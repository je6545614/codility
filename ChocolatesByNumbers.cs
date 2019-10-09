using System;

class Solution {
    public int solution(int N, int M) {
        if (M == 1) return N;
        if (M == N) return 1;
    
        int a = N, b = M;
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
    
        return N / a;
        }
}
