using System;

class Solution {
    public int solution(int K, int[] A) {
        int numberOfRopes = 0;
        int currentRopeLenght = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] >= K)
            {
                numberOfRopes++;
                currentRopeLenght = 0;
                continue;
            }

            currentRopeLenght += A[i];
            if (currentRopeLenght >= K)
            {
                numberOfRopes++;
                currentRopeLenght = 0;
            }
        }

        return numberOfRopes;
    }
}
