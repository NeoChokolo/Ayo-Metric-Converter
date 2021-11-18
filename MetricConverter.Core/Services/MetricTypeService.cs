using AutoMapper;
using MetricConverter.Core.Entities;
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
        public async Task<Guid> AddAsync(MetricType metricType)
        {
            var metricTypeEntity = _mapper.Map<MetricTypeEntity>(metricType);
            var result = await metricTypeRepository.AddAsync(metricTypeEntity);
            return result;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var result = await metricTypeRepository.DeleteAsync(id);
            return result;
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

        public async Task<MetricType> GetByIdAsync(Guid id)
        {
            var result = await metricTypeRepository.GetByIdAsync(id);
            var metricTypeEntity = _mapper.Map<MetricType>(result);
            return metricTypeEntity;
        }

        public async Task<Guid> UpdateAsync(MetricType metricType)
        {
            var metricTypeEntity = _mapper.Map<MetricTypeEntity>(metricType);
            var result = await metricTypeRepository.UpdateAsync(metricTypeEntity);
            return result;
        }
    }
}
