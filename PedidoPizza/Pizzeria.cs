using System;
using System.Threading.Tasks;

namespace PedidoPizza
{
	public class Pizzeria
	{
		public Task<Pizza> ServirPizza(string tipo)
		{
			return new Task<Pizza>(() =>
			{
				return new Pizza(tipo);
			});
		}
	}
}
