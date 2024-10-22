using Humanizer;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using System.Data;
using Vinoteca.Data;
using Vinoteca.Entities;
using Vinoteca.Models.Dtos;
using Vinoteca.Repository.interfaces;

namespace Vinoteca.Repository
{
    public class WineRepository : IWineRepository //va a tener las definiciones de los metodos que estan en el repositorio, definicion: que retorna y como se llama
    {
        private VinotecaContext _context;
        public WineRepository(VinotecaContext context)
        {
            _context = context;
        }

        //los metodos interactuan directamente con la lista 
        public GetWineByDto GetWineById(int wineId)
        {
            var wine = _context.Wines.SingleOrDefault(w => w.Id == wineId);
            if (wine is not null)
            {
                return new GetWineByDto()
                {
                    Name = wine.Name,
                    Variety = wine.Variety,
                    Year = wine.Year,
                    Region = wine.Region,
                    Stock = wine.Stock,
                    CreatedAt = wine.CreatedAt
                };
            }
            return null;
        }

        public void addOneWine(CreateAndUpdateWineDto dto) // es un void porque hace una operacion y no hace falta que devuelva nada
        {
            Wine newWine = new Wine()
            {
                Name = dto.Name,
                Variety = dto.Variety,
                Year = dto.Year,
                Region = dto.Region,
                Stock = dto.Stock,
                CreatedAt = dto.CreatedAt
            };
            _context.Wines.Add(newWine);
            _context.SaveChanges();
        }

        public List<GetWineByDto> GetWinesList()
        {
            return _context.Wines.Select(u => new GetWineByDto()
            {
                Name = u.Name,
                Variety = u.Variety,
                Year = u.Year,
                Region = u.Region,
                Stock = u.Stock,
                CreatedAt = u.CreatedAt
            }).ToList();
        }


        public void removeWine(int wineId)
        {

            var wine = _context.Wines.SingleOrDefault(u => u.Id == wineId);
            if (wine is null)
            {
                throw new Exception("El vino que intenta eliminar no existe");
            }


            Delete(wineId);

        }

        private void Delete(int id)
        {
            _context.Wines.Remove(_context.Wines.Single(w => w.Id == id));
            _context.SaveChanges();
        }

        public List<Wine> GetWinesByVariety(string variety)
        {
            return _context.Wines
            .Where(w => w.Variety.ToLower() == variety.ToLower())
            .ToList();
        }

        public bool UpdateWineStock(int id, int newStock)
        {
            var wine = _context.Wines.FirstOrDefault(w => w.Id == id);
            if (wine == null)
            {
                return false;
            }

            wine.Stock = newStock;
            return true;
        }


    }





}
