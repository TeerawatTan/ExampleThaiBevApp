using System.ComponentModel.DataAnnotations;

namespace ExampleThaiBevApp.Dtos
{
    public class ProfileDto
    {
        [Required(ErrorMessage = "กรุณากรอกชื่อ")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณากรอกนามสกุล")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณากรอกอีเมลล์")]
        [EmailAddress(ErrorMessage = "Please provide a valid Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณากรอกเบอร์โทรศัพท์")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Please provide a valid Phone")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณาเลือกรูปโปรไฟล์")]
        public string ProfilePicture { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณากรอกวันเดือนปีเกิด")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "กรุณาเลือกอาชีพ")]
        public string Occupation { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณาเลือกเพศ")]
        public string Sex { get; set; } = string.Empty;
    }
}
