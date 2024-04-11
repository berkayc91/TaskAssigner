namespace Core.Utils
{
    public interface IDataResult<out T> : IResult 
    {
        T Data { get; }
    }
}
