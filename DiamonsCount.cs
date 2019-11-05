using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    public int solution(int[] X, int[] Y)
    {
        List<int> list_X = new List<int>(X);
        List<int> list_Y = new List<int>(Y);

        Dictionary<int, List<int>> x_dict = new Dictionary<int, List<int>>();
        Dictionary<int, List<int>> y_dict = new Dictionary<int, List<int>>();

        var results = list_X.Zip(list_Y, (x, y) => new { x, y });

        foreach (var data in results)
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

        if (x_dict.Count <= 2 || y_dict.Count <= 2)
        {
            return 0;
        }

        int count = 0;

        foreach (var i in x_dict)
        {
            Dictionary<int, List<int>> point_count = new Dictionary<int, List<int>>();
            point_count.Add(i.Key, i.Value);
            if (point_count[i.Key].Count > 1)
            {
                for (int o = 0; o < (point_count[i.Key].Count - 1); o++)
                {
                    for (int t = o + 1; t < point_count[i.Key].Count; t++)
                    {
                        int y_sum = point_count[i.Key][o] + point_count[i.Key][t];

                        if ((y_sum % 2) == 0)
                        {
                            int y_value = y_sum / 2;

                            if (y_dict.Keys.Contains(y_value))
                            {
                                Dictionary<int, List<int>> y_point = new Dictionary<int, List<int>>();
                                y_point.Add(y_value, y_dict[y_value]);

                                if (y_point[y_value].Count > 1)
                                {
                                    var sort_y_point = y_point[y_value].ToList();
                                    sort_y_point.Sort();
                                    int min_num = sort_y_point[0];
                                    int max_num = sort_y_point[sort_y_point.Count - 1];

                                    if (min_num < i.Key && i.Key < max_num)
                                    {
                                        foreach (var j in sort_y_point)
                                        {
                                            if (j < i.Key)
                                            {
                                                if (sort_y_point.Contains((2 * i.Key) - j))
                                                {
                                                    count += 1;
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
