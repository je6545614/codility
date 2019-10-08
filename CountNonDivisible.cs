using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int[] solution(int[] A) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        int[] result = new int[A.Length];
        
        for(int i=0; i<result.Length; i++){
            result[i] = 0;
            int divTemp = A[i];
            for(int x=0; x<A.Length; x++){
                if((divTemp % A[x]) != 0){
                    result[i] += 1;
                }
            }
        }
        
        return result;
        
    }
}
