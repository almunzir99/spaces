using System;
using apiplate.Models;

namespace apiplate.Resources
{
    public class VolunteerResource : BaseResource
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate  { get; set; }
        public Gender Gender { get; set; }
        public string CVLink { get; set; }
        public string Reason { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public int SectorId { get; set; }
        public SectorResource Sector { get; set; }
    }
}