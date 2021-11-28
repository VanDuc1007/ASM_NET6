using System.ComponentModel.DataAnnotations;

namespace ASM.Share.Models
{
    public class ViewWebLogin
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
