using System.ComponentModel.DataAnnotations;

namespace VentasDeCelulares_Antonio.api.DTOS
{
    public class CaracteristicasDTO
    {
        [MaxLength(15)]
        public string Ram { get; set; }
        [MaxLength(10)]
        public string EspacioIntero { get; set; }

        [MaxLength(120)]
        public string Color { get; set; }

        [MaxLength(250)]
        public string Procesador { get; set; }

        public int IdCompania { get; set; }
    }
}