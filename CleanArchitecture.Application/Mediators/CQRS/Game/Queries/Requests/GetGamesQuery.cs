﻿using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.Mediators.CQRS.Game.Queries.Responses;

namespace CleanArchitecture.Application.Mediators.CQRS.Game.Queries.Requests
{
    public record GetGamesQuery : IQuery<GetGamesResponse>;
}
