using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;


namespace PTPapi3
{
    [CodedUITest]
    public class CodedUITest1
    {

        private const string OrgUrlGetDev =
            "http://organization-management.patient-access-services-dev-agwdevsci03.availity.net/api/organization";

        private const string OrgUrlPostDev =
            "http://organization-management.patient-access-services-dev-agwdevsci03.availity.net/api/organization";

        private const string ConfUrlGetDev =
            "http://configuration-evaluator.patient-access-services-dev-agwdevsci03.availity.net/api/ptp/canrun/123156";

        private const string ConfUrlPost =
            "http://configuration-evaluator.patient-access-services-dev-agwdevsci03.availity.net/api/ptp ";

        [TestMethod]
        public void OrgGet()
        {

            try
            {
                var client = new RestClient(OrgUrlGetDev);
                var request = new RestRequest(Method.GET);
                var response = client.Execute(request);
                
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Content-Type", "application/json");
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        JObject orgs = JObject.Parse(response.Content);
                        var orgNames =
                            from p in orgs["Organizations"] select (string) p["Name"];

                        var hosp = orgNames.ToList();

                        // go search this list with first string and compare 
                        Assert.AreEqual("Evans Memorial Hospital",
                            hosp.FirstOrDefault(s => s.Equals("Evans Memorial Hospital")));
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        public void OrgPost()
        {
            try
            {
                var client = new RestClient(OrgUrlPostDev);
                var request = new RestRequest(Method.POST);
                var payload = new Rootobject

                {
                    OrganizationToken = "ca976f5e-85d3-4cb1-b3e0-1e0cb359634e",
                    Ptpexecution = new Configuration
                    {
                        Id = 1,
                        ExecutionDaysInterval = 10,
                        ConfigurationTypeId = 1,
                        ConfigurationType = new Configurationtype
                        {
                            Id = 1,
                            Name = "PTP"
                        }

                    }
                };

                request.RequestFormat = DataFormat.Json;
                request.AddBody(payload);
                var response = client.Execute(request);
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {

                        Assert.AreEqual("", response.ContentEncoding);

                        SQLDataTable sdt = new SQLDataTable();
                        sdt.Server = "agwtstsql03.availity.net";
                        sdt.Database = "master";
                        sdt.Command =
                            "SELECT cf.Name, cf.FacilityId, cf.DemographicProviderId, oco.OrganizationId, cp.ExecutionDaysInterval FROM OrganizationManagement.Client.Organization oco JOIN SmartCycle.Client.Facility cf on cf.OrganizationIdentifier = oco.OrganizationId JOIN OrganizationManagement.Client.Module cm on cm.OrganizationId = oco.OrganizationId JOIN OrganizationManagement.Configuration.PtpConfiguration cp on cp.PtpConfigurationId = cm.ConfigurationId";

                        sdt.Execute();

                        foreach (DataRow row in sdt.DataTable.Rows)
                        {
                            Assert.AreEqual(row["Name"], "Tito Jackson");
                            Assert.AreEqual(row["ExecutionDaysInterval"], 10);

                        }

                    }
                }
                ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        public void ConfGet()
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest(Method.GET);
                var response = client.Execute(request);
                request.AddHeader("Content-Type", "application/json");
                request.RequestFormat = DataFormat.Json;
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var text = response.Content;
                        Assert.IsTrue(text != null && text.Contains("false"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [TestMethod]

        public void ConfPost()
        {
            try
            {
                var client = new RestClient(ConfUrlPost);
                var request = new RestRequest(Method.POST);
                var payload = new Rootobject

                {
                    Ptpexecution = new Ptpexecution()
                    {
                        Id = 1,
                        DemographicRequestId = "123456",
                        OrganizationToken = "ca976f5e-85d3-4cb1-b3e0-1e0cb359634e",
                        LastRanDate = "10/2/2016 7:23:57 PM -07:00"
                        
                    }
                };

                request.RequestFormat = DataFormat.Json;
                request.AddBody(payload);
                var response = client.Execute(request);
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {

                        Assert.AreEqual("", response.ContentEncoding);

                        SQLDataTable sdt = new SQLDataTable();
                        sdt.Server = "agwtstsql03.availity.net";
                        sdt.Database = "master";
                        sdt.Command =
                            "SELECT cf.Name, cf.FacilityId, cf.DemographicProviderId, oco.OrganizationId, cp.ExecutionDaysInterval FROM OrganizationManagement.Client.Organization oco JOIN SmartCycle.Client.Facility cf on cf.OrganizationIdentifier = oco.OrganizationId JOIN OrganizationManagement.Client.Module cm on cm.OrganizationId = oco.OrganizationId JOIN OrganizationManagement.Configuration.PtpConfiguration cp on cp.PtpConfigurationId = cm.ConfigurationId";

                        sdt.Execute();

                        foreach (DataRow row in sdt.DataTable.Rows)
                        {
                            Assert.AreEqual(row["Name"], "Tito Jackson");
                            Assert.AreEqual(row["ExecutionDaysInterval"], 10);

                        }

                    }
                }
                ;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}