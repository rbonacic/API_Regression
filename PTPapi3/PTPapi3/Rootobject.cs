namespace PTPapi3
{
    public class Rootobject
    {

        public string facilityId { get; set; }
        public string facilityAssociationTypeCode { get; set; }
        public string visitServiceDate { get; set; }
        public string serviceCategoryCode { get; set; }
        public Patient patient { get; set; }
        public Guarantor guarantor { get; set; }
        public Orderingprovider orderingProvider { get; set; }
        public string orderNumber { get; set; }
        public string orderControlNumber { get; set; }
        public Coverage[] coverages { get; set; }
        public Service[] services { get; set; }
    }
    ;
}