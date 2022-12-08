using DL_EF;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result AddSP(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "ProductoAdd";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[6];
                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;

                        collection[1] = new SqlParameter("@PrecioUnitario", System.Data.SqlDbType.Money);
                        collection[1].Value = producto.PrecioUnitario;

                        collection[2] = new SqlParameter("@Stock", System.Data.SqlDbType.VarChar);
                        collection[2].Value = producto.Stock;

                        collection[3] = new SqlParameter("@IdProovedor", System.Data.SqlDbType.Int);
                        collection[3].Value = producto.Proveedor.IdProovedor;

                        collection[4] = new SqlParameter("@IdDepartamento", System.Data.SqlDbType.Int);
                        collection[4].Value = producto.Departamento.IdDepartamento;

                        collection[5] = new SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar);
                        collection[5].Value = producto.Descripcion;

                        //collection[6] = new SqlParameter("@IdProducto", System.Data.SqlDbType.Int);
                        //collection[6].Value = producto.IdProducto;



                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al registrar el producto";
                            Console.ReadKey();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "ProductoGetAll";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;


                        DataTable tableProducto = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(tableProducto);

                        if (tableProducto.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableProducto.Rows)
                            {
                                ML.Producto producto = new ML.Producto();

                                producto.IdProducto = int.Parse(row[0].ToString());
                                producto.Nombre = row[1].ToString();
                                producto.PrecioUnitario = int.Parse(row[2].ToString());
                                producto.Stock = int.Parse(row[3].ToString());

                                ML.Proveedor proveedor = new ML.Proveedor();
                                producto.Proveedor.IdProovedor = int.Parse(row[4].ToString());

                                ML.Departamento departamento = new ML.Departamento();
                                producto.Departamento.IdDepartamento = int.Parse(row[5].ToString());

                                producto.Descripcion = row[6].ToString();

                                result.Objects.Add(producto);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            Console.ReadKey();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "ProductoGetById";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("@IdProducto", SqlDbType.Int);
                        collection[0].Value = IdProducto;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableProducto = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(tableProducto);

                        if (tableProducto.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            DataRow row = tableProducto.Rows[0];

                            ML.Producto producto = new ML.Producto();

                            producto.IdProducto = int.Parse(row[0].ToString());
                            producto.Nombre = row[1].ToString();
                            producto.PrecioUnitario = int.Parse(row[2].ToString());
                            producto.Stock = int.Parse(row[3].ToString());

                            ML.Proveedor proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProovedor = int.Parse(row[4].ToString());

                            ML.Departamento departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = int.Parse(row[5].ToString());

                            producto.Descripcion = row[6].ToString();

                            result.Object = producto;
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }
        public static ML.Result Delete(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "ProductoDelete";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdProducto", System.Data.SqlDbType.Int);
                        collection[0].Value = producto.IdProducto;


                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                            Console.ReadKey();
                        }
                        else
                        {
                            result.Correct = false;
                            Console.ReadKey();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return (result);
        }

        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "ProductoUpdate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[6];
                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;

                        collection[1] = new SqlParameter("@PrecioUnitario", System.Data.SqlDbType.VarChar);
                        collection[1].Value = producto.PrecioUnitario;

                        collection[2] = new SqlParameter("@Stock", System.Data.SqlDbType.VarChar);
                        collection[2].Value = producto.Stock;

                        collection[3] = new SqlParameter("@IdProveedor", System.Data.SqlDbType.Int);
                        collection[3].Value = producto.Proveedor.IdProovedor;

                        collection[4] = new SqlParameter("@IdDepartamento", System.Data.SqlDbType.Int);
                        collection[4].Value = producto.Departamento.IdDepartamento;

                        collection[5] = new SqlParameter("@Descripciom", System.Data.SqlDbType.VarChar);
                        collection[5].Value = producto.Descripcion;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        //Entity Framework
        public static ML.Result AddEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    var query = context.ProductoAdd(producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Proveedor.IdProovedor, producto.Departamento.IdDepartamento, producto.Descripcion,producto.Imagen,producto.Departamento.Nombre);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo hacer le registro del producto";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetAllEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    producto.Proveedor = new ML.Proveedor();
                    producto.Nombre = (producto.Nombre==null) ?"": producto.Nombre;
                    //producto.Proveedor.IdProovedor = (producto.Proveedor.IdProovedor == null) ? 0 : producto.Proveedor.IdProovedor;
                    producto.Proveedor.IdProovedor = (producto.Proveedor.IdProovedor == null) ? 0 : producto.Proveedor.IdProovedor;

                    var productos = context.ProductoGetAll(producto.Nombre,producto.Proveedor.IdProovedor).ToList();
                    result.Objects = new List<object>();
                    if (productos != null)
                    {
                        foreach (var obj in productos)
                        {
                            //ML.Producto producto = new ML.Producto();
                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.Nombre;
                            producto.PrecioUnitario = obj.PrecioUnitario;
                            producto.Stock = obj.Stock;

                            //producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProovedor = obj.IdProovedor;
                            producto.Proveedor.Nombre = obj.NombreProovedor;
                            

                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = obj.IdDepartamento;
                            producto.Departamento.Nombre = obj.NombreDepartamento;

                            producto.Descripcion = obj.Descripcion;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static Result UpdateEF(ML.Producto producto)
        {
            Result result = new Result();
            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    var update = context.ProductoUpdate(producto.IdProducto, producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Proveedor.IdProovedor, producto.Departamento.IdDepartamento, producto.Descripcion, producto.Imagen);
                    if (update >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo Actualizar el Producto ";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetByIdEF(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {

                    var obj = context.ProductoGetById(IdProducto).FirstOrDefault();
                    result.Objects = new List<object>();
                    if (obj != null)
                    {
                        ML.Producto producto = new ML.Producto();
                        producto.IdProducto = obj.IdProducto;
                        producto.Nombre = obj.Nombre;
                        producto.PrecioUnitario = obj.PrecioUnitario;
                        producto.Stock = obj.Stock;

                        producto.Proveedor = new ML.Proveedor();
                        producto.Proveedor.IdProovedor = obj.IdProovedor;

                        producto.Departamento = new ML.Departamento();
                        producto.Departamento.IdDepartamento = obj.IdDepartamento;
                        producto.Descripcion = obj.Descripcion;

                        result.Object = producto;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result DeleteEF(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    var query = context.ProductoDelete(IdProducto);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        //LINQ
        public static ML.Result AddLINQ(ML.Producto producto)
        {
            Result result = new ML.Result();
            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    DL_EF.Producto productoDL = new DL_EF.Producto();
                    productoDL.Nombre = producto.Nombre;
                    productoDL.PrecioUnitario = producto.PrecioUnitario;
                    productoDL.Stock = producto.Stock;
                    productoDL.IdProovedor = producto.Proveedor.IdProovedor;
                    productoDL.IdDepartamento = producto.Departamento.IdDepartamento;
                    producto.Departamento = producto.Departamento;

                    context.Productoes.Add(productoDL);
                    var query = context.SaveChanges();

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result DeleteLINQ(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    var query = (from a in context.Productoes
                                 where a.IdProducto == producto.IdProducto
                                 select a).First();
                    context.Productoes.Remove(query);
                    int RowAffected = context.SaveChanges();

                    if (RowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        Console.WriteLine("Error al borrar el prodcuto");
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    var query = (from obj in context.Productoes
                                 select obj).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Producto producto = new ML.Producto();

                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.Nombre;
                            producto.PrecioUnitario = obj.PrecioUnitario;

                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProovedor = obj.IdProovedor.Value;

                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = obj.IdDepartamento.Value;

                            producto.Descripcion = obj.Descripcion;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetByIdLINQ(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    var query = (from producto in context.Productoes
                                 where producto.IdProducto == IdProducto
                                 select new
                                 {
                                     producto.IdProducto,
                                     producto.Nombre,
                                     producto.PrecioUnitario,
                                     producto.Stock,
                                     producto.IdProovedor,
                                     producto.IdDepartamento,
                                     producto.Descripcion
                                 }).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Producto producto = new ML.Producto();
                        producto.IdProducto = query.IdProducto;
                        producto.Nombre = query.Nombre;
                        producto.PrecioUnitario = query.PrecioUnitario;
                        producto.Stock = query.Stock;

                        producto.Proveedor = new Proveedor();
                        producto.Proveedor.IdProovedor = query.IdProovedor.Value;

                        //producto.Departamento = new Departamento();
                        producto.Departamento.IdDepartamento = query.IdDepartamento.Value;

                        producto.Descripcion = query.Descripcion;

                        result.Object = producto;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        Console.WriteLine("Ocurrio un error al hacer la consulta");
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result UpdateLINQ(ML.Producto producto)
        {
            Result result = new ML.Result();
            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {


                    var query = (from a in context.Productoes
                                where a.IdProducto == producto.IdProducto
                                select a).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = producto.Nombre;
                        query.PrecioUnitario = producto.PrecioUnitario;
                        query.Stock = producto.Stock;
                        query.IdProovedor = producto.Proveedor.IdProovedor;
                        query.IdDepartamento = producto.Departamento.IdDepartamento;
                        query.Descripcion = producto.Descripcion;
                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro registro para actualizar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


    }
}
