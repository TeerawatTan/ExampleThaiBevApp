using ExampleThaiBevApp.Constants;
using System.ComponentModel.DataAnnotations;

namespace ExampleThaiBevApp.Models
{
    public class Document
    {
        public int Id { get; set; }
        [Required]
        public string DocumentName { get; set; } = string.Empty;
        public string? Remark { get; set; }
        public string Status { get; set; } = ConstantAndEnum.STATUS_DOCUMENT_WAIT_APPROVED;
    }
}
