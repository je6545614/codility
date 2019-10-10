using System;

class Solution {
    public int solution(int M, int[] A) {
        int vMax = A[0];
          for (int i = 1; i < A.Length; ++i) vMax = Math.Max(vMax, A[i]);
          int[] vLastPos = new int[vMax + 1];
          for (int i = 0; i < vLastPos.Length; ++i) vLastPos[i] = -1;
          int vSlices = 0, vNewStart = -1;
          for (int i = 0; i < A.Length; ++i)
          {
             int vVal = A[i];
             int vPrevPos = vLastPos[vVal];
             vSlices += i - Math.Max(vPrevPos, vNewStart);
             if (vSlices > 1000000000) return 1000000000;
             if (vPrevPos != -1) vNewStart = Math.Max(vNewStart, vPrevPos);
             vLastPos[vVal] = i;
          }
          return vSlices;
    }
}
