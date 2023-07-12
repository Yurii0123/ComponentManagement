using AutoMapper;
using TCM.Core.Dto.TrainComponentDto;
using TCM.Core.Entities;

namespace TCM.Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TrainComponent, TrainComponentResponse>();

            CreateMap<TrainComponent, TrainComponentHierarchyResponse>()
                .ForMember(s => s.Children, c => c.MapFrom(m => m.Children));


        }
    }

}
