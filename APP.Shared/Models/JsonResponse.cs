
using System.Text.Json.Serialization;

namespace App.Shared.Models
{
    
    public class JsonResponse
    {
        private string _message { get; set; }
        public bool IsSuccess { get; set; } = false;
        public bool IsValid { get; set; }
        public bool HasError { get; internal set; }
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
                    else if (HasError)
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
        public object ResponseData { get; set; }
        public object TotalRecords { get; set; }
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
                HasError = true;
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
