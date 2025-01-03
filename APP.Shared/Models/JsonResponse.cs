﻿
namespace App.Shared.Models
{
    public class JsonResponse
    {
        private string _message { get; set; }
        public bool IsSuccess { get; set; } = false;
        public bool IsValidSubmissionNO { get; set; }
        public bool IsValid { get; set; }
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    if (IsSuccess)
                    {
                        _message = ATTMessages.RECORD_FOUND;

                    }
                    else if (ErrorTrap)
                    {
                        _message = ATTMessages.GENERIC_ERROR;
                    }
                    else
                    {
                        _message = ATTMessages.NO_RECORDS_FOUND;
                    }

                }
                else
                {
                    _message = value;
                }
            }
        }
        public dynamic data { get; set; }
        public string Token { get; set; }
        public object ResponseData { get; set; }
        public object Records { get; set; }
        public string OutputParam { get; set; }
        public object TotalRecords { get; set; }
        public string CallBack { get; set; }
        public bool IsToken { get; set; }
        public string ProfileImage { get; set; }
        public bool HasError { get; set; }
        public bool HasPasswordChanged { get; set; }
        public bool ErrorTrap { get; set; }
        public object ResponseData2 { get; set; }

        public object ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public JsonResponse ServerError(Exception? ex = null)
        {
            if (ex != null)
            {
                Message=ex.Message;
                ErrorTrap = true;
            }
            return this;
        }

        public JsonResponse SuccessResponse()
        {
            IsSuccess = true;
            return this;
        }
        public JsonResponse BadRequest( string? msg=null)
        {
            IsValid = false;
            Message = msg ?? "Validation Error.";
            return this;
        }
    }

}
