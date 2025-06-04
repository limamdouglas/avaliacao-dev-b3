namespace AvaliacaoDevCalculoCDB.Domain.Dtos.v1.Response;

public class Response<T>(int StatusCode, string Message, T? Data = default)
{
    public int StatusCode { get; } = StatusCode;
    public string Message { get; } = Message;
    public T? Data { get; } = Data;
}