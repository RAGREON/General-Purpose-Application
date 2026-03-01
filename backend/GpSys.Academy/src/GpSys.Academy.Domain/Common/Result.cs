namespace GpSys.Academy.Domain.Common
{
  public class Result<T> 
  {
    public bool IsSuccess { get; }
    public T? Value { get; }
    public string ErrorMessage { get; }
    public IList<Error> Errors { get; } = [];

    protected Result(bool isSuccess, T? value, string errorMessage, IList<Error>? errors = null)
    {
      IsSuccess = isSuccess;
      Value = value;
      ErrorMessage = errorMessage;
      Errors = errors ?? [];
    }

    public static Result<T> Success(T value) => new(true, value, string.Empty);
    public static Result<T> Failure(string errorMessage) => new(false, default, errorMessage);
    public static Result<T> Failure(IList<Error> errors) => new(false, default, "Multiple errors occured.", errors);
  }
}