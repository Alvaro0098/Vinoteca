using Microsoft.AspNetCore.Mvc;
using Vinoteca.Models.Dtos;
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
        public IActionResult AddWine([FromBody] CreateAndUpdateWineDto wine)
        {
            try
            {
                _wineService.addWine(wine);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", wine);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var wines = _wineService.GetAllWines();
            return Ok(wines);

        }

        [HttpGet("{id}")]
        public IActionResult getOneWineById(int id)
        {
            var wine = _wineService.GetOneWine(id);


            if (wine != null)
            {
                return Ok(wine);
            }

            return NotFound();
        }

        [HttpGet("variety/{variety}")]
        public IActionResult GetWinesByVariety(string variety)
        {
            var wines = _wineService.GetWinesByVariety(variety);
            if (wines == null)
            {
                return NotFound($"No se encuentran vinos de la variedad: {variety}");
            }
            return Ok(wines);
        }

        [HttpPut("update-stock/{id}")]
        public IActionResult UpdateWineStock(int id, [FromBody] int newStock)
        {
            var result = _wineService.ChangeWineStock(id, newStock);
            if (!result)
            {
                return NotFound($"No existe un vino con el id: {id}");
            }
            return Ok($"Stock actualizado en {newStock} para el vino con id: {id}");
        }

    }

}
