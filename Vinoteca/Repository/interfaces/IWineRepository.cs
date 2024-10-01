using Vinoteca.Entities;


namespace Vinoteca.Repository.interfaces
{
    public interface IWineRepository 
    {
        
        void addOneWine(Wine wine);
        //Wine GetWineById(int id);
        public List<Wine> GetWinesList();
        //bool removeWine(int id);
    }
}
