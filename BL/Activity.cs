using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace BL
{
    public class Activity
    {
        public static ML.Result Add(ML.Activity Activity)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JrodriguezExamenPracticoTrueHomeContext context = new DL.JrodriguezExamenPracticoTrueHomeContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"[ActivityAdd] '{Activity.Tittle}','{Activity.Created_at}','{Activity.Update_at}','{Activity.Status}',{Activity.Property.IdProperty},'{Activity.Schedule_Inicial}','{Activity.Schedule_Final}'");
                    if (query != null)
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
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JrodriguezExamenPracticoTrueHomeContext contex = new DL.JrodriguezExamenPracticoTrueHomeContext())
                {
                    var query = contex.Activities.FromSqlRaw("[ActivityGetAll]").ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Activity Activity = new ML.Activity();

                            Activity.IdActivity = item.IdActivity;
                            Activity.Tittle = item.Tittle;
                            Activity.Created_at = item.CreatedAt.ToString();
                            Activity.Update_at = item.UpdatedAt.ToString();
                            Activity.Condicion = item.ActivityStatus.ToString();
                            Activity.Status = item.Status.ToString();

                            Activity.Property = new ML.Property();
                            Activity.Property.IdProperty = item.IdProperty.Value;
                            Activity.Property.Tittle = item.PropetyTittle.ToString();

                            Activity.Cronograma = "Inicia: " + item.ScheduleInicial + " " +
                                                  "Finaliza: " + item.ScheduleFinal;


                            result.Objects.Add(Activity);

                            result.Correct = true;

                        }
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

        public static ML.Result GetById(int IdActivity)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JrodriguezExamenPracticoTrueHomeContext contex = new DL.JrodriguezExamenPracticoTrueHomeContext())
                {
                    var query = contex.Activities.FromSqlRaw($"[ActivityGetById] {IdActivity}").AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                        ML.Activity activity = new ML.Activity();
                        activity.IdActivity = query.IdActivity;
                        activity.Property = new ML.Property();
                        activity.Property.IdProperty = query.IdProperty.Value;
                        activity.Created_at = query.CreatedAt.ToString();
                        activity.Update_at = query.UpdatedAt.ToString();
                        activity.Tittle = query.Tittle;
                        activity.Status = query.Status;

                        result.Object = activity;
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