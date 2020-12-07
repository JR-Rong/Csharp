using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day05_jiaocuoshuzu
{
    class day05
    {
        static void Main1(string[] args)
        {
            int[][] array;
            array = new int[4][];
            array[0] = new int[2];
            array[1] = new int[3];
            array[2] = new int[4];
            array[3] = new int[5];
        }

        static void Main()
        {
            //变量值类型和引用类型的区分
            //值类型：int float char。。。
            //引用类型：string int[] object。。。
            //值类型存储在栈中，引用类型变量名存储在栈中，值存储在堆中
            int a = 1;
            int b = a;
            a = 2;
            Console.WriteLine(b);

            int[] c =  new int[1] {1};
            int[] d = c;
            c[0] = 2;
            Console.WriteLine(d[0]);

            string e = "as";
            string f = "b";
            e = "c";
            Console.WriteLine(f);

            int aa = 0;
            Abc(ref a);
            Console.WriteLine(a);

            a = 1;
            Abcd(out a);
            

            Console.Read();
        }
        //类型确定，参数个数不确定时使用数组
        //params
        private static int Add(params int[] arr)
        {
            return 0;
        }

        private static void Abc(ref int arr)
        {
            arr = 3;
        }

        private static void Abcd(out int arr)
        {//ref（引用参数） 和 out（输出参数）区别：1、方法内out必须赋值，ref不用。2、传参进入方法时，ref必须赋值，out不必
            //ref改变方法外部数据
            //out返回结果

            arr = 3;
        }
    }
}
