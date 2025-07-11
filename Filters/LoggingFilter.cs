using Microsoft.AspNetCore.Mvc.Filters;

namespace ProductsService.Filters
{
  public class LoggingFilter:Attribute, IActionFilter
  {
    public void OnActionExecuting(ActionExecutingContext context)
    {
      var fileName = $"Log_{DateTime.Now.ToString("yyyyMMdd")}.txt";
      var filePath = $"C:\\Users\\1029693\\source\\repos\\ProductsService\\Log\\{fileName}"; 
      // Log the action execution start
      //var logFile = File.Create(filePath);
      var fileContents = $"{DateTime.Now}: Action {context.ActionDescriptor.DisplayName} has started execution...!!!!";

      File.AppendAllLines(filePath, new List<string> { fileContents });
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
      var fileName = $"Log_{DateTime.Now.ToString("yyyyMMdd")}.txt";
      var filePath = $"C:\\Users\\1029693\\source\\repos\\ProductsService\\Log\\{fileName}";
      var fileContents = $"{DateTime.Now}: Action {context.ActionDescriptor.DisplayName} has finished execution...!!!!";
      File.AppendAllLines(filePath, new List<string>{ fileContents });
    }
  }
}
