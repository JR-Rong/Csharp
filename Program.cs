using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day02
{
    class Program
    {
        static void Main1(string[] args)
        {
            string gunname = "AK47";
            string ammoCapcity = "30";
            
            string str = 
                string.Format("枪名称为：{0}, 剩余容量为：{1}", gunname, ammoCapcity);
            Console.WriteLine(str);
            Console.WriteLine("{0:d2}", 5);
            Console.WriteLine("{0:f2}", 1.33);
            Console.WriteLine("{0:p1}", 0.1);
            Console.WriteLine("i love \"unity\"!");
            Console.WriteLine("i love \n\t!");

            Console.ReadLine();
        }

        static void Main2()
        {
            float n1 = 5, n2 = 2;
            float res = n1 / n2;
            int a = 1;
            string b = a > 2 ? "yes" : "no";
            Console.WriteLine(b);
            Console.ReadLine();

        }

        static void Main3()
        {
            //数据类型转换
            //string num = "19";
            //int num1 = int.Parse(num);
            //float num2 = float.Parse(num);

            //string str = num2.ToString();

            Console.WriteLine("请输入一个4位数字：");
            string user_Input_Num = Console.ReadLine();
            int res = int.Parse(user_Input_Num[0].ToString());
            res += int.Parse(user_Input_Num[1].ToString());
            res += int.Parse(user_Input_Num[2].ToString());
            res += int.Parse(user_Input_Num[3].ToString());
            Console.WriteLine("结果为：{0}", res);
            Console.ReadLine();

        }

        static void Main4()
        {
            //隐式转换
            byte n1 = 100;
            int i1 = n1;

            int n2 = 100;
            byte i2 = (byte)n2;

        }

        static void Main5()
        {
            Console.WriteLine("请输入性别：");
            string sex = Console.ReadLine();
            if (sex == "男")
            {
                Console.WriteLine("nan");
            }
            else if (sex == "女")
            {
                Console.WriteLine("nv");
            }
            else
            {
                Console.WriteLine("unknow");
            }

        }

        static void Main6()
        {
            int res;
            Console.WriteLine("输入第一个数");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("输入第二个数");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("输入一个符号");
            string op = Console.ReadLine();

            switch (op)
            {
                case "+":
                    res = num1 + num2;
                    break;
                case "-":
                    res = num1 - num2;
                    break;
                case "*":
                    res = num1 * num2;
                    break;
                case "/":
                    res = num1 / num2;
                    break;
                default:
                    res = -1;
                    break;
            }

        }

        static void Main7()
        {
            int i = 0;
            float height = 100, distance = 0;
            for (; (height/2) >= 0.01; i++)
            {
                distance += height;
                height /= 2;
                distance += height;
            }
            distance += height;
            Console.WriteLine("共弹了{0}次，共弹了{1}米", i, distance);
            Console.ReadLine();

        }

        static void Main8()
        {
            //猜随机数
            Random random = new Random();
            int num = random.Next(0, 101);
            Console.WriteLine("请输入一个数");
            int user_num = int.Parse(Console.ReadLine());
            int i = 1;
            while (user_num != num)
            {
                if (user_num > num)
                {
                    Console.WriteLine("大了");
                    user_num = int.Parse(Console.ReadLine());
                }
                else if (user_num < num)
                {
                    Console.WriteLine("小了");
                    user_num = int.Parse(Console.ReadLine());
                }
                i++;
            }
            Console.WriteLine("猜对了！,猜了{0}次", i);
            Console.ReadLine();
        }

        private static void Fun1()
        {
            Console.WriteLine("fun1执行了");
            Console.ReadLine();
        }

        static void Main9()
        {
            Fun1();
        }


        static void Main()
        {
            Console.WriteLine("请输入年份：");
            int year = int.Parse(Console.ReadLine());
            Print_Year(year);
            Console.ReadLine();
        }
        /// <summary>
        /// 根据年月日得到星期几的方法
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        private static int GetWeekByDay(int year, int month, int day)
        {
            DateTime dt = new DateTime(year, month, day);
            return (int)dt.DayOfWeek;
        }

        private static int Get_Daynum_Of_month(int month, int flag = 0)
        {
            switch (month)
            {
                case 2:
                    if (flag == 1)
                    {
                        return 29;
                    }
                    else
                    {
                        return 28;
                    }
                    break;
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                    break;
                default:
                    return 30;
                    break;
            }
        }

        private static int Judge_Run_Year(int year)
        {
            if (year % 4 != 0)
            {
                return 0;
            }
            else
            {
                if (year % 400 != 0 && year % 100 == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        private static void Print_Month(int year, int month)
        {
            Console.WriteLine("{0}年{1}月", year, month);
            Console.WriteLine();
            Console.WriteLine("日\t一\t二\t三\t四\t五\t六");
            for (int i=0; i< GetWeekByDay(year, month, 1); i++)
            {
                Console.Write("\t");
            }

            for (int i = 1; i<=Get_Daynum_Of_month(month, Judge_Run_Year(year)); i++)
            {
                Print_Day(year, month, i);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void Print_Day(int year, int month, int day)
        {
            Console.Write("{0}\t", day);
            if (GetWeekByDay(year, month, day) == 6)
            {
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static void Print_Year(int year)
        {
            for (int i=1; i<=12; i++)
            {
                Print_Month(year, i);
            }
        }

    }
}
