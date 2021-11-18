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
    public class MetricUnitController : ControllerBase
    {
        private readonly IMetricUnitService metricUnitService;

        /// <summary>
        /// 
        /// </summary>
        public MetricUnitController(IMetricUnitService metricUnitService)
        {
            this.metricUnitService = metricUnitService;
        }

        /// <summary>
        /// Get all metric unit by typeid
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(typeof(List<MetricUnit>), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(typeof(ValidationResult), 500)]
        public async Task<IActionResult> MetricUnitByTypeId(Guid Id)
        {
            try
            {
                var response = await metricUnitService.GetAllAsync(Id);
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
