using Microsoft.AspNetCore.Mvc;

namespace dotnet_app.Shared
{
    public class CustomError

    {
        public static BadRequestObjectResult CustomErrorResponse(ActionContext actionContext)
        {
            var errorRecordList = actionContext.ModelState
              .Where(modelError => modelError.Value.Errors.Count > 0)
              .Select(modelError => new
              {
                  ErrorField = modelError.Key,
                  ErrorDescription = modelError.Value.Errors.FirstOrDefault().ErrorMessage
              }).ToList();

            string concatenatedMessage = string.Empty;
            foreach (var error in errorRecordList)
            {
                concatenatedMessage += error.ErrorField.Replace("_", " ") + ": " + error.ErrorDescription + ",";
            }
            concatenatedMessage = concatenatedMessage;
            return new BadRequestObjectResult(new
            {
                success = "failed",
                message = concatenatedMessage
            });
        }
    }
}