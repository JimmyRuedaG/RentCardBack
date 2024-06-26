namespace RentCard.Models.DTO
{
    public class DTO_Consultar
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public int TiempoAlquilado { get; set; }
        public decimal Saldo { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
    }
}
