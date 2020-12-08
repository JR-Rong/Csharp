using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day06
{

    class day06
    {
        static void Main(string[] args)
        {
            PrintPersonStyle(PersonSytle.tall);
            Wife wife01;
            wife01 = new Wife();
            wife01.SetName("abc");
            Console.WriteLine(wife01.GetName());

            Wife wife02 = new Wife();
            wife02.Name = "真理";
            Console.WriteLine(wife02.Name);

            Wife[] wifearr = new Wife[3];
            wifearr[0] = new Wife("01", 25);
            wifearr[1] = new Wife("02", 18);
            wifearr[2] = new Wife("03", 20);

            Wife smallwife = Abc(wifearr);




            Console.ReadLine();
        }

        private static Wife Abc(Wife[] wifearr)
        {
            Wife temp = wifearr[0];
            for (int i = 0; i < 3; i++)
            {
                if (temp.Age > wifearr[i].Age)
                {
                    temp = wifearr[i];
                }

            }
            return temp;
        }

        private static void PrintPersonStyle(PersonSytle style)
        {
            if(style == PersonSytle.tall)
            {
                Console.WriteLine("高个子");
            }
            else
            {
                Console.WriteLine("hao");
            }
        }
    }
}
