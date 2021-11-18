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
    public class MetricFormulaService : IMetricFormulaService
    {

        private readonly IMapper _mapper;
        private readonly IMetricFormulaRepository metricFormulaRepository;

        public MetricFormulaService(IMetricFormulaRepository metricFormulaRepository)
        {
            this.metricFormulaRepository = metricFormulaRepository;
            var autoMapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperHelper());
            });
            _mapper = autoMapperConfig.CreateMapper();
        }

        public async Task<Guid> AddAsync(MetricFormula metricFormula)
        {
            var metricFormulaEntity = _mapper.Map<MetricFormulaEntity>(metricFormula);
            var result = await metricFormulaRepository.AddAsync(metricFormulaEntity);
            return result;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var result = await metricFormulaRepository.DeleteAsync(id);
            return result;
        }

        public async Task<IReadOnlyList<MetricFormula>> GetAllAsync(Guid id)
        {
            var result = await metricFormulaRepository.GetAllAsync(id);
            var metricFormula = _mapper.Map<IReadOnlyList<MetricFormula>>(result);
            return metricFormula;
        }

        public Task<IReadOnlyList<MetricFormula>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<MetricFormula> GetByIdAsync(Guid id)
        {
            var result = await metricFormulaRepository.GetByIdAsync(id);
            var metricFormula = _mapper.Map<MetricFormula>(result);
            return metricFormula;
        }

        public async Task<Guid> UpdateAsync(MetricFormula metricFormula)
        {
            var metricFormulaEntity = _mapper.Map<MetricFormulaEntity>(metricFormula);
            var result = await metricFormulaRepository.UpdateAsync(metricFormulaEntity);
            return result;
        }
    }
}
