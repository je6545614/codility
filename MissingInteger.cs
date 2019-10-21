using System;
using System.Linq;

class Solution {
    
    const int maxSize = 100000;
    
    public int solution(int[] A) {
        int[] counter = new int[maxSize];
        Array.Sort(A);
        int[] S = Distinct(A);
        
        foreach(int number in S){
            if(number > 0 && number <= maxSize){
                counter[number - 1] = 1;
            }
        }
        
        for(int i = 0; i < maxSize; i++){
            if(counter[i] == 0){
                return i + 1;
            }
        }
        
        return maxSize + 1;
        
    }
    
    public int[] Distinct(int[] handles)
    {
        return handles.ToList().Distinct().ToArray();
    }
}
