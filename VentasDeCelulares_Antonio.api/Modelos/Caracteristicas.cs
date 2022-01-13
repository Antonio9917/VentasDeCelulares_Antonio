using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VentasDeCelulares_Antonio.api.DTOS;

namespace VentasDeCelulares_Antonio.api.Modelos
{
    public class Caracterisiticas
    {

        public Caracterisiticas()
        {

        }

        public Caracterisiticas(CaracteristicasDTO nuevo)
        {
            Ram = nuevo.Ram;
            EspacioInterno = nuevo.EspacioIntero;
            Color = nuevo.Color;
            Procesador = nuevo.Procesador;
            IdCompania = nuevo.IdCompania;
            Activo = true;
        }

        [Key]
        public int IdCaracteristicas { get; set; }

        [Required]
        [MaxLength(90)]
        public string Ram { get; set; }

        [MaxLength(10)]
        public string EspacioInterno { get; set; }

        [MaxLength(120)]
        public string Color { get; set; }

        [MaxLength(250)]
        public string Procesador { get; set; }

        [Required]
        public bool Activo { get; set; }

        public int IdCompania { get; set; }

        [ForeignKey("IdCompania")]

        public Compania Compania { get; set; }


        public virtual List<Model> Modelo { get; set; }

    }
}
