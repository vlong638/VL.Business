using System;
using VL.Common.Protocol.IService;
using VL.User.Objects.Entities;
using VL.User.Objects.SubResults;
using VL.User.Service.DomainEntities;

namespace VL.User.Service
{
    /// <summary>
    /// Service是工作单元块,这里负责单元化的工作处理
    /// 以及服务日志的处理(这里将UnitOfWork无关的部分移至ServiceDelegator,仅留下了纯粹的UnitOfWork)
    /// </summary>
    public class UserService : IUserService
    {
        #region 依赖项检测
        ////TODO 这里需要构建一个机制,即服务启动时预检测依赖项(如:日志,其他服务的存活)
        //static UserService()
        //{
        //    ServiceLogHelper.ServiceLogger.Info("服务已启动");
        //    ServiceLogHelper.ServiceLogger.Info("检查依赖项开始");
        //    //配置文件依赖检测
        //    CheckAvailabilityOfConfig();
        //    //数据库依赖检测
        //    CheckAvailabilityOfDbSession(nameof(User));
        //    //服务依赖检测
        //    ServiceLogHelper.ServiceLogger.Info("检查依赖项结束");
        //}

        //private static void CheckAvailabilityOfConfig()
        //{
        //    try
        //    {
        //        ProtocolConfig.Load();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        ////TODO 制定标准的检测规范:数据库依赖检测,服务依赖检测
        //private static void CheckAvailabilityOfDbSession(string dbName)
        //{
        //    try
        //    {
        //        var session = DbConfigs.GetDbSession(dbName);
        //        if (session != null)
        //        {
        //            session.Open();
        //            ServiceLogHelper.ServiceLogger.Info("数据库" + dbName + "连接成功");
        //            session.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceLogHelper.ServiceLogger.Error("数据库" + dbName + "连接失败");
        //        ServiceLogHelper.ServiceLogger.Error("错误详情" + ex.ToString());
        //    }
        //} 
        #endregion

        #region Ordinary Operation
        public Result<CreateUserResult> Register(TUser user)
        {
            return ServiceDelegator.HandleSimpleTransactionEvent(nameof(User), (session) =>
            {
                return new Operator().CreateUser(session, user);
            });
        }
        #endregion

        #region Simulation
        public Result SimulateRegister(TUser user, DateTime simulateTime)
        {
            return ServiceDelegator.HandleSimpleTransactionEvent(nameof(User), (session) =>
            {
                return new Operator().SimulateCreate(session, user, simulateTime);
            }, true);
        }
        #endregion
    }
}
