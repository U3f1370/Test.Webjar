using MediatR;

namespace BusinessLayout.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}