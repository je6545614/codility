using System;

class Solution {
    public int solution(string S) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        int l = S.Length;
        int count=0;
        
        if (l == 0) return 1;
        
        foreach (char c in S)
        {
            
            if (c == '(') count++;
            else count--;
            if(count <0) return 0;//CORRECTING ABOVE ERROR!
        }
        if (count ==0 && S[0]=='(' && S[l-1]==')') return 1;
        else return 0;
    }
}
