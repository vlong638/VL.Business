using System;
using VL.Common.DAS.Utilities;
using VL.Common.Protocol.IResult;

namespace VL.User.Service.Utilities
{
    public class ServiceDelegator
    {
        /// <summary>
        /// 整体异常处理
        /// ,日志处理
        /// </summary>
        public static T HandleEvent<T>(Func<T> func) where T : Result, new()
        {
            var result = new T();
            result.ResultCode = EResultCode.Success;
            try
            {
                result = func();
            }
            catch (Exception ex)
            {
                result.ResultCode = EResultCode.Error;
                result.Content = ex.Message;
            }
            LogHelper.LogResult(result);
            return result;
        }
        /// <summary>
        /// 整体异常处理
        /// ,日志处理
        /// ,Simulatable检测
        /// </summary>
        public static T HandleSumilatableEvent<T>(Func<T> func) where T : Result, new()
        {
            var result = new T();
            result.ResultCode = EResultCode.Success;
            try
            {
                if (!ProtocolConfig.IsSimulationAvailable)
                {
                    result.ResultCode = EResultCode.Failure;
                    result.Content = "未开启对Simulation的支持";
                }
                else
                {
                    result = func();
                }
            }
            catch (Exception ex)
            {
                result.ResultCode = EResultCode.Error;
                result.Content = ex.Message;
            }
            LogHelper.LogResult(result);
            return result;
        }

        #region old
        ///// <summary>
        ///// 整体异常处理
        ///// ,日志处理
        ///// </summary>
        //public static Result HandleEvent(Func<Result> func)
        //{
        //    var result = new Result();
        //    result.ResultCode = EResultCode.Success;
        //    try
        //    {
        //        result = func();
        //    }
        //    catch (Exception ex)
        //    {
        //        result.ResultCode = EResultCode.Error;
        //        result.Content = ex.Message;
        //    }
        //    LogHelper.LogResult(result);
        //    return result;
        //}
        ///// <summary>
        ///// 整体异常处理
        ///// ,日志处理
        ///// </summary>
        //public static Result<T> HandleEvent<T>(Func<Result<T>> func)
        //{
        //    var result = new Result<T>();
        //    result.ResultCode = EResultCode.Success;
        //    try
        //    {
        //        result = func();
        //    }
        //    catch (Exception ex)
        //    {
        //        result.ResultCode = EResultCode.Error;
        //        result.Content = ex.Message;
        //    }
        //    LogHelper.LogResult(result);
        //    return result;
        //}
        ///// <summary>
        ///// 整体异常处理
        ///// ,日志处理
        ///// ,Simulatable检测
        ///// </summary>
        //public static Result HandleSumilatableEvent(Func<Result> func)
        //{
        //    var result = new Result();
        //    result.ResultCode = EResultCode.Success;
        //    try
        //    {
        //        if (!ProtocolConfig.IsSimulationAvailable)
        //        {
        //            result.ResultCode = EResultCode.Failure;
        //            result.Content = "未开启对Simulation的支持";
        //        }
        //        else
        //        {
        //            result = func();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.ResultCode = EResultCode.Error;
        //        result.Content = ex.Message;
        //    }
        //    LogHelper.LogResult(result);
        //    return result;
        //}
        ///// <summary>
        ///// 整体异常处理
        ///// ,日志处理
        ///// ,Simulatable检测
        ///// </summary>
        //public static Result<T> HandleSumilatableEvent<T>(Func<Result<T>> func)
        //{
        //    var result = new Result<T>();
        //    result.ResultCode = EResultCode.Success;
        //    try
        //    {
        //        if (!ProtocolConfig.IsSimulationAvailable)
        //        {
        //            result.ResultCode = EResultCode.Failure;
        //            result.Content = "未开启对Simulation的支持";
        //        }
        //        else
        //        {
        //            result = func();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.ResultCode = EResultCode.Error;
        //        result.Content = ex.Message;
        //    }
        //    LogHelper.LogResult(result);
        //    return result;
        //} 
        #endregion
    }
}
