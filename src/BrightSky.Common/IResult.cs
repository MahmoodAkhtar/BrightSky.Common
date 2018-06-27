namespace BrightSky.Common
{
    public interface IResult
    {
        string Error { get; }
        bool IsFailure { get; }
        bool IsSuccess { get; }
    }

    public interface IResult<T> : IResult
    {
    }
}