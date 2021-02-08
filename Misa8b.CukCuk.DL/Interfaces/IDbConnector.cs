using System;
using System.Collections.Generic;
using System.Text;

namespace Misa8b.CukCuk.DL.Interfaces
{
    public interface IDbConnector<T>
    {
        public List<T> GetAllData<T>();
        public List<T> GetAllDataWithPagging<T>(int limit, int ofset);
        public T GetDataById<T>(Guid id);
        public void Insert<T>(T t);
        public void Update<T>(T t);
        public int DeleteData<T>(Guid id);
    }
}
