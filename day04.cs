using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day04
{
    class day04
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            int[,] chessboard = new int[4,4];
            chessboard = RandomCreateNumOnBoard(chessboard);
            PrintChessBoard(chessboard);

            while (true)
            {
                int direction = GetOperation();

                if (direction == 0)
                {
                    continue;
                }
                for (int i=0; i<4; i++)
                {
                    int[] array = GetArrayFromBoard(direction, i, chessboard);
                    array = OperateArray(array);
                    chessboard = PutArray2Board(direction, i, array, chessboard);
                }
                chessboard = RandomCreateNumOnBoard(chessboard);
                Console.Clear();
                PrintChessBoard(chessboard);
                if (WhetherGameOver(chessboard) == 1)
                {
                    break;
                }
            }
            Console.WriteLine("游戏结束！！");
            Console.ReadLine();

        }


        private static int[,] RandomCreateNumOnBoard(int[,] chessboard)
        {
            int probability =1, num_prob=1;
            for (int i =0; i< 4; i++)
            {
                for (int j=0; j < 4; j++)
                {
                    probability = random.Next(1, 5);
                    num_prob = random.Next(1, 7);
                    if (chessboard[i, j] == 0 && probability == 1)
                    {
                        switch (num_prob)
                        {
                            case 1:
                            case 2:
                            case 3:
                                chessboard[i, j] = 2;
                                break;
                            case 4:
                            case 5:
                                chessboard[i, j] = 4;
                                break;
                            case 6:
                                chessboard[i, j] = 8;
                                break;
                        }
                    }
                }
            }
            return chessboard;
        }

        private static int GetOperation()
        {
            Console.WriteLine("\n\tw/s/a/d ?");
            string op = Console.ReadLine();
            switch(op)
            {
                case "w":
                    return 1;
                case "s":
                    return 2;
                case "a":
                    return 3;
                case "d":
                    return 4;
                default:
                    return 0;
            }

        }

        private static void PrintChessBoard(int[,] chessboard)
        {
            Console.WriteLine("\n\t2\t0\t4\t8\n\n");
            Console.WriteLine("\t-------------------------------");
            for (int i = 0; i<4; i++)
            {
                Console.Write("\t");
                for(int j = 0; j<4; j++)
                {
                    Console.Write("{0}\t", chessboard[i, j]);
                }
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// 从棋盘上获得一维数组，并返回数组
        /// </summary>
        /// <param name="direction"></param>操作方向 1234分别为上下左右
        /// <param name="i"></param>返回二维数组第i行
        /// <param name="chessboard"></param>二维数组
        /// <returns></returns>
        private static int[] GetArrayFromBoard(int direction, int i, int[,] chessboard)
        {
            int[] array = new int[4];
            switch (direction)
            {
                case 1:
                    for (int j = 0; j < 4; j++)
                    {
                        array[j] = chessboard[j, i];
                    }
                    break;
                case 2:
                    for (int j = 3; j >=0 ; j--)
                    {
                        array[3 - j] = chessboard[j, i];
                    }
                    break;
                case 3:
                    for (int j = 0; j < 4; j++)
                    {
                        array[j] = chessboard[i, j];
                    }
                    break;
                case 4:
                    for (int j = 3; j >= 0; j--)
                    {
                        array[3 - j] = chessboard[i, j];
                    }
                    break;
            }
            
            return array;
        }

        private static int[] OperateArray(int[] array)
        {
            array = MoveZeroFromArray(array);
            array = CombineSameNum(array);
            return array;
        }

        private static int[] MoveZeroFromArray(int[] array)
        {
            for (int j=0; j<3; j++)
            {
                for (int i = 3; i > 0; i--)
                {
                    if (array[i - 1] == 0 && array[i] != 0)
                    {
                        array[i - 1] = array[i];
                        array[i] = 0;
                    }
                }
            }
            return array;
        }

        private static int[] CombineSameNum(int[] array)
        {
            for (int i=0; i<3; i++)
            {
                if (array[i] == array[i+1])
                {
                    array[i] += array[i + 1];
                    array[i + 1] = 0;
                }
            }
            array = MoveZeroFromArray(array);
            return array;
        }

        private static int[,] PutArray2Board(int direction, int i, int[] array, int[,] chessboard)
        {
            switch (direction)
            {
                case 1:
                    for (int j = 0; j < 4; j++)
                    {
                        chessboard[j, i] = array[j];
                    }
                    break;
                case 2:
                    for (int j = 3; j >= 0; j--)
                    {
                        chessboard[j, i] = array[3 - j];
                    }
                    break;
                case 3:
                    for (int j = 0; j < 4; j++)
                    {
                        chessboard[i, j] = array[j];
                    }
                    break;
                case 4:
                    for (int j = 3; j >= 0; j--)
                    {
                        chessboard[i, j] = array[3 - j];
                    }
                    break;
            }
            return chessboard;
        }

        private static int WhetherGameOver(int[,] chessboard)
        {
            for (int i = 0; i<4; i++)
            {
                for (int j = 0; j<4; j++)
                {
                    if (chessboard[i, j] == 0)
                    {
                        return 0;
                    }
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (chessboard[i, j] == chessboard[i, j + 1])
                    {
                        return 0;
                    }
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (chessboard[j, i] == chessboard[j + 1, i])
                    {
                        return 0;
                    }
                }
            }

            return 1;
        }


    }
}
