using CleanArchitecture.BlazorApp.DataModels.Abstract;

namespace CleanArchitecture.BlazorApp.DataModels;

public class GenreModel:BaseDataModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}
