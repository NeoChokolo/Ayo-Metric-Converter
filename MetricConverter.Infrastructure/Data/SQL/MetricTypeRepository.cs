using MetricConverter.Core.Entities;
using MetricConverter.Core.Repositories;
using MetricConverter.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Guid> AddAsync(MetricTypeEntity entity)
        {
            try
            {
                var entityEntry = await metricConverterContext.MetricType.AddAsync(entity);
                await metricConverterContext.SaveChangesAsync();
                return entityEntry.Entity.Id;
            }
            catch (Exception ex)
            {
                // Log error message ex
                throw new ArgumentException("An error occured while storing metric type information - ", nameof(MetricTypeEntity));
            }
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await metricConverterContext.MetricType.FindAsync(id);
                var deletedEntity = metricConverterContext.MetricType.Remove(entity);
                await this.metricConverterContext.SaveChangesAsync();
                return deletedEntity.Entity.Id;
            }
            catch (Exception ex)
            {
                // Log error message ex
                throw new ArgumentException("An error occured while removing metric type information.");
            }
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

        public async Task<Guid> UpdateAsync(MetricTypeEntity entity)
        {
            try
            {
                metricConverterContext.Entry(entity).State = EntityState.Modified;
                await metricConverterContext.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception ex)
            {
                // Log error message ex
                throw new ArgumentException("An error occured while updating metric type information - ", nameof(MetricFormulaEntity));
            }
        }
    }
}
