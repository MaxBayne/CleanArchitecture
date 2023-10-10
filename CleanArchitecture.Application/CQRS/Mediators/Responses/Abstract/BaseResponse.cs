using System.Diagnostics;
using System.Text.Json.Serialization;
using CleanArchitecture.Application.Exceptions.Abstract;
using FluentValidation.Results;

namespace CleanArchitecture.Application.CQRS.Mediators.Responses.Abstract
{
    public abstract class BaseResponse
    {
        /// <summary>
        /// if response is success or fail
        /// </summary>
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        /// log message used for log operations
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// List of Errors if operation failure
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();

        #region Helpers

        /// <summary>
        /// Watcher used to calc process time just start stopWatch before process and stop watcher after finish it
        /// </summary>
        [JsonIgnore]
        public Stopwatch StopWatch { get; private set; } = new Stopwatch();

        [JsonIgnore]
        public BaseException? Exception { get; set; }


        [JsonIgnore]
        private ValidationResult _validationResult = new ValidationResult();

        [JsonIgnore]
        public ValidationResult ValidationResult
        {
            get => _validationResult;
            set
            {
                _validationResult = value;

                IsSuccess = _validationResult.IsValid;

                _validationResult.Errors.ForEach((error) => Errors.Add(error.ErrorMessage));
            }
        }

        #endregion

    }
}
