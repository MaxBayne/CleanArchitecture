using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Domain.Abstract;

namespace CleanArchitecture.Domain.Entities
{
    public class Book:Entity<int>
    {
        #region Properites

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public bool IsActive { get; private set; }

        #endregion

        #region Constructors

        public Book()
        {
            Title = string.Empty;
            Description = string.Empty;
            Category = string.Empty;
            IsActive = true;
        }
        public Book(string title, string description, string category, bool isActive)
        {
            Title = title;
            Description = description;
            Category = category;
            IsActive = isActive;
        }
        public Book(int id, string title, string description, string category, bool isActive) : base(id)
        {
            Title = title;
            Description = description;
            Category = category;
            IsActive = isActive;
        }


        #endregion

        #region Methods

        public Result ChangeTitle(string title)
        {
            //validate
            if (string.IsNullOrEmpty(title))
            {
                return Result.Failure(BookErrors.EmptyTitle);
            }

            Title = title;

            return Result.Success();
        }

        public Result ChangeDescription(string description)
        {
            //validate

            if (string.IsNullOrEmpty(description))
            {
                return Result.Failure(BookErrors.EmptyDescription);
            }

            Description = description;

            return Result.Success();
        }

        public Result ChangeCategory(string category)
        {
            //validate

            if (string.IsNullOrEmpty(category))
            {
                return Result.Failure(BookErrors.EmptyCategory);
            }

            Category = category;

            return Result.Success();
        }

        public void EnableBook()
        {
            IsActive = true;
        }
        public void DisableBook()
        {
            IsActive = false;
        }

        #endregion

    }
}
