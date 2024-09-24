using Vinoteca.Entities;


namespace Vinoteca.Repository.interfaces
{
    public interface IWineRepository 
    {
        
        void addWine(Wine wine);
        Wine GetWineById(int id);

        bool removeWine(int id);
    }
}
