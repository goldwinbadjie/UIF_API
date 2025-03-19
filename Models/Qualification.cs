namespace UIF_API.Models
{
    public class Qualification
    {
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }
    }

    public class QualificationResponse
    {
        public List<Qualification> Qualifications { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
