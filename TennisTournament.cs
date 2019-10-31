using System;

class Solution {
    public int solution(int P, int C) {
        
        if(P > 30000){
            P = 30000;
        }else if(P < 1){
            P = 1;
        }
        
        if(C > 30000){
            C = 30000;
        }else if(C < 1){
            C = 1;
        }
        
        int player = P / 2;
        return player >= C ? C : player;
    }
}
