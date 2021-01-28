using AutoMapper;
using MediaTec.Dtos;
using MediaTec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaTec.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}