namespace BookingSystem.Api.Controllers
{
    using BookingSystem.Common.Utils;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;

    public class ExtendedApiController : ControllerBase
    {

        protected static HttpStatusCode GetStatusCode(ResultType resultType)
        {
            HttpStatusCode statusCode;

            switch (resultType)
            {
                case ResultType.NotFound:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case ResultType.Forbidden:
                    statusCode = HttpStatusCode.Forbidden;
                    break;
                case ResultType.Conflicted:
                    statusCode = HttpStatusCode.Conflict;
                    break;
                case ResultType.Validation:
                    statusCode = HttpStatusCode.NotAcceptable;
                    break;
                case ResultType.PartiallyOk:
                    statusCode = HttpStatusCode.MultiStatus;
                    break;
                case ResultType.Unauthorized:
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            return statusCode;
        }

        protected IActionResult OkOrError<T>(Result<T> result)
        {
            IActionResult errorResponse = GetErrorResponse(result);

            if (errorResponse != null)
            {
                return errorResponse;
            }

            return Ok(result.Value);
        }

        protected IActionResult OkOrError(ResultCommonLogic result)
        {
            IActionResult errorResponse = GetErrorResponse(result);

            if (errorResponse != null)
            {
                return errorResponse;
            }

            return Ok();
        }

        private IActionResult GetErrorResponse(ResultCommonLogic result)
        {
            if (result.IsFailure)
            {
                HttpStatusCode statusCode = GetStatusCode(result.ResultType);

                var errorResponse = new ObjectResult(result.Message)
                {
                    StatusCode = (int)statusCode
                };

                return errorResponse;
            }

            return null;
        }
    }
}
