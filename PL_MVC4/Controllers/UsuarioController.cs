using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario


        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = new ML.Result();
            usuario.Rol = new ML.Rol();

            ML.Result resultRol = BL.Rol.GetAll();
            result = BL.Usuario.GetAll_EF(usuario);



            if (result.Correct)
            {
                usuario.Rol.NombreRol = resultRol.Objects;
                usuario.Usuarios = result.Objects;

                return View(usuario);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
                return View();
            }

        }
        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            result = BL.Usuario.GetAll_EF(usuario);
            //ML.Result result = BL.Usuario.GetAll_EF();


            if (result.Correct)
            {
                //ML.Usuario usuario = new ML.Usuario();
                usuario.Usuarios = result.Objects;

                return View(usuario);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
                return View();
            }

        }

        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {

            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();



            ML.Result resultRol = BL.Rol.GetAll();
            ML.Result resultPais = BL.Pais.GetAll();




            if (IdUsuario == null)
            {
                //
                usuario.Rol.NombreRol = resultRol.Objects;

                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;


                return View(usuario);
            }
            else
            {

                //GetbyId
                ML.Result result = BL.Usuario.GeById_EF(IdUsuario.Value);


                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                    usuario.Rol.NombreRol = resultRol.Objects;


                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                    //Estado
                    ML.Result resultEstados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;

                    //Municipio
                    ML.Result resultMunicipio = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;

                    //Colonia
                    ML.Result resultColonia = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    usuario.Direccion.Colonia.Colonias = resultColonia.Objects;

                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar el Usuario seleccionado";
                }
                return View(usuario);
            }

        }

        [HttpPost]


        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            //HttpPostedFileBase file = Request.Files["ImagenData"];

            //if (file.ContentLength > 0)
            //{
            //    usuario.Imagen = ConvertToBytes(file);
            //}


            if (usuario.IdUsuario == 0)
            {
                //add
                result = BL.Usuario.Add_EF(usuario);



                if (result.Correct)
                {
                    ViewBag.Message = "Se ha registrado el Usuario";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No ha registrado el Usuario" + result.ErrorMessage;
                    return PartialView("Modal");
                }

            }
            else
            {
                //update
                result = BL.Usuario.Update_EF(usuario);
                if (result.Correct)
                {

                    ViewBag.Mensaje = "Se ha registrado el Usuario";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Mensaje = "No ha registrado el Usuario" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
        }

        [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            result = BL.Usuario.Delete_EF(IdUsuario);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Se ha elimnado el registro";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Mensaje = "No see ha elimnado el registro" + result.ErrorMessage;
                return PartialView("Modal");
            }
        }


        public JsonResult GetEstado(int IdPais)
        {
            var result = BL.Estado.GetByIdPais(IdPais);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDireccion(int IdPais)
        {
            var result = BL.Estado.GetByIdPais(IdPais);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.GetByIdEstado(IdEstado);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.GetByIdMunicipio(IdMunicipio);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public byte[] ConvertToBytes(HttpPostedFileBase imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(imagen.InputStream);
            data = reader.ReadBytes((int)imagen.ContentLength);
            return data;
        }
    }
}