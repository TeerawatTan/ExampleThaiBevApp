using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleThaiBevApp.Models
{
    public class Queue
    {
        public int Id { get; set; }
        public string QueueNo { get; set; } = string.Empty;

        [Column(TypeName = "timestamp")]
        public DateTime? CreatedAt { get; set; }
    }
}
