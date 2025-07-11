using Microsoft.AspNetCore.Mvc.Filters;

namespace ProductsService.Filters
{
  public class ExceptionFilter: Attribute, IExceptionFilter
  {
    public void OnException(ExceptionContext context)
    {
      string userMessage = context.Exception.Message;
      var exceptionType = context.GetType();

      if (exceptionType == typeof(KeyNotFoundException))
      {
        userMessage = "Product with given id not found. Please provide valid id.";
      }

      var errorContainer = new ErrorContainer()
      {
        UserMessage = userMessage,
        DevMessage = context.Exception.StackTrace
      };
      context.Result = new Microsoft.AspNetCore.Mvc.ObjectResult(errorContainer)
      {
        StatusCode = 404
      };
      context.ExceptionHandled = true;
      string fileName = $"Log_{DateTime.Now:yyyyMMdd}.txt";
      string filePath = $"C:\\Users\\1029693\\source\\repos\\ProductsService\\Log\\{fileName}";

      // Log the exception details
      var stackTrace = context.Exception.StackTrace;
      var fileContents = $@"{DateTime.Now}: Exception occurred in action {context.ActionDescriptor.DisplayName} - {errorContainer.DevMessage} \n Stack trace: {stackTrace}";
      File.AppendAllLines(filePath, new List<string>{fileContents});
    }
  }
}
