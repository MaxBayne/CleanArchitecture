using CleanArchitecture.Domain.Abstract;

namespace CleanArchitecture.Domain.Entities
{
    public class Book:BaseEntity<int>
    {
        public string Title { get;private set; }
        public string Description { get;private set; }
        public string Category { get;private set; }
        public bool IsActive { get;private set; }

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
        public Book(int id,string title, string description, string category, bool isActive)
        {
            Id = id;
            Title = title;
            Description = description;
            Category = category;
            IsActive = isActive;
        }


        public void ChangeTitle(string title)
        {
            Title=title;
        }

        public void ChangeDescription(string description)
        {
            Description=description;
        }

        public void ChangeCategory(string category)
        {
            Category=category;
        }

        public void EnableBook()
        {
            IsActive=true;
        }
        public void DisableBook()
        {
            IsActive = false;
        }
    }
}
