using Lab_MVC_WebApI.Enum;

public class BaseResponse<T>
{
    public ErrorCode ErrorCode { get; set; } 
    public string Message { get; set; }
    public T Data { get; set; }

    public BaseResponse(ErrorCode errorCode, string message, T data)
    {
        ErrorCode = errorCode;
        Message = message;
        Data = data;
    }
}

public class BaseResponse
{
    public ErrorCode ErrorCode { get; set; }
    public string Message { get; set; }
    
    public BaseResponse(ErrorCode errorCode, string message)
    {
        ErrorCode = errorCode;
        Message = message;
    }
}