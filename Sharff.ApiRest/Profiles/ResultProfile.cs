using AutoMapper;
using Sharff.ApiRest.Models;
using Sharff.Domain.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharff.ApiRest.Profiles
{
    public class ResultProfile : Profile
    {
        public ResultProfile()
        {
            CreateMap<ResultDto, TblLog>();
            CreateMap<TblLog, ResultDto>();
        }
    }
}
