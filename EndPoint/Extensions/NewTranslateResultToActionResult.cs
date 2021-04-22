//using EndPoint.Result;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;

//namespace EndPoint.Controllers
//{
//    public class NewTranslateResultToActionResult : ActionFilterAttribute
//    {
//        public override void OnActionExecuted(ActionExecutedContext context)
//        {
//            if (!((context.Result as ObjectResult)?.Value is IResult result)) return;

//            if (!(context.Controller is ControllerBase controller)) return;

//            if (result.Status == ResultStatus.NotFound)
//                context.Result = controller.NotFound();

//            if (result.Status == ResultStatus.Invalid)
//            {
//                foreach (var error in result.ValidationErrors)
//                {
//                    // TODO: Fix after updating to 3.0.0
//                    (context.Controller as ControllerBase)?.ModelState.AddModelError(error.Identifier, error.ErrorMessage);
//                }
//                context.Result = controller.BadRequest(controller.ModelState);
//            }

//            if (result.Status == ResultStatus.Ok)
//            {
//                //var resultObj = new { Data = result.GetValue(), Message = result.Suc}
//                context.Result = new OkObjectResult(result.GetValue());
//            }
//        }
//    }
//}
