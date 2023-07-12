using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class SignUpModel
    {

        public int UserId { get; set; }

        public string Fullname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Pwd { get; set; } = null!;

        public DateTime DateCreation { get; set; }
    }
}
