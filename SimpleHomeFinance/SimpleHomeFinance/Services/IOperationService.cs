using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleHomeFinance.Contracts.V1;
using SimpleHomeFinance.Domain;

namespace SimpleHomeFinance.Services
{
    public interface IOperationService
    {
        Task<List<Operation>> GetOperationsAsync();

        Task<Operation> GetOperationByIdAsync(int operationId);

        Task<bool> CreateOperationAsync(Operation operation);
        
        Task<bool> UpdateOperationAsync(Operation operationToUpdate);
        
        Task<bool> DeleteOperationAsync(int operationId);
    }
}