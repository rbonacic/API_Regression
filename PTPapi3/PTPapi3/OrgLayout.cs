using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


        public class RootobjectOrg
        {
            public global::Ptpexecution PtpExecution { get; set; }
           
        }

        public class Ptpexecution
        {
            public int Id { get; set; }
            public string DemographicRequestId { get; set; }
            public string LastRanDate { get; set; }
            public string OrganizationToken { get; set; }
        }

    

