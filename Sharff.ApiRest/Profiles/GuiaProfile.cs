using AutoMapper;
using Sharff.ApiRest.Models;
using Sharff.Domain.Model.DbModel;

namespace Sharff.ApiRest.Profiles
{
    public class GuiaProfile: Profile
    {
        public GuiaProfile()
        {
            CreateMap<GuiaInboundFedexDto, TblGuiaInboundFedex>();
            CreateMap<TblGuiaInboundFedex, GuiaInboundFedexDto>();
        }
    }
}
