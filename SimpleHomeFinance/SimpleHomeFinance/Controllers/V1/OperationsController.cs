using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SimpleHomeFinance.Contracts;
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
        public IActionResult GetAll()
        {
            return Ok(_operationService.GetOperations());
        }


        [HttpGet(ApiRoutes.Operations.Get)]
        public IActionResult Get([FromRoute] Guid operationId)
        {
            var operation = _operationService.GetOperationById(operationId);

            if (operation == null)
                return NotFound();

            return Ok(operation);
        }

        [HttpPut(ApiRoutes.Operations.Update)]
        public IActionResult Update([FromRoute] Guid operationId, [FromBody] UpdateOperationRequest request)
        {
            var operation = new Operation
            {
                 Id = operationId,
                 Name = request.Name
            };

            var updated = _operationService.UpdateOperation(operation);

            if (updated)
                return Ok(operation);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Operations.Delete)]
        public IActionResult Delete([FromRoute] Guid operationId)
        {
            var deleted = _operationService.DeleteOperation(operationId);

            if (deleted)
                return NoContent();

            return NotFound();
        }


        [HttpPost(ApiRoutes.Operations.Create)]
        public IActionResult Create([FromBody] CreateOperationRequest operationRequest)
        {
            var operation = new Operation
            {
                Id = operationRequest.Id
            };

            if (operation.Id != Guid.Empty)
                operation.Id = Guid.NewGuid();

            _operationService.GetOperations().Add(operation);

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