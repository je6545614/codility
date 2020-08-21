using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int[] solution(int[] A, int K) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        int[] rotatedA = new int[A.Length];
       
        for(int i=0; i<A.Length; i++) {
          int rotatedIndex = (i + K) % A.Length;
    
          rotatedA[rotatedIndex] = A[i];
        }
        return rotatedA;
    }
}
