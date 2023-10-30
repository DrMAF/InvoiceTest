using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels.Requests
{
    public class Register
    {
        //[Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        //[Required]
        [MaxLength(100)]
        public string SecondName { get; set; } = string.Empty;
        //[Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        //public DateTime DateOfBirth { get; set; }
        //[Required]
        //[MaxLength(100)]
        //[EmailAddress]
        //public string Email { get; set; } 
        //[Required]
        //[MaxLength(50)]
        //public string Phone { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }       
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string ConfirmPassword { get; set; }
    }
}
