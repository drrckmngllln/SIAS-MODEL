using API.DTOs.Settings;
using AutoMapper;
using Core.Entities.Settings;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Settings Profiles

            CreateMap<Course, CourseDto>()
                .ForMember(d => d.Level, o => o.MapFrom(s => s.Level.Code))
                .ForMember(d => d.Campus, o => o.MapFrom(s => s.Campus.Code))
                .ForMember(d => d.Department, o => o.MapFrom(s =>s.Department.Code));

            #endregion
        }
    }
}
