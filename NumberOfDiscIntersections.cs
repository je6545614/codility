public static int solution(int[] A)
{
    // obtain ordered starts array
    long n = A.Length;
    if (n < 2)
        return 0;
    long numIntersecs = n * (n - 1) / 2; // unordered pairs, initialized to max possible
    long[] hiVals = new long[n];
    long[] loVals = new long[n];
    for (long i = 0; i < n; i++)
    {
        hiVals[i] = i + A[i]; // high value of disk edge (along x-axis)
        loVals[i] = i - A[i]; // low value of disk edge (along x-axis)
    }
    Array.Sort(hiVals);
    Array.Sort(loVals);
    int jLo = 0; // initialize inner iterator only once
    for (int iHi = 0; iHi < n; iHi++)
    {
        for ( ; jLo < n; jLo++) // nested, but only cycled thru once (or twice, sorta)
        {
            if (loVals[jLo] > hiVals[iHi]) // disks don't intersect if one's lo > other's hi
            {
                numIntersecs -= n - jLo; // decrement by the num of lo values > this hi value
                break; // don't increment iterator, check this low value again next time
            }
        }
        if (jLo == n)
            break; // no more low values > high values
    }
    if (numIntersecs > 10E6)
        return -1;
    else
       return (int) numIntersecs;
}
