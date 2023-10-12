using AutoMapper;
using MediatR;

namespace CleanArchitecture.Application.Mediators.Abstract;

/// <summary>
/// Extended IRequestHandler For Mediator to support AutoMapper
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public abstract class RequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{

    #region Properties

    protected IMapper AutoMapper { get; set; }

    #endregion

    #region Constructors

    protected RequestHandler(IMapper autoMapper)
    {
        AutoMapper = autoMapper;
    }


    #endregion

    #region Methods

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

    #endregion
}



/// <summary>
/// Extended IRequestHandler For Mediator to support Repository and AutoMapper
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
/// <typeparam name="TRepository"></typeparam>
public abstract class RequestHandler<TRequest, TResponse,TRepository> : IRequestHandler<TRequest,TResponse> where TRequest : IRequest<TResponse>
{

    #region Properties

    protected TRepository Repository { get; set; }
    protected IMapper AutoMapper { get; set; }

    #endregion

    #region Constructors

    protected RequestHandler(TRepository repository, IMapper autoMapper)
    {
        Repository = repository;
        AutoMapper = autoMapper;
    }


    #endregion

    #region Methods

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

    #endregion
}

