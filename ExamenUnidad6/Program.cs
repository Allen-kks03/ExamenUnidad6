using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExamenUnidad6
{
    class Program
    {
        class Amazon
        {
            string nombre;
            string descripcion;
            float precio;
            int stock;
            public Amazon(string nombre, string descripcion, float precio, int stock)
            {
                this.nombre = nombre;
                this.descripcion = descripcion;
                this.precio = precio;
                this.stock = stock;
            }
            ~Amazon()
            {
                Console.WriteLine("Memoria liberada de la clase Amazon");
            }
        }
        static void Main(string[] args)
        {
            int opcion;
            string nombre;
            string descripcion;
            float precio;
            int stock;
            do
            {
                Console.Clear();
                Console.WriteLine("- - - Registro de producto - - -");
                Console.WriteLine("1. Registrar producto ");
                Console.WriteLine("2. Ver producto(s) ");
                Console.Write("\nSu opción: ");
                opcion = Int16.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        StreamWriter sw = new StreamWriter("productos.txt", true);

                        Console.Write("Dame el nombre del producto: ");
                        nombre = Console.ReadLine();
                        Console.Write("Dame la descripcion del producto: ");
                        descripcion = Console.ReadLine();
                        Console.Write("Dame el precio del producto: ");
                        precio = float.Parse(Console.ReadLine());
                        Console.Write("Dame la cantidad de productos restantes: ");
                        stock = int.Parse(Console.ReadLine());

                        Amazon miAmazon = new Amazon(nombre, descripcion, precio, stock);

                        sw.WriteLine("Nombre del producto: " + nombre);
                        sw.WriteLine("Descripcion: " + descripcion);
                        sw.WriteLine("Precio: $" + precio);
                        sw.WriteLine("Cantidad restante: " + stock+"\n\n");

                        sw.Close();
                        break;
                    case 2:
                        Console.Clear();
                        StreamReader sr = new StreamReader("productos.txt", true);
                        string Line;

                        while ((Line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(Line);
                        }
                        Console.Write("\n\n");
                        Console.ReadKey();
                        sr.Close();

                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("¡Adios, ten un buen dia!");
                        break;
                    default:
                        Console.Write("\n¡Ingresaste una opcion inválida!, Presione ENTER para continuar");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 3);
        }
    }
}
