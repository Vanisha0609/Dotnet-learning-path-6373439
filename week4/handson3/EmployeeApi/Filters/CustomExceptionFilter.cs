using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace EmployeeApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var errorMessage = context.Exception.ToString();
            File.AppendAllText("error_log.txt", errorMessage + Environment.NewLine);

            context.Result = new ObjectResult("Internal Server Error - Logged")
            {
                StatusCode = 500
            };
        }
    }
}
