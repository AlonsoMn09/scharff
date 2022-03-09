using AutoMapper;
using Sharff.ApiRest.Models;
using Sharff.Domain.Model.Model;

namespace Sharff.ApiRest.Profiles
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            CreateMap<Example, ExampleDto>();
        }
    }
}
