using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfWordInSentence
{
    class NumberOfWordInSentence
    {

        public static string A = @"We test coders. Give us a try?";
        public static string B = @"Forget CVs..Save time. x x";

        static void Main(string[] args)
        {
            char[] splitOperator = new char[] { '.'/*, '?', '!'*/ };
            string[] stringTemp = B.Split(splitOperator);
            char[] seperator = new char[] { ' ' };
            int numberOfWords = stringTemp[stringTemp.Length-1].Split(seperator, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine("Number of words: {0}", numberOfWords);
        }
    }
}
