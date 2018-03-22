using System;
using System.IO;
using VL.Common.Core.DAS;
using VL.Common.Logger;

namespace VL.Common.Testing.Utilities
{
    class TransactionHelper
    {
        /// <summary>
        /// 封装了事务处理的方法
        /// 只需专注于业务逻辑的实现
        /// </summary>
        public static void HandleTransactionEvent(string sessionString, Action<DbSession> action,Action<Exception> onError=null)
        {
            using (var session1 = new DbSession(EDatabaseType.SQLite, sessionString))
            {
                session1.IsLogQuery = true;
                //业务逻辑处理
                try
                {
                    session1.Open();
                    session1.BeginTransaction();
                    try
                    {
                        action(session1);
                        session1.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        session1.RollBackTransaction();
                        if (onError != null)
                        {
                            onError(ex);

                            var dllLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
                            var logger = new TextLogger("PmLogger.txt", dllLocation.Substring(0, dllLocation.LastIndexOf("\\")));
                            logger.Error(ex.ToString());
                        }
                    }
                    session1.Close();
                }
                catch (Exception ex)
                {
                    if (session1 != null && session1.Connection.State == System.Data.ConnectionState.Open)
                        session1.Close();
                    if (onError != null)
                    {
                        onError(ex);

                        var dllLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
                        var logger = new TextLogger("PmLogger.txt", dllLocation.Substring(0, dllLocation.LastIndexOf("\\")));
                        logger.Error(ex.ToString());
                    }
                }
            }
        }
    }
}
