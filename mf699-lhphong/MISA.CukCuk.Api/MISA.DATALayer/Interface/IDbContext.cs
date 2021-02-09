using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DATALayer.Interface
{
    public interface IDbContext<MisaEntity>
    {
        public IEnumerable<MisaEntity> GetAll();
        public IEnumerable<MisaEntity> GetAll(string sqlCommand, CommandType commandType = CommandType.Text);
        public IEnumerable<MisaEntity> GetData(string sqlCommand, object parameters = null, CommandType commandType = CommandType.Text);
        public int InsertObject(MisaEntity entity);
    }
}
