using Core.Services.Extensions;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services
{
    public class ServiceResult : IServiceResult
    {
        public bool IsSuccess { get { return Errors.Count() == 0; } }
        public List<IServiceError> Errors { get; }

        #region .ctor
        public ServiceResult(int code, string description, Exception exception) : this()
        {
            Errors.Add(code, description, exception);
        }
        public ServiceResult()
        {
            Errors = new List<IServiceError>();
        }
        public ServiceResult(int code) : this(code, null) { }
        public ServiceResult(int code, string description) : this(code, description, null) { }

        #endregion
        public static IServiceResult Success()
        {
            return new ServiceResult();
        }
    }
    public class ServiceResult<TResult> : ServiceResult, IServiceResult<TResult>
    {
        public TResult Result { get; set; }
        public ServiceResult(TResult result) : this()
        {
            Result = result;
        }
        public ServiceResult() : base() { }
        public ServiceResult(TResult result, string description) : this(result, 0, description, null) { }
        public ServiceResult(TResult result, int code, string desription, Exception exception) : base(code, desription, exception)
        {
            Result = result;
        }
    }
}
