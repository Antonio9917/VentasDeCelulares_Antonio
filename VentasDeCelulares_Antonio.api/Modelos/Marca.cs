using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VentasDeCelulares_Antonio.api.DTOS;

namespace VentasDeCelulares_Antonio.api.Modelos
{
    public class Marca
    {
        public Marca()
        {

        }

        public Marca(MarcaDTO nuevo)
        {
            Nombre = nuevo.Nombre;
            Activo = true;
            IdModelo = nuevo.IdModelo;
        }

        [Key]
        public int IdCategoria { get; set; }



        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        public bool Activo { get; set; }

        public int IdModelo { get; set; }

        [ForeignKey("IdModelo")]

        public Model Modelo { get; set; }


    }
}
