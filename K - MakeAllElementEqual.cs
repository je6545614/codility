using System;

class Solution {
    public int solution(int[] A) {
        // Initialize cost to 0
        int cost = 0;
                        
        int min = 5;
        int max = 0;

        foreach (var val in A)
        {
            if (min > val) min = val;
            if (max < val) max = val;
        }

        int midVal = (max + min) / 2;
        foreach (var val in A)
            cost += Math.Abs(val - midVal);

        //Console.WriteLine("[" + String.Join(", ", A) + "] : " + cost);
        return cost;
    }
}
