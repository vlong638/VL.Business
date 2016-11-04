using System;
using VL.Common.DAS.Objects;
using VL.Common.Logger.Utilities;
using VL.Common.Protocol.IService;
using VL.User.Objects.Entities;
using VL.User.Objects.SubResults;
using VL.User.Service.Configs;
using VL.User.Service.Utilities;

namespace VL.User.Service.DomainEntities
{
    public class SubjectOperator: ISubjectUserService
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
        #endregion
        public Report CreateUser(TUser user)
        {
            return ServiceContext.ServiceDelegator.HandleTransactionEvent(DbConfigOfUser.DbName,(session)=>
            {
                return user.Create(session);
            });
        }

        public Report AuthenticateUser(TUser user)
        {
            return ServiceContext.ServiceDelegator.HandleTransactionEvent(DbConfigOfUser.DbName, (session) =>
            {
                return user.Authenticate(session);
            });
        }
    }
}
