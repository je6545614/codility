public static int Solution(int N, int K)
{
            string str_num = N.ToString();
            int chat_count = str_num.Length;

            int result = 0;

            for (int i = 0; i < K && Int32.Parse(str_num) < 1000; i++)
            {
                for (int c = 0; c < chat_count; c++)
                {
                    int digit_val = Int32.Parse(str_num[c].ToString());
                    if (digit_val <= 9)
                    {

                        char[] char_array = str_num.ToCharArray();
                        char_array[c] = (digit_val + 1).ToString()[0];
                        str_num = String.Join("", char_array);
                        break;
                    }
                }
            }
            result = Int32.Parse(str_num);
            return result;
}
