using System.ComponentModel.DataAnnotations;

namespace Vinoteca.Models.Dtos
{
    public class CreateAndUpdateUserDto
    {
        [Required]
        public string UserName { get; set; }

        [MinLength(8)]
        public string Password { get; set; }
        

    }
}
