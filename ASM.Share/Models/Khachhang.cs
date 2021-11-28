//using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Spatial;

namespace ASM.Share.Models
{
    
    public class Khachhang
    {
        /*
        a.	Mã số CustomerID int key
b.	Họ Te6nnvarchar 50 not null
//c.	Tên nvarchar 50 not null
d.	Ngày sinh Birthday Datetime not null
e.	Số phone Phone varchar 50 null
f.	Email varchar 50 not null
g.	FaceBooklink varchar 50 null
h.	Password nvarchar 50 not null

        */

        [Key]
        public int KhachhangID { get; set;}

        [StringLength(150)]
        [Required(ErrorMessage = "Bạn cần nhập họ tên.")]
        [Display(Name = "Họ & Tên")]
        public string FullName { get; set; }
        
        [Display(Name="Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Ngaysinh { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập số điện thoại."), Display(Name = "Số phone")]
        [Column(TypeName = "varchar(15)"), MaxLength(15)]
        [RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{4})[-. ]?([0-9]{3})$", ErrorMessage = "Số điện thoại không phù hợp.")]
        //091-1234-567
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập email."), Display(Name = "Email")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không phù hợp.")]
        public string EmailAddress { get; set; }

        //[Required(ErrorMessage = "Bạn cần nhập mật khẩu"), Display(Name = "Mật khẩu")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Bạn cần gõ lại mật khẩu."), Display(Name = "Mật khẩu (gõ lại)")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu gõ lại không khớp.")]
        public string ConfirmPassword { get; set; }

        [StringLength(250)]
        [Display(Name = "Mô tả")]
        public string Mota { get; set; }
    }
}
