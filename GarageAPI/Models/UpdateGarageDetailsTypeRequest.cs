namespace GarageAPI.Models
{
    public class UpdateGarageDetailsTypeRequest
    {
        public string Description { get; set; }

        public bool isActive { get; set; }

        public string Domain { get; set; }

        public string LegalName { get; set; }

        public string VATNumber { get; set; }

        public string VATOffice { get; set; }

        public string? Country { get; set; }

        public string? Region { get; set; }

        public string? City { get; set; }

        public string? Address { get; set; }

        public string? ZipCode { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Website { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}