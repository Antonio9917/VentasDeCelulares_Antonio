using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VentasDeCelulares_Antonio.api.DTOS;

namespace VentasDeCelulares_Antonio.api.Modelos
{
    public class Model
    {

        public Model()
        {

        }

        public Model(ModeloDTO nuevo)
        {
            Modelo = nuevo.Modelo;
            Activo = true;
            IdCaracteristicas = nuevo.IdCaracteristicas;
        }

        [Key]
        public int IdModel { get; set; }
        [Required]
        [MaxLength(13)]
        public string Modelo { get; set; }

        [MaxLength(120)]
        public bool Activo { get; set; }

        public int IdCaracteristicas { get; set; }

        [ForeignKey("IdCaracteristicas")]
        public Caracterisiticas Caracteristicas { get; set; }
    }
}
