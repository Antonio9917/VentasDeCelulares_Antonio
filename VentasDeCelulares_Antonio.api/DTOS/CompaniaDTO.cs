using System.ComponentModel.DataAnnotations;

namespace VentasDeCelulares_Antonio.api.DTOS
{
    public class CompaniaDTO
    {
        [MaxLength(15)]
        public string Nombre { get; set; }
    }
}
