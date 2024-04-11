using Core.Util.Enum;

namespace Core.Utils
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(ResultStatus.Error, message)
        {

        }

        public ErrorResult() : base(ResultStatus.Error)
        {

        }
    }
}
