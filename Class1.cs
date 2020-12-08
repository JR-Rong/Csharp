using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day06
{
    [Flags]//可以多选
    enum PersonSytle
    {
        tall = 1, 
        rich = 2,
        handsome = 4,
        white = 8,
        beautiful = 16
    }
}
