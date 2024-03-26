using API.DTOs.Settings;
using AutoMapper;
using Core.Entities;
using Core.Entities.Settings;
using Core.Interfaces;
using Core.Parameters.Settings;
using Core.Specifications.Settings;
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

        #region Add Update Delete Shortcut
        private async Task AddAsync<T>(T entity) where T : BaseEntity
        {
            _unitOfWork.Repository<T>().Add(entity);
            await _unitOfWork.Complete();
        }

        private async Task UpdateAsync<T>(T entity) where T : BaseEntity
        {
            _unitOfWork.Repository<T>().Update(entity);
            await _unitOfWork.Complete();
        }

        private async Task DeleteAsync<T>(T entity) where T : BaseEntity
        {
            _unitOfWork.Repository<T>().Delete(entity);
            await _unitOfWork.Complete();
        }

        #endregion


        #region Campuses

        [HttpGet("Campuses")]
        public async Task<ActionResult<IReadOnlyList<Campus>>> GetCampusesAsync([FromQuery] CampusesParameters parameters)
        {
            var spec = new CampusesSpecifications(parameters);

            var campuses = await _unitOfWork.Repository<Campus>().ListAsync(spec);

            return Ok(campuses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Campus>> GetCampusAsync(int id)
        {
            var spec = new CampusesSpecifications(id);

            var campus = await _unitOfWork.Repository<Campus>().GetByIdAsync(id);

            return Ok(campus);
        }

        [HttpPost("Campuses/create")]
        public async Task<ActionResult<Campus>> CreateCampus(Campus campus)
        {
            if (!await CheckCampusExisting(campus.Code))
            {
                var item = new Campus
                {
                    Code = campus.Code,
                    Description = campus.Description,
                    Address = campus.Address
                };
                await AddAsync(item);
                return Ok(item);
            }

            return BadRequest("Campus already exist");
        }

        private async Task<bool> CheckCampusExisting(string code)
        {
            var campuses = await _unitOfWork.Repository<Campus>().ListAllAsync();
            if (campuses.Any(x => x.Code == code))
            {
                return true;
            }

            return false;
        }

        [HttpPut("Campuses/update")]
        public async Task<ActionResult<Campus>> UpdateCampus(Campus campus)
        {
            await UpdateAsync(campus);
            return Ok(campus);
        }

        [HttpDelete("Campuses/{id}")]
        public async Task<ActionResult<Campus>> DeleteCampus(Campus campus)
        {
            await DeleteAsync(campus);
            return Ok(campus);
        }

        #endregion

        #region Courses

        [HttpGet("Courses")]
        public async Task<ActionResult<IReadOnlyList<CourseDto>>> GetCoursesAsync([FromQuery] CoursesParameters coursesParameters)
        {
            var spec = new CoursesSpecifications(coursesParameters);

            var courses = await _unitOfWork.Repository<Course>().ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Course>, IReadOnlyList<CourseDto>>(courses);

            return Ok(data);
        }

        [HttpGet("Courses/{id}")]
        public async Task<ActionResult<CourseDto>> GetCourseAsync(int id)
        {
            var spec = new CoursesSpecifications(id);

            var course = await _unitOfWork.Repository<Course>().GetEntityWithSpec(spec);

            var data = _mapper.Map<Course, CourseDto>(course);

            return Ok(data);
        }

        [HttpPost("Courses/create")]
        public async Task<ActionResult<CourseDto>> CreateCourseAsync(CourseDto courseDto)
        {
            if (!await CheckCourseExisting(courseDto.Code))
            {
                var levels = await _unitOfWork.Repository<Level>().ListAllAsync();
                
            }
        }

        private async Task<bool> CheckCourseExisting(string code)
        {
            var courses = await _unitOfWork.Repository<Course>().ListAllAsync();
            if (courses.Any(x => x.Code == code))
            {
                return true;
            }
            return false;
        }


        #endregion
    }
}
