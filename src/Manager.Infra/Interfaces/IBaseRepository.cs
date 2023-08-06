using Manager.Domain.Entities;
namespace Manager.Infra.Interfaces;

public interface IBaseRepository<T> where T : Base
{
    Task<List<T>> Get();
    Task<T> Get(long id);
    Task<T> Create(T obj);
    Task<T> Update(T obj);
    Task Remove(long id);
}