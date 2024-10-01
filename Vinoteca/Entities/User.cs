using System.ComponentModel.DataAnnotations;

namespace Vinoteca.Entities
{
    public class User
    {
        public int id { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;

        [MinLength(8)]
        public string Password { get; set; }
    }
}
