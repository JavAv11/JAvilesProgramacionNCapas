using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Departamento
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    var query = context.DepartamentoGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Departamento departamento = new ML.Departamento();

                            departamento.IdDepartamento = obj.IdDepartamento;
                            departamento.Nombre = obj.Nombre;

                            result.Objects.Add(departamento);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        Console.WriteLine("Se ha producido un error");
                        Console.ReadKey();
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

        public static ML.Result GetById(int IdDepartamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    var departamentos = context.DepartamentoGetById(IdDepartamento).FirstOrDefault();
                    result.Objects = new List<object>();
                    if (departamentos != null)
                    {

                        ML.Departamento departamento = new ML.Departamento();
                        departamento.IdDepartamento = departamentos.IdDepartamento;
                        departamento.Nombre = departamentos.Nombre;

                        departamento.Area = new ML.Area();
                        departamento.Area.IdArea = departamentos.IdArea.Value;
                        departamento.Area.Nombre = departamentos.NombreArea;


                        result.Objects.Add(departamento);

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

        public static ML.Result Add(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    var query = context.DepartamentoAdd( departamento.Nombre, departamento.Area.IdArea);
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

        public static ML.Result Update(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                    var query = context.DepartamentoUpdate(departamento.IdDepartamento, departamento.Nombre,departamento.Area.IdArea);
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

        public static ML.Result Delete(int IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JAvilesProgramacionNCapasEntities context = new DL_EF.JAvilesProgramacionNCapasEntities())
                {
                   var query = context.DepartamentoDelete(IdDepartamento);
                    if (query >= 1)
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo Borrar el departaamento";
                    }
                    else
                    {

                        result.Correct = true;
                    }
                    //result.Correct = true;
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
