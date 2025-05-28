namespace TaskManager.Application.Models;

public class ResultViewModel
{
    public ResultViewModel(bool isSuccess = true, string message = "")
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public bool IsSuccess { get; }
    public string Message { get; }

    public static ResultViewModel Success(string? message = null)
        => new(true, message ?? string.Empty);

    public static ResultViewModel Error(string message)
        => new(false, message);
}

public class ResultViewModel<T> : ResultViewModel
{
    public ResultViewModel(T? data, bool isSuccess = true, string message = "")
        : base(isSuccess, message)
    {
        Data = data;
    }

    public T? Data { get; }

    public static ResultViewModel<T> Success(T data, string? message = null)
        => new(data, true, message ?? string.Empty);

    public static ResultViewModel<T> Failure(string message)
        => new(default, false, message);
}
