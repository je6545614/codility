using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class RectanglesStrip
    {
        //1. Given A = [2, 3, 2, 3, 5] and B = [3, 4, 2, 4, 2], the function should return 3
        //2. Given A = [2, 3, 1, 3] and B = [2, 3, 1, 3], the function should return 2
        //3. Given A = [2, 10, 4, 1, 4] and B = [4, 1, 2, 2, 5], the function should return 3

        static void Main(string[] args)
        {
            int[] A = new int[] { 2, 3, 2, 3, 5 };
            int[] B = new int[] { 3, 4, 2, 4, 2 };
            //return 3

            //int[] A = new int[] { 2, 3, 1, 3 };
            //int[] B = new int[] { 2, 3, 1, 3 };
            //return 2

            //int[] A = new int[] { 2, 10, 4, 1, 4 };
            //int[] B = new int[] { 4, 1, 2, 2, 5 };
            //return 3

            int result = GetSqrt(A, B);

            Console.WriteLine("Result : {0}", result);
        }
        
        static int GetSqrt(int[] A, int[] B)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            if (A.Length == B.Length)
            {

                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] == B[i])
                    {
                        if (!dict.ContainsKey(A[i]))
                        {
                            dict.Add(A[i], 0);
                        }
                        dict[A[i]]++;
                    }
                    else
                    {
                        if (!dict.ContainsKey(A[i]))
                        {
                            dict.Add(A[i], 0);
                        }
                        dict[A[i]]++;
                        if (!dict.ContainsKey(B[i]))
                        {
                            dict.Add(B[i], 0);
                        }
                        dict[B[i]]++;
                    }
                }

                int dupValue = dict.Values.Max();

                try
                {
                    int result = dict.OrderByDescending(obj => obj.Key)
                        .Where(obj => obj.Value >= dupValue)
                        .FirstOrDefault().Value;

                    return result;
                }
                catch (Exception ex)
                {
                    return dupValue;
                }
            }

            return 0;
        }
        
    }
}
