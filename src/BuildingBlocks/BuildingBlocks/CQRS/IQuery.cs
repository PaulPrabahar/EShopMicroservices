using MediatR;

namespace BuildingBlocks.CQRS;

public interface IQuery<TResponce>:IRequest<TResponce>
    where TResponce : notnull
{

}
