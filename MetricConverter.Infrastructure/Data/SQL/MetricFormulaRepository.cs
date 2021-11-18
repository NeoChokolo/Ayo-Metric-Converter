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
    public class MetricFormulaRepository : IMetricFormulaRepository
    {
        private readonly MetricConverterContext metricConverterContext;

        public MetricFormulaRepository(MetricConverterContext metricConverterContext)
        {
            this.metricConverterContext = metricConverterContext;
        }
        public async Task<Guid> AddAsync(MetricFormulaEntity entity)
        {
            try
            {
                var entityEntry = await metricConverterContext.MetricFormula.AddAsync(entity);
                await metricConverterContext.SaveChangesAsync();
                return entityEntry.Entity.Id;
            }
            catch (Exception ex)
            {
                // Log error message ex
                throw new ArgumentException("An error occured while storing metric formula information - ", nameof(MetricFormulaEntity));
            }
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await metricConverterContext.MetricFormula.FindAsync(id);
                var deletedEntity = metricConverterContext.MetricFormula.Remove(entity);
                await this.metricConverterContext.SaveChangesAsync();
                return deletedEntity.Entity.Id;
            }
            catch (Exception ex)
            {
                // Log error message ex
                throw new ArgumentException("An error occured while removing metric formula information.");
            }
        }

        public async Task<IReadOnlyList<MetricFormulaEntity>> GetAllAsync(Guid id)
        {
            try
            {
                var entity = metricConverterContext.MetricFormula.Where(o => o.TypeId == id).ToList();
                return entity;
            }
            catch (Exception ex)
            {
                // Log error message ex
                throw new ArgumentException("An error occured while retriving metric formula by type Id.");
            }
        }

        public async Task<IReadOnlyList<MetricFormulaEntity>> GetAllAsync()
        {
            try
            {
                var entity = metricConverterContext.MetricFormula.ToList();
                return entity;
            }
            catch (Exception ex)
            {
                // Log error message ex e.g. log4net,send emails, etc...
                throw new ArgumentException("An error occured while retriving metric formulas.");
            }
        }

        public async Task<MetricFormulaEntity> GetByIdAsync(Guid id)
        {
            try
            {
                var entity = await metricConverterContext.MetricFormula.FindAsync(id);
                return entity;
            }
            catch (Exception ex)
            {
                // Log error message ex
                throw new ArgumentException("An error occured while retriving metric formula information.");
            }
        }


        /// <summary>
        /// Retrieves the formula based on the unitId combination
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="unitFromId"></param>
        /// <param name="unitToId"></param>
        /// <returns></returns>
        public async Task<MetricFormulaEntity> GetFormula(Guid typeId, Guid unitFromId, Guid unitToId)
        {
            try
            {
                var entity = metricConverterContext.MetricFormula.Where(o => o.TypeId == typeId && o.UnitFromId == unitFromId && o.UnitToId== unitToId).First();
                return entity;
            }
            catch (Exception ex)
            {
                // Log error message ex
                throw new ArgumentException("An error occured while retriving formula.");
            }
        }

        public async Task<Guid> UpdateAsync(MetricFormulaEntity entity)
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
                throw new ArgumentException("An error occured while updating product information - ", nameof(MetricFormulaEntity));
            }
        }
    }
}
