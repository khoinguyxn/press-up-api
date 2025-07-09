using FluentResults;

namespace PressUpAspireApp.Domain.Services;

public interface IBaseService<T> where T: class
{
    Task<Result<IEnumerable<T>>> GetAllAsync(CancellationToken cancellationToken);
}