using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project1.Controllers
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;

        public T? Data { get; set; }

        public List<string>? Error { get; set; }

        public int StatusCode { get; set; }

        public DateTime TimeStamp { get; set; }

        public ApiResponse(T data, int statusCode, string message = "")
        {
            Success = true;
            Message = message;
            Data = data;
            Error = null;
            StatusCode = statusCode;
            TimeStamp = DateTime.UtcNow;
        }
    }
}