using System;
using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A, int[] B, int[] C) {
        int maxB = 0;
        int min = 0;
        int max = C.Length;
        bool atLeastOne = false;
        int i = 0;
        List<int> totalNailsList = new List<int>();
        
        if(C.Length == 1) {
            if(A[0] <= C[0] && C[0] <= B[0]) {
                return 1;
            } else {
                return -1;
            }
        }
        
        for(i=0; i<A.Length; i++) {
            maxB = Math.Max(maxB, B[i]);
        }
        
        for(i=0; i<=maxB; i++) {
            totalNailsList.Add(0);
        }
        
        int[] totalNails = totalNailsList.ToArray();
        
        while(min <= max) {
            var mid = ((min + max) / 2);
            
            for(i=0; i<totalNails.Length; i++) {
                totalNails[i] = 0;
            }
            
            for(i=0; i<mid; i++) {
                try{
                    totalNails[C[i]] = 1;
                }catch(Exception ex){
                    Array.Resize(ref totalNails, totalNails.Length + 1);
                    totalNails[totalNails.GetUpperBound(0)] = 1;
                }
            }
            
            for(i=1; i<totalNails.Length; i++) {
                totalNails[i] += totalNails[i-1];
            }
            
            var result = allNailed(A, B, totalNails);
            
            if(result) {
                atLeastOne = true;
                if(max == mid) {
                    break;
                }
                
                max = mid;
            } else {
                min = mid + 1;
            }
        }
        
        if(!atLeastOne) {
            return -1;
        } else {    
            return min;
        }
    }

    public bool allNailed(int[] A, int[] B, int[] totalNails) {
        for(var i=0; i<A.Length; i++) {
            if(totalNails[A[i]-1] == totalNails[B[i]]) {
                return false;
            }
        }
        return true;
    }
}
