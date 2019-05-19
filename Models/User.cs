using System.ComponentModel.DataAnnotations;

namespace crud_aspnetcore_mvc.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Maximum allowed is 20 characters.")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(20, ErrorMessage = "Maximum allowed is 20 characters.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}