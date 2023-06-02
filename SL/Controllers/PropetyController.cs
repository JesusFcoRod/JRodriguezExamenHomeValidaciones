using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class PropetyController : Controller
    {
        [HttpGet]
        [Route("api/Property/GetById/{IdPropety}")]

        public ActionResult GetbyId(int IdPropety)
        {
            ML.Result result = BL.Propety.GetById(IdPropety);

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
        [Route("api/Property/GetAll")]

        public ActionResult GetAll()
        {
            ML.Result result = BL.Propety.GetAll();

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
