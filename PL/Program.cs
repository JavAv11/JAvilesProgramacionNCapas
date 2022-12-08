using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Que desea realizar?");
            Console.WriteLine("Seleccione el numero de su opcion unicamente");

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Opciones de Usuario");
            Console.WriteLine("1.- Agregar, 2.- Actualizar, 3.- Borrar 4-. GettAll 5-. GetById");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Opciones de Producto");
            Console.WriteLine("6.- Agregar, 7.- Actualizar, 8.- Borrar 9-. GettAll 10-. GetById");
            Console.WriteLine("----------------------------------------------------------------");

            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    PL.Usuario.Add();
                    break;
                case 2:
                    PL.Usuario.Update();
                    break;
                case 3:
                    //PL.Usuario.Delete();
                    break;
                case 4:
                    //PL.Usuario.GetAll();
                    break;
                case 5:
                    PL.Usuario.GetById();
                    break;
                case 6:
                    PL.Producto.Add();
                    break;
                case 7:
                    PL.Producto.Update();
                    break;
                case 8:
                    PL.Producto.Delete();
                    break;
                case 9:
                    PL.Producto.GetALL();
                    break;
                case 10:
                    PL.Producto.GetById();
                    break;

            }
        }
    }
}
