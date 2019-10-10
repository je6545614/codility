using System;
using System.Collections.Generic;
using System.Linq;

class Solution {
    public int solution(int[] A) {
        var bound = A.Max() + 1;
        var multiverse = new List<int>();
        foreach (var point in A)
        {
            multiverse.Add(bound * 2 + point);
            multiverse.Add(bound * 2 - point);
            multiverse.Add(point);
        }
        return LongestIncreasingSubsequence(multiverse);
    }
    
    private int LongestIncreasingSubsequence(List<int> seq)
    {
        var smallest_end_value = new int?[seq.Count + 1];
        smallest_end_value[0] = -1;
        var lic_length = 0;

        for(var i=0;i<seq.Count;i++)
        {
            var lower = 0;
            var upper = lic_length;
            while (lower <= upper)
            {
                var mid = (upper + lower) / 2;
                if (seq[i] < smallest_end_value[mid])
                {
                    upper = mid - 1;
                }
                else if (seq[i] > smallest_end_value[mid])
                {
                    lower = mid + 1;
                }
                else
                {
                    return -1;
                }
            }
            if (smallest_end_value[lower] == null)
            {
                smallest_end_value[lower] = seq[i];
                lic_length += 1;
            }
            else
            {
                smallest_end_value[lower] = Math.Min(smallest_end_value[lower].Value, seq[i]);
            }
        }
        return lic_length;
    }
}
