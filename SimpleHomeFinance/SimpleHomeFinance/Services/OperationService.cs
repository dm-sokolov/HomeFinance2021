using System;
using System.Collections.Generic;
using System.Linq;
using SimpleHomeFinance.Domain;

namespace SimpleHomeFinance.Services
{
    public class OperationService : IOperationService
    {
        private readonly List<Operation> _operations;

        public OperationService()
        {
            _operations = new List<Operation>();
            for (int i = 0; i < 5; i++)
            {
                _operations.Add(new Operation
                {
                    Id = Guid.NewGuid(),
                    Name = $"Operation Name {i}"
                });
            }
        }
        public List<Operation> GetOperations()
        {
            return _operations;
        }

        public Operation GetOperationById(Guid operationId)
        {
            return _operations.SingleOrDefault(x => x.Id == operationId);
        }
    }
}