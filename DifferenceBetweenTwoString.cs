using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferenceBetweenTwoString
{
    class DifferenceBetweenTwoString
    {
        static void Main(string[] args)
        {
            var result = Intersect();
            Console.WriteLine(result);
        }

        private static string Intersect()
        {
            string test1 = "a,b,c,d,e";
            string test2 = "b,e";
            var diff = string.Join(",", test1.ToArray().Where(item => !test2.Contains(item.ToString())).ToArray());

            var arr1 = new string[] { "a", "b", "c", "d" };
            var arr2 = new string[] { "a", "b" };
            var difference = arr1.Except(arr2).ToArray();

            return string.Join(",", difference);
        }
    }
}
