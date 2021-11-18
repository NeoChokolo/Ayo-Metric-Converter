using AutoMapper;
using MetricConverter.Core.Entities;
using MetricConverter.Model;

namespace MetricConverter.Core.Helpers
{
    public class MapperHelper : Profile
    {
        public MapperHelper()
        {
            CreateMap<MetricTypeEntity, MetricType>().ReverseMap();
            CreateMap<MetricFormulaEntity, MetricFormula>().ReverseMap();
            CreateMap<MetricUnitEntity, MetricUnit>().ReverseMap();
        }
    }
}
