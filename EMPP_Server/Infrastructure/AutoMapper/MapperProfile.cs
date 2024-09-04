using AutoMapper;
using DataAccess.ApplicationData;
using DataModels.ApplicationModels;

namespace EMPP_Server.Infrastructure.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MainInfo, MainInfoDTO>().ReverseMap();
            CreateMap<WorkHistory, WorkHistoryDTO>().ReverseMap();
            CreateMap<Skill, SkillDTO>().ReverseMap();
            CreateMap<InitialStage, InitialStageDTO>().ReverseMap();
            CreateMap<LanguageTest, LanguageTestDTO>().ReverseMap();
            CreateMap<LanguageData, LanguageDataDTO>().ReverseMap();
            CreateMap<WorkAchievement, WorkAchievementDTO>().ReverseMap();
            CreateMap<Volunteer, VolunteerDTO>().ReverseMap();
        }
    }
}
