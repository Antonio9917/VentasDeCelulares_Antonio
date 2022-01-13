using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentasDeCelulares_Antonio.api.DTOS;
using VentasDeCelulares_Antonio.api.Modelos;

namespace VentasDeCelulares_Antonio.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly Contexto _bd;

        public MarcaController(Contexto contexto)
        {
            _bd = contexto;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _bd.Marca.ToList();
            return Ok(lista);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Buscar(int id)
        {
            var obj = _bd.Marca.Find(id);

            if (obj == null)
                return NotFound();

            return Ok(obj);
        }
        [HttpPost]
        public IActionResult Guardar(MarcaDTO obj)
        {
            var nuevo = new Marca(obj);
            _bd.Marca.Add(nuevo);
            _bd.SaveChanges();
            return Ok(nuevo);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Modificar(int id, Marca obj)
        {
            var modificar = _bd.Marca.Find(id);
            if (modificar == null)
                return NoContent();
            modificar.Nombre = obj.Nombre;
            _bd.Marca.Update(modificar);
            _bd.SaveChanges();
            return Ok(modificar);
        }
        [HttpPut]
        public IActionResult CambiarEtatus(int id)
        {

            var modificar = _bd.Marca.Find(id);
            if (modificar == null)
                return NoContent();
            modificar.Activo = !modificar.Activo;
            _bd.Entry(modificar).State = EntityState.Modified;
            _bd.SaveChanges();


            return Ok(modificar);


        }
        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var borrar = _bd.Marca.Find(id);

            if (borrar == null)
                return NoContent();
            _bd.Marca.Remove(borrar);
            _bd.SaveChanges();
            return Ok(borrar);
        }
    }
}