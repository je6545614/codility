using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutdownTheTrees
{
    class CutdownTheTrees
    {

        public static int[] A = { 3, 4, 5, 4 }; //return 2
        public static int[] B = { 4, 5, 2, 3, 4 }; //return 0
        public static int[] C = { 1, 2, 3, 4, 5, 6, 7 }; //return 7

        static void Main(string[] args)
        {
            int[] intUse = C;
            List<int> intList = intUse.ToList();
            int waysCan = 0;
            for (int i = 0; i < intList.Count; i++)
            {
                List<int> tempList = intUse.ToList();
                tempList.RemoveAt(i);
                for (int x = 1; x < tempList.Count; x++)
                {
                    if (tempList[x - 1] <= tempList[x])
                    {
                        if ((x + 1) == tempList.Count)
                        {
                            waysCan += 1;
                        }
                    }
                    else { break; }
                }
            }

            Console.WriteLine("Ways to cutdown the trees : " + waysCan);

        }
    }
}
