using MediatR;
using Vehicably.Infrastructure.Services.Interfaces;

namespace Vehicably.Application.Behaviors;

public class UnitOfWorkDecorator<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkDecorator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        return await _unitOfWork.ExecuteAsync(async () => await next());
    }
}
