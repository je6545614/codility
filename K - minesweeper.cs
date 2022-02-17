public void solution(int N, int[] R, int[] C)
        {
            //  1) Set field
            int[,] arr_fields = new int[N, N];

            //  2) Set bombs, Set bomb = -1;
            if ((R != null && C != null)
                && (R.Length > 0 && C.Length > 0 && R.Length == C.Length))
            {
                for (int i = 0; i < R.Length; i++)
                    arr_fields[R[i], C[i]] = -1;
            }

            //  3) Find number of nearest bombs
            if ((R != null && C != null)
                && (R.Length > 0 && C.Length > 0 && R.Length == C.Length))
            {
                for (int i = 0; i < R.Length; i++)
                {
                    for (int n = -1; n <= 1; n++)
                    {
                        for (int m = -1; m <= 1; m++)
                        {
                            if (!(n == 0 && m == 0))
                            {
                                try
                                {
                                    if (arr_fields[R[i] + n, C[i] + m] != -1)
                                    {
                                        arr_fields[R[i] + n, C[i] + m]++;
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                }
            }

            //  4) Print result
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(arr_fields[i, j]);
                Console.WriteLine();
            }

            Console.WriteLine("Finish!");
            Console.ReadKey();
        }
