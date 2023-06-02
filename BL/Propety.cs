using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Propety
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JrodriguezExamenPracticoTrueHomeContext contex = new DL.JrodriguezExamenPracticoTrueHomeContext())
                {
                    var query = contex.Properties.FromSqlRaw("[PropetyGetAll]").ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Property property = new ML.Property();
                            property.IdProperty = item.IdProperty;
                            property.Tittle = item.Tittle;
                            property.Address = item.Address;
                            property.Descripcion = item.Descripcion;
                            property.Created_at = item.CreatedAt.ToString();
                            property.Update_at = item.UpdatedAt.ToString();
                            property.Disable_at = item.DisabledAt.ToString();
                            property.Status = item.Status;

                            result.Objects.Add(property);
                            result.Correct = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdPropety)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JrodriguezExamenPracticoTrueHomeContext contex = new DL.JrodriguezExamenPracticoTrueHomeContext())
                {
                    var query = contex.Properties.FromSqlRaw($"[PropetyGetByID] {IdPropety}").AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                        ML.Property property = new ML.Property();

                        property.IdProperty = query.IdProperty;
                        property.Tittle = query.Tittle;
                        property.Address = query.Address;
                        property.Descripcion = query.Descripcion;
                        property.Created_at = query.CreatedAt.ToString();
                        property.Update_at = query.UpdatedAt.ToString();
                        property.Disable_at = query.DisabledAt.ToString();
                        property.Status = query.Status;

                        result.Object = property;
                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
    }
}
