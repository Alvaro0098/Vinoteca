using System.Security.Cryptography.X509Certificates;
using Vinoteca.Entities;
using Vinoteca.Models.Dtos;

namespace Vinoteca.Services.interfaces
{
    public interface IWineService
    {
        
        void addOneWine(CreateAndUpdateWineDto dto);

        Wine? getOneWine(int id);

        public bool RemoveOneWine(int id);

    }
}
