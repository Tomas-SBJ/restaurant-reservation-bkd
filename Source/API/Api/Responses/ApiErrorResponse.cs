namespace API.Api.Responses;

public class ApiErrorResponse
{
    public List<ErrorModel> Errors { get; set; } = [];

    public void AddError(string type, string error, string details)
    {
        Errors.Add(new ErrorModel(type, error, details));
    }
}

public record ErrorModel(string Property, string Error, string StatusCode);