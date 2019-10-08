using System;
using System.Linq;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A) {
        if (A.Length < 3)
        {
            return 0;
        }
    
        // get a new array with peaks
        bool[] peaks = new bool[A.Length];
        Int32 peaksCounter = 0;
        for (Int32 i = 1; i < A.Length - 1; i++)
        {
            if (A[i] > A[i - 1] && A[i] > A[i + 1])
            {
                peaks[i] = true;
                peaksCounter++;
            }
        }
    
        // start testing each possible division
        for (Int32 groupSize = 1; groupSize < (A.Length+1); groupSize++)
        {
            if ((A.Length % groupSize) == 0) // is divisible
            {
                // test actual divisor
                if (PeaksCorrect(peaks, peaksCounter, groupSize))
                {
                    return A.Length / groupSize;
                }                 
            }
        }
    
        return 0;
    }
    
    public bool PeaksCorrect(bool[] peaks, Int32 peaksCounter, Int32 groupSize)
    {
        int groupNumber = peaks.Length / groupSize;
    
        // should be at least one peak per group
        if (peaksCounter < groupNumber)
        {
            return false;
        }
    
        // this is what should be improved (should only store the peaks indexes, not the whole array)
        for (Int32 i = 0; i < groupNumber; i++)
        {
            bool hasPeak = peaks.Skip(i * groupSize).Take(groupSize).Any(t => t == true);
    
            if (!hasPeak)
            {
                return false;
            }
        }
    
        return true;
    }
        
}
