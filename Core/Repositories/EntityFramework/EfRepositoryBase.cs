using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Repositories.EntityFramework
{
    public class EfRepositoryBase<T, TContext> : IAsyncRepository<T>
    where T : class
    where TContext : DbContext
    {
        protected readonly TContext _context;
        public EfRepositoryBase(TContext context)
        {
            _context = context;
        }   


        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate != null)
            {
                return await _context.Set<T>().Where(predicate).ToListAsync();
            }
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T?>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

//T                     Generic tür parametresi. Örneğin: Product, Category gibi Entity sınıfları.

//TContext	            DbContext'ten türetilmiş olan kendi veritabanı context sınıfın. Örneğin: AppDbContext.

//IAsyncRepository<T>	Sınıfın uyguladığı arayüz (interface). CRUD metodları bu arayüzde tanımlanır.

//where T :             class T sadece referans tür (class) olabilir.Primitive türler(int, bool vs.) olamaz.

//where TContext :      DbContext TContext, EF Core'dan gelen DbContext sınıfını genişletmelidir.


// ----------------------------------------------------------------------------------------------


//DbContext                 Veritabanı erişimi sağlar	Microsoft.EntityFrameworkCore

//Set<T>()	                Tablolara erişmek için kullanılır	EF Core

//Expression<Func<T,bool>>	Dinamik filtreleme	System.Linq.Expressions

//IAsyncRepository<T>	    CRUD metodlarının arayüzü	Senin oluşturduğun interface

//Task<T>                   Asenkron yapı	System.Threading.Tasks