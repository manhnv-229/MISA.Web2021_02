using System;
using System.Collections.Generic;
using System.Text;

namespace FresherProject.DataLayer.Interfaces
{
    public interface IDBConnector<T>
    {
        IEnumerable<T> GetAllData();
        IEnumerable<T> GetAllData(string commandText);
        IEnumerable<T> GetById(Guid id);
        int Insert(T entity);
        int Delete(Guid id);
        int Update(T entity);
    }
}
