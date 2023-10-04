using CleanArchitecture.Application.HandleExceptions.Abstract;
using FluentValidation.Results;

namespace CleanArchitecture.Application.HandleExceptions.Exceptions
{
    public class ValidationException : BaseException
    {
        public List<ValidationFailure> Failures { get; private set; } = new List<ValidationFailure>();
        public List<string> ErrorsList { get; private set; } = new List<string>();
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException(string errorMessage)
        {
            ErrorsList.Add(errorMessage);
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(ValidationResult validationResult)
        {
            Failures= validationResult.Errors;

            validationResult.Errors.ForEach((error) => {ErrorsList.Add(error.ErrorMessage);});

            Errors = Failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

       
    }
}
