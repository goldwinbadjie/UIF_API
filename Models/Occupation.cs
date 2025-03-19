namespace UIF_API.Models
{
    public class Occupation
    {
        public string OccupationName { get; set; }
        public string OccupationCode { get; set; }

    }

    public class OccupationResponse
    {
        public List<Occupation> Occupations { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

    }
}
