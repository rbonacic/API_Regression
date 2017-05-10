using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPapi3
{
    public class TestData
    {
        public ssoUser ssoLF = new ssoUser()
        {
            userId = "126LF",
            firstName = "LF-BTEST",
            lastName = "UserLF",
            facilityId = 528
        };

        public ssoUser ssoLFAdmin = new ssoUser()
        {
            userId = "126LFA",
            firstName = "LFA-BTEST",
            lastName = "UserLFA",
            facilityId = 528
        };

        public ssoUser ssoLFReport = new ssoUser()
        {
            userId = "126LFR",
            firstName = "LFR-BTEST",
            lastName = "UserLFR",
            facilityId = 528
        };

        public ssoUser ssoLFReportAdmin = new ssoUser()
        {
            userId = "126LFRA",
            firstName = "LFRA-BTEST",
            lastName = "UserLFRA",
            facilityId = 528
        };
    }
}
