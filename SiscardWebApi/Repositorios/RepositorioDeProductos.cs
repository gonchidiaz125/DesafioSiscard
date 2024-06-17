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

			using (SqlConnection conexion = new SqlConnection(connectionString))
			{
				conexion.Open();

				using (SqlCommand comando = new SqlCommand("SELECT Id, Nombre, Descripcion, Codigo, Precio FROM Productos WHERE Id = @Id", conexion))
				{
					comando.Parameters.AddWithValue("id", id);

					using (SqlDataReader reader = comando.ExecuteReader())
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

		public int Crear(Producto producto)
		{
			int idInsertado = 0;
			using (SqlConnection conexion = new SqlConnection(connectionString))
			{
				
				var sql = "INSERT INTO productos (Nombre, Descripcion, Codigo, Precio ) VALUES (@Nombre, @Descripcion, @Codigo, @Precio); SELECT SCOPE_IDENTITY();";
				SqlCommand comandoSql = new SqlCommand(sql, conexion);
				comandoSql.Parameters.AddWithValue("@Nombre", producto.Nombre);
				comandoSql.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
				comandoSql.Parameters.AddWithValue("@Codigo", producto.Codigo);
				comandoSql.Parameters.AddWithValue("@Precio", producto.Precio);
				conexion.Open();
				// Ejecuto el SQL esperando que retorne un solo valor (el valor identity del producto inserado)
				idInsertado = Convert.ToInt32(comandoSql.ExecuteScalar());
			}
			return idInsertado;
		}

	}
}
