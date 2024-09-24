using Vinoteca.Entities;
using Vinoteca.Models.Dtos;
using Vinoteca.Repository.interfaces;

namespace Vinoteca.Repository
{
    public class WineRepository : IWineRepository
    {
        public static List<Wine> wines = new List<Wine>();

        public Wine GetWineById(int id)
        {
            return wines.FirstOrDefault(w => w.id == id);
        }

        public void addWine(Wine wine)
        {
            wines.Add(wine);
        }

        public bool removeWine(int id)
        {
            var wineToRemove = wines.FirstOrDefault(u => u.id == id);

            if (wineToRemove != null)
            {
                wines.Remove(wineToRemove);
                return true;
            }

            return false;
        }


    }
}
