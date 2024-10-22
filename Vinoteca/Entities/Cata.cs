namespace Vinoteca.Entities
{
    public class Cata
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }

        public List<Wine> Vinos { get; set; } = new List<Wine>();

        public List<string> ListaDeInvitados { get; set; } = new List<string>();
    }
}
