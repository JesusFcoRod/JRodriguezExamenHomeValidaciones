using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ActivityController : Controller
    {
        //Inyeccion de dependencias-- patron de diseño
        private readonly IConfiguration _configuration;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public ActivityController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = new ML.Result();
            ML.Activity activity = new ML.Activity();

            result.Objects = new List<object>();

            try
            {
                using (var Client = new HttpClient())
                {
                    string urlApi = _configuration["urlApi"];
                    Client.BaseAddress = new Uri(urlApi);

                    var responseTask = Client.GetAsync("Activity/GetAll");
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Activity resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Activity>(resultItem.ToString());
                            result.Objects.Add(resultItemList);
                        }
                    }
                    activity.Activitys = result.Objects;
                }

            }
            catch (Exception ex)
            {

            }
            return View(activity);
        }

        [HttpGet]
        public ActionResult Form(int? IdActivity)
        {
            ML.Result resultPropetys = BL.Propety.GetAll();
            ML.Activity Activity = new ML.Activity();

            Activity.Property = new ML.Property();

            if (resultPropetys.Correct)
            {
                Activity.Property.Propertys = resultPropetys.Objects;
            }

            if (IdActivity != null)
            {
                Activity.IdActivity = IdActivity.Value;
                ML.Result result = new ML.Result();

                try
                {
                    using (var client = new HttpClient())
                    {
                        string urlApi = _configuration["urlApi"];
                        client.BaseAddress = new Uri(urlApi);

                        var responseTask = client.GetAsync("Activity/GetById/" + IdActivity);
                        responseTask.Wait(); 

                        var resultServicio = responseTask.Result;

                        if (resultServicio.IsSuccessStatusCode)
                        {
                            var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();

                            string usuarioCast = readTask.Result.Object.ToString();

                            ML.Activity resultItem = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Activity>(usuarioCast);
                            result.Object = resultItem;
                            result.Correct = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;
                }
                if (result.Correct)
                {
                    Activity = (ML.Activity)result.Object;//unboxing
                    Activity.Property.Propertys = resultPropetys.Objects;

                    return View(Activity);
                }
                else
                {
                    ViewBag.Message = "Ocurrio algo al consultar la informacion de la actividad" + resultPropetys.ErrorMessage;
                    return View("Modal");
                }

            }
            else
            {
                return View(Activity);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Activity Activity)
        {

            using (var client = new HttpClient())
            {
                if (Activity.IdActivity == 0)
                {

                    ML.Result resultPE = BL.Propety.GetById(Activity.Property.IdProperty);//Obtener propiedad
                    ML.Property propetyEstado = (ML.Property)resultPE.Object;//unboxing


                            client.BaseAddress = new Uri(_configuration["urlApi"]);

                            //HTTP POST
                            var postTask = client.PostAsJsonAsync<ML.Activity>("Activity/Add", Activity);
                            postTask.Wait();

                            var result = postTask.Result;
                            if (result.IsSuccessStatusCode)
                            {
                                ViewBag.Message = "Se ha registrado la actividad";
                                return PartialView("Modal");
                            }
                            else
                            {
                                ViewBag.Message = "No se ha registrado la actividad";
                                return PartialView("Modal");
                            }


                }
                else
                {
                    client.BaseAddress = new Uri(_configuration["urlApi"]);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Activity>("Activity/Update/", Activity);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Se ha actualizado la actividad";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Mensaje = "No se ha actualizado la actividad";
                        return PartialView("Modal");
                    }

                }

            }
        }
    }
}

