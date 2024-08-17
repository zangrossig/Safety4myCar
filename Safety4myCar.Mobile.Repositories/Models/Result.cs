namespace Safety4myCar.Mobile.Repositories.Models
{
	public sealed class Result<T>
	{
		public bool IsSuccess { get; }

		public T? Data { get; }

		public ResultFailure Failure { get; } = ResultFailure.None;

		public string? ErrorCode { get; }

		private Result(T? data, string? errorCode, ResultFailure failure, bool isSuccess)
		{
			Data = data;
			ErrorCode = errorCode;
			IsSuccess = isSuccess;
			Failure = failure;
		}

		public static Result<T> Success(T data) => new Result<T>(data, null, ResultFailure.None, true);

		public static Result<T> Success() => new Result<T>(default, null, ResultFailure.None, true);

		public static Result<T> Fail(string errorCode, ResultFailure failure) => new Result<T>(default, errorCode, failure, false);
	}

	public enum ResultFailure
	{
		None,
		InternalError,
		RequestFailed,
		NotAuthorized
	}
}