using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentasDeCelulares_Antonio.api.DTOS;
using VentasDeCelulares_Antonio.api.Modelos;

namespace VentasDeCelulares_Antonio.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniaController : ControllerBase
    {
        private readonly Contexto _bd;

        public CompaniaController(Contexto contexto)
        {
            _bd = contexto;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _bd.Compania.ToList();
            return Ok(lista);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Buscar(int id)
        {
            var obj = _bd.Compania.Find(id);

            if (obj == null)
                return NotFound();

            return Ok(obj);
        }
        [HttpPost]
        public IActionResult Guardar(CompaniaDTO obj)
        {
            var nuevo = new Compania(obj);
            _bd.Compania.Add(nuevo);
            _bd.SaveChanges();
            return Ok(nuevo);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Modificar(int id, Compania obj)
        {
            var modificar = _bd.Compania.Find(id);
            if (modificar == null)
                return NoContent();
            modificar.Nombre = obj.Nombre;
            _bd.Compania.Update(modificar);
            _bd.SaveChanges();
            return Ok(modificar);
        }
        [HttpPut]
        public IActionResult CambiarEtatus(int id)
        {

            var modificar = _bd.Compania.Find(id);
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
            var borrar = _bd.Compania.Find(id);

            if (borrar == null)
                return NoContent();
            _bd.Compania.Remove(borrar);
            _bd.SaveChanges();
            return Ok(borrar);
        }
    }
}
