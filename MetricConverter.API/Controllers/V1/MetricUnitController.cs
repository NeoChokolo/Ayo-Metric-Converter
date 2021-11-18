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
        [Route("type/{typeId}")]
        [ProducesResponseType(typeof(List<MetricUnit>), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(typeof(ValidationResult), 500)]
        public async Task<IActionResult> MetricUnitByTypeId(Guid typeId)
        {
            try
            {
                var response = await metricUnitService.GetAllAsync(typeId);
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

        /// <summary>
        /// Get metric unit information
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(typeof(MetricUnit), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(typeof(ValidationResult), 500)]
        public async Task<IActionResult> GetMetricUnit(Guid Id)
        {
            try
            {
                var response = await metricUnitService.GetByIdAsync(Id);
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

        /// <summary>
        /// Add new metric unit information
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(typeof(ValidationResult), 500)]
        public async Task<IActionResult> AddMetricUnit(MetricUnit metricUnit)
        {
            try
            {
                var response = await metricUnitService.AddAsync(metricUnit);
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

        /// <summary>
        /// Delete metric unit information
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{Id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(typeof(ValidationResult), 500)]
        public async Task<IActionResult> DeleteMetricUnit(Guid Id)
        {
            try
            {
                var response = await metricUnitService.DeleteAsync(Id);
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

        /// <summary>
        /// Update metric unit information
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(typeof(ValidationResult), 500)]
        public async Task<IActionResult> UpdateMetricUnit(MetricUnit metricUnit)
        {
            try
            {
                var response = await metricUnitService.UpdateAsync(metricUnit);
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
