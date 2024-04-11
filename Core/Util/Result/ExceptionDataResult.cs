using Core.Util.Enum;

namespace Core.Utils
{
    public class ExceptionDataResult<T> : DataResult<T>
    {
        public ExceptionDataResult(T data, Exception exception, bool showException = true)
            : base(data, ResultStatus.Exception,
                showException == true ?
                    (exception != null ? "Exception: " + exception.Message +
                                         (exception.InnerException != null ? " | Inner Exception: " + exception.InnerException.Message +
                                                                             (exception.InnerException.InnerException != null ? " | " + exception.InnerException.InnerException.Message : "")
                                             : "")
                        : "")
                    : "Exception"
                )
        {

        }
        public ExceptionDataResult() : base(default, ResultStatus.Exception, "Exception")
        {

        }


    }
}
