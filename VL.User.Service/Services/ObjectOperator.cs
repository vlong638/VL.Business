using System;
using System.Collections.Generic;
using VL.Common.DAS.Objects;
using VL.Common.Logger.Utilities;
using VL.Common.Protocol.IService;
using VL.User.Objects.Entities;
using VL.User.Service.Configs;
using VL.User.Service.Utilities;

namespace VL.User.Service.DomainEntities
{
    public class ObjectOperator: IObjectUserService
    {
        #region 服务基础
        static ServiceContextOfUser _serviceContext;
        static Object ServiceLock = new object();
        static ServiceContextOfUser ServiceContext
        {
            get
            {
                if (_serviceContext == null)
                {
                    lock (ServiceLock)
                    {
                        try
                        {
                            if (_serviceContext == null)
                            {
                                _serviceContext = new ServiceContextOfUser();
                            }
                            _dependencyResult = _serviceContext.Init();
                        }
                        catch (Exception ex)
                        {
                            LoggerProvider.GetLog4netLogger(ServiceContextOfUser.DefaultLogName).Error(ex.ToString());
                        }
                    }
                }
                return _serviceContext;
            }
        }
        static DependencyResult _dependencyResult;
        static DependencyResult DependencyResult
        {
            get
            {
                if (ServiceContext != null)
                    return _dependencyResult;
                else
                    return null;
            }
        }
        public bool CheckAlive()
        {
            return DependencyResult.IsAllDependenciesAvailable;
        }
        public DependencyResult CheckNodeReferences()
        {
            return DependencyResult;
        }
        //static ServiceContextOfUser ServiceContext { set; get; }
        //static DependencyResult DependencyResult { set; get; }

        //public bool CheckAlive()
        //{
        //    var result = CheckNodeReferences();
        //    return result.IsAllDependenciesAvailable;
        //}
        //public DependencyResult CheckNodeReferences()
        //{
        //    try
        //    {
        //        if (DependencyResult == null)
        //        {
        //            ServiceContext = new ServiceContextOfUser();
        //        }
        //        DependencyResult = ServiceContext.Init();
        //    }
        //    catch (Exception ex)
        //    {
        //        LoggerProvider.GetLog4netLogger(ServiceContextOfUser.DefaultLogName).Error(ex.ToString());
        //    }
        //    return DependencyResult;
        //}
        #endregion

        public Report<List<TUser>> GetAllUsers()
        {
            return ServiceContext.ServiceDelegator.HandleTransactionEvent(DbConfigOfUser.DbName, (session) =>
            {
                Report<List<TUser>> result = new Report<List<TUser>>();
                result.Data = new List<TUser>().DbSelect(session);
                return result;
            });
        }
    }
}
