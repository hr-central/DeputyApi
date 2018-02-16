using System;

namespace DeputyApi.Models
{
    public class UserModel
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Company { get; set; }
        public CompanyModel CompanyObject { get; set; }
        public string Portfolio { get; set; }
        public string DeputyVersion { get; set; }
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public string PrimaryEmail { get; set; }
        public string PrimaryPhone { get; set; }
        public string[] Permissions { get; set; }
        public object[] JournalCategories { get; set; }
        public object InProgressTS { get; set; }
        public DateTimeOffset UserSince { get; set; }
        public ApiUserModel UserObjectForAPI { get; set; }
        public object[] OPS { get; set; }
        public object[] MemosToConfirm { get; set; }
    }
}
