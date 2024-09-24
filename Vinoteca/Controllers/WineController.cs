using Microsoft.AspNetCore.Mvc;
using Vinoteca.Models.Dtos;
using Vinoteca.Services;
using Vinoteca.Services.interfaces;

namespace Vinoteca.Controllers
{
    [Route("api/wines")]
    public class WineController : Controller
    {
        public readonly IWineService _wineService;
        public WineController(IWineService wineService)
        {
            _wineService = wineService;
        }

        [HttpPost]
        public IActionResult AddWine(CreateAndUpdateWineDto dto)
        {
            try
            {
                _wineService.addOneWine(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", dto);
        }

        [HttpGet("{id}")]
        public IActionResult getOneWineById(int id)
        {
            var wine = _wineService.getOneWine(id);


            if (wine != null)
            {
                return Ok(wine);  // Retorna el objeto completo si existe
            }

            return NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteWine(int id)
        {
            bool isRemoved = _wineService.RemoveOneWine(id);

            if (isRemoved)
            {
                return Ok(); // El usuario fue eliminado correctamente
            }

            return NotFound(); // El usuario no fue encontrado
        }

    }

}
