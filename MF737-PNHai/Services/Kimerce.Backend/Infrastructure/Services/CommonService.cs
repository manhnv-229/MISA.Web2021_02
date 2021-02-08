using Kimerce.Backend.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kimerce.Backend.Infrastructure.Services
{
    public static class CommonService
    {

        public static T UpdateCommonInt<T>(this T entity, int updateBy = 0, string updateByUserName = "") where T : BaseEntityByInt
        {
            if (entity.Id > 0)
            {
                if (updateBy > 0 && !string.IsNullOrEmpty(updateByUserName))
                {
                    entity.UpdatedBy = updateBy;
                    entity.UpdatedByUserName = updateByUserName;
                }
                entity.UpdatedTime = DateTimeOffset.Now;
            }
            else
            {
                if (updateBy > 0 && !string.IsNullOrEmpty(updateByUserName))
                {
                    entity.UpdatedBy = entity.CreatedBy = updateBy;
                    entity.UpdatedByUserName = entity.CreatedByUserName = updateByUserName;
                }
                entity.UpdatedTime = entity.CreatedTime = DateTimeOffset.Now;
            }
            return entity;
        }

        public static T UpdateCommonLong<T>(this T entity, int updateBy = 0, string updateByUserName = "") where T : BaseEntityByLong
        {
            if (entity.Id > 0)
            {
                if (updateBy > 0 && !string.IsNullOrEmpty(updateByUserName))
                {
                    entity.UpdatedBy = updateBy;
                    entity.UpdatedByUserName = updateByUserName;
                }
                entity.UpdatedTime = DateTimeOffset.Now;
            }
            else
            {
                if (updateBy > 0 && !string.IsNullOrEmpty(updateByUserName))
                {
                    entity.UpdatedBy = entity.CreatedBy = updateBy;
                    entity.UpdatedByUserName = entity.CreatedByUserName = updateByUserName;
                }
                entity.UpdatedTime = entity.CreatedTime = DateTimeOffset.Now;
            }
            return entity;
        }

        public static T UpdateCommonInt<T>(this T entity) where T : BaseEntityInt
        {
            if (entity.Id > 0)
            {
                entity.UpdatedTime = DateTimeOffset.Now;
            }
            else
            {
                entity.UpdatedTime = entity.CreatedTime = DateTimeOffset.Now;
            }
            return entity;
        }

        public static T UpdateCommonlong<T>(this T entity) where T : BaseEntityLong
        {
            if (entity.Id > 0)
            {
                entity.UpdatedTime = DateTimeOffset.Now;
            }
            else
            {
                entity.UpdatedTime = entity.CreatedTime = DateTimeOffset.Now;
            }
            return entity;
        }

       
    }
}