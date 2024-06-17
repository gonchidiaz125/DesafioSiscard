using SiscardWebApi.Entidades;
using System.Data.SqlClient;

namespace SiscardWebApi.Repositorios
{
	public class RepositorioDeProductos
	{

		// Crear, Modificar, Eliminar, ObtenerPorId, ObtenerTodos
		string connectionString = "Server=localhost;Database=Siscard;Trusted_Connection=True;MultipleActiveResultSets=true";


		public Producto ObtenerPorId(int id)		{
			Producto producto = null;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (SqlCommand command = new SqlCommand("SELECT Id, Nombre, Descripcion, Codigo, Precio FROM Productos WHERE Id = @Id", connection))
				{
					command.Parameters.AddWithValue("id", id);

					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							producto = new Producto
							{
								Id = Convert.ToInt32(reader["Id"]),
								Nombre = Convert.ToString(reader["Nombre"]),
								Descripcion = Convert.ToString(reader["Descripcion"]),
								Codigo = Convert.ToString(reader["Codigo"]),
								Precio = Convert.ToDecimal(reader["Precio"]),
							};
						}
					}
				}
			}
			return producto;
		}

	}
}
