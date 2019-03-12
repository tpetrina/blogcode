namespace sample_resultobject
{
    public class ResultObject<TResult, TError>
    {
        public TResult Result { get; }
        public bool IsError { get; }
        public TError Error { get; }

        public ResultObject(TResult result) => Result = result;
        public ResultObject(TError error) => (IsError, Error) = (true, error);

        public static implicit operator ResultObject<TResult, TError>(TResult result)
            => new ResultObject<TResult, TError>(result);

        public static implicit operator ResultObject<TResult, TError>(TError error)
            => new ResultObject<TResult, TError>(error);

        public void Deconstruct(out TResult result, out TError error)
            => (result, error) = (Result, Error);
    }

    public abstract class BaseError
    {
        public const BaseError None = null;
    }

    public class GenericError : BaseError
    {
        public GenericError(string message) { }
    }

    public class CommonError : BaseError
    {
        public CommonErrors Error { get; set; }

        public CommonError(CommonErrors commonError) => Error = commonError;

        public override string ToString() => $"Common error: {Error}";
    }

    public class ValidationError : BaseError
    {
        public string Field { get; }
        public string Description { get; }

        public ValidationError(string field, string description)
            => (Field, Description) = (field, description);
    }

    public enum CommonErrors
    {
        NotFound = 1
    }
}
