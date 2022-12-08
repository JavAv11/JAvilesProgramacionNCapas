using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        /*public static void AddSP()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Escribe el nombre del usuario");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el Apellido Paterno del usuario");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Escribe el Apellido Materno del usuario");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Escribe la Fecha de Nacimiento del usuario");
            usuario.FechaDeNacimiento = Console.ReadLine();

            Console.WriteLine("Escribe el sexo del usuario");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Escribe el UserName");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Escribe el Email del usuario");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Escribe el Password del usuario");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Escribe el Telefono del usuario");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Escribe el Celular del usuario");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Escribe el CURP del usuario");
            usuario.CURP = Console.ReadLine();


            usuario.Rol = new ML.Rol();
            Console.WriteLine("Escribe el IdRol del usuario");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            ;

            ML.Result result = new ML.Result();

            result = BL.Usuario.AddSP(usuario);

            if (result.Correct == true)
            {
                Console.WriteLine("El usuario se registro correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El usuario no pudo ser registrado ");
                Console.ReadKey();
            }

        }*/

        public static void Delete(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Escribe el Id del usuario que quieres borrar");
            usuario.IdUsuario = Convert.ToInt32(Console.ReadLine());

            ML.Result result = new ML.Result();

            //result = BL.Usuario.Delete(usuario);
            result = BL.Usuario.Delete_EF(IdUsuario);
            //result = BL.Usuario.DeleteLINQ(usuario);

            if (result.Correct == true)
            {
                Console.WriteLine("El usuario se borro correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El usuario no pudo ser borrado " + result.ErrorMessage);
                Console.ReadKey();
            }


        }

        public static void Update()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Que usuario desea modificar");
            usuario.IdUsuario = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Escribe los nuevos valores");

            Console.WriteLine("Escribe el nombre del usuario");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el Apellido Paterno del usuario");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Escribe el Apellido Materno del usuario");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Escribe la Fecha de Nacimiento del usuario");
            usuario.FechaDeNacimiento = Console.ReadLine();

            Console.WriteLine("Escribe el sexo del usuario");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Escribe el UserName");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Escribe el Email del usuario");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Escribe el Password del usuario");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Escribe el Telefono del usuario");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Escribe el Celular del usuario");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Escribe el CURP del usuario");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Escribe el IdRol del Usuario");

            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());
            ML.Result result = new ML.Result();

            //result = BL.Usuario.Update(usuario);

            result = BL.Usuario.Update_EF(usuario);
            //result = BL.Usuario.UpdateLINQ(usuario);
            if (result.Correct == true)
            {
                Console.WriteLine("El usuario se actualizo correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El usuario no pudo ser actualizado " + result.ErrorMessage);
                Console.ReadKey();
            }

        }

        //public static void GetAll(string nombre, string apellidoPaterno, int IdRol)
        //{
        //    //ML.Result result = BL.Usuario.GetAll();

        //    //ML.Result result = BL.Usuario.GetAll_EF( nombre,  apellidoPaterno,  IdRol);
        //    //ML.Result result = BL.Usuario.GetAllLINQ();

        //    if (result.Correct)
        //    {
        //        foreach (ML.Usuario usuario in result.Objects)
        //        {
        //            Console.WriteLine("---------------------------------------------");
        //            Console.WriteLine("El Id del usuario es: " + usuario.IdUsuario);
        //            Console.WriteLine("El Nombre del usuario es: " + usuario.Nombre);
        //            Console.WriteLine("El Apellido Paterno del usuario es: " + usuario.ApellidoPaterno);
        //            Console.WriteLine("El Apellido Materno del usuario es: " + usuario.ApellidoMaterno);
        //            Console.WriteLine("El Fecha de Nacimiento del usuario es: " + usuario.FechaDeNacimiento);
        //            Console.WriteLine("El Sexo del usuario es: " + usuario.Sexo);
        //            Console.WriteLine("El UserName del usuario es: " + usuario.UserName);
        //            Console.WriteLine("El Email del usuario es: " + usuario.Email);
        //            Console.WriteLine("El Password del usuario es: " + usuario.Password);
        //            Console.WriteLine("El Telefono del usuario es: " + usuario.Telefono);
        //            Console.WriteLine("El Celular del usuario es: " + usuario.Celular);
        //            Console.WriteLine("El CURP del usuario es: " + usuario.CURP);
        //            Console.WriteLine("El Rol del usuario es: " + usuario.Rol.IdRol);

        //            Console.WriteLine("-------------------------------------------------");

        //            Console.ReadKey();
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Ocurrio un error: " + result.ErrorMessage);
        //        Console.ReadKey();
        //    }
        //}

        public static void GetById()
        {

            Console.WriteLine("Ingresa Id de Usuario que desea Consultar");
            int IdUsuario = int.Parse(Console.ReadLine());


            ML.Result result = BL.Usuario.GeById_EF(IdUsuario);
            //ML.Result result = BL.Usuario.GetByIdLINQ(IdUsuario);



            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;

                //ML.Usuario usuario = (ML.Usuario)result.Object;

                Console.WriteLine("");
                Console.WriteLine("El Id del usuario es: " + usuario.IdUsuario);
                Console.WriteLine("El Nombre del usuario es: " + usuario.Nombre);
                Console.WriteLine("El Apellido Paterno del usuario es: " + usuario.ApellidoPaterno);
                Console.WriteLine("El Apellido Materno del usuario es: " + usuario.ApellidoMaterno);
                Console.WriteLine("El Fecha de Nacimiento del usuario es: " + usuario.FechaDeNacimiento);
                Console.WriteLine("El Sexo del usuario es: " + usuario.Sexo);
                Console.WriteLine("El UserName del usuario es: " + usuario.UserName);
                Console.WriteLine("El Email del usuario es: " + usuario.Email);
                Console.WriteLine("El Password del usuario es: " + usuario.Password);
                Console.WriteLine("El Telefono del usuario es: " + usuario.Telefono);
                Console.WriteLine("El Celular del usuario es: " + usuario.Celular);
                Console.WriteLine("El CURP del usuario es: " + usuario.CURP);
                Console.WriteLine("El Rol del usuario es: " + usuario.Rol.IdRol);

                Console.WriteLine("");

                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Ocurrio un error: " + result.ErrorMessage);
                Console.ReadKey();
            }
        }

        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Escribe el nombre del usuario");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el Apellido Paterno del usuario");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Escribe el Apellido Materno del usuario");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Escribe la Fecha de Nacimiento del usuario");
            usuario.FechaDeNacimiento = Console.ReadLine();

            Console.WriteLine("Escribe el sexo del usuario");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Escribe el UserName");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Escribe el Email del usuario");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Escribe el Password del usuario");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Escribe el Telefono del usuario");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Escribe el Celular del usuario");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Escribe el CURP del usuario");
            usuario.CURP = Console.ReadLine();


            usuario.Rol = new ML.Rol();
            Console.WriteLine("Escribe el IdRol del usuario");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            ;

            ML.Result result = new ML.Result();

            //result = BL.Usuario.AddSP(usuario);
            result = BL.Usuario.Add_EF(usuario);
            //result = BL.Usuario.AddLINQ(usuario);

            if (result.Correct == true)
            {
                Console.WriteLine("El usuario se registro correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El usuario no pudo ser registrado ");
                Console.ReadKey();
            }
        }


    }
}
