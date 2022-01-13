using System.ComponentModel.DataAnnotations;

namespace VentasDeCelulares_Antonio.api.DTOS
{
    public class MarcaDTO
    {
        [MaxLength(50)]
        public string Nombre { get; set; }

        public int IdModelo { get; set; }


    }
}