using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BL
{
    public class Usuario
    {
        /*public static void Add(ML.Usuario objUsuario)
        {
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "INSERT INTO Usuario (Nombre, ApellidoPaterno, ApellidoMaterno, FechaDeNacimiento, Sexo, ContactoDeEmergencia, CorreoElectronico)" +
                            "VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @FechaDeNacimiento, @Sexo, @ContactoDeEmergencia, @CorreoElectronico)";
                        
                        cmd.Connection = context;

                        SqlParameter[] collection= new SqlParameter[7];

                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = objUsuario.Nombre;
                        
                        collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = objUsuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = objUsuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("@FechaDeNacimiento", System.Data.SqlDbType.Date);
                        collection[3].Value = objUsuario.FechaDeNacimiento;
                        
                        collection[4] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                        collection[4].Value = objUsuario.Sexo;
                        
                        collection[5] = new SqlParameter("@ContactoDeEmergencia", System.Data.SqlDbType.Int);
                        collection[5].Value = objUsuario.ContactoDeEmergencia;
                        
                        collection[6] = new SqlParameter("@CorreoElectronico", System.Data.SqlDbType.VarChar);
                        collection[6].Value = objUsuario.CorreoElectronico;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("El objUsuario se ha registrado de manera exitosa");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("El objUsuario no se ha podido registrar");
                            Console.ReadKey();
                        }

                    }
                }
            }
            catch(Exception ex)
            {

            }
        }*/

        /*public static void Delete(ML.Usuario objUsuario)
        {
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                                            ///Consulta para borrar un objUsuario
                        cmd.CommandText = "DELETE FROM Usuario WHERE IdUsuario= @IdUsuario";

                        cmd.Connection = context;

                        
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                        collection[0].Value = objUsuario.IdUsuario;

                        
                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("El objUsuario se ha borrado de manera exitosa");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("El objUsuario no se ha podido borrar");
                            Console.ReadKey();
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }*/

        /*public static void Update(ML.Usuario objUsuario)
        {
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UPDATE Usuario SET Nombre=@Nombre, ApellidoPaterno=@ApellidoPaterno, ApellidoMaterno=@ApellidoMaterno, FechaDeNacimiento=@FechaDeNacimiento, Sexo=@Sexo, ContactoDeEmergencia=@ContactoDeEmergencia, CorreoElectronico=@CorreoElectronico WHERE IdUsuario = @IdUsuario";

                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = objUsuario.Nombre;

                        collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = objUsuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = objUsuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("@FechaDeNacimiento", System.Data.SqlDbType.Date);
                        collection[3].Value = objUsuario.FechaDeNacimiento;

                        collection[4] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                        collection[4].Value = objUsuario.Sexo;

                        collection[5] = new SqlParameter("@ContactoDeEmergencia", System.Data.SqlDbType.Int);
                        collection[5].Value = objUsuario.ContactoDeEmergencia;

                        collection[6] = new SqlParameter("@CorreoElectronico", System.Data.SqlDbType.VarChar);
                        collection[6].Value = objUsuario.CorreoElectronico;

                        collection[7] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.VarChar);
                        collection[7].Value = objUsuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("El objUsuario se ha actualizado de manera exitosa");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("El objUsuario no se ha podido actualizado");
                            Console.ReadKey();
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }

        }*/

        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "INSERT INTO Usuario (Nombre, ApellidoPaterno, ApellidoMaterno, FechaDeNacimiento, Sexo, UserName, Email, Password, Telefono, Celular, CURP)" +
                            "VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @FechaDeNacimiento, @Sexo, @UserName, @Email, @Password, @Telefono, @Celular, @CURP )";

                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[11];

                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("@FechaDeNacimiento", System.Data.SqlDbType.Date);
                        collection[3].Value = usuario.FechaDeNacimiento;

                        collection[4] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                        collection[4].Value = usuario.Sexo;
                        ////////////////////
                        collection[5] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                        collection[5].Value = usuario.UserName;

                        collection[6] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                        collection[6].Value = usuario.Email;

                        collection[7] = new SqlParameter("@PassWord", System.Data.SqlDbType.VarChar);
                        collection[7].Value = usuario.Password;

                        collection[8] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
                        collection[8].Value = usuario.Telefono;

                        collection[9] = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
                        collection[9].Value = usuario.Celular;

                        collection[10] = new SqlParameter("@CURP", System.Data.SqlDbType.VarChar);
                        collection[10].Value = usuario.CURP;




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
            return result;
        }

        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        ///Consulta para borrar un objUsuario
                        cmd.CommandText = "UsuarioDelete";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;


                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdUsuario", System.Data.SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;


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

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioUpdate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[11];

                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("@FechaDeNacimiento", System.Data.SqlDbType.Date);
                        collection[3].Value = usuario.FechaDeNacimiento;

                        collection[4] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                        collection[4].Value = usuario.Sexo;
                        ////////////
                        collection[5] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                        collection[5].Value = usuario.UserName;

                        collection[6] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                        collection[6].Value = usuario.Email;

                        collection[7] = new SqlParameter("@PassWord", System.Data.SqlDbType.VarChar);
                        collection[7].Value = usuario.Password;

                        collection[8] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
                        collection[8].Value = usuario.Telefono;

                        collection[9] = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
                        collection[9].Value = usuario.Celular;

                        collection[10] = new SqlParameter("@CURP", System.Data.SqlDbType.VarChar);
                        collection[10].Value = usuario.CURP;

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

        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioAdd";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[12];

                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("@FechaDeNacimiento", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.FechaDeNacimiento;

                        collection[4] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                        collection[4].Value = usuario.Sexo;

                        collection[5] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                        collection[5].Value = usuario.UserName;

                        collection[6] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                        collection[6].Value = usuario.Email;

                        collection[7] = new SqlParameter("@PassWord", System.Data.SqlDbType.VarChar);
                        collection[7].Value = usuario.Password;

                        collection[8] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
                        collection[8].Value = usuario.Telefono;

                        collection[9] = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
                        collection[9].Value = usuario.Celular;

                        collection[10] = new SqlParameter("@CURP", System.Data.SqlDbType.VarChar);
                        collection[10].Value = usuario.CURP;


                        collection[11] = new SqlParameter("@IdRol", System.Data.SqlDbType.Int);
                        collection[11].Value = usuario.Rol.IdRol;



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
                            result.ErrorMessage = "Ocurrio un error al registrar al Usuario";
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
        public static ML.Result GetAll(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioGetAll";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;


                        DataTable tableUsuario = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableUsuario.Rows)
                            {
                                //ML.Usuario objUsuario = new ML.Usuario();

                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno = row[3].ToString();
                                usuario.FechaDeNacimiento = row[4].ToString();
                                usuario.Sexo = row[5].ToString();
                                usuario.UserName = row[6].ToString();
                                usuario.Email = row[7].ToString();
                                usuario.Password = row[8].ToString();
                                usuario.Telefono = row[9].ToString();
                                usuario.Celular = row[10].ToString();
                                usuario.CURP = row[11].ToString();

                                ML.Rol rol = new ML.Rol();
                                usuario.Rol.IdRol = int.Parse(row[12].ToString());

                                result.Objects.Add(usuario);

                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            Console.WriteLine("A ocurrido un error");
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

        public static ML.Result GetById(ML.Usuario IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioGetById";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                        collection[0].Value = IdUsuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableUsuario = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            DataRow row = tableUsuario.Rows[0];

                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.FechaDeNacimiento = row[4].ToString();
                            usuario.Sexo = row[5].ToString();
                            usuario.UserName = row[6].ToString();
                            usuario.Email = row[7].ToString();
                            usuario.Password = row[8].ToString();
                            usuario.Telefono = row[9].ToString();
                            usuario.Celular = row[10].ToString();
                            usuario.CURP = row[11].ToString();
                            usuario.Rol.IdRol = int.Parse(row[12].ToString());

                            //result.Objects.Add(objUsuario);
                            result.Object = usuario;

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

        ///Entity

        public static ML.Result Add_EF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    var Usuario = context.UsuarioAdd(usuario.Nombre, 
                                                    usuario.ApellidoPaterno, 
                                                    usuario.ApellidoMaterno,
                                                    usuario.FechaDeNacimiento, 
                                                    usuario.Sexo,
                                                    usuario.UserName,
                                                    usuario.Email,
                                                    usuario.Password,
                                                    usuario.Telefono,
                                                    usuario.Celular,
                                                    usuario.CURP,
                                                    usuario.Rol.IdRol,
                                                    usuario.Imagen.ToString(),
                                                    usuario.Direccion.Calle,
                                                    usuario.Direccion.NumeroInterior,
                                                    usuario.Direccion.NumeroExterior,
                                                    usuario.Direccion.Colonia.IdColonia);

                    if (Usuario > 0)
                    {

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo agregar al objUsuario";
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

        public static ML.Result Delete_EF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    var query = context.UsuarioDelete(IdUsuario);

                    if (query > 0)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo borrar al objUsuario";
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

        public static ML.Result Update_EF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    var query = context.UsuarioUpdate(
                        usuario.IdUsuario,
                        usuario.Nombre, 
                        usuario.ApellidoPaterno, 
                        usuario.ApellidoMaterno,
                        usuario.FechaDeNacimiento, 
                        usuario.Sexo,
                        usuario.UserName, 
                        usuario.Email,
                        usuario.Password, 
                        usuario.Telefono,
                        usuario.Celular, 
                        usuario.CURP,
                        usuario.Rol.IdRol, 
                        usuario.Imagen.ToString(),
                        
                        usuario.Direccion.Calle,
                        usuario.Direccion.NumeroInterior,
                        usuario.Direccion.NumeroExterior,
                        usuario.Direccion.Colonia.IdColonia);

                    if (query > 0)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar el objUsuario";
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

        public static ML.Result GetAll_EF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre;
                    usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno;
                    usuario.Rol.IdRol = (usuario.Rol.IdRol == null) ? 0 : usuario.Rol.IdRol;
                    var query = context.UsuarioGetAll(usuario.Nombre,usuario.ApellidoPaterno,usuario.Rol.IdRol).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Usuario objUsuario = new ML.Usuario();

                            objUsuario.IdUsuario = obj.IdUsuario;
                            objUsuario.Nombre = obj.Nombre;
                            objUsuario.ApellidoPaterno = obj.ApellidoPaterno;
                            objUsuario.ApellidoMaterno = obj.ApellidoMaterno;
                            objUsuario.FechaDeNacimiento = obj.FechaDeNacimiento.ToString("dd-MM-yyyy");
                            objUsuario.Sexo = obj.Sexo;
                            objUsuario.UserName = obj.UserName;
                            objUsuario.Email = obj.Email;
                            objUsuario.Password = obj.Password;
                            objUsuario.Telefono = obj.Telefono;
                            objUsuario.Celular = obj.Celular;
                            objUsuario.CURP = obj.CURP;

                            objUsuario.Rol = new ML.Rol();
                            objUsuario.Rol.IdRol = obj.IdRol.Value;
                            objUsuario.Rol.Nombre = obj.NombreRol;

                            objUsuario.Imagen = obj.Imagen;
                            objUsuario.Status = obj.Status.Value;


                            //Direccion
                            objUsuario.Direccion = new ML.Direccion();
                            objUsuario.Direccion.IdDireccion = obj.IdDireccion;
                            objUsuario.Direccion.Calle = obj.Calle;
                            objUsuario.Direccion.NumeroInterior = obj.NumeroInterior;
                            objUsuario.Direccion.NumeroExterior = obj.NumeroExterior;

                            //////Colonia
                            objUsuario.Direccion.Colonia = new ML.Colonia();
                            objUsuario.Direccion.Colonia.IdColonia = obj.IdColonia;
                            objUsuario.Direccion.Colonia.Nombre = obj.NombreColonia;
                            objUsuario.Direccion.Colonia.CP = obj.CodigoPostal;

                            ////Municipio

                            objUsuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            objUsuario.Direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio;
                            objUsuario.Direccion.Colonia.Municipio.Nombre = obj.NombreMunicipio;

                            ////Estado
                            objUsuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            objUsuario.Direccion.Colonia.Municipio.Estado.IdEstado = obj.IdEstado;
                            objUsuario.Direccion.Colonia.Municipio.Estado.Nombre = obj.NombreEstado;

                            ////Pais
                            objUsuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            objUsuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = obj.IdPais;
                            objUsuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.NombrePais;



                            result.Objects.Add(objUsuario);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        Console.WriteLine("Se ha producido un error");

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

        public static ML.Result GeById_EF(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    var objUsuario = context.UsuarioGetById(IdUsuario).FirstOrDefault();
                    result.Objects = new List<object>();


                    if (objUsuario != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.Nombre = objUsuario.Nombre;
                        usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuario.FechaDeNacimiento = objUsuario.FechaDeNacimiento.ToString("dd-MM-yyyy");
                        usuario.Sexo = objUsuario.Sexo;
                        usuario.UserName = objUsuario.UserName;
                        usuario.Email = objUsuario.Email;
                        usuario.Password = objUsuario.Password;
                        usuario.Telefono = objUsuario.Telefono;
                        usuario.Celular = objUsuario.Celular;
                        usuario.CURP = objUsuario.CURP;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objUsuario.IdRol.Value;
                        //objUsuario.Imagen = objUsuario.Imagen;

                        

                        //Direccion
                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = objUsuario.IdDireccion;
                        usuario.Direccion.Calle = objUsuario.Nombre;
                        usuario.Direccion.NumeroInterior = objUsuario.NumeroInterior;
                        usuario.Direccion.NumeroExterior = objUsuario.NumeroExterior;

                        //Colonia
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = objUsuario.IdColonia.Value;
                        usuario.Direccion.Colonia.Nombre = objUsuario.NombreColonia;
                        usuario.Direccion.Colonia.CP = objUsuario.CodigoPostal;

                        //Municipio

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = objUsuario.IdMunicipio.Value;
                        usuario.Direccion.Colonia.Municipio.Nombre = objUsuario.NombreMunicipio;

                        //Estado
                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objUsuario.IdEstado.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = objUsuario.NombreEstado;

                        //Pais
                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objUsuario.IdPais.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = objUsuario.NombrePais;


                        result.Object = usuario;
                        result.Correct = true;
                    }

                    else
                    {
                        result.ErrorMessage = "No se ha encontrado ningun registro con este Id";
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
        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            Result result = new Result();
            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioDL = new DL_EF.Usuario();

                    usuarioDL.Nombre = usuario.Nombre;
                    usuarioDL.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioDL.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioDL.FechaDeNacimiento = DateTime.Parse(usuario.FechaDeNacimiento);
                    usuarioDL.Sexo = usuario.Sexo;
                    usuarioDL.UserName = usuario.UserName;
                    usuarioDL.Email = usuario.Email;
                    usuarioDL.Password = usuario.Password;
                    usuarioDL.Telefono = usuario.Telefono;
                    usuarioDL.Celular = usuario.Celular;
                    usuarioDL.CURP = usuario.CURP;

                    usuarioDL.IdRol = usuario.Rol.IdRol;

                    context.Usuarios.Add(usuarioDL);
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

        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            Result result = new ML.Result();
            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    var query = (from a in context.Usuarios
                                 where a.IdUsuario == usuario.IdUsuario
                                 select a).SingleOrDefault();
                    if (query != null)
                    {
                        query.Nombre = usuario.Nombre;
                        query.ApellidoPaterno = usuario.ApellidoPaterno;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.FechaDeNacimiento = DateTime.Parse(usuario.FechaDeNacimiento);
                        query.Sexo = usuario.Sexo;
                        query.UserName = usuario.UserName;
                        query.Email = usuario.Email;
                        query.Password = usuario.Password;
                        query.Telefono = usuario.Telefono;
                        query.Celular = usuario.Celular;
                        query.CURP = usuario.CURP;
                        query.IdRol = usuario.Rol.IdRol;

                        context.SaveChanges();
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro Id para actualizar";
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

        public static ML.Result DeleteLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    var query = (from a in context.Usuarios
                                 where a.IdUsuario == usuario.IdUsuario
                                 select a).First();
                    context.Usuarios.Remove(query);
                    int RowAffected = context.SaveChanges();

                    if (RowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        Console.WriteLine("Error al borrar al objUsuario");
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
                    var query = (from obj in context.Usuarios
                                 select obj).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.FechaDeNacimiento = obj.FechaDeNacimiento.ToString();
                            usuario.Sexo = obj.Sexo;
                            usuario.UserName = obj.UserName;
                            usuario.Email = obj.Email;
                            usuario.Password = obj.Password;
                            usuario.Telefono = obj.Telefono;
                            usuario.Celular = obj.Celular;
                            usuario.CURP = obj.CURP;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = obj.IdRol.Value;

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se detectaron registros";
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

        public static ML.Result GetByIdLINQ(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    var query = (from usuario in context.Usuarios
                                 where usuario.IdUsuario == idUsuario
                                 select new
                                 {
                                     usuario.IdUsuario,
                                     usuario.Nombre,
                                     usuario.ApellidoPaterno,
                                     usuario.ApellidoMaterno,
                                     usuario.FechaDeNacimiento,
                                     usuario.Sexo,
                                     usuario.UserName,
                                     usuario.Email,
                                     usuario.Password,
                                     usuario.Telefono,
                                     usuario.Celular,
                                     usuario.CURP,
                                     usuario.IdRol
                                 }).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.FechaDeNacimiento = query.FechaDeNacimiento.ToString();
                        usuario.Sexo = query.Sexo;
                        usuario.UserName = query.UserName;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.CURP = query.CURP;

                        //objUsuario.Rol = new Rol();
                        usuario.Rol.IdRol = query.IdRol.Value;

                        result.Object = usuario;
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
    }
}




