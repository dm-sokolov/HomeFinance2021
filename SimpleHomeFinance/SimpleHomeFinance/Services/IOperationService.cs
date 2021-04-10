using System;
using System.Collections.Generic;
using SimpleHomeFinance.Contracts.V1;
using SimpleHomeFinance.Domain;

namespace SimpleHomeFinance.Services
{
    public interface IOperationService
    {
        List<Operation> GetOperations();

        Operation GetOperationById(Guid operationId);

    }
}