using System;
using System.Collections.Generic;

class Solution {
    public int solution(int[] A) {
        List<int> peaks = new List<int>();
        for (int i = 1; i < A.Length - 1; i++)
        {
            if (A[i - 1] < A[i] && A[i + 1] < A[i])
            {
                peaks.Add(i);
            }
        }
        if (peaks.Count == 1 || peaks.Count == 0)
        {
            return peaks.Count;
        }
        int leastFlags = 1;
        int mostFlags = peaks.Count;
        int result = 1;
        while (leastFlags <= mostFlags)
        {
            int flags = (leastFlags + mostFlags) / 2;
            bool suc = false;
            int used = 0;
            int mark = peaks[0];
            for (int i = 0; i < peaks.Count; i++)
            {
                if (peaks[i] >= mark)
                {
                    used++;
                    mark = peaks[i] + flags;
                    if (used == flags)
                    {
                        suc = true;
                        break;
                    }
                }
            }
            if (suc)
            {
                result = flags;
                leastFlags = flags + 1;
            }
            else
            {
                mostFlags = flags - 1;
            }
        }
        return result;
    }
}
