using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day06
{
    class Wife
    {
        private string name;

        private string sex;

        private int age;

        public Wife()
        {
            Console.WriteLine("老婆被创建出来了");
        }
        public Wife(string name):this()
        {
            this.name = name;
        }
        public Wife(string name, int age):this(name)
        {
            this.age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set 
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public Wife Abc(Wife[] wifearr)
        {
            Wife temp = wifearr[0];
            for (int i = 0; i < 5; i++)
            {
                if (temp.age > wifearr[i].age)
                {
                    temp = wifearr[i];
                }
            }
            return temp;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
    }
}
