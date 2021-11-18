using MetricConverter.Core.Services;
using MetricConverter.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricConverter.API.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MetricTypeController : ControllerBase
    {
        private readonly IMetricTypeService metricTypeService;

        /// <summary>
        /// 
        /// </summary>
        public MetricTypeController(IMetricTypeService metricTypeService)
        {
            this.metricTypeService = metricTypeService;
        }

        /// <summary>
        /// Get all metric types defined
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<MetricType>), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(typeof(ValidationResult), 500)]
        public async Task<IActionResult> MetricTypes()
        {
            try
            {
                var response = await metricTypeService.GetAllAsync();
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
