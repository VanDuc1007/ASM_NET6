//using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ASM.Share.Models
{
    public enum Role
    {
        [EnumMember(Value = "Quản trị")]
        [Display(Name = "Admin")]
        Admin,
        [EnumMember(Value = "Người dùng")]
        [Display(Name = "User")]
        User,
    }

    public class Nguoidung
    {
        [Key]
        public int NguoidungID { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Bạn cần nhập tài khoản.")]        
        public string UserName { get; set; }
        
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Bạn cần nhập họ tên.")]
        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail không đúng")]
        public string Email { get; set; }

        [Display(Name = "Chức danh")]
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }

        [Display(Name = "Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DOB { get; set; } // date of birth

        [Display(Name = "Quản trị")]
        public bool Admin { get; set; }

        [Display(Name = "Sử dụng")]
        public bool Locked { get; set; }

        //[Required(ErrorMessage = "Bạn cần nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Bạn cần nhập lại mật khẩu")]
        [Display(Name = "Mật khẩu (lần 2)")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]        
        //[NotMapped]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Vai trò")]
        public Role Role { get; set; }
        
        //[Column(TypeName = "nvarchar(100)")]
        //public string Role { get; set; }
    }
}
