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

            _wineRepository.addOneWine(dto);

        }

        public List<GetWineByDto> GetAllWines()
        {
            return _wineRepository.GetWinesList();

        }

        public GetWineByDto GetOneWine(int id)
        {
            return _wineRepository.GetWineById(id);
        }

        public List<Wine> GetWinesByVariety(string variety)
        {
            return _wineRepository.GetWinesByVariety(variety);
        }

        public bool ChangeWineStock(int id, int newStock)
        {
            return _wineRepository.UpdateWineStock(id, newStock);
        }
    }
}
