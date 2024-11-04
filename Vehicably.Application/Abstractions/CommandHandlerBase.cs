﻿using MediatR;
using Vehicably.Domain.Repositories;

namespace Vehicably.Application.Abstractions;

public abstract class CommandHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public CommandHandlerBase(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public IUnitOfWork UnitOfWork { get; set; }

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}