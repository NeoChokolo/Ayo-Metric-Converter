using MetricConverter.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MetricConverter.Core.Services
{
    public interface IMetricUnitService
    {
        Task<MetricUnit> GetByIdAsync(Guid id);
        Task<IReadOnlyList<MetricUnit>> GetAllAsync(Guid id);
        Task<IReadOnlyList<MetricUnit>> GetAllAsync();
        Task<Guid> AddAsync(MetricUnit metricUnit);
        Task<Guid> UpdateAsync(MetricUnit metricUnit);
        Task<Guid> DeleteAsync(Guid id);
    }
}
