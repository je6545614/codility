using System;

class Solution {
    public int solution(string S) {
       
        int l = S.Length;
        int count=0;
        
        if (l == 0) return 1;
        
        foreach (char c in S)
        {
            if (c == '(') count++;
            else count--;
        }
        if (count ==0 && S[0]=='(' && S[l-1]==')') return 1;
        else return 0;
    }
}
