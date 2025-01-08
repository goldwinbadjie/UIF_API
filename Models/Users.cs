using System.ComponentModel.DataAnnotations;

namespace UIF_API.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; } 

        public int IDNumber { get; set; } // ID number field

        public string MobileNumber { get; set; } // Mobile number field

        public string Initials { get; set; } // Initials field

        public string Surname { get; set; } // Surname field

        public string AccNo { get; set; } // Account number field

        public string deviceId { get; set; }
    }

}
