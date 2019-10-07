using System;
using System.Collections;
using System.Collections.Generic;
class Solution {
    public int solution(string S) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
         Dictionary<string, string> matched = new Dictionary<string, string>();
            matched.Add("]", "[");
            matched.Add("}", "{");
            matched.Add(")", "(");
            List<string> pushElement = new List<string>();
            pushElement.Add("[");
            pushElement.Add("{");
            pushElement.Add("(");
            Stack stack = new Stack();
            foreach (char c in S)
            {
                if (pushElement.Contains(c.ToString()))
                    stack.Push(c.ToString());
                else
                    if (stack.Count == 0)
                        return 0;
                    else if (!stack.Pop().Equals(matched[c.ToString()]))
                    {
                        return 0;
                    }
            }
            if (stack.Count == 0)
                return 1;
            return 0;
    }
}
