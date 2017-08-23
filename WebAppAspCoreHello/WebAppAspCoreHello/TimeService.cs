using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAspCoreHello
{
    public class TimeService
    {
        public string gettime() => System.DateTime.Now.ToString();
    }
}
