using System.ComponentModel.DataAnnotations;

namespace Vinoteca.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;

        [MinLength(8)]
        public string Password { get; set; }
    }
}
