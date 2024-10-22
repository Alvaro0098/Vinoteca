using System.Security.Cryptography.X509Certificates;
using Vinoteca.Entities;
using Vinoteca.Models.Dtos;

namespace Vinoteca.Services.interfaces
{
    public interface IWineService
    {

        void addWine(CreateAndUpdateWineDto wine);

        public List<GetWineByDto> GetAllWines();
        GetWineByDto GetOneWine(int id);

        List<Wine> GetWinesByVariety(string variety);

        public bool ChangeWineStock(int id, int newStock);

    }
}
