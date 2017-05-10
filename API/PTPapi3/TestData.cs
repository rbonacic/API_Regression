using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPapi3
{
    public class TestData: Rootobject
    {
        public ssoUser TestUser = new ssoUser()
        {
            userId = "9999",
            firstName = "9999",
            lastName = "999",
            facilityId = 999
        };
    }
}
