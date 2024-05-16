using System.Net;
using System.Text.Json.Serialization;

namespace NetBootcamp.API.SharedDTOs
{
    public struct NoContent;

    public record ResponseModelDto<T>
    {
        public T? Data { get; init; }

        [JsonIgnore] public bool IsSuccess { get; init; }

        public List<string>? FailMessages { get; init; }

        [JsonIgnore] public HttpStatusCode StatusCode { get; set; }

        public static ResponseModelDto<T> Success(T data, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ResponseModelDto<T>
            {
                Data = data,
                IsSuccess = true,
                StatusCode = statusCode,
            };
        }

        public static ResponseModelDto<T> Success(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ResponseModelDto<T>()
            {
                IsSuccess = true,
                StatusCode = statusCode,
            };
        }

        public static ResponseModelDto<T> Fail(List<string> messages, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ResponseModelDto<T>()
            {
                IsSuccess = false,
                FailMessages = messages,
                StatusCode = statusCode
            };
        }

        public static ResponseModelDto<T> Fail(string messages, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ResponseModelDto<T>()
            {
                IsSuccess = false,
                FailMessages = new List<string> { messages },
                StatusCode = statusCode
            };
        }
    }
}
