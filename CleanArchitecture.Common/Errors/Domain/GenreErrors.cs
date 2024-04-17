using CleanArchitecture.Common.Errors.Abstract;

namespace CleanArchitecture.Common.Errors.Domain;

public static class GenreErrors
{
    public static readonly Error NotFound = new Error("Genre.NotFound", "Genre Id Not Found");
    public static readonly Error EmptyName = new Error("Genre.EmptyName", "Cant Use Empty Name For Genre");
}