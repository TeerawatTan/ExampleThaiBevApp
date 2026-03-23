using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleThaiBevApp.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName 
        { 
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Column(TypeName = "date")]
        public DateTime Birthdate { get; set; }
        public string? Address { get; set; }

        public int Age
        {
            get
            {
                var age = DateTime.Now.Year - Birthdate.Year;
                return age;
            }
        }
    }
}
