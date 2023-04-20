namespace MoviesAPI.Business
{
    public class OperationResult
    {
        public bool IsSuccessful { get; set; }
        public Exception? Exception { get; set; }
    }

    public class OperationResult<T> : OperationResult
    {
        public T? Result { get; set; }
    }
}