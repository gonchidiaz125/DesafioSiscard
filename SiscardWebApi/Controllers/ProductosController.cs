﻿using Microsoft.AspNetCore.Mvc;
using SiscardWebApi.Entidades;
using SiscardWebApi.Logica;

namespace SiscardWebApi.Controllers
{
	[ApiController]
	[Route("api/Productos")]
	public class ProductosController : ControllerBase
	{
		private readonly LogicaDeProductos logicaDeProductos;

		public ProductosController()
		{
			logicaDeProductos = new LogicaDeProductos();
		}

		[HttpGet("{id}")]
		public ActionResult<Producto> Get(int id)
		{
			var producto = logicaDeProductos.ObtenerPorId(id);

			if (producto == null)
			{
				return NotFound();
			}
			return Ok(producto);
		}

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            List<Producto> productos = logicaDeProductos.ObtenerTodosLosProductos().ToList();
            return Ok(productos);
        }

        [HttpPost]
		public IActionResult Crear([FromBody] Producto producto)
		{
			try
			{
				var id = logicaDeProductos.Crear(producto);
				// devuelvo al front-end el Id del producto creado
				return Ok(id);
			}
			catch (ArgumentException ex)
			{
				// Devuelve un 400 Bad Request con el mensaje de error
				return BadRequest(new { mensaje = ex.Message });
			}
			catch (Exception ex)
			{
				// Devuelve un 500 Internal Server Error para otros tipos de errores
				return StatusCode(500, new { mensaje = "Error inesperado", detalle = ex.Message });
			}
			
		}
		[HttpPut]
		public IActionResult Actualizar([FromBody] Producto producto)
		{

			try
			{
				var id = logicaDeProductos.Actualizar(producto);

				return Ok(id);

			}
			catch (ArgumentException ex)
			{
				return BadRequest(new { mensaje = ex.Message });
			}
            catch (Exception ex) 
			{
				return StatusCode(500, new { mensaje = "Error inesperado", detalle = ex.Message });
			}
        }

    }	
}
