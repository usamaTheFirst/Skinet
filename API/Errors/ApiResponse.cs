﻿namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode,string message=null )
        {
            this.Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            StatusCode = statusCode;
        }

        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 =>
                    "Errors are the path to the dark side. Errors lead to Anger. Anger leads to hate. Hate Leads to career change.,"
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
