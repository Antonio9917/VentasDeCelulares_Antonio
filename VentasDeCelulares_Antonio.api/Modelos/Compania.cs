using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VentasDeCelulares_Antonio.api.DTOS;

namespace VentasDeCelulares_Antonio.api.Modelos
{
    public class Compania

    {
        public Compania()
        {

        }

        public Compania(CompaniaDTO nuevo)
        {
            Nombre = nuevo.Nombre;
            Activo = true;
        }

        [Key]
        public int IdCompania { get; set; }


        [MaxLength(30)]
        [Required]
        public string Nombre { get; set; }

        [Required]
        public bool Activo { get; set; }


        public virtual List<Caracterisiticas> Caracterisiticas { get; set; }
    }
}
