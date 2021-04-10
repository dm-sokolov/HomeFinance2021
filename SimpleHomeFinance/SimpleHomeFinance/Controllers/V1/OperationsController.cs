using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleHomeFinance.Contracts;
using SimpleHomeFinance.Contracts.V1;
using SimpleHomeFinance.Contracts.V1.Requests;
using SimpleHomeFinance.Contracts.V1.Response;
using SimpleHomeFinance.Domain;

namespace SimpleHomeFinance.Controllers.V1
{
    public class OperationsController : Controller
    {
        private List<Operation> _operations;

        public OperationsController()
        {
            _operations = new List<Operation>();
            for (int i = 0; i < 5; i++)
            {
                _operations.Add(new Operation
                {
                    Id = Guid.NewGuid().ToString()
                });
            }
        }

        [HttpGet(ApiRoutes.Operations.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_operations);
        }


        [HttpGet(ApiRoutes.Operations.Get)]
        public IActionResult Get(string operationId)
        {
            return Ok();
        }


        [HttpPost(ApiRoutes.Operations.Create)]
        public IActionResult Create([FromBody] CreateOperationRequest operationRequest)
        {
            var operation = new Operation
            {
                Id = operationRequest.Id
            };

            if (string.IsNullOrEmpty(operation.Id))
                operation.Id = Guid.NewGuid().ToString();

            _operations.Add(operation);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Operations.Get.Replace("{operationId}", operation.Id);

            var response = new OperationResponse
            {
                Id = operation.Id
            };

            return Created(locationUri, response);
        }
    }
}