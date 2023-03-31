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
            
            Thread T1 = new Thread (() => FibonacciConteo(10));
            Thread T2 = new Thread (CuentaArriva);

            Console.WriteLine(hiloPrincipal.Name + " inicia los conteos:");
          
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
            Console.WriteLine("El conteo Fibonacci a terminado.");
        }
        public static void CuentaArriva()
        {
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Temporizador 2 : " + i + " segundos");
                Thread.Sleep(1000);
            }
            Console.WriteLine("El temporizador a terminado.");
        }
        public static void ImprimirResultados()
        {
            bool repetir = true;
            while (repetir)
            {
                // Ejecutar los conteos
                Thread T1 = new Thread(() => FibonacciConteo(10));
                Thread T2 = new Thread(CuentaArriva);

                Console.WriteLine("Iniciando los conteos:");

                T1.Start();
                T2.Start();

                // Esperar a que terminen los conteos
                T1.Join();
                T2.Join();

                // Preguntar al usuario si quiere repetir
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

