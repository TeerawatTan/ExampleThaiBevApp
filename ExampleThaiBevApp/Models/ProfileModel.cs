using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleThaiBevApp.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? ProfilePicture { get; set; }
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        public string Occupation { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
    }
}
