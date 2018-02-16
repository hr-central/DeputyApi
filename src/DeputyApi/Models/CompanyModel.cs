using System;

namespace DeputyApi.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public object Portfolio { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
        public int ParentCompany { get; set; }
        public string CompanyName { get; set; }
        public string TradingName { get; set; }
        public string BusinessNumber { get; set; }
        public string CompanyNumber { get; set; }
        public bool IsWorkplace { get; set; }
        public bool IsPayrollEntity { get; set; }
        public string PayrollExportCode { get; set; }
        public int Address { get; set; }
        public string Contact { get; set; }
        public int Creator { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
    }
}
