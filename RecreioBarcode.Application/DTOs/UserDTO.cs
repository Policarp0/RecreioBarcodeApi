using System.ComponentModel.DataAnnotations;

namespace RecreioBarcode.Application.DTOs
{
    public sealed class UserDTO
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
