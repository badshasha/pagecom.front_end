namespace pagecom.mvc.application.Dto.SendandResive;

public class ResponseDto
{
    public bool IsSuccess { get; set; }
    public object? Result { get; set; }
    public List<string>? Error { get; set; }
    public string Message { get; set; }
}