using Core.Util.Enum;

namespace Core.Utils
{
    public  interface IResult
    {
        ResultStatus Status { get; }
        string Message { get; }
    }
}
