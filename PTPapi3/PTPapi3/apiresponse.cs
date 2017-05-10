using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPapi3
{
   public class apiresponse
    {
        public class Rootobject
        {
            public int id { get; set; }
            public object[] messages { get; set; }
        }

    }
}
