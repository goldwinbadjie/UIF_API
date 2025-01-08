using System.ComponentModel.DataAnnotations;

namespace UIF_API.Models
{
    public class Claims
    {
        [Key]
        public int ClaimId { get; set; }
        public string RefID { get; set; }
        public byte[] IDCopy {get; set;}
        public byte[] Unemployment { get; set; }
        public byte[] MedicalCert { get; set; }
    }
}
