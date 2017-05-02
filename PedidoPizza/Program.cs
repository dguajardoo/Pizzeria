using System;
using System.Threading.Tasks;

namespace PedidoPizza
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Pidiendo una pizza de pepperoni con mi amigo");
			Console.WriteLine("============================================");
			Console.WriteLine();

			Task t = PrimeraEspera();
			t.Wait();

			Task t2 = EsperandoLaPizza();
			t2.Wait();

			Console.WriteLine("BUEN PROVECHO!");
			Console.WriteLine();
			HablandoDeFutbol();
			Console.WriteLine("Pulse cualquier tecla para finalizar...");
			Console.ReadKey(true);
		}

		public async static Task PrimeraEspera()
		{
			var miPizza = new Pizza("Pepperoni");
			Console.WriteLine("Llegamos a la pizzería a las {0} y esperamos para hacer el pedido...",
							  DateTime.Now.ToString("T"));

            HablandoDeFutbol();
			await Task.Delay(10000);

			Console.WriteLine("Pedimos una pizza de {0} a las {1}",
							  miPizza.Tipo, DateTime.Now.ToString("T"));
		}

		private async static Task<Pizza> EsperandoLaPizza()
		{
			Pizzeria dominos = new Pizzeria();
			var task = dominos.ServirPizza("Pepperoni");
			task.Start();

			//Llega el empleado y hacemos el pedido y nos quedamos esperando...
			var miPizza = await task;
			await Task.Delay(10000);

			Console.WriteLine("Nos traen la pizza de {0} a las {1}",
							  miPizza.Tipo, DateTime.Now.ToString("T"));
			return miPizza;
		}

		private static void HablandoDeFutbol()
		{
			Console.WriteLine("...hablando de futbol...");
			Console.WriteLine("Bla bla bla....");
			Console.WriteLine();
		}
	}
}
