using Core.Util.Enum;

namespace Core.Utils
{
    public class Result : IResult
    {
        public Result(ResultStatus status, string message) : this(status)
        {
            Message = message;
        }

        
        public Result(ResultStatus status)
        {
            Status = status;
        }

       

        public ResultStatus Status { get; }

        public string Message { get; set; }
    }
}
