namespace UIF_API.Models
{
    public class LabourDolCentre
    {
        public int DolCentreId { get; set; }
        public string DolCentre { get; set; }
    }

    public class LabourDolCentreResponse
    {
        public List<LabourDolCentre> DolCentres { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

    }
}
