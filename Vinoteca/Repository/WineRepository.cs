using Vinoteca.Entities;
using Vinoteca.Models.Dtos;
using Vinoteca.Repository.interfaces;

namespace Vinoteca.Repository
{
    public class WineRepository : IWineRepository //va a tener las definiciones de los metodos que estan en el repositorio, definicion: que retorna y como se llama
    {
        public static List<Wine> wines = new List<Wine>();

        //los metodos interactuan directamente con la lista 
        //public Wine GetWineById(int id)
        //{
        //    return wines.FirstOrDefault(w => w.id == id);
        //}

        public void addOneWine(Wine wine) // es un void porque hace una operacion y no hace falta que devuelva nada
        {
            wines.Add(wine);
        }

        public List<Wine> GetWinesList()
        {
            return wines.ToList();
        }

        //public bool removeWine(int id)
        //{
        //    var wineToRemove = wines.FirstOrDefault(u => u.id == id);

        //    if (wineToRemove != null)
        //    {
        //        wines.Remove(wineToRemove);
        //        return true;
        //    }

        //    return false;
        //}


    }
}
