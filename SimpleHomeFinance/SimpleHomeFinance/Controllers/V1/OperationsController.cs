using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleHomeFinance.Contracts;
using SimpleHomeFinance.Contracts.V1;
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

        // GET
        [HttpGet(ApiRoutes.Operations.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_operations);
        }
    }
}