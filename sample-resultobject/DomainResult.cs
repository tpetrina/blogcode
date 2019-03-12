namespace sample_resultobject
{
    public class DomainResult<TResult> : ResultObject<TResult, BaseError>
    {
        public DomainResult(TResult result) : base(result) { }
        public DomainResult(BaseError error) : base(error) { }

        public static implicit operator DomainResult<TResult>(TResult result) => new DomainResult<TResult>(result);
        public static implicit operator DomainResult<TResult>(BaseError error) => new DomainResult<TResult>(error);
        public static implicit operator DomainResult<TResult>(string errorMessage) => new DomainResult<TResult>(new GenericError(errorMessage));
        public static implicit operator DomainResult<TResult>(CommonErrors commonError) => new DomainResult<TResult>(new CommonError(commonError));
    }
}
