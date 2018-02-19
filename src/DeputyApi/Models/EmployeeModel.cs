using System;

namespace DeputyApi.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public int Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string OtherName { get; set; }
        public string Salutation { get; set; }
        public int? MainAddress { get; set; }
        public int? PostalAddress { get; set; }
        public int Contact { get; set; }
        public int? EmergencyAddress { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public int? Photo { get; set; }
        public int? UserId { get; set; }
        public int? JobAppId { get; set; }
        public bool Active { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? TerminationDate { get; set; }
        public int? StressProfile { get; set; }
        public string Position { get; set; }
        public bool? HigherDuty { get; set; }
        public int Role { get; set; }
        public bool AllowAppraisal { get; set; }
        public int? HistoryId { get; set; }
        public int? CustomFieldData { get; set; }
        public int? Creator { get; set; }
        public DateTimeOffset? Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
    }
}
