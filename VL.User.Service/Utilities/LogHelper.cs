using System;
using VL.Common.Logger.Objects;
using VL.Common.Logger.Utilities;
using VL.Common.Protocol.IResult;

namespace VL.User.Service.Utilities
{
    public class LogHelper
    {
        public static ILogger ServiceLogger = LoggerProvider.GetTextLogger("ServiceLog.txt", Environment.CurrentDirectory + "/ServiceLogs");

        public static void LogResult(Result result)
        {
            try
            {
                if (result.ResultCode == EResultCode.Success)
                    return;
                if (result.ResultCode == EResultCode.Failure)
                    ServiceLogger.Info(result.Content);
                if (result.ResultCode == EResultCode.Error)
                    ServiceLogger.Error(result.Content);
            }
            catch// (Exception ex)
            {
                //日志不影响功能
            }
        }
    }
}
