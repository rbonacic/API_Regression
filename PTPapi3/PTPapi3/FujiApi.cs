using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Availity.QA;
using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;

namespace PTPapi3
{
    [CodedUITest]
    public class FujiRegression
    {
        [TestMethod]
        public void ValidateDuplicateVisit()
        {
            Api api = new Api();
            EnvFuji env = new EnvFuji("QUA");
            FujiPayloadVisit fpv = new FujiPayloadVisit();

            //Get the VisitId
            string response = api.ApiCall(new Availity.QA.EnvFuji("QUA"), Method.POST, fpv.payloadVisit);
            var deserializedResponse = JObject.Parse(response);
           
            //string description = descriptionObject.messages.description;
            var description = deserializedResponse["messages"].Children()["description"];

        }

        [TestMethod]
        public void CreateVisit()
        {
            try
            {
                Api api = new Api();
                EnvFuji env = new EnvFuji("QUA");

                FujiPayloadVisit fpv = new FujiPayloadVisit();
                fpv.payloadVisit.patient.patientAccountNumber = "QA-FUJI-" + DateTime.Now.ToString("yyMMdd-HHmmss");

                //Get the VisitId
                string visitID = api.ApiCall(new Availity.QA.EnvFuji("QUA"), Method.POST, fpv.payloadVisit); //Post visit

                //Parse for VisitId
                JObject IDobject = JObject.Parse(visitID);
                var ID = IDobject["id"];
                
                //Get the SSO User Token ID
                TestData usr = new TestData();
                string tokenID = api.ApiCall(env, Method.POST, usr.ssoLFAdmin); //Post SSO user for token
            
                //parse for Accesstoken
                JObject accessTokenObject = JObject.Parse(tokenID);
                var accessToken = accessTokenObject["accessToken"];

              if (ID != null && accessToken != null)
                {

                    //add logic to use with accessstoken and ID 
                }

            }
            
            catch (Exception ex)

            {
                throw ex;
            }

        }

        //[CodedUITest]
        //public class Original_Test
        //{
        //    private const string Uri = "https://qa-patientaccess.availity.com/public/api/v1/visits";
        //    private const string Key = "vbc9gtwhj8d7mfhyv3zwp67h";
        //    private const string Secret = "SECRET";
        //    private const string Callback = "https://tst-rcm-mirth.availity.net/webhooks/api/v1/notify";



        //    [TestMethod]
        //    public void FujiOne()
        //    {
        //        try
        //        {
        //            var client = new RestClient(Uri);
        //            var request = new RestRequest(Method.POST);

        //            var payload = new fujiRootobject()
        //            {
        //                facilityId = "528",
        //                facilityAssociationTypeCode = "1",
        //                visitServiceDate = "2017-01-30",
        //                serviceCategoryCode = "CLI",

        //                patient = new Patient()
        //                {
        //                    firstName = "Jeff",
        //                    middleName = "M",
        //                    lastName = "Adams",
        //                    suffix = "",
        //                    patientAccountNumber = "B1ELGINA8",
        //                    medicalRecordNumber = "HEY820582637",
        //                    birthDate = "1986-07-28",
        //                    genderCode = "M",
        //                },
        //                guarantor = new Guarantor()
        //                {
        //                    firstName = "Jeff",
        //                    middleName = "M",
        //                    lastName = "Adams",
        //                    suffix = "",
        //                    birthDate = "1986-07-28",
        //                    genderCode = "M",
        //                    phone = "912-425-7349",

        //                    address = new Address()
        //                    {
        //                        line1 = "603 DAVIS STREET",
        //                        city = "SYLVANIA",
        //                        stateCode = "GA",
        //                        zipCode = "30467"
        //                    }
        //                },
        //                orderingProvider = new Orderingprovider()
        //                {
        //                    firstName = "Mike",
        //                    middleName = "fi",
        //                    lastName = "Thomas",
        //                    suffix = "",
        //                    npi = "1326043548"
        //                },

        //                orderControlNumber = "2345234",

        //                coverages = new Coverage[] {
        //                    new Coverage()
        //                    {
        //                        payerId = "BC.PPO",

        //                        subscriber = new Subscriber()
        //                        {
        //                        firstName = "CLIFFORD",
        //                        middleName = "M",
        //                        lastName = "ADAMS",
        //                        suffix = "",
        //                        birthDate = "1986-07-28",
        //                        genderCode = "M",
        //                        ssn = "",
        //                        memberId = "HEY820582637",
        //                        patientRelationship = "Self"
        //                        },
        //                        serviceTypeCodes = new string[1]{"30"}
        //                    }

        //                },

        //                services = new Service[]
        //            {
        //                    new Service
        //                    {
        //                        procedureCode = "57500",
        //                        description = "Hello World",
        //                        dateEntered = "2017-01-10",
        //                        units = 1,
        //                        accessionNumber = "1321467",
        //                        procedureChargeAmount = "1235.50",
        //                        diagnosisCodes = new string[2] {"m5003","m5001"}
        //                    }
        //            }
        //            };








        //            request.AddHeader("X-Api-Key", Key);
        //            request.AddHeader("sig", Availity.QA.Tools.sha256(Key + Secret + Availity.QA.Tools.epochTime()));
        //            request.AddHeader("X-CALLBACK-URL", Callback);
        //            request.AddHeader("Content-Type", "application/json");


        //            request.RequestFormat = DataFormat.Json;
        //            request.AddBody(payload);
        //            var response = client.Execute(request); //execute 
        //            {
        //                if (response.StatusCode == HttpStatusCode.OK) { Assert.AreEqual("", response.ContentEncoding); }

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}
    }
}
