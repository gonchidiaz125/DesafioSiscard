﻿namespace SiscardWebApi.Entidades
{
	public class Producto
	{
        public int Id { get; set; }
		public string Nombre { get; set; }

		public string Descripcion { get; set; }

		public string Codigo { get; set; }

		public decimal Precio { get; set; }
	}
}
