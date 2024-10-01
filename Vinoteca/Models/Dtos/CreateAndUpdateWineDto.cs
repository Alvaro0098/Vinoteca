using System.ComponentModel.DataAnnotations;

namespace Vinoteca.Models.Dtos
{
    public class CreateAndUpdateWineDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string Variety { get; set; } = string.Empty;
 
        public int Year { get; set; }
        
        public string Region { get; set; } = string.Empty;
       
        private int _stock;
        public int Stock { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    
    }

}

