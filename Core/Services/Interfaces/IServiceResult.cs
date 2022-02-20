using Core;
using System.Collections.Generic;

namespace Core.Services.Interfaces
{

    public interface IServiceResult
    {
        bool IsSuccess { get; }
        List<IServiceError> Errors { get; }
    }
    public interface IServiceResult<TResult> : IServiceResult
    {
        TResult Result { get; set; }
    }
}
