using System.ComponentModel.DataAnnotations;

namespace RecreioBarcode.Application.DTOs
{ 
    public class LocationDTO
    {
        public int Id { get; set; }
        [Required]
        public char Zona { get; set; }
        [Range(1, 99)] [Required]
        public int Rua { get; set; }
        [Range(1,999)] [Required]
        public int Estante { get; set; }
        [Required]
        public char Prateleira { get; set; }
        [Range(1,999)] [Required]
        public int Numero { get; set; }

    }
}
