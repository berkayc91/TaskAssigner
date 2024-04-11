using Core.Util.Enum;

namespace Core.Utils
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message):base(data,ResultStatus.Success,message)
        {
                
        }

        public SuccessDataResult(T data) : base(data,ResultStatus.Success) 
        {
                
        }
    }
}
