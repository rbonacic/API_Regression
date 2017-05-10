using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPapi3
{
    public class Patient:Rootobject
        {
            public string firstName { get; set; }
            public string middleName { get; set; }
            public string lastName { get; set; }
            public string suffix { get; set; }
            public string patientAccountNumber { get; set; }
            public string medicalRecordNumber { get; set; }
            public string birthDate { get; set; }
            public string genderCode { get; set; }
        }

        public class Guarantor
        {
            public string firstName { get; set; }
            public string middleName { get; set; }
            public string lastName { get; set; }
            public string suffix { get; set; }
            public string birthDate { get; set; }
            public string genderCode { get; set; }
            public string phone { get; set; }
            public Address address { get; set; }
        }

        public class Address
        {
            public string line1 { get; set; }
            public string city { get; set; }
            public string stateCode { get; set; }
            public string zipCode { get; set; }
        }

        public class Orderingprovider
        {
            public string firstName { get; set; }
            public string middleName { get; set; }
            public string lastName { get; set; }
            public string suffix { get; set; }
            public string npi { get; set; }
        }

        public class Coverage
        {
            public string payerId { get; set; }
            public Subscriber subscriber { get; set; }
            public string[] serviceTypeCodes { get; set; }
        }

        public class Subscriber
        {
            public string firstName { get; set; }
            public string middleName { get; set; }
            public string lastName { get; set; }
            public string suffix { get; set; }
            public string birthDate { get; set; }
            public string genderCode { get; set; }
            public string ssn { get; set; }
            public string memberId { get; set; }
            public string patientRelationship { get; set; }
        }

        public class Service
        {
            public string procedureCode { get; set; }
            public string description { get; set; }
            public string dateEntered { get; set; }
            public int units { get; set; }
            public string accessionNumber { get; set; }
            public string procedureChargeAmount { get; set; }
            public string[] diagnosisCodes { get; set; }
        }


    }

