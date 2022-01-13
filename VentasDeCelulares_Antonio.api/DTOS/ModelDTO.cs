using System.ComponentModel.DataAnnotations;

namespace VentasDeCelulares_Antonio.api.DTOS
{
    public class ModeloDTO
    {
        [MaxLength(90)]
        public string Modelo { get; set; }

        public int IdCaracteristicas { get; set; }
    }
}
