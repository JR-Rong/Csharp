using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day03
{
    class Program
    {
        static Random random = new Random();
        static void Main1(string[] args)
        {
            Console.WriteLine("input num");
            int res = Add_and_Subtract(int.Parse(Console.ReadLine()));
            Console.WriteLine("result is:" + res);
            Console.ReadLine();
        }

        private static int Add_and_Subtract(int i)
        {
            if (i == 1) return 1;
            if (i % 2 == 0)
            {
                return -i + Add_and_Subtract(i - 1); 
            }
            else
            {
                return i + Add_and_Subtract(i - 1);
            }
        }

        static void Main2()
        {
            Console.WriteLine("请输入学生人数");
            int count = int.Parse(Console.ReadLine());
            float[] scores = GetScore(count);
            for (int i = 0; i< scores.Length; i++)
            {
                Console.WriteLine(scores[i]);
            }
            
            Console.ReadLine();
        }

        private static float[] GetScore(int count)
        {
            float[] scores = new float[count];
            for (int i = 0; i<scores.Length; )
            {
                Console.WriteLine("请输入第{0}个学生成绩", i+1);
                float score = float.Parse(Console.ReadLine());

                if (score >= 0 && score <= 100)
                {
                    scores[i++] = score;
                }
                else
                {
                    Console.WriteLine("成绩输入有误，请重新输入");
                }
                
            }
            return scores;
        }

        static void Main3()
        {
            int[] a = new int[2] { 1, 2 };
            int[] b = { 1, 2, 3 };
            //var可以自动判断数据类型如 var a = 1，var b = 2.0
            //array类型为数组的父类，各数组类型为子类，如int[],float[]...
            //子类可以幅值给父类，如array a = int[], array b = float[]
            //object为万类之父
            //数组操作：数组名.Length, Array.Clare, Array.copy, 数组名.CopyTo, 数组名.Clone, Array.IndexOf, Array.LastIndexOf, Array.Soft, Array.Reverse
            foreach (int item in new int[3] {1, 2, 3 })
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        //彩票生成器
        static void Main()
        {
            bool flag = true;
            int total_award = 50000;
            int count = 0;
            int total_win = 0;
            Console.WriteLine("双色球规则：红球6个，号码为1-33，蓝球1个，号码为1-16");

            Console.WriteLine("请输入投注数（2元一注，最少一注）：");
            int money = int.Parse(Console.ReadLine());
            total_award += 2 * money;

            Console.WriteLine("\n本期奖池总奖金为：{0}\n", total_award);

            int[] Red_ball = new int[6];
            int blue_ball = 0;

            Red_ball = BuyRedBall(Red_ball);
            blue_ball = BuyBlueBall();
            int[] buy_ball = ConcatBalls(Red_ball, blue_ball); 

            Console.WriteLine("\n购买的球为");
            for (int i = 0; i < buy_ball.Length; i++)
            {
                Console.Write("{0}\t", buy_ball[i]);
            }

            while (flag)
            {
                Console.WriteLine("\n\n第{0}次開獎中.........\n", count+1);
                int[] balls = GenerateBall();

                Console.WriteLine("\n中奖号码为");
                for (int i = 0; i < balls.Length; i++)
                {
                    Console.Write("{0}\t", balls[i]);
                }

                Console.WriteLine();

                int award = LevelCountAward(WinMoneyLevel(buy_ball, balls, total_award), money, total_award);

                if (award > 0)
                {
                    Console.WriteLine("恭喜你獲得了{0}元獎金", award);
                }
                else
                {
                    Console.WriteLine("謝謝參與！\n");
                }

                total_win += award;

                count++;

                if (count >= money)
                { 
                    break;
                }

                //Console.WriteLine("是否繼續抽獎?(Y/N)");
                //string cont_flag = Console.ReadLine();
                //if (cont_flag == "N" || cont_flag == "n")
                //{
                //    break;
                //}
                //else if(cont_flag == "Y" || cont_flag == "y" || cont_flag == "")
                //{
                //    count++;
                //}     
                
            }
            Console.WriteLine("開獎結束");
            Console.WriteLine("共花費{0}元,賺了{1}元", count * 2, total_win);
            Console.ReadLine();

        }

        private static int[] BuyRedBall(int[] Red_ball)
        {
            int temp=0;
            for (int i = 0; i < Red_ball.Length;)
            {
                Console.WriteLine("请输入第{0}个红球号码", i+1);
                temp = int.Parse(Console.ReadLine());
                if (temp > 0 && temp < 34 && !(Array.IndexOf(Red_ball, temp) >= 0))
                    Red_ball[i++] = temp;
                else
                    Console.WriteLine("请重新输入");
            }
            Array.Sort(Red_ball);
            return Red_ball;
        }

        private static int BuyBlueBall()
        {
            Console.WriteLine("请输入蓝球号码");
            return int.Parse(Console.ReadLine());
        }

        private static int[] GenerateBall()
        {
            int[] redball = new int[6];
            int[] ball = new int[7];
            for (int i = 0; i < redball.Length;)
            {
                int temp = random.Next(1, 34);
                if (Array.IndexOf(redball, temp) < 0)
                {
                    redball[i++] = temp;
                }
            }
            Array.Sort(redball);
            int blueball = random.Next(1, 17);
            redball.CopyTo(ball, 0);
            ball[6] = blueball;
            return ball;
        }

        private static int[] ConcatBalls(int[] red, int blue)
        {
            int[] balls = new int[7];
            red.CopyTo(balls, 0);
            balls[6] = blue;
            return balls;
        }

        private static int WinMoneyLevel(int[] buy, int[] goal, int money)
        {
            int[] red = new int[buy.Length - 1];
            Array.Copy(buy, 0, red, 0, 6);
            int red_hit = 0, blue_hit = 0;
            for (int i = 0; i < red.Length; i++)
            {
                if (Array.IndexOf(red, goal[i]) >= 0)
                {
                    red_hit++;
                }
            }

            if (goal[6] == buy[6]) blue_hit++; 

            if (red_hit == 6 && blue_hit == 1)
            {
                return 1;
            }
            else if (red_hit == 6 && blue_hit == 0)
            {
                return 2;
            }
            else if (red_hit == 5 && blue_hit == 1)
            {
                return 3;
            }
            else if ((red_hit == 5 && blue_hit == 0) || (red_hit == 4 && blue_hit == 1))
            {
                return 4;
            }
            else if ((red_hit == 4 && blue_hit == 0) || (red_hit == 3 && blue_hit == 1))
            {
                return 5;
            }
            else if (red_hit < 3 && blue_hit == 1)
            {
                return 6;
            }
            else
            {
                return 0;
            }
        }

        private static int LevelCountAward(int level, int money, int total)
        {
            switch (level)
            {
                case 1:
                    return (int)(((float)total - 3215) * 0.7);
                case 2:
                    return (int)(((float)total - 3215) * 0.3);
                case 3:
                    return 3000;
                case 4:
                    return 200;
                case 5:
                    return 10;
                case 6:
                    return 5;
                default:
                    return 0;
            }
              
        }
    }
}
