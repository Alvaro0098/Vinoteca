using Vinoteca.Entities;
using Vinoteca.Models.Dtos;
using Vinoteca.Repository.interfaces;
using Vinoteca.Services.interfaces;

namespace Vinoteca.Services
{
    public class WineService : IWineService
    {
        public readonly IWineRepository _wineRepository;
        public WineService(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        public void addOneWine(CreateAndUpdateWineDto dto)
        {
            Wine newWine = new Wine()
            {
                name = dto.name,
                storeHouse = dto.storeHouse,
                price = dto.price,
            };
            _wineRepository.addWine(newWine);
            
        }

        public Wine getOneWine(int id)
        {
            return _wineRepository.GetWineById(id);
        }

        public bool RemoveOneWine(int id)
        {
            return _wineRepository.removeWine(id);
        }

    }
}
