using Newtonsoft.Json;

namespace API.Model
{
    public class ApiResult
    {
        public ApiResult(object data = null) {
            Success = true;
            Message = "Operação realizada com sucesso";
            Data = data;
        }

        public ApiResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        [JsonProperty("success")]
        public bool Success { get; private set; } = true;

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
    }
}
