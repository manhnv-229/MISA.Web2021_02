using AutoMapper;
using System;
using Kimerce.Backend.Dto.Models.Employees;
using Kimerce.Backend.Domain.Employees;

namespace Kimerce.Backend.Dto
{
    public class AutoMapperConfig
    {
        #region Properties
        private static MapperConfiguration _mapperConfiguration;
        private static IMapper _mapper;

        /// <summary>
        /// Mapper
        /// </summary>
        public static IMapper Mapper => _mapper;

        /// <summary>
        /// Mapper configuration
        /// </summary>
        public static MapperConfiguration MapperConfiguration => _mapperConfiguration;
        #endregion

        public static void Init()
        {
            try
            {
                _mapperConfiguration = new MapperConfiguration(cfg =>
                {


                   

                    #region Employee
                    cfg.CreateMap<Employee, Employee>()
                        .ForMember(dest => dest.Id, opt => opt.Ignore())
                        .ForMember(dest => dest.CreatedTime, opt => opt.Ignore())
                        .ForMember(dest => dest.UpdatedTime, opt => opt.Ignore());
                      
                    cfg.CreateMap<Employee, EmployeeModel>();
                    cfg.CreateMap<EmployeeModel, Employee>();


                    #endregion

                   
                });




                _mapper = _mapperConfiguration.CreateMapper();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}