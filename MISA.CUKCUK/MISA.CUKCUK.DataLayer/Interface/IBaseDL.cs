using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.Interface
{
    public interface IBaseDL<T> where T: class
    {
        IEnumerable<T> GetAll();

        T GetById(Guid id);

        int Insert(T entity);

        int Update(T entity);

        int Delete(Guid id);
    }
}
