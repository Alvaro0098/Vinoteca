using System.ComponentModel.DataAnnotations;

namespace Vinoteca.Models.Dtos
{
    public class CreateAndUpdateUserDto
    {
        [StringLength(12, MinimumLength = 0, ErrorMessage = "El usuario no puede ser vacio")]
        public string UserName { get; set; }

        [MinLength(8)]
        public string Password { get; set; }
        

    }
}
