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
    public class ModeloController : ControllerBase
    {
        private readonly Contexto _bd;

        public ModeloController(Contexto contexto)
        {
            _bd = contexto;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _bd.Model.ToList();
            return Ok(lista);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Buscar(int id)
        {
            var obj = _bd.Model.Find(id);

            if (obj == null)
                return NotFound();

            return Ok(obj);
        }
        [HttpPost]
        public IActionResult Guardar(ModeloDTO obj)
        {
            var nuevo = new Model(obj);
            _bd.Model.Add(nuevo);
            _bd.SaveChanges();
            return Ok(nuevo);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Modificar(int id, Model obj)
        {
            var modificar = _bd.Model.Find(id);
            if (modificar == null)
                return NoContent();
            modificar.Modelo = obj.Modelo;

            _bd.Model.Update(modificar);
            _bd.SaveChanges();
            return Ok(modificar);
        }
        [HttpPut]
        public IActionResult CambiarEtatus(int id)
        {

            var modificar = _bd.Model.Find(id);
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
            var borrar = _bd.Model.Find(id);

            if (borrar == null)
                return NoContent();
            _bd.Model.Remove(borrar);
            _bd.SaveChanges();
            return Ok(borrar);
        }
    }
}