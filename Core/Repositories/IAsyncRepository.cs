using System.Diagnostics.Metrics;
using System.Linq.Expressions;

namespace Repositories.Interfaces
{
    public interface IAsyncRepository<T>
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}

//GetAsync	    Şartı sağlayan tek kayıt
//GetAllAsync	Şartlı veya şartsız tüm kayıtlar
//AddAsync	    Yeni kayıt ekleme
//UpdateAsync	Kayıt güncelleme
//DeleteAsync	Kayıt silme
//AnyAsync	    Kayıt var mı kontrolü (boolean)