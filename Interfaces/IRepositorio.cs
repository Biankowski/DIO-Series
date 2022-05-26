using System.Collections.Generic;

namespace DIO.Series
{
    public interface IRepository<T>
    {
        List<T> SeriesList();
        T ReturnById(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int NextId();
    }
}