using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class ActivityController : Controller
    {
        [HttpPost]
        [Route("api/Activity/Add")]

        public ActionResult Add([FromBody]ML.Activity Activity)
        {
            ML.Result result = BL.Activity.Add(Activity);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }


        [HttpGet]
        [Route("api/Activity/GetAll")]
        public ActionResult GetAll()
        {
            ML.Activity activity = new ML.Activity();
            ML.Result result = BL.Activity.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpGet]
        [Route("api/Activity/GetById/{IdActivity}")]

        public ActionResult Get(int IdActivity)
        {
            ML.Result result = BL.Activity.GetById(IdActivity);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
    }
}
