using System;

namespace ConsoleApp1
{
    class CoverBuildings
    {
        static void Main(string[] args)
        {
            int[] H1 = new int[] { 3, 1, 4 }; //return 10
            int[] H2 = new int[] { 5, 3, 2, 4 }; //return 17
            int[] H3 = new int[] { 5, 3, 5, 2, 1 }; //return 19
            int[] H4 = new int[] { 7, 7, 3, 7, 7 }; //return 35
            int[] H5 = new int[] { 1, 1, 7, 6, 6, 6 }; //return 30
            int[] H6 = new int[] { 7, 1, 7, 6, 6, 7 }; //return 42

            Console.WriteLine("Result of [{0}] return 10 : {1}", string.Join(", ", H1), GetCoverBuildings(H1));
            Console.WriteLine("Result of [{0}] return 17 : {1}", string.Join(", ", H2), GetCoverBuildings(H2));
            Console.WriteLine("Result of [{0}] return 19 : {1}", string.Join(", ", H3), GetCoverBuildings(H3));
            Console.WriteLine("Result of [{0}] return 35 : {1}", string.Join(", ", H4), GetCoverBuildings(H4));
            Console.WriteLine("Result of [{0}] return 30 : {1}", string.Join(", ", H5), GetCoverBuildings(H5));
            Console.WriteLine("Result of [{0}] return 42 : {1}", string.Join(", ", H6), GetCoverBuildings(H6));
        }

        static int GetCoverBuildings(int[] H)
        {
            int result = 0;
            int hLength = H.Length;

            if (hLength <= 100000)
            {
                int[] hMaxL = new int[hLength + 1];
                int[] hMaxR = new int[hLength + 1];
                
                int currMax = H[0];

                for (int i = 0; i < hLength; i++)
                {
                    currMax = currMax > H[i] ? currMax : H[i];
                    hMaxL[i + 1] = currMax;
                }

                currMax = H[hLength - 1];

                for (int i = hLength - 1; i > -1; i--)
                {
                    currMax = currMax > H[i] ? currMax : H[i];
                    hMaxR[i] = currMax;
                }
                
                int currMinVal = 0;
                int prevMinVal = hMaxL[0] * 0 + hMaxR[0] * (hLength - 0);

                for (int i = 0; i < hLength + 1; i++)
                {
                    currMinVal = hMaxL[i] * i + hMaxR[i] * (hLength - i);
                    result = currMinVal < prevMinVal ? currMinVal : prevMinVal;

                    prevMinVal = result;
                }
            }

            return result;
        }
    }
}
