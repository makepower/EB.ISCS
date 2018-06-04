using AutoMapper;
using EB.ISCS.ToolService.Adapter;
using Hangfire;
using Maticsoft.Model.ISSC;
using System;
using System.Collections.Generic;
using Top.Api.Domain;

namespace EB.ISCS.ToolService
{
    /// <summary>
    /// 任务调度池
    /// </summary>
    public class EBJobScheduler
    {
        private TradeSyncContextService tradeSyncContextService;
        private string _constr = null;

        private List<UserSyncContext> syncList = null;


        public EBJobScheduler(string constr)
        {
            _constr = constr;
            tradeSyncContextService = new TradeSyncContextService(constr);
        }

        /// <summary>
        /// 初始化调度计划
        /// </summary>
        public bool Start()
        {
            try
            {
                FrameworkLog.LogModel.LogHelper.WriteInfoLog($"开始启动任务调度");
                tradeSyncContextService.BuildContext();
                syncList = tradeSyncContextService.SyncContext.Context;

                syncList.ForEach(x =>
                {
                    var syncService = new TradeSyncService(_constr);
                    x.TaskId = Guid.NewGuid().ToString();
                    RecurringJob.AddOrUpdate(x.TaskId, () => syncService.DoJob(x.Shops), Cron.HourInterval(x.SyncPeriodHours));
                });
                FrameworkLog.LogModel.LogHelper.WriteInfoLog($"启动任务调度完毕");
                return true;
            }
            catch (Exception ex)
            {
                FrameworkLog.LogModel.LogHelper.WriteErrorLog($"启动任务调度失败", ex);
                return false;
            }
        }

        /// <summary>
        /// 重新载入调度 
        /// </summary>
        public bool ReStart()
        {
            try
            {
                Stop();
                Start();
                return true;
            }
            catch (Exception ex)
            {
                FrameworkLog.LogModel.LogHelper.WriteErrorLog($"重新启动任务调度失败", ex);
                return false;
            }

        }

        /// <summary>
        /// 根据用户重新载入任务
        /// </summary>
        /// <returns></returns>
        public bool ReloadByUserId(params int[] userIds)
        {
            try
            {
                var syncService = new TradeSyncService(_constr);
                tradeSyncContextService.BuildContext(userIds);
                var array = tradeSyncContextService.SyncContext;
                array.Context.ForEach(x =>
                {
                    var tmp = syncList.Find(y => y.UserId == x.UserId);
                    if (tmp != null)
                    {
                        RecurringJob.RemoveIfExists(tmp.TaskId);
                    }
                    else
                    {
                        x.TaskId = Guid.NewGuid().ToString();
                        syncList.Add(x);
                    }
                    RecurringJob.AddOrUpdate(x.TaskId, () => syncService.DoJob(x.Shops), Cron.HourInterval(x.SyncPeriodHours));

                });
                return true;
            }
            catch (Exception ex)
            {
                FrameworkLog.LogModel.LogHelper.WriteErrorLog($"根据用户重新载入任务", ex);
                return false;
            }
        }

        public void Stop()
        {
            syncList.ForEach(x =>
            {
                RecurringJob.RemoveIfExists(x.TaskId);
            });
        }
    }
}
