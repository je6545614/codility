using System;
using System.Collections.Generic;
using System.Linq;

class Solution {
    public int solution(String S, String T) {
        /*
        S = "15:15:00";
        T = "15:15:12";
        S = "22:22:21";
        T = "22:22:23";
        */
        string numI = string.Empty;
        string numJ = string.Empty;
        string numK = string.Empty;
        string number = string.Empty;
        int count = 0;
        List<string> str = new List<string>();
        for (int i = 0; i < 24; i++)
        {
            for (int j = 0; j < 60; j++)
            {
                for (int k = 0; k < 60; k++)
                {
                    if (i < 10)
                    {
                        numI += "0" + i;
                    }
                    if (j < 10)
                    {
                        numJ += "0" + j;
                    }
                    if (k < 10)
                    {
                        numK += "0" + k;
                    }
                    number = !string.IsNullOrEmpty(numI) ? numI : i.ToString();
                    number += !string.IsNullOrEmpty(numJ) ? numJ : j.ToString();
                    number += !string.IsNullOrEmpty(numK) ? numK : k.ToString();

                    if (number.Distinct().ToArray().Length < 3)
                    {
                        str.Add(number);
                    }
                    number = string.Empty;
                    numI = string.Empty;
                    numJ = string.Empty;
                    numK = string.Empty;
                }
            }
        }
        var s1Arr = S.Split(':');
        var s2Arr = T.Split(':');

        var s1Num = Convert.ToInt32(String.Join("", s1Arr));
        var s2Num = Convert.ToInt32(String.Join("", s2Arr));

        while (s1Num <= s2Num)
        {
            if (str.Contains(s1Num.ToString()))
                count++;
            s1Num++;
        }

        return count;
    }
}
