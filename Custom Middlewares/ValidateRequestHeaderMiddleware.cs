namespace ProductsService.Custom_Middlewares
{
  public class ValidateRequestHeaderMiddleware
  {
    private readonly RequestDelegate _next;

    public ValidateRequestHeaderMiddleware(RequestDelegate requestDelegate)
    {
      _next = requestDelegate;
    }

    public async Task Invoke(HttpContext context)
    {
      if (!context.Request.Headers.ContainsKey("X-Correlation-ID"))
      {
        Guid id = Guid.NewGuid();
        context.Items.Add("X-Correlation-ID", id);
        context.Response.Headers.Add("X-Correlation-ID", context.Items["X-Correlation-ID"]?.ToString());
      }

      await _next(context); // Call the next middleware in the pipeline (if any
    }
  }
}
