using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Producto
    {
        public static void AddSP()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el nombre del Producto");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su precio unitario");
            producto.PrecioUnitario = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese cantidad de Stock");
            producto.Stock = int.Parse(Console.ReadLine());

            producto.Proveedor = new ML.Proveedor();
            Console.WriteLine("Ingrese el Id de Proveedor");
            producto.Proveedor.IdProovedor = int.Parse(Console.ReadLine());

            producto.Departamento = new ML.Departamento();
            Console.WriteLine("Ingrese el Id del Departamento");
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la descripcion del producto");
            producto.Descripcion = Console.ReadLine();

            ML.Result result = new ML.Result();

            result = BL.Producto.AddSP(producto);

            if (result.Correct == true)
            {
                Console.WriteLine("El Producto se registro correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El Producto no pudo ser registrado ");
                Console.ReadKey();
            }
        }

        public static void GetALL()
        {
            // ML.Result result = BL.Producto.GetAll();
            //ML.Result result = BL.Producto.GetAllEF();
            ML.Result result = BL.Producto.GetAllLINQ();

            if (result.Correct)
            {
                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("El Id del Producto es: " + producto.IdProducto);
                    Console.WriteLine("El Nombre del Producto es: " + producto.Nombre);
                    Console.WriteLine("El Precio Unitario del Producto es: " + producto.PrecioUnitario);
                    Console.WriteLine("El Stock del Producto es: " + producto.Stock);
                    Console.WriteLine("El Proveedor del Producto es: " + producto.Proveedor.IdProovedor);
                    Console.WriteLine("El Departamento del Producto es: " + producto.Departamento.IdDepartamento);
                    Console.WriteLine("El Descripcion del Producto es: " + producto.Descripcion);
                    Console.WriteLine(" ");

                    Console.ReadKey();

                }
            }
            else
            {
                Console.WriteLine("Ocurrio un error:  " + result.ErrorMessage);
                Console.ReadKey();
            }

        }

        public static void GetById()
        {
            
            Console.WriteLine("Ingresa el Id del Producto que quiere buscar");
            int IdProducto = int.Parse(Console.ReadLine());

           
            //ML.Result result = BL.Producto.GetById(producto.IdProducto);
            ML.Result result = BL.Producto.GetByIdLINQ(IdProducto);

            if (result.Correct)
            {
                ML.Producto producto = (ML.Producto)result.Object;

                Console.WriteLine(" ");
                Console.WriteLine("El Id del Producto es: " + producto.IdProducto);
                Console.WriteLine("El Nombre del Producto es: " + producto.Nombre);
                Console.WriteLine("El Precio Unitario del Producto es: " + producto.PrecioUnitario);
                Console.WriteLine("El Stock del Producto es: " + producto.Stock);
                Console.WriteLine("El Proveedor del Producto es: " + producto.Proveedor.IdProovedor);
                Console.WriteLine("El Departamento del Producto es: " + producto.Departamento.IdDepartamento);
                Console.WriteLine("El Descripcion del Producto es: " + producto.Descripcion);
                Console.WriteLine(" ");

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ocurrio un error: " + result.ErrorMessage);
                Console.ReadKey();
            }

        }

        public static void Delete()
        {
            ML.Producto producto = new ML.Producto();
            Console.WriteLine("Ingrsea el Id del Producto que quiere borrar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Producto.Delete(producto);
            //ML.Result result = BL.Producto.DeleteEF(producto);
            ML.Result result = BL.Producto.DeleteLINQ(producto);

            if (result.Correct)
            {
                Console.WriteLine("El Producto ha sido Eliminado");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El Producto no ha sido Eliminado");
                Console.ReadKey();
            }
        }

        public static void Update()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el Id del Producto que quiere actualizar");
            producto.IdProducto =int.Parse( Console.ReadLine());

            Console.WriteLine("Ingrese nuevo nombre o ingrese el mismo");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su precio unitario");
            producto.PrecioUnitario = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese cantidad de Stock");
            producto.Stock = int.Parse(Console.ReadLine());

            producto.Proveedor = new ML.Proveedor();
            Console.WriteLine("Ingrese el Id de Proveedor");
            producto.Proveedor.IdProovedor = int.Parse(Console.ReadLine());

            producto.Departamento = new ML.Departamento();
            Console.WriteLine("Ingrese el Id del Departamento");
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la descripcion del producto");
            producto.Descripcion = Console.ReadLine();

            //result = BL.Producto.Update(producto);
            //result = BL.Producto.UpdateEF(producto);
            ML.Result result = BL.Producto.UpdateLINQ(producto);
            if(result.Correct == true)
            {
                Console.WriteLine("El producto ha sido actualizado con exito");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El producto no pudo se actualizado");
                Console.ReadKey();
            }
        }

        public static void Add()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el nombre del Producto");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su precio unitario");
            producto.PrecioUnitario = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese cantidad de Stock");
            producto.Stock = int.Parse(Console.ReadLine());

            producto.Proveedor = new ML.Proveedor();
            Console.WriteLine("Ingrese el Id de Proveedor");
            producto.Proveedor.IdProovedor = int.Parse(Console.ReadLine());

            producto.Departamento = new ML.Departamento();
            Console.WriteLine("Ingrese el Id del Departamento");
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la descripcion del producto");
            producto.Descripcion = Console.ReadLine();

            ML.Result result = new ML.Result();

            //result = BL.Producto.AddEF(producto);
            result = BL.Producto.AddLINQ(producto);

            if (result.Correct == true)
            {
                Console.WriteLine("El Producto se registro correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El Producto no pudo ser registrado ");
                Console.ReadKey();
            }
        }

    }
}

