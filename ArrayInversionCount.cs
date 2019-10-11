using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A) {
        if (A.Length < 2)
        return 0;
        
        int m = (A.Length + 1) / 2;
        int[] left= ArrayCopyOfRange(A, 0, m);
        int[] right= ArrayCopyOfRange(A, m, A.Length);
        
        int result = solution(left) + solution(right) + merge(A, left, right);
        if(result > 1000000000) return -1;
        return result;
    }

    public int[] ArrayCopyOfRange (int[] src, int start, int end) {
        int len = end - start;
        int[] dest = new int[len];
        Array.Copy(src, start, dest, 0, len);
        return dest;
    }

    public int merge(int[] arr, int[] left, int[] right) {
        int i = 0, j = 0, count = 0;
        while (i < left.Length || j < right.Length) {
            if (i == left.Length) {
                arr[i+j] = right[j];
                j++;
            } else if (j == right.Length) {
                arr[i+j] = left[i];
                i++;
            } else if (left[i] <= right[j]) {
                arr[i+j] = left[i];
                i++;                
            } else {
                arr[i+j] = right[j];
                count += left.Length-i;
                j++;
            }
        }
        return count;
    }
}
