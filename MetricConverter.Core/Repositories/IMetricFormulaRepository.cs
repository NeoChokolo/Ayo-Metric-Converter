using MetricConverter.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MetricConverter.Core.Repositories
{
    public interface IMetricFormulaRepository : IGenericRepository<MetricFormulaEntity>
    {
        Task<MetricFormulaEntity> GetFormula(Guid typeId, Guid unitFromId, Guid unitToId);
    }
}
