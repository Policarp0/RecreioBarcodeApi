using System.ComponentModel.DataAnnotations;

namespace RecreioBarcode.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
