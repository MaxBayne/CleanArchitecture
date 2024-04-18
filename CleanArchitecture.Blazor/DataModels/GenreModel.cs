using CleanArchitecture.Blazor.DataModels.Abstract;

namespace CleanArchitecture.Blazor.DataModels
{
    public class GenreModel:BaseDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
