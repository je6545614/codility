using System;

class Solution {
    public int solution(int[] A, int[] B) {
        if(A.Length==0 || B.Length==0){
            return 0;    
        }
        
        int ni=0;
        int c=1;
        for(int i=1;i<A.Length;i++){
            if(A[i]>B[ni]){
                c++;
                ni=i;
            }
        }
        
        return c;
    }
}
