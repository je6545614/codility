using System;

class Solution {
    public int solution(int[] A, int[] B) {
        int Z = A.Length;
        int result = 0;

        for(int i=0; i<Z; i++) {
            if(isSameDivisors(A[i], B[i])) {
                result++;
            }
        }
        
        return result;
    }
    
    public int gcd(int a, int b) {
        if(a % b == 0) {
            return b;
        }
        
        return gcd(b, a%b);
    }
    
    private bool isSameDivisors(int a, int b) {
        int gcd_ab = gcd(a, b);
        int gcd_a = 0;
        int gcd_b = 0;
        
        while(gcd_a != 1) {
            gcd_a = gcd(a, gcd_ab);
            a /= gcd_a;
        }
        
        while(gcd_b != 1) {
            gcd_b = gcd(b, gcd_ab);
            b /= gcd_b;
        }
        
        return (a == 1 && b == 1) ? true : false;
    }
}
