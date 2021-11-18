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
    public class MetricFormulaController : ControllerBase
    {
        private readonly IMetricFormulaService metricFormulaService;

        /// <summary>
        /// 
        /// </summary>
        public MetricFormulaController(IMetricFormulaService metricFormulaService)
        {
            this.metricFormulaService = metricFormulaService;
        }



        /// <summary>
        /// Update metric formula information
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(typeof(ValidationResult), 500)]
        public async Task<IActionResult> UpdateMetricFormula(MetricFormula metricFormula)
        {
            try
            {
                var response = await metricFormulaService.UpdateAsync(metricFormula);
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
        /// Add new metric formula information
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(typeof(ValidationResult), 500)]
        public async Task<IActionResult> AddMetricFormula(MetricFormula metricFormula)
        {
            try
            {
                var response = await metricFormulaService.AddAsync(metricFormula);
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
        /// Delete metric formula information
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{Id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(typeof(ValidationResult), 500)]
        public async Task<IActionResult> DeleteMetricFormula(Guid Id)
        {
            try
            {
                var response = await metricFormulaService.DeleteAsync(Id);
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
        /// Get metric formula information
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(typeof(MetricFormula), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(typeof(ValidationResult), 500)]
        public async Task<IActionResult> GetMetricFormula(Guid Id)
        {
            try
            {
                var response = await metricFormulaService.GetByIdAsync(Id);
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
        /// Get all metric formula by typeid
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{Id}/type")]
        [ProducesResponseType(typeof(List<MetricFormula>), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(typeof(ValidationResult), 500)]
        public async Task<IActionResult> MetricFormulaByTypeId(Guid Id)
        {
            try
            {
                var response = await metricFormulaService.GetAllAsync(Id);
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
