namespace Vinoteca.Models.Dtos
{
    public class GetWineByDto
    {

        public string Name { get; set; } 

        public string Variety { get; set; } 

        public int Year { get; set; }

        public string Region { get; set; }

        public int Stock { get; set; }

        public DateTime CreatedAt { get; set; } 

    }
}
