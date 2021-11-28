using System.ComponentModel.DataAnnotations;

namespace ASM.Share.Models
{
    public class ViewLogin
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
