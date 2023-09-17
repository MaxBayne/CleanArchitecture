using CleanArchitecture.Application.HandleExceptions.Abstract;
using FluentValidation.Results;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CleanArchitecture.Application.HandleExceptions.Exceptions
{
    public class ValidationException : BaseException
    {
        public List<ValidationFailure> Failures { get; private set; } = new List<ValidationFailure>();
        public List<string> Errors { get; private set; } = new List<string>();

        public ValidationException(string errorMessage)
        {
            Errors.Add(errorMessage);
        }

        public ValidationException(ValidationResult validationResult)
        {
            Failures= validationResult.Errors;

            validationResult.Errors.ForEach((error) => {Errors.Add(error.ErrorMessage);});
        }
    }
}
