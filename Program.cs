using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasAutomotrices
{
    internal class Program
    {
        static string[] CODIGOS = new string[6] {"AUTO-201", "AUTO-202", "AUTO-203", "AUTO-204", "AUTO-205", "AUTO-206"};
        static string[] VEHICULOS = new string[6] {"SUV Interceptor", "Sedan Executive", "PickUp Titan", "City Hatchback", "Electric EV", "Van Carga"};
        static double[] PRECIOS = new double[6] { 28000.00, 18500.00, 35000.00, 14000.00, 42000.00, 22500.00 }, TOTALES = new double[6];
        static int[] CANTIDAD = new int[6] {2, 4, 1, 5, 1, 3};
        static double totalacumulado = 0;
        static int premiums = 0;

        static void ValidarDatos()
        {
            for (int i = 0; i < 6; i++)
            {
                if (PRECIOS[i] <= 0 || CANTIDAD[i] <= 0)
                {
                    Console.WriteLine("Error: El precio y la cantidad deben ser valores positivos.");
                    return;
                }
            }
        }
        static void Calculaciao()
        {
            for (int i = 0; i < 6; i++)
            {
                TOTALES[i] = PRECIOS[i] * CANTIDAD[i];
                totalacumulado += TOTALES[i];
                if (TOTALES[i] > 50000)
                {
                    premiums++;
                }
            }
        }
        static void ImpresionMatriz()
        {
            Console.WriteLine("--- MATRIZ BIDIMENSIONAL DE DATOS (PRECIO Y CANTIDAD) ---");
            Console.WriteLine("Fila\t| Código\t| Precio\t| Cantidad\t");
            Console.WriteLine("--------------------------------------------------------");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"[{i}]\t| {CODIGOS[i]}\t| $     {PRECIOS[i]}\t|          {CANTIDAD[i]}");
            }
        }
        static void Reporte()
        {
            Console.WriteLine("\n--- REPORTE ORDENADO POR MONTO NETO (DECRECIENTE) ---");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{i + 1}. Código: {CODIGOS[i]}\t| Modelo: {VEHICULOS[i]}     \t| Monto: $ {TOTALES[i]}");
            }
            Console.WriteLine("--------------------------------------------------------\n" +
                "MÉTRICAS RESUMEN:\n" +
                $"* Gran Total Acumulado      : $ {totalacumulado}\n" +
                $"* Ventas Premium (> $50,000): {premiums} transacciones\n" +
                "\n" +
                "\n" +
                "--------------------------------------------------------");
        }
        static void BubbleOrdenacionMAYORaMENOR()
        {
            for (int i = 0; i < CODIGOS.Length - 1; i++)
            {
                for (int j = 0; j < CODIGOS.Length - 1 - i; j++)
                {
                    if (TOTALES[j] < TOTALES[j + 1])
                    {
                        string AUXCOD = CODIGOS[j];
                        CODIGOS[j] = CODIGOS[j + 1];
                        CODIGOS[j + 1] = AUXCOD;

                        string AUXVHCL = VEHICULOS[j];
                        VEHICULOS[j] = VEHICULOS[j + 1];
                        VEHICULOS[j + 1] = AUXVHCL;

                        double AUXPRECIO = PRECIOS[j];
                        PRECIOS[j] = PRECIOS[j + 1];
                        PRECIOS[j + 1] = AUXPRECIO;

                        int AUXCANTIDAD = CANTIDAD[j];
                        CANTIDAD[j] = CANTIDAD[j + 1];
                        CANTIDAD[j + 1] = AUXCANTIDAD;

                        double AUXTOTAL = TOTALES[j];
                        TOTALES[j] = TOTALES[j + 1];
                        TOTALES[j + 1] = AUXTOTAL;
                    }
                }
            }
        }

        static void Search(string codiguillo)
        {
            if (string.IsNullOrWhiteSpace(codiguillo))
            {
                Console.WriteLine("Error, por favor ingrese el nombre código del vehículo.");
                return;
            }
            codiguillo.Trim();
            bool hallazgo = false;
            for (int i = 0; i < CODIGOS.Length; i++)
            {
                if (codiguillo == CODIGOS[i])
                {
                    Console.WriteLine("CÓDIGO ENCONTRADO EN EL SISTEMA\n" +
                        $"| Modelo: {VEHICULOS[i]}     \t| Monto: $ {TOTALES[i]}");
                    hallazgo = true;
                    break;
                }
            }
            if (!hallazgo) Console.WriteLine("No se encontró el código en el sistema.");
        }
        static void Main(string[] args)
        {
            ValidarDatos();
            Calculaciao();
            ImpresionMatriz();
            BubbleOrdenacionMAYORaMENOR();
            Reporte();
            Console.Write("PRUEBA DE BÚSQUEDA SECUENCIAL: "); string codigo = Console.ReadLine();
            Search(codigo);
            Console.ReadKey();
        }
    }
}
