using System.ComponentModel.DataAnnotations;

namespace Vinoteca.Entities
{
    public class Wine
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Variety { get; set; } = string.Empty;

        public int Year { get; set; }

        public string Region { get; set; } = string.Empty;

        private int _stock;
        public int Stock
        {
            get => _stock;
            set
            {
                if (value < 0) throw new ArgumentException("El stock no puede ser negativo.");
                _stock = value;
            }
        }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int? CataId { get; set; }
        public Cata Cata { get; set; }


        public void AddStock(int amount)
        {
            if (amount <= 0) throw new ArgumentException("La cantidad a añadir debe ser mayor a 0.");
            Stock += amount;
        }

        public void RemoveStock(int amount)
        {
            if (amount <= 0) throw new ArgumentException("La cantidad a reducir debe ser mayor a 0.");
            if (Stock - amount < 0) throw new InvalidOperationException("No hay suficiente stock disponible.");
            Stock -= amount;
        }


    }
}
