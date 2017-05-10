using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Availity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Newtonsoft;

namespace Availity.QA
{
    public class Tools
    {
        public static string sha256(string value)
        {
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(value), 0, Encoding.UTF8.GetByteCount(value));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        public static string epochTime()
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (DateTime.UtcNow - dt).Ticks.ToString().Substring(0, 10);
        }
    }

    public class EnvFuji
    {
        public string UriVisit { get; set; }
        public string UriSSO { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
        public string Callback { get; set; }
        
        public EnvFuji(string Environment)
        {
            switch (Environment.ToUpper())
            {
                case "QUA":
                    this.QUA();
                    break;
                case "TV":
                    this.TV();
                    break;
            }

        }
        private void QUA()
        {
            this.UriVisit = "https://qa-patientaccess.availity.com/public/api/v1/visits";
            this.UriSSO = "https://qa-patientaccess.availity.com/public/api/v1/sso";
            this.Key = "vbc9gtwhj8d7mfhyv3zwp67h";
            this.Secret = "SECRET";
            this.Callback = "https://tst-rcm-mirth.availity.net/webhooks/api/v1/notify";
        }
        private void TV()
        {
            this.UriVisit = "https://qa-patientaccess.availity.com/public/api/v1/visits";
            this.UriSSO = "https://qa-patientaccess.availity.com/public/api/v1/sso";
            this.Key = "vbc9gtwhj8d7mfhyv3zwp67h";
            this.Secret = "SECRET";
            this.Callback = "https://tst-rcm-mirth.availity.net/webhooks/api/v1/notify";
        }

    }

    public class Api
    {
        ////public Api()
        ////{

        ////}

        public string ApiCall(EnvFuji env, Method type, PTPapi3.ssoUser payload)
        {
            try
            {
                var client = new RestClient(env.UriSSO);
                var request = new RestRequest(type);  //Method.POST

                request.AddHeader("X-Api-Key", env.Key);
                request.AddHeader("sig", Tools.sha256(env.Key + env.Secret + Tools.epochTime()));
                request.AddHeader("X-CALLBACK-URL", env.Callback);
                request.AddHeader("Content-Type", "application/json");

                request.RequestFormat = DataFormat.Json;
                request.AddBody(payload);
                var response = client.Execute(request); //execute 
                {
                    if (response.StatusCode == HttpStatusCode.OK) { Assert.AreEqual("", response.ContentEncoding); }
                    return response.Content;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string ApiCall(EnvFuji env, Method type, PTPapi3.fujiRootobject payload)
        {
            try
            {
                //const string Uri = "https://qa-patientaccess.availity.com/public/api/v1/visits";
                //const string Key = "vbc9gtwhj8d7mfhyv3zwp67h";
                //const string Secret = "SECRET";
                //const string Callback = "https://tst-rcm-mirth.availity.net/webhooks/api/v1/notify";

                //EnvFuji env = new EnvFuji("QUA");
                
                

                var client = new RestClient(env.UriVisit);
                var request = new RestRequest(type);  //Method.POST

                
                request.AddHeader("X-Api-Key", env.Key);
                request.AddHeader("sig", Tools.sha256(env.Key + env.Secret + Tools.epochTime()));
                request.AddHeader("X-CALLBACK-URL", env.Callback);
                request.AddHeader("Content-Type", "application/json");


                request.RequestFormat = DataFormat.Json;
                request.AddBody(payload);
                var response = client.Execute(request); //execute 
                {
                    if (response.StatusCode == HttpStatusCode.OK) { Assert.AreEqual("", response.ContentEncoding); }
                    return response.Content;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
