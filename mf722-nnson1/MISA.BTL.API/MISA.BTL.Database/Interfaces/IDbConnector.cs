using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.BTL.Database.Interfaces
{
    public interface IDbConnector<T>
    {
        IEnumerable<T> GetData();
        IEnumerable<T> GetData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text);
        int Insert(T entity);
        int Update(T entity);
        int Delete(string id);

        bool CheckCustomerGroupIdExist(string id);

        bool CheckCustomerGroupNameExist(string name);

        bool CheckEmptyCustomerGroupName(string customerGroupName);
        bool CheckCustomerIdExist(string id);
        bool CheckCustomerCodeExist(string code);
        bool CheckPhoneNumberExist(string phoneNumber);
        bool CheckEmptyFullName(string fullName);
        bool CheckEmptyPhoneNumber(string phoneNumber);
        bool CheckEmptyEmail(string email);
        bool CheckEmptyCustomerCode(string code);
    }
}
