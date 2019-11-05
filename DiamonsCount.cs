using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    public int solution(int[] X, int[] Y)
    {
        int chkX = X.Length, chkY = Y.Length;
        if (chkX < 4 || chkX > 1500 || chkY < 4 || chkY > 1500)
        {
            return 0;
        }

        List<Int32> list_X = new List<Int32>(X);
        List<Int32> list_Y = new List<Int32>(Y);

        Dictionary<Int16, List<Int16>> x_dict = new Dictionary<Int16, List<Int16>>();
        Dictionary<Int16, List<Int16>> y_dict = new Dictionary<Int16, List<Int16>>();
        var results = list_X.Zip(list_Y, (x, y) => new { x, y });

        foreach (var data in results)
        {
            Int16 dataX = Convert.ToInt16(data.x);
            Int16 dataY = Convert.ToInt16(data.y);

            if (x_dict.Keys.Contains(dataX))
            {
                x_dict[dataX].Add(dataY);
            }
            else
            {
                x_dict.Add(dataX, new List<Int16> { dataY });
            }

            if (y_dict.Keys.Contains(dataY))
            {
                y_dict[dataY].Add(dataX);
            }
            else
            {
                y_dict.Add(dataY, new List<Int16> { dataX });
            }
        }
        
        if (x_dict.Count <= 2 || y_dict.Count <= 2)
        {
            return 0;
        }

        int count = 0;

        foreach (var i in x_dict)
        {
            Dictionary<Int16, List<Int16>> point_count = new Dictionary<Int16, List<Int16>>();
            point_count.Add(i.Key, i.Value);
            if (point_count[i.Key].Count > 1)
            {
                for (int o = 0; o < (point_count[i.Key].Count - 1); o++)
                {
                    for (int t = o + 1; t < point_count[i.Key].Count; t++)
                    {
                        Int16 y_sum = Convert.ToInt16(point_count[i.Key][o] + point_count[i.Key][t]);

                        if ((y_sum % 2) == 0)
                        {
                            Int16 y_value = Convert.ToInt16(y_sum / 2);

                            if (y_dict.Keys.Contains(y_value))
                            {
                                Dictionary<int, List<Int16>> y_point = new Dictionary<int, List<Int16>>();
                                y_point.Add(y_value, y_dict[y_value]);

                                if (y_point[y_value].Count > 1)
                                {
                                    List<Int16> sort_y_point = new List<Int16>(y_point[y_value].ToList());
                                    sort_y_point.Sort();
                                    Int16 min_num = sort_y_point[0];
                                    Int16 max_num = sort_y_point[sort_y_point.Count - 1];

                                    if (min_num < i.Key && i.Key < max_num)
                                    {
                                        foreach (var j in sort_y_point)
                                        {
                                            if (j < i.Key)
                                            {
                                                if (sort_y_point.Contains(Convert.ToInt16((2 * i.Key) - j)))
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
