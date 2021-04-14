using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleHomeFinance.Data;
using SimpleHomeFinance.Domain;

namespace SimpleHomeFinance.Services
{
    public class OperationService : IOperationService
    {
        private readonly DataContext _dataContext;

        public OperationService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Operation>> GetOperationsAsync()
        {
            return await _dataContext.Operations.ToListAsync();
        }

        public async Task<Operation> GetOperationByIdAsync(Guid operationId)
        {
            return await _dataContext.Operations.SingleOrDefaultAsync(x => x.Id == operationId);
        }

        public async Task<bool> UpdateOperationAsync(Operation operationToUpdate)
        {
            _dataContext.Operations.Update(operationToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteOperationAsync(Guid operationId)
        {
            var operation = await GetOperationByIdAsync(operationId);

            if (operation == null)
                return false;
            
            _dataContext.Operations.Remove(operation);
            var deleted = await _dataContext.SaveChangesAsync();
            
            return deleted > 0;
        }

        public async Task<bool> CreateOperationAsync(Operation operation)
        {
            _dataContext.Operations.AddAsync(operation);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
    }
}