using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPapi3
{
    class FujiApi
    {
        [CodedUITest]
        public class CodedUITest1
        {
            private const string Uri =
                "https://qa-patientaccess.availity.com/public/api/";

            [TestMethod]
            public void FujiOne()
            {
                try
                {
                    var client = new RestClient(Uri);
                    var request = new RestRequest(Method.POST);

                    var payload = new fujiRootobject()
                    {
                        facilityId = "528",
                        facilityAssociationTypeCode = "1",
                        visitServiceDate = "2017-01-30",
                        serviceCategoryCode = "CLI",

                        patient = new Patient()
                        {
                            firstName = "Jeff",
                            middleName = "M",
                            lastName = "Adams",
                            suffix = "",
                            patientAccountNumber = "B1ELGINA8",
                            medicalRecordNumber = "HEY820582637",
                            birthDate = "1986-07-28",
                            genderCode = "M",
                        },
                        guarantor = new Guarantor()
                        {
                            firstName = "Jeff",
                            middleName = "M",
                            lastName = "Adams",
                            suffix = "",
                            birthDate = "1986-07-28",
                            genderCode = "M",
                            phone = "912-425-7349",

                            address = new Address()
                            {
                                line1 = "603 DAVIS STREET",
                                city = "SYLVANIA",
                                stateCode = "GA",
                                zipCode = "30467"
                            }
                        },
                        orderingProvider = new Orderingprovider()
                        {
                            firstName = "Mike",
                            middleName = "fi",
                            lastName = "Thomas",
                            suffix = "",
                            npi = "1326043548"
                        },

                        orderControlNumber = "2345234",

                        coverages = new Coverage[] {
                            new Coverage()
                            {
                                payerId = "BC.PPO",

                                subscriber = new Subscriber()
                                {
                                firstName = "CLIFFORD",
                                middleName = "M",
                                lastName = "ADAMS",
                                suffix = "",
                                birthDate = "1986-07-28",
                                genderCode = "M",
                                ssn = "",
                                memberId = "HEY820582637",
                                patientRelationship = "Self"
                                },
                                serviceTypeCodes = new string[1]{"30"}
                            }

                        },

                        services = new Service[]
                        {
                            new Service
                            {
                                procedureCode = "57500",
                                description = "Hello World",
                                dateEntered = "2017-01-10",
                                units = 1,
                                accessionNumber = "1321467",
                                procedureChargeAmount = "1235.50",
                                diagnosisCodes = new string[2] {"m5003","m5001"}
                            }
                        }
                    };
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}