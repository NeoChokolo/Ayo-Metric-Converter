using MetricConverter.Core.Repositories;
using MetricConverter.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jace;

namespace MetricConverter.Core.Services
{
    public class MetricConverterService : IMetricConverterService
    {
        /// <summary>
        /// 
        /// </summary>
        /// </summary>
        private readonly IMetricFormulaRepository metricFormulaRepository;
        private readonly IMetricTypeRepository metricTypeRepository;
        private readonly IMetricUnitRepository IMetricUnitRepository;
        CalculationEngine calcuator = new CalculationEngine();

        public MetricConverterService(IMetricFormulaRepository metricFormulaRepository, 
            IMetricTypeRepository metricTypeRepository, 
            IMetricUnitRepository IMetricUnitRepository)
        {
            this.metricFormulaRepository = metricFormulaRepository;
            this.metricTypeRepository = metricTypeRepository;
            this.IMetricUnitRepository = IMetricUnitRepository;
        }
        public async Task<ConversionResponse> Converter(ConversionRequest conversionRequest)
        {
            // check Type

            var metricType = await metricTypeRepository.GetByIdAsync(conversionRequest.TypeId);
            var unitTo = await IMetricUnitRepository.GetByIdAsync(conversionRequest.UnitToId);
            var unitFrom = await IMetricUnitRepository.GetByIdAsync(conversionRequest.UnitFromId);
            var formulaEntity = await metricFormulaRepository.GetFormula(conversionRequest.TypeId, conversionRequest.UnitFromId, conversionRequest.UnitToId);
            var formula = formulaEntity.Formula.Replace("value", conversionRequest.Value.ToString());

            var result = calcuator.Calculate(formula);

            return new ConversionResponse
            {
                Type = metricType.Name,
                Result = string.Format("{0} {1} = {2} {3}", conversionRequest.Value, unitFrom.Name, result.ToString(), unitTo.Name) 
            };

        }
    }
}
