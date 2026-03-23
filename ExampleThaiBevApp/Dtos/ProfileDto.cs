using System.ComponentModel.DataAnnotations;

namespace ExampleThaiBevApp.Dtos
{
    public class ProfileDto
    {
        [Required(ErrorMessage = "กรุณากรอกชื่อ")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณากรอกนามสกุล")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a valid Email")]
        [EmailAddress(ErrorMessage = "รูปแบบ Email ไม่ถูกต้อง")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a valid Phone")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone ต้องเป็นตัวเลข 10 หลัก")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please selected any profile picture")]
        public string ProfilePicture { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a valid Birth Date")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Please selected any Occupation")]
        public string Occupation { get; set; } = string.Empty;

        [Required]
        public string Sex { get; set; } = string.Empty;
    }
}
