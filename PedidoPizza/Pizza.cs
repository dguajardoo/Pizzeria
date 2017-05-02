using System;
namespace PedidoPizza
{
	public class Pizza
	{
		public string Tipo { get; set; }

		public Pizza(string t)
		{
			this.Tipo = t;
		}
	}
}
