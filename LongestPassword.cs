using System;
using System.Linq;
using System.Text.RegularExpressions;

class Solution {
    public int solution(string S) {
        string value = S;
        if (value == null || value.Length == 0) return -1;
            Regex r = new Regex(@"^[a-zA-Z0-9]+$");
            string[] passwords = value.Split(' ')
                .Where(x => x.Length % 2 != 0 && r.IsMatch(x) && x.Any(z => Char.IsDigit(z)))
                .ToArray();
 
            if(passwords.Length == 0)
            {
                return -1;
            }
 
            for (int i = 0; i < passwords.Length; i++)
            {
                string password = passwords[i];
                if(password.Length == 1)
                {
                    continue;
                }
 
 
                int countLetter = 0;
                int countNumbers = 0;
                for (int j = 0; j < password.Length; j++)
                {
                    char c = password[j];
                    if (Char.IsLetter(c))
                    {
                        countLetter++;
                    }
 
                    if (Char.IsDigit(c))
                    {
                        countNumbers++;
                    }
 
                    if(j == password.Length - 1 && (countNumbers % 2 == 0 || countLetter % 2 != 0))
                    {
                        passwords[i] = null;
                    }
                }
            }
 
            if(passwords.All(x => x == null))
            {
                return -1;
            }
 
            return passwords.Where(x => x != null).Max(x => x.Length);
    }
}
