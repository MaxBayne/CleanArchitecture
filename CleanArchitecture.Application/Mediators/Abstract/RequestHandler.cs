using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using MediatR;

namespace CleanArchitecture.Application.Mediators.Abstract;

/// <summary>
/// Extended IRequestHandler For Mediator to support AutoMapper (Object Mapping) and DbContext as UnitOfWork
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public abstract class RequestHandler<TRequest, TResponse> : IRequestHandler<TRequest,TResponse> where TRequest : IRequest<TResponse>
{

    #region Properties

    /// <summary>
    /// DbContext as Unit Of Work
    /// </summary>
    protected IUnitOfWork UnitOfWork { get; set; }

    /// <summary>
    /// Auto Mapper For Object Mapping like dto to other class
    /// </summary>
    protected IMapper AutoMapper { get; set; }

    /// <summary>
    /// Publisher For Notification to Handle by its handlers
    /// </summary>
    protected INotificationPublisher NotificationPublisher { get; set; }

    #endregion

    #region Constructors

    protected RequestHandler(IMapper autoMapper)
    {
        UnitOfWork = null!;
        AutoMapper = autoMapper;
        NotificationPublisher = null!;

    }
    protected RequestHandler(IMapper autoMapper, INotificationPublisher notificationPublisher)
    {
        UnitOfWork = null!;
        AutoMapper = autoMapper;
        NotificationPublisher = notificationPublisher;
    }

    protected RequestHandler(IUnitOfWork unitOfWork, IMapper autoMapper)
    {
        UnitOfWork = unitOfWork;
        AutoMapper = autoMapper;
        NotificationPublisher = null!;
     
    }

    protected RequestHandler(IUnitOfWork unitOfWork,IMapper autoMapper, INotificationPublisher notificationPublisher)
    {
        UnitOfWork = unitOfWork;
        AutoMapper = autoMapper;
        NotificationPublisher = notificationPublisher;
    }


    #endregion

    #region Methods

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

    #endregion
}

