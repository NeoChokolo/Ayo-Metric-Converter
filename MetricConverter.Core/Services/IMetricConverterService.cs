using MetricConverter.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MetricConverter.Core.Services
{
    public interface IMetricConverterService
    {
        Task<ConversionResponse> Converter(ConversionRequest conversionRequest);
    }
}
