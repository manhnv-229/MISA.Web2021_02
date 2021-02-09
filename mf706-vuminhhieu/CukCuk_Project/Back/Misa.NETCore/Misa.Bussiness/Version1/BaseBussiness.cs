using Misa.Bussiness.Interfaces;
using Misa.Common;
using Misa.Common.Entities;
using Misa.Common.Enum;
using Misa.Common.Requests;
using Misa.Common.Results;
using Misa.Data.Interfaces;
using Misa.Data.Version2;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.Bussiness.Version1
{
    public class BaseBussiness<T> : IBaseBussiness<T>
    {
        private IBaseData<T> _baseData;
        //private DbConnection<T> dbConnection;
       
        public BaseBussiness(IBaseData<T> baseData)
        {
            //dbConnection = new DbConnection<T>();
            _baseData = baseData;
            
        }

        /// <summary>
        /// Lấy ra toàn bộ danh sách
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// create: 6/2/2021
        public async Task<ServiceResult> GetData()
        {            
            var listEntity = await _baseData.GetData();
            return new ServiceResult()
            {
                Data = listEntity,
                Error = null,
                MISACukCukCode = MISACukCukServiceCode.Success

            };
        }

        /// <summary>
        /// Lấy danh sách đối tượng theo trang và số bản ghi
        /// </summary>
        /// <param name="pageRequestBase">trang và bản ghi</param>
        /// <returns>ServiceResult</returns>
        /// create 6/2/2021
        public async Task<ServiceResult> GetData(PageRequestBase pageRequestBase)
        {

            var listEntiry = await _baseData.GetData(pageRequestBase);
            var ListPage = new PageResult<T>()
            {
                Items = listEntiry,
                TotalRecord = listEntiry.Count()
            };
            return new ServiceResult()
            {
                Data = ListPage,
                Error = null,
                MISACukCukCode = MISACukCukServiceCode.Success

            };
        }

        /// <summary>
        /// Thêm mới đối tượng
        /// </summary>
        /// <param name="entity">kiểu thực thể</param>
        /// <returns>ServiceResult</returns>
        /// create: 7/2/2021
        public virtual async Task<ServiceResult> Insert(T entity)
        {
            var row =await _baseData.Insert(entity);
            ServiceResult serviceResult = new ServiceResult();
            if (row == 1)
            {
                serviceResult.MISACukCukCode = MISACukCukServiceCode.Success;
            }
            else
            {
                serviceResult.MISACukCukCode = MISACukCukServiceCode.Exception;
                serviceResult.Error.Add(new ErrorResult()
                {
                    DevMsg = Properties.Resources.ErrorServive_Employee_Insert,
                    UserMsg = Properties.Resources.ErrorServive_Employee_Insert

                });
            }
            return serviceResult;
        }

        /// <summary>
        /// Cập nhật thông tin đối tượng
        /// </summary>
        /// <param name="entity">Kiểu đố tượng</param>
        /// <returns>ServiceResult</returns>
        /// create: 7/2/2021
        public virtual async Task<ServiceResult> Update(T entity)
        {
            var effectRow = await _baseData.Update(entity);
            ServiceResult serviceResult = new ServiceResult();
            if (effectRow == 1)
            {
                serviceResult.MISACukCukCode = MISACukCukServiceCode.Success;
            }
            else
            {
                serviceResult.MISACukCukCode = MISACukCukServiceCode.Exception;
                serviceResult.Error.Add(new ErrorResult()
                {
                    DevMsg = Properties.Resources.ErrorServive_Employee_Update,
                    UserMsg = Properties.Resources.ErrorServive_Employee_Update

                });
            }
            return serviceResult;
        }

        /// <summary>
        /// Xóa đối tượng
        /// </summary>
        /// <param name="id">id của đối tượng</param>
        /// <returns>ServiceResult</returns>
        /// create: 7/2/2021
        public virtual async Task<ServiceResult> Delete(string id)
        {
            ServiceResult serviceResult = new ServiceResult();
            if (await _baseData.Delete(id) == 1)
            {
                serviceResult.MISACukCukCode = MISACukCukServiceCode.Success;
            }
            else
            {
                serviceResult.MISACukCukCode = MISACukCukServiceCode.BadRequest;
                serviceResult.Error.Add(new ErrorResult()
                {
                    DevMsg = Properties.Resources.ErrorServive_Employee_EmployeeId_notExist,
                    UserMsg = Properties.Resources.ErrorServive_Employee_EmployeeId_notExist

                });
            }
            return serviceResult;
        }

        /// <summary>
        /// Lấy ra 1 đối tượng theo ID 
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// create 5/2/2021
        public async Task<ServiceResult> GetById(string id)
        {
            var result = await _baseData.GetById(id);
            ServiceResult serviceResult = new ServiceResult();
            if (result != null)
            {
                serviceResult.MISACukCukCode = MISACukCukServiceCode.Success;
            }
            else
            {
                serviceResult.MISACukCukCode = MISACukCukServiceCode.Exception;
                serviceResult.Error.Add(new ErrorResult()
                {
                    DevMsg = Properties.Resources.ErrorServive_Employee_GetData,
                    UserMsg = Properties.Resources.ErrorServive_Employee_GetData

                });
            }
            return serviceResult;

        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của dữ liệu
        /// </summary>
        /// <param name="entity"> thông tin đối tượng</param>
        /// create by : vu minh hieu (7/2/2021)
        public void ValidateObject(ref ServiceResult serviceResult, T entity)
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propValue = property.GetValue(entity);
                // Nếu có attribute là [Required] thì kiểm tra thực hiện bắt buộc nhập
                //IsDefined: kiểm tra loại của thuộc tính: nếu đúng là true
                if (property.IsDefined(typeof(Required), true) && (propValue == null || propValue.ToString() == string.Empty))
                {
                    /// GetCustomAttributes
                    var requiredAttribute = property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as Required).PropertyName;
                        var errorMsg = (requiredAttribute as Required).ErrorMessenger;
                        serviceResult.Error.Add(new ErrorResult()
                        {
                            DevMsg = errorMsg,
                            UserMsg = errorMsg

                        }); ;
                        serviceResult.MISACukCukCode = MISACukCukServiceCode.BadRequest;
                    }

                }

                //Nếu có attribute là [MaxLength] thì thực hiện kiểm độ dài
                if (property.IsDefined(typeof(MaxLength), true))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(MaxLength), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as MaxLength).PropertyName;
                        var errorMsg = (requiredAttribute as MaxLength).ErrorMessenger;
                        var length = (requiredAttribute as MaxLength).Length;
                        if (propValue.ToString().Trim().Length > length)
                        {
                            serviceResult.Error.Add(new ErrorResult()
                            {
                                DevMsg = errorMsg,
                                UserMsg = errorMsg

                            }); ;
                            serviceResult.MISACukCukCode = MISACukCukServiceCode.BadRequest;
                        }
                    }
                }
                //Nếu có attribute là [FixLength] thì thực hiện kiểm độ dài
                if (property.IsDefined(typeof(FixLength), true))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(FixLength), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as FixLength).PropertyName;
                        var errorMsg = (requiredAttribute as FixLength).ErrorMessenger;
                        var length = (requiredAttribute as FixLength).Length;
                        if (propValue.ToString().Trim().Length == length)
                        {
                            serviceResult.Error.Add(new ErrorResult()
                            {
                                DevMsg = errorMsg,
                                UserMsg = errorMsg

                            }); ;
                            serviceResult.MISACukCukCode = MISACukCukServiceCode.BadRequest;
                        }
                    }
                }
            }
        }
    }
}
