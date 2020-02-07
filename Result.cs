using XPServerBL.Utils;

namespace XPServerBL.HelperClasses
{
    public struct Result
    {
        public bool Success { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public (string Code, string Message) ErrorInfo { get { return (Code, Message); } }

        public Result((string Code, string Message) errorInfo = default, bool success = false)
        {
            Success = success;
            Code = errorInfo.Code ?? string.Empty;
            Message = errorInfo.Message ?? string.Empty;
        }

        public void Deconstruct(out bool success, out string code, out string message)
        {
            success = Success;
            code = Code;
            message = Code;
        }
    };

    public struct Result<T>
    {
        public bool Success { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public (string Code, string Message) ErrorInfo { get { return (Code, Message); } }
        public T Obj { get; set; }

        public Result(bool success, (string Code, string Message) errorInfo = default, T obj = default)
        {
            Success = success;
            Code = errorInfo.Code ?? string.Empty;
            Message = errorInfo.Message ?? string.Empty;
            Obj = obj;
        }

        public Result(T obj)
        {
            Success = true;
            Code = Results.Ok.Code;
            Message = Results.Ok.Message;
            Obj = obj;
        }

        public static implicit operator Result<T>(Result r) => new Result<T> (false, r.ErrorInfo);

        public void Deconstruct(out bool success, out string code, out string message, out T obj)
        {
            success = Success;
            code = Code;
            message = Code;
            obj = Obj;
        }
    }
}