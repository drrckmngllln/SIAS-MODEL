using AutoMapper;
using Core.Entities.Settings;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings
{
    public class SettingsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SettingsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Campuses

        [HttpGet("Campuses")]
        public async Task<ActionResult<IReadOnlyList<Campus>>> GetCampusesAsync([FromQuery] string search)
        {

        }

        #endregion
    }
}
