using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace James_is_Bussinessman
{
    class Program
    {

        [STAThread]

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public static string[] dateArray = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

        public static string inputStringA = @"Sun 10:00-20:00
Fri 05:00-10:00
Fri 16:30-23:50
Sat 10:00-24:00
Sun 01:00-04:00
Sat 02:00-06:00
Tue 03:30-18:15
Tue 19:00-20:00
Wed 04:25-15:14
Wed 15:14-22:40
Thu 00:00-23:59
Mon 05:00-13:00
Mon 15:00-21:00";

        public static string inputStringB = @"Mon 01:00-23:00
Tue 01:00-23:00
Wed 01:00-23:00
Thu 01:00-23:00
Fri 01:00-23:00
Sat 01:00-23:00
Sun 01:00-21:00";

        public static string SplitText(string inputText, string[] splitChar, int index)
        {
            string result = "";

            result = inputText.Split(splitChar, StringSplitOptions.None)[index];

            return result;
        }
        static void Main(string[] args)
        {
            AllocConsole();

            string A = inputStringA;
            Console.WriteLine("Original String");
            Console.WriteLine(A);
            Console.WriteLine(Environment.NewLine);

            string[] stringArray = A.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            List<string> stringList = new List<string>();

            Console.WriteLine("Transform String");

            foreach (string d in dateArray)
            {
                int addindex = 0;
                string dateResult = "";

                List<string> tempString = new List<string>();

                for (int i = 0; i < stringArray.Length; i++)
                {
                    if (stringArray[i].Contains(d))
                    {
                        addindex = i;
                        tempString.Add(stringArray[addindex]);
                    }

                    //if (i == stringArray.Length - 1)
                    //{
                    //    stringList.Add(stringArray[addindex]);
                    //    Console.WriteLine(stringArray[addindex]);
                    //}
                }
                tempString.Sort();
                dateResult = "";
                dateResult = d + " " + SplitText(tempString[0], new string[] { " ", "-" }, 1) + "-" + SplitText(tempString[tempString.Count - 1], new string[] { " ", "-" }, 2);
                stringList.Add(dateResult);
                Console.WriteLine(dateResult);
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Split Text");

            int maxTimeSleep = 0;
            string beforeDay = "";
            int x = 0;

            for (int i = 0; i < stringList.Count; i++)
            {
                string stringMessage = stringList[i];
                Console.WriteLine((i + 1).ToString() + " : " + stringMessage);

                string currentDay = stringMessage.Substring(0, 3);

                string startTime = "";
                string endTime = "";

                DateTime startDate = new DateTime();
                DateTime endDate = new DateTime();

                if (i == 0)
                {
                    startTime = SplitText(stringList[i], new string[] { " ", "-" }, 2);

                    endTime = SplitText(stringList[i + 1], new string[] { " ", "-" }, 1);

                    var dateValue = DateTime.Now.AddDays(x);
                    var dateValue2 = DateTime.Now.AddDays(x += 1);

                    var startDateString = DateTime.TryParse(SplitText(dateValue.ToString(), new string[] { " ", "-" }, 0) + " " + startTime.Replace("24", "00") + ":00", out startDate);
                    if (startTime.Substring(0, 2) == "24")
                    {
                        startDate.AddDays(1);
                    }
                    Console.WriteLine("startDateTime : " + startDate.ToString());

                    var endDateString = DateTime.TryParse(SplitText(dateValue2.ToString(), new string[] { " ", "-" }, 0) + " " + endTime.Replace("24", "00") + ":00", out endDate);
                    Console.WriteLine("endDateTime : " + endDate.ToString());

                }
                else if (i < stringList.Count - 1)
                {
                    beforeDay = stringList[i - 1].Substring(0, 3);

                    if (currentDay != beforeDay)
                    {
                        x += 1;
                    }

                    startTime = SplitText(stringList[i], new string[] { " ", "-" }, 2);

                    endTime = SplitText(stringList[i + 1], new string[] { " ", "-" }, 1);

                    var dateValue = DateTime.Now.AddDays(x - 1);
                    if (startTime.Substring(0, 2) == "24")
                    {
                        dateValue = DateTime.Now.AddDays(x);
                    }
                    var dateValue2 = DateTime.Now.AddDays(x);

                    var startDateString = DateTime.TryParse(SplitText(dateValue.ToString(), new string[] { " ", "-" }, 0) + " " + startTime.Replace("24", "00") + ":00", out startDate);

                    Console.WriteLine("startDateTime : " + startDate.ToString());

                    var endDateString = DateTime.TryParse(SplitText(dateValue2.ToString(), new string[] { " ", "-" }, 0) + " " + endTime.Replace("24", "00") + ":00", out endDate);
                    Console.WriteLine("endDateTime : " + endDate.ToString());

                }
                else
                {
                    beforeDay = stringList[i - 1].Substring(0, 3);

                    if (currentDay == beforeDay)
                    {
                        x += 1;
                    }

                    startTime = SplitText(stringList[i], new string[] { " ", "-" }, 2);

                    endTime = SplitText(stringList[i], new string[] { " ", "-" }, 1);

                    var dateValue = DateTime.Now.AddDays(x - 1);
                    if (startTime.Substring(0, 2) == "24")
                    {
                        dateValue = DateTime.Now.AddDays(x);
                    }
                    var dateValue2 = DateTime.Now.AddDays(x);

                    var startDateString = DateTime.TryParse(SplitText(dateValue.ToString(), new string[] { " ", "-" }, 0) + " " + startTime.Replace("24", "00") + ":00", out startDate);
                    Console.WriteLine("startDateTime : " + startDate.ToString());

                    var endDateString = DateTime.TryParse(SplitText(dateValue2.ToString(), new string[] { " ", "-" }, 0) + " 00:00:00", out endDate);
                    Console.WriteLine("endDateTime : " + endDate.ToString());

                }

                var timeSleep = endDate.Subtract(startDate);
                Console.WriteLine("timeSleep : " + timeSleep.TotalMinutes.ToString());
                maxTimeSleep = Convert.ToInt32(timeSleep.TotalMinutes) > maxTimeSleep ? Convert.ToInt32(timeSleep.TotalMinutes) : maxTimeSleep;

            }

            Console.WriteLine("maxTimeSleep : " + maxTimeSleep.ToString());

        }


    }
}
