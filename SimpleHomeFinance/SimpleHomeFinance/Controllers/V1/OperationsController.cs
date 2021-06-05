using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleHomeFinance.Contracts.V1;
using SimpleHomeFinance.Contracts.V1.Requests;
using SimpleHomeFinance.Contracts.V1.Response;
using SimpleHomeFinance.Domain;
using SimpleHomeFinance.Services;

namespace SimpleHomeFinance.Controllers.V1
{
    public class OperationsController : Controller
    {
        private readonly IOperationService _operationService;


        public OperationsController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpGet(ApiRoutes.Operations.GetAll)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _operationService.GetOperationsAsync());
        }


        [HttpGet(ApiRoutes.Operations.Get)]
        public async Task<IActionResult> GetAsync([FromRoute] int operationId)
        {
            var operation = await _operationService.GetOperationByIdAsync(operationId);

            if (operation == null)
                return NotFound();

            return Ok(operation);
        }

        [HttpPut(ApiRoutes.Operations.Update)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int operationId, [FromBody] UpdateOperationRequest request)
        {
            var operation = new Operation
            {
                 Id = operationId,
                 Name = request.Name
            };

            var updated = await _operationService.UpdateOperationAsync(operation);

            if (updated)
                return Ok(operation);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Operations.Delete)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int operationId)
        {
            var deleted = await _operationService.DeleteOperationAsync(operationId);

            if (deleted)
                return NoContent();

            return NotFound();
        }


        [HttpPost(ApiRoutes.Operations.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOperationRequest operationRequest)
        {
            var operation = new Operation
            {
                Name = operationRequest.Name
            };

            await _operationService.CreateOperationAsync(operation);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Operations.Get.Replace("{operationId}", operation.Id.ToString());

            var response = new OperationResponse
            {
                Id = operation.Id
            };

            return Created(locationUri, response);
        }
    }
}