using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day06
{
    class User
    {
        //字段
        private string loginId;
        //属性
        public string LoginId
        {
            get
            {
                return loginId;
            }
            set { this.loginId = value; }
        }

        public string Password
        {
            get;
            set;
        }

        //构造函数

        public User()
        {

        }

        public User(string loginId, string pwd)
        {
            this.loginId = loginId;
            this.Password = pwd;
        }

        //方法

        public void PrintUser()
        {
            Console.WriteLine("{0},{1}", LoginId, Password);
        }
    }
}
