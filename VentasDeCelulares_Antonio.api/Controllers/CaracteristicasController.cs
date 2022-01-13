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
    public class CaracteristicasController : ControllerBase
    {
        private readonly Contexto _bd;

        public CaracteristicasController(Contexto contexto)
        {
            _bd = contexto;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _bd.Caracterisitcas.ToList();
            return Ok(lista);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Buscar(int id)
        {
            var obj = _bd.Caracterisitcas.Find(id);

            if (obj == null)
                return NotFound();

            return Ok(obj);
        }
        [HttpPost]
        public IActionResult Guardar(CaracteristicasDTO obj)
        {
            var nuevo = new Caracterisiticas(obj);
            _bd.Caracterisitcas.Add(nuevo);
            _bd.SaveChanges();
            return Ok(nuevo);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Modificar(int id, Caracterisiticas obj)
        {
            var modificar = _bd.Caracterisitcas.Find(id);
            if (modificar == null)
                return NoContent();
            modificar.Ram = obj.Ram;
            modificar.EspacioInterno = obj.EspacioInterno;
            modificar.Color = obj.Color;
            modificar.Procesador = obj.Procesador;
            _bd.Caracterisitcas.Update(modificar);
            _bd.SaveChanges();
            return Ok(modificar);
        }
        [HttpPut]
        public IActionResult CambiarEtatus(int id)
        {

            var modificar = _bd.Caracterisitcas.Find(id);
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
            var borrar = _bd.Caracterisitcas.Find(id);

            if (borrar == null)
                return NoContent();
            _bd.Caracterisitcas.Remove(borrar);
            _bd.SaveChanges();
            return Ok(borrar);
        }
    }
}