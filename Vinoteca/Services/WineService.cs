using Microsoft.AspNetCore.Mvc;
using Vinoteca.Entities;
using Vinoteca.Models.Dtos;
using Vinoteca.Repository;
using Vinoteca.Repository.interfaces;
using Vinoteca.Services.interfaces;

namespace Vinoteca.Services
{
    public class WineService : IWineService
    {
        public readonly IWineRepository _wineRepository; //crea una variable privada de lectura de la interfaz
    
        public WineService(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        public void addWine([FromBody] CreateAndUpdateWineDto dto)
        {
            Wine newWine = new Wine()
            {
                Name = dto.Name,
                Region = dto.Region,
                Variety = dto.Variety,
                CreatedAt = dto.CreatedAt,
                Year = dto.Year,
                Stock = dto.Stock,

            };
            _wineRepository.addOneWine(newWine);
            
        }

        public List<Wine> GetAllWines()
        {
            return _wineRepository.GetWinesList();

        }

        //public bool RemoveOneWine(int id)
        //{
        //    return _wineRepository.removeWine(id);
        //}

    }
}
