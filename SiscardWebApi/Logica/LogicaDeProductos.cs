using SiscardWebApi.Entidades;
using SiscardWebApi.Repositorios;

namespace SiscardWebApi.Logica
{
	public class LogicaDeProductos
	{
		private readonly RepositorioDeProductos repositorioDeProductos;

		public LogicaDeProductos()
		{
			repositorioDeProductos = new RepositorioDeProductos();
		}

		public Producto ObtenerPorId(int id)
		{
			return repositorioDeProductos.ObtenerPorId(id);
		}

	}
}
