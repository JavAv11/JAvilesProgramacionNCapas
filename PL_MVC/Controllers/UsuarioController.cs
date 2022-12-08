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
            ML.Result result = new ML.Result();
            result = BL.Usuario.GetAll_EF();
            //ML.Result result = BL.Usuario.GetAll_EF();
            
            
            if(result.Correct)
            {
                ML.Usuario usuario = new ML.Usuario();
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

            ML.Result resultRol = new ML.Result();
            resultRol=BL.Rol.GetAll();
            usuario.Rol.Roles = resultRol.Objects;

            if (IdUsuario == null)
            {              
                //
                return View();
            }
            else
            {

                //GetbyId
                ML.Result result = BL.Usuario.GeById_EF(IdUsuario.Value);
                //ML.Usuario usuario = new ML.Usuario();

                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;

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
            if (usuario.IdUsuario == 0)
            {
                //add
                //ml.result = agergar
                ML.Result result = BL.Usuario.Add_EF(usuario);

                if (result.Correct)
                {
                    usuario =(ML.Usuario)result.Object;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al agregar al usuario";
                }

            }
            else
            {
                //update
                //ml.result = update
                //if
                ML.Result result = BL.Usuario.Update_EF(usuario);
                if (result.Correct)
                {

                    usuario = (ML.Usuario)result.Object;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al Actualizar al usuario";
                }
            }
            return PartialView(usuario);
       
        }

    }
}