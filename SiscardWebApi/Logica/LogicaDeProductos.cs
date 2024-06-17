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

		public int Crear(Producto producto)
		{
			if (producto == null) {
				throw new ArgumentException("Error al crear un producto. El paramétro producto es null");
			}

			if (string.IsNullOrEmpty(producto.Nombre))
			{
				throw new ArgumentException("Error al crear un producto. El nombre del producto no puede estar vacío");
			}

			if (string.IsNullOrEmpty(producto.Descripcion))
			{
				throw new ArgumentException("Error al crear un producto. La descripción del producto no puede estar vacío");
			}

			if (string.IsNullOrEmpty(producto.Codigo))
			{
				throw new ArgumentException("Error al crear un producto. El código del producto no puede estar vacío");
			}

			// Vamos a admitir precio 0 por si queremos crear un producto y aun no tenemos definido el precio
			if (producto.Precio < 0)
			{
				throw new ArgumentException("Error al crear un producto. El precio del producto no puede ser negativo");
			}

			var id = repositorioDeProductos.Crear(producto);
			return id;
		}

	}
}
