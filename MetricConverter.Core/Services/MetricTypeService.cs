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
    public class MetricTypeService : IMetricTypeService
    {
        private readonly IMapper _mapper;
        private readonly IMetricTypeRepository metricTypeRepository;

        public MetricTypeService(IMetricTypeRepository metricTypeRepository)
        {
            this.metricTypeRepository = metricTypeRepository;
            var autoMapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperHelper());
            });
            _mapper = autoMapperConfig.CreateMapper();
        }
        public Task<Guid> AddAsync(MetricType metricType)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<MetricType>> GetAllAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<MetricType>> GetAllAsync()
        {
            var metricTypeEntities = await metricTypeRepository.GetAllAsync();
            var metricTypes = _mapper.Map<IReadOnlyList<MetricType>>(metricTypeEntities);
            return metricTypes;
        }

        public Task<MetricType> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateAsync(MetricType metricType)
        {
            throw new NotImplementedException();
        }
    }
}
