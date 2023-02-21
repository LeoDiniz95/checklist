using checklist_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace checklist_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckListController : ControllerBase
    {
        [HttpPost]
        public JsonResult GetAll([FromServices] CheckList checkList)
        {
            return new JsonResult(checkList.GetAll());
        }

        [HttpPost]
        public JsonResult Add([FromBody] string name, [FromServices] CheckList checkList)
        {
            return new JsonResult(checkList.Add(name));
        }

        [HttpPost]
        public JsonResult CheckItem([FromBody] int id, [FromServices] CheckList checkList)
        {
            return new JsonResult(checkList.CheckItem(id));
        }

        [HttpPost]
        public JsonResult ChangeStatus([FromBody] int id, [FromServices] CheckList checkList)
        {
            return new JsonResult(checkList.ChangeStatus(id));
        }
    }
}
