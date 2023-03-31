using System;
using System.Threading;

namespace MultihilosConteoTempFib
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread hiloPrincipal = Thread.CurrentThread;
            hiloPrincipal.Name = "Hilo principal";

            ImprimirResultados();

            Console.WriteLine("Programa terminado.");
            Console.ReadKey();

        }
        public static void FibonacciConteo(int len)
        {
            int a = 0, b = 1, c = 0;
            Console.WriteLine("Conteo Fibonacci:  " + a);
            Console.WriteLine("Conteo Fibonacci:  " + b);
            for (int i = 2; i < len; i++)
            {
                c = a + b;
                Console.WriteLine("Conteo Fibonacci: " + " {0}", c);
                a = b;
                b = c;
                Thread.Sleep(1000);
            }
            Console.WriteLine("El conteo Fibonacci ha terminado.");
        }
        public static void CuentaAtras(int segundos)
        {
            for (int i = segundos; i >= 0; i--)
            {
                Console.WriteLine("Temporizador: " + i + " segundos");
                Thread.Sleep(1000);
            }
            Console.WriteLine("El temporizador ha terminado.");
        }
        public static void ImprimirResultados()
        {
            bool repetir = true;
            while (repetir)
            {
                // Pregunta al usuario la cantidad de numeros fibonacci
                Console.WriteLine("Ingrese la cantidad de números Fibonacci a imprimir:");
                int cantidadFibonacci = int.Parse(Console.ReadLine());

                // Pregunta al usuario la cantidad de segundos
                Console.WriteLine("Ingrese la cantidad de segundos a contar:");
                int cantidadSegundos = int.Parse(Console.ReadLine());

                // Ejecucion de los conteos
                Thread T1 = new Thread(() => FibonacciConteo(cantidadFibonacci));
                Thread T2 = new Thread(() => CuentaAtras(cantidadSegundos));

                Console.WriteLine("Iniciando los conteos:");

                T1.Start();
                T2.Start();

                // Esperar a que terminen los conteos
                T1.Join();
                T2.Join();

                // Pregunta si quiere continuar
                Console.WriteLine("¿Desea volver a imprimir los resultados? (S/N)");
                string respuesta = Console.ReadLine();

                if (respuesta.ToUpper() != "S")
                {
                    repetir = false;
                }
            }
        }

    }
}