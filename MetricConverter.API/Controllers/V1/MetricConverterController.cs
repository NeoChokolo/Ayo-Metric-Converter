using MetricConverter.Core.Services;
using MetricConverter.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MetricConverter.API.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MetricConverterController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMetricConverterService metricConverterService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="metricConverterService"></param>
        public MetricConverterController(IMetricConverterService metricConverterService)
        {
            this.metricConverterService = metricConverterService;
        }

        /// <summary>
        /// Metric Calculator
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(ConversionResponse), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(typeof(ValidationResult), 500)]
        public async Task<IActionResult> ConvertMetric(ConversionRequest conversionRequest)
        {
            try
            {
                var response = await metricConverterService.Converter(conversionRequest);
                return Ok(response);
            }
            catch (ApplicationException ax)
            {
                ValidationResult validationResult = new ValidationResult();
                validationResult.ValidationMessages.Add(ax.Message);
                return StatusCode(500, validationResult);
            }
            catch (Exception ex)
            {
                ValidationResult validationResult = new ValidationResult();
                validationResult.ValidationMessages.Add(ex.Message);
                return StatusCode(400, validationResult);
            }
        }
    }
}
