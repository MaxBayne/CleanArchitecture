using CleanArchitecture.Common.Errors.Abstract;

namespace CleanArchitecture.Common.Errors.Domain;

public static class GameErrors
{
    public static readonly Error NotFound = new Error("Game.NotFound", "Game Id Not Found");
    public static readonly Error EmptyName = new Error("Game.EmptyName", "Cant Use Empty Name For Game");
    public static readonly Error EmptyGenre = new Error("Game.EmptyGenre", "Cant Use Empty Genre For Game");
    public static readonly Error ZeroPrice = new Error("Game.ZeroPrice", "Cant Use Zero Price For Game");
    public static readonly Error ZeroYear = new Error("Game.ZeroYear", "Cant Use Zero Year For Game");
}