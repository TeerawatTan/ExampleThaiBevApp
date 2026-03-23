using System.ComponentModel.DataAnnotations;

namespace ExampleThaiBevApp.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "กรุณากรอกชื่อผู้ใช้งาน")]
        [Display(Name = "User")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "กรุณากรอกรหัสผ่าน")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "กรุณายืนยันรหัสผ่าน")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "รหัสผ่านและยืนยันรหัสผ่านไม่ตรงกัน")]
        public string? ConfirmPassword { get; set; }
    }
}
