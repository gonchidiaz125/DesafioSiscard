using Microsoft.AspNetCore.Mvc;
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

	}	
}
