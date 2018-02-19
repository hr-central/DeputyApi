using System;

namespace DeputyApi.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string UnitNo { get; set; }
        public string StreetNo { get; set; }
        public string SuiteNo { get; set; }
        public string PoBox { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public int? Country { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public int? Format { get; set; }
        public bool? Saved { get; set; }
        public int? Creator { get; set; }
        public DateTimeOffset? Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public string Print { get; set; }
    }
}
