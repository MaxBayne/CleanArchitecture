﻿using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.Mediators.CQRS.Game.Commands.Responses;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Game;

namespace CleanArchitecture.Application.Mediators.CQRS.Game.Commands.Requests
{
    public record CreateGameCommand(CreateGameDto CreateGameDto) : ICommand<CreateGameResponse>;
}
