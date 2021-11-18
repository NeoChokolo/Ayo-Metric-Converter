using MetricConverter.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MetricConverter.Core.Services
{
    public interface IMetricFormulaService
    {
        Task<MetricFormula> GetByIdAsync(Guid id);
        Task<IReadOnlyList<MetricFormula>> GetAllAsync(Guid id);
        Task<IReadOnlyList<MetricFormula>> GetAllAsync();
        Task<Guid> AddAsync(MetricFormula metricFormula);
        Task<Guid> UpdateAsync(MetricFormula metricFormula);
        Task<Guid> DeleteAsync(Guid id);
    }
}
