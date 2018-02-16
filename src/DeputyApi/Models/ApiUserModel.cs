using System;

namespace DeputyApi.Models
{
    public class ApiUserModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public int Employee { get; set; }
        public Uri Photo { get; set; }
    }
}
