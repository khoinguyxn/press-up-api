namespace PressUpAspireApp.Domain.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
}