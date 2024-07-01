using CleanArchitecture.Blazor.Wasm.DataModels.Abstract;

namespace CleanArchitecture.Blazor.Wasm.DataModels;

public class GenreModel:BaseDataModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}
