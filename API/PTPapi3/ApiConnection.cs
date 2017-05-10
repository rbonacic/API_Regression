using System;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace PTPapi3
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

    public class Env
    {
        /// <summary>
        /// Change to meet Enviroment requirements 
        /// </summary>
        public string UriVisit { get; set; }
        public string UriSSO { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
        public string Callback { get; set; }
        
        public Env(string environment)
        {
            switch (environment.ToUpper())
            {
                case "QA":
                    this.QA();
                    break;
                case "Dev":
                    this.Dev();
                    break;
            }

        }
        private void QA()
        {
            this.UriVisit = "https://EnterURI.com";
        
        }
        private void Dev()
        {
            this.UriVisit = "https://EnterURI.com";
           
        }

    }

    public class Api
    {
     

        public string ApiCall(Env env, Method type, ssoUser payload)
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
       
        }
    }

