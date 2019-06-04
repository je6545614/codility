using System;
using System.Linq;

// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        int[] store = new int[A.Length];
		//Console.WriteLine("A.Length " +A.Length);
        store[0] = A[0];
        for (int i = 1; i < A.Length; i++) {
            store[i] = store[i-1];
            for (int minus = 2; minus <= 6; minus++) {
                if (i >= minus) {
                    store[i] = Math.Max(store[i], store[i - minus]);
                } else {
                    break;
                }
            }
            store[i] += A[i];
        }
        return store[A.Length - 1];
    }
}