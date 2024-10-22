using Vinoteca.Entities;
using Vinoteca.Models.Dtos;


namespace Vinoteca.Repository.interfaces
{
    public interface IWineRepository
    {

        void addOneWine(CreateAndUpdateWineDto wine);
        GetWineByDto GetWineById(int id);
        public List<GetWineByDto> GetWinesList();
        void removeWine(int id);

        List<Wine> GetWinesByVariety(string variety);

        bool UpdateWineStock(int id, int newStock);
    }
}
