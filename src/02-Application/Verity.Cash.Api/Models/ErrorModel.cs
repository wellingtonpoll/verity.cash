using FluentValidation.Results;

namespace Verity.Cash.Api.Models
{
    public class ErrorModel
    {
        public ErrorModel(int statusCode, List<ValidationFailure> errors)
        {
            StatusCode = statusCode;
            Messages = errors.Select(c => c.ErrorMessage).ToArray(); 
        }

        public int StatusCode { get; set; }
        public string[] Messages { get; set; }
    }
}