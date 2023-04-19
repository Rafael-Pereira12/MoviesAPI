using System.Transactions;

namespace MoviesAPI.Business
{
    public abstract class BaseBusinessObject
    {
        private readonly TransactionScopeOption req = TransactionScopeOption.Required;
        private readonly TransactionScopeAsyncFlowOption enableFlow = TransactionScopeAsyncFlowOption.Enabled;
        private readonly TransactionOptions defaultOptions = new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted, Timeout = TimeSpan.FromSeconds(60) };

        protected OperationResult ExecuteOperation<T>(Func<T> operation)
        {
            try
            {
                var result = operation.Invoke();
                return new OperationResult<T>() { Result = result, IsSuccessful = true };

            }
            catch (Exception ex)
            {
                return new OperationResult() { Exception = ex };
            }
        }

        protected OperationResult ExecuteOperation(Action operation)
        {
            try
            {
                operation.Invoke();
                return new OperationResult() { IsSuccessful = true };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Exception = ex };
            }
        }

        protected async Task<OperationResult> ExecuteOperationAsync(Func<Task> operation, TransactionOptions options = default)
        {

            try
            {
                using (var scope = new TransactionScope(req, options == default ? defaultOptions : options, enableFlow))
                {
                    await operation.Invoke();
                    scope.Complete();
                    return new OperationResult() { IsSuccessful = true };
                }
            }
            catch (Exception ex)
            {
                return new OperationResult() { Exception = ex };
            }
        }

        protected async Task<OperationResult<T>> ExecuteOperationAsync<T>(Func<Task<T>> operation, TransactionOptions options = default)
        {
            try
            {
                using (var scope = new TransactionScope(req, options == default ? defaultOptions : options, enableFlow))
                {
                    var result = await operation.Invoke();
                    scope.Complete();
                    return new OperationResult<T>() { IsSuccessful = true, Result = result };
                }
            }
            catch (Exception ex)
            {
                return new OperationResult<T>() { Exception = ex };
            }
        }
    }
}


