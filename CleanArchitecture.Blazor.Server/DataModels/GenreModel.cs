using CleanArchitecture.Blazor.Server.DataModels.Abstract;

namespace CleanArchitecture.Blazor.Server.DataModels;

public class GenreModel:BaseDataModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}
