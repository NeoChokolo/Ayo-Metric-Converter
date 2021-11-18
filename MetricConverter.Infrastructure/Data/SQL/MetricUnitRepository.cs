using MetricConverter.Core.Entities;
using MetricConverter.Core.Repositories;
using MetricConverter.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricConverter.Infrastructure.Data.SQL
{
    public class MetricUnitRepository : IMetricUnitRepository
    {
        private readonly MetricConverterContext metricConverterContext;

        public MetricUnitRepository(MetricConverterContext metricConverterContext)
        {
            this.metricConverterContext = metricConverterContext;
        }

        public Task<Guid> AddAsync(MetricUnitEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<MetricUnitEntity>> GetAllAsync(Guid id)
        {
            try
            {
                var entity = metricConverterContext.MetricUnit.Where(o => o.TypeId == id).ToList();
                return entity;
            }
            catch (Exception ex)
            {
                // Log error message ex
                throw new ArgumentException("An error occured while retriving metric units by type Id.");
            }
        }

        public async Task<IReadOnlyList<MetricUnitEntity>> GetAllAsync()
        {
            try
            {
                var entity = metricConverterContext.MetricUnit.ToList();
                return entity;
            }
            catch (Exception ex)
            {
                // Log error message ex
                throw new ArgumentException("An error occured while retriving metric units.");
            }
        }

        public async Task<MetricUnitEntity> GetByIdAsync(Guid id)
        {
            try
            {
                var entity = await metricConverterContext.MetricUnit.FindAsync(id);
                return entity;
            }
            catch (Exception ex)
            {
                // Log error message ex
                throw new ArgumentException("An error occured while retriving metric unit information.");
            }
        }

        public Task<Guid> UpdateAsync(MetricUnitEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
