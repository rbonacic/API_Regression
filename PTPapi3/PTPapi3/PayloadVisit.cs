using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPapi3
{
    public class PayloadVisit:Rootobject
    {

        public Rootobject payloadVisit = new Rootobject()
        {
            facilityId = "999",
            facilityAssociationTypeCode = "999",
            visitServiceDate = "2017-01-30",
            serviceCategoryCode = "CLI",

            patient = new Patient()
            {
                firstName = "TEST",
                middleName = "M",
                lastName = "TEST",
                suffix = "",
                patientAccountNumber = "TEST",
                medicalRecordNumber = "TEST",
                birthDate = "1986-07-28",
                genderCode = "M",
            },
            guarantor = new Guarantor()
            {
                firstName = "TEST",
                middleName = "T",
                lastName = "TEST",
                suffix = "",
                birthDate = "1986-07-28",
                genderCode = "M",
                phone = "912-555-5555",

                address = new Address()
                {
                    line1 = "603 TEST STREET",
                    city = "TEST",
                    stateCode = "TN",
                    zipCode = "37211"
                }
            },
            orderingProvider = new Orderingprovider()
            {
                firstName = "TEST",
                middleName = "Test",
                lastName = "Test",
                suffix = "",
                npi = "9999999"
            },

            orderControlNumber = "999999",

            coverages = new Coverage[] {
                        new Coverage()
                        {
                            payerId = "BC.PPO",

                            subscriber = new Subscriber()
                            {
                            firstName = "Test",
                            middleName = "t",
                            lastName = "Test",
                            suffix = "",
                            birthDate = "1986-07-28",
                            genderCode = "M",
                            ssn = "",
                            memberId = "99999999",
                            patientRelationship = "Self"
                            },
                            serviceTypeCodes = new string[1]{"30"}
                        }

                    },

            services = new Service[]
                   {
                        new Service
                        {
                            procedureCode = "9999",
                            description = "Hello World",
                            dateEntered = "2017-01-10",
                            units = 1,
                            accessionNumber = "999999",
                            procedureChargeAmount = "1235.50",
                            diagnosisCodes = new string[2] {"999","999"}
                        }
                   }
        };
    }
}
