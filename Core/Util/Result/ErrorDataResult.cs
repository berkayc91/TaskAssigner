using Core.Util.Enum;

namespace Core.Utils
{
    public class ErrorDataResult<T>: DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, ResultStatus.Error, message)
        {

        }

        public ErrorDataResult(T data) : base(data, ResultStatus.Error)
        {

        }
    }
}
