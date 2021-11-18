using AutoMapper;
using MetricConverter.Core.Helpers;
using MetricConverter.Core.Repositories;
using MetricConverter.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MetricConverter.Core.Services
{
    public class MetricUnitService : IMetricUnitService
    {

        private readonly IMapper _mapper;
        private readonly IMetricUnitRepository metricUnitRepository;

        public MetricUnitService(IMetricUnitRepository metricUnitRepository)
        {
            this.metricUnitRepository = metricUnitRepository;
            var autoMapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperHelper());
            });
            _mapper = autoMapperConfig.CreateMapper();
        }

        public Task<Guid> AddAsync(MetricUnit metricUnit)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<MetricUnit>> GetAllAsync(Guid id)
        {
            var result = await metricUnitRepository.GetAllAsync(id);
            var metricUnit = _mapper.Map<IReadOnlyList<MetricUnit>>(result);
            return metricUnit;
        }

        public Task<IReadOnlyList<MetricUnit>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MetricUnit> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateAsync(MetricUnit metricUnit)
        {
            throw new NotImplementedException();
        }
    }
}
