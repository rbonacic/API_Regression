using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using Newtonsoft.Json.Linq;

namespace PTPapi3
{
    [CodedUITest]
    public class FujiRegression
    {
        [TestMethod]
        public void ValidateDuplicateVisit()
        {
            Api api = new Api();
            Env env = new Env("QA");
            PayloadVisit fpv = new PayloadVisit();

            //Get the VisitId
            string response = api.ApiCall(new Env("QA"), Method.POST, fpv.payloadVisit);
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
                Env env = new Env("QA");

                PayloadVisit fpv = new PayloadVisit();
                fpv.payloadVisit.patient.patientAccountNumber = "QA" + DateTime.Now.ToString("yyMMdd-HHmmss");

                //Get the VisitId
                string visitID = api.ApiCall(new Env("QA"), Method.POST, fpv.payloadVisit); //Post visit

                //Parse for VisitId
                JObject IDobject = JObject.Parse(visitID);
                var ID = IDobject["id"];
                
                //Get the SSO User Token ID
                TestData usr = new TestData();
                string tokenID = api.ApiCall(env, Method.POST, usr.TestUser); //Post SSO user for token
            
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
    }

    public class CodedUITestAttribute : Attribute
    {
    }
}
