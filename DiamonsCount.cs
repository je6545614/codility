using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    public int solution(int[] X, int[] Y)
    {
        if (X.Length > 1500 || X.Length < 4 || Y.Length > 1500 || Y.Length < 4)
        {
            return 0;
        }
        else
        {
            Dictionary<int, List<int>> x_dict = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> y_dict = new Dictionary<int, List<int>>();

            /*
            x_dict = {1: [3, 4], 2: [1, 3, 5], 3: [3, 4]}
            y_dict = {3: [1, 2, 3], 4: [1, 3], 1: [2], 5: [2]} 
            */

            foreach (var data in X.Zip(Y, (x, y) => new { x, y }))
            {
                if (x_dict.Keys.Contains(data.x))
                {
                    x_dict[data.x].Add(data.y);
                }
                else
                {
                    x_dict.Add(data.x, new List<int> { data.y });
                }

                if (y_dict.Keys.Contains(data.y))
                {
                    y_dict[data.y].Add(data.x);
                }
                else
                {
                    y_dict.Add(data.y, new List<int> { data.x });
                }
            }

            /*
            //print result of x_dict and y_dict
            foreach (KeyValuePair<int, List<int>> kv in x_dict)
            {
                Console.WriteLine("x_dict : Key = {0}, Value = {1}", kv.Key, String.Join(", ", kv.Value));
            }

            foreach (KeyValuePair<int, List<int>> kv in y_dict)
            {
                Console.WriteLine("y_dict : Key = {0}, Value = {1}", kv.Key, String.Join(", ", kv.Value));
            }
            */

            if (x_dict.Count < 3 || y_dict.Count < 3)
            {
                return 0;
            }

            int count = 0;

            foreach (var i in x_dict)
            {
                Dictionary<int, List<int>> point_count = new Dictionary<int, List<int>>();
                point_count.Add(i.Key, i.Value);

                int pCount = point_count[i.Key].Count;

                if (pCount > 1)
                {
                    for (int o = 0; o < (pCount - 1); o++)
                    {
                        for (int t = o + 1; t < pCount; t++)
                        {
                            int y_sum = point_count[i.Key][o] + point_count[i.Key][t];

                            if ((y_sum % 2) == 0)
                            {
                                int y_value = y_sum / 2;

                                if (y_dict.Keys.Contains(y_value))
                                {
                                    Dictionary<int, List<int>> y_point = new Dictionary<int, List<int>>();
                                    y_point.Add(y_value, y_dict[y_value]);

                                    int y_pointCount = y_point[y_value].Count;

                                    if (y_pointCount > 1)
                                    {
                                        List<int> sort_y_point = new List<int>(y_point[y_value].ToList());
                                        sort_y_point.Sort();
                                        int min_num = sort_y_point.Min();
                                        int max_num = sort_y_point.Max();

                                        if (min_num < i.Key && i.Key < max_num)
                                        {
                                            foreach (int j in sort_y_point)
                                            {
                                                if (j < i.Key)
                                                {
                                                    if (sort_y_point.Contains((2 * i.Key) - j))
                                                    {
                                                        count++;
                                                    }
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return count;
        }
    }
}
