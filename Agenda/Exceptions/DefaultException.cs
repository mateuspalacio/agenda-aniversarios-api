using Agenda.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Exceptions
{
    public class DefaultException : Exception
    {
        public ErrorResponse ErrorResponse { get; set; }
        public DefaultException()
        {

        }
        public DefaultException(ErrorResponse errorResponse)
        {
            ErrorResponse = errorResponse;
        }
        public BadRequestObjectResult CustomErrorResponse(ActionContext actionContext)
        {
            //BadRequestObjectResult is class found Microsoft.AspNetCore.Mvc and is inherited from ObjectResult.    
            //Rest code is linq.    
            return new BadRequestObjectResult(actionContext.ModelState
             .Where(modelError => modelError.Value.Errors.Count > 0)
             .Select(modelError => new Error
             {
                 Message = modelError.Value.Errors.FirstOrDefault().ErrorMessage,
                 StatusCode = 400
             }).ToList());
        }
    }
    public class ErrorResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
