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
    public class MetricTypeRepository : IMetricTypeRepository
    {
        private readonly MetricConverterContext metricConverterContext;

        public MetricTypeRepository(MetricConverterContext metricConverterContext)
        {
            this.metricConverterContext = metricConverterContext;
        }

        public Task<Guid> AddAsync(MetricTypeEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<MetricTypeEntity>> GetAllAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<MetricTypeEntity>> GetAllAsync()
        {
            try
            {
                var entity = metricConverterContext.MetricType.ToList();
                return entity;
            }
            catch (Exception ex)
            {
                // Log error message ex e.g. log4net etc...
                throw new ArgumentException("An error occured while retriving metric types.");
            }
        }

        public async Task<MetricTypeEntity> GetByIdAsync(Guid id)
        {
            try
            {
                var entity = await metricConverterContext.MetricType.FindAsync(id);
                return entity;
            }
            catch (Exception ex)
            {
                // Log error message ex
                throw new ArgumentException("An error occured while retriving metric type information.");
            }
        }

        public Task<Guid> UpdateAsync(MetricTypeEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
