using System;

class Solution {
    public int solution(int[] A) {
        if (A.Length == 0) {
            return 1;
        }
        int[] dp = new int[A.Length + 2];
        dp[0] = 1;
        dp[A.Length + 1] = -1;
        for (int i = 1; i < A.Length + 2; i++) {
            int step = 1;
            int previous = 1;
            int min = Int32.MaxValue;
            while (step <= i) {
                if ((i == A.Length + 1 || A[i - 1] == 1) && (i - step - 1 == -1 || A[i - step - 1] == 1) && dp[i - step] > 0) {
                    min = Math.Min(min, dp[i - step] + 1);
                }
                int tmp = step;
                step = step + previous;
                previous = tmp;
            }
            if (min < Int32.MaxValue) {
                dp[i] = min;
            }
        }
        return dp[A.Length + 1] == -1 ? -1 : dp[A.Length + 1] - 1;
    }
}
