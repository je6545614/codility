class Solution {
    public int solution(int[] A) {
        int minI=0;
        double minValue = 100001.0;
        
        for (int i=0; i<A.Length-1; i++)
        {
            
             if (((A[i]+A[i+1])/2.0) < minValue)    
             {
                 minI=i;
                 minValue=(A[i]+A[i+1])/2.0;
    
             }           
             if (i < A.Length-2)
             {
                  if (((A[i] +A[i+1]+A[i+2])/3.0)< minValue)
                  {
                     minI=i;
                     minValue= (A[i] +A[i+1]+A[i+2]) / 3.0;              
                   }          
             }      
        }
        
        return minI;
 }
}
