namespace UIF_API.Models
{
    public class PostalAddress
    {
        public int ApplicationNumber { get; set; }
        public string? IdNumber { get; set; }
        public int StreetAddressTypeID { get; set; }
        public int PostalCodeID { get; set; }
        public string? StreetAddressLine1 { get; set; }
        public string? StreetAddressLine2 { get; set; }
        public string? StreetAddressLine3 { get; set; }
        public int PostalAddressTypeID { get; set; }
        public int PostalCodeID2 { get; set; }
        public string? PostalAddressLine1 { get; set; }
        public string? PostalAddressLine2 { get; set; }
        public string? PostalAddressLine3 { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }

    public class GenericResponse
    {
        public string? Message { get; set; }
        public bool Success { get; set; }
    }

    
}
