using System;

namespace DeputyApi.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Fax { get; set; }
        public string Phone1Type { get; set; }
        public string Phone2Type { get; set; }
        public string Phone3Type { get; set; }
        public int? PrimaryPhone { get; set; }
        public string Email1 { get; set; }
        public string Email1Type { get; set; }
        public string Email2Type { get; set; }
        public string Email2 { get; set; }
        public int? PrimaryEmail { get; set; }
        public string Im1 { get; set; }
        public string Im2 { get; set; }
        public string Im1Type { get; set; }
        public string Im2Type { get; set; }
        public string Web { get; set; }
        public string Notes { get; set; }
        public bool? Saved { get; set; }
        public int? Creator { get; set; }
        public DateTimeOffset? Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
