using AutoMapper;
using Sharff.ApiRest.Models;
using Sharff.Domain.Model.DbModel;

namespace Sharff.ApiRest.Profiles
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            CreateMap<ExampleDto, TblExampleFedex>();
            CreateMap<TblExampleFedex, ExampleDto>();           
        }
    }
}
