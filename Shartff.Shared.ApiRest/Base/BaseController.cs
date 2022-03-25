using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Shartff.Shared.ApiRest.Base
{
    public class BaseController: ControllerBase
    {
        public readonly IMapper _mapper;

        public BaseController(IMapper mapper)
        {
            this._mapper = mapper;
        }
    }
}
