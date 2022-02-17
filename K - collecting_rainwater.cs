public static int Solution(string S)
{

        string tempS = S.Replace("H-H", "X").Replace("-H", "Y").Replace("H-", "Z");
        if (tempS.IndexOf("H") > -1) return -1;
        string tempResult = tempS.Replace("X", "HTH").Replace("Y", "TH").Replace("Z", "HT");

        return tempResult.Length - tempResult.Replace("T", "").Length;
}
