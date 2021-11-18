using MetricConverter.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MetricConverter.Core.Services
{
    public interface IMetricTypeService
    {
        Task<MetricType> GetByIdAsync(Guid id);
        Task<IReadOnlyList<MetricType>> GetAllAsync(Guid id);
        Task<IReadOnlyList<MetricType>> GetAllAsync();
        Task<Guid> AddAsync(MetricType metricType);
        Task<Guid> UpdateAsync(MetricType metricType);
        Task<Guid> DeleteAsync(Guid id);
    }
}
