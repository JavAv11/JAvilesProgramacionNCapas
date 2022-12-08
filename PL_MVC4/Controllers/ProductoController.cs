using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC4.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();
            ML.Result result = new ML.Result();
            result = BL.Producto.GetAllEF(producto);

            if (result.Correct)
            {
                //ML.Producto producto = new ML.Producto();
                producto.Productos = result.Objects;

                return View(producto);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult Form(int? IdProducto)
        {

            ML.Producto producto = new ML.Producto();
            //producto.Rol = new ML.Rol();
            producto.Departamento = new ML.Departamento();
            producto.Proveedor = new ML.Proveedor();
            ML.Result resultDepartamento = BL.Departamento.GetAll();
            ML.Result resultProveedor= BL.Proovedor.GetAll();

            if (IdProducto == null)
            {
                //
                //producto.Rol.Roles = resultRol.Objects;
                producto.Departamento.Departamentos = resultDepartamento.Objects;
                producto.Proveedor.Proveedores = resultProveedor.Objects;
                return View(producto);
            }
            else
            {

                //GetbyId
                ML.Result result = BL.Producto.GetByIdEF(IdProducto.Value);

                if (result.Correct)
                {
                    producto =(ML.Producto)result.Object;
                    producto.Departamento.Departamentos = resultDepartamento.Objects;
                    producto.Proveedor.Proveedores= resultProveedor.Objects;


                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar el Usuario seleccionado";
                }
                return View(producto);
            }

        }

        [HttpPost]

        public ActionResult Form(ML.Producto producto)
        {
            if (producto.IdProducto == 0)
            {
                ML.Result result = BL.Producto.AddEF(producto);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha registrado el producot";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Mensaje = "No se ha registrado el Producto" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                ML.Result result = BL.Producto.UpdateEF(producto);
                if (result.Correct)
                {

                    ViewBag.Mensaje = "Se ha registrado el Producto";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Mensaje = "No ha registrado el Producto" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
        }



        [HttpGet]
        public ActionResult Delete(int IdProducto)
        {
            ML.Result result = new ML.Result();

            result = BL.Producto.DeleteEF(IdProducto);
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
    }
}