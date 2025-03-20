namespace UIF_API.Models
{
    public class DolRegionResponse
    {
        public List<DolRegion> DolRegions { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }

    public class DolRegion
    {
        public int DolRegionId { get; set; }
        public string DolRegionName { get; set; }
    }
}
