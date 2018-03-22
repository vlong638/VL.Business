using System;
using VL.Common.Core.DAS;
using VL.Common.Core.ORM;
using VL.Common.Core.Protocol;
using VL.Common.Core.Object.Subsidence;
using VL.Common.Testing.Utilities;
using PmSoft.ConstructionManagement.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Subsidence.Business
{
    public static class TEarthworkBlockingDomain
    {
        /// <summary>
        /// ���ع�����������������
        /// </summary>
        /// <param name="tEarthworkBlocking"></param>
        /// <param name="session"></param>
        public static void LoadSolid(this TEarthworkBlocking tEarthworkBlocking, DateTime issueTime)
        {
            TransactionHelper.HandleTransactionEvent(SQLiteHelper.GetConnectingString(), (session) =>
            {
                tEarthworkBlocking.IssueDateTime = issueTime.Date;
                //����TEarthworkBlocking;
                if (tEarthworkBlocking.DbLoad(session))//����TEarthworkBlocking�¼�����
                {
                    tEarthworkBlocking.FetchEarthworkBlocks(session);
                    foreach (TEarthworkBlock earthworkBlock in tEarthworkBlocking.EarthworkBlocks)
                    {
                        if (earthworkBlock.FetchEarthworkBlockElements(session))
                        {
                            foreach (var earthworkBlockElements in earthworkBlock.EarthworkBlockElements)
                            {
                                earthworkBlock.ElementIds.AddRange(earthworkBlockElements.ElementIds.Split(',').Select(c => Convert.ToInt32(c)));
                            }
                            if (earthworkBlock.ElementIds.Count() > 0)
                            {
                                earthworkBlock.CPSettings_Obj.ApplySetting(tEarthworkBlocking, earthworkBlock.ElementIds.Select(c => new Autodesk.Revit.DB.ElementId(c)).ToList());
                            }
                        }
                    }
                    tEarthworkBlocking.EarthworkBlocks = tEarthworkBlocking.EarthworkBlocks.OrderBy(c => c.Indexer).ToList();
                }
                else
                {
                    tEarthworkBlocking = new TEarthworkBlocking();
                }
            });
            tEarthworkBlocking.ColorForUnsettled_Color = ColorTranslator.FromHtml(tEarthworkBlocking.ColorForUnsettled);
            tEarthworkBlocking.ColorForSettled_Color = ColorTranslator.FromHtml(tEarthworkBlocking.ColorForSettled);
        }

        /// <summary>
        /// �ύ����
        /// </summary>
        /// <param name="tEarthworkBlocking"></param>
        /// <param name="issueTime"></param>
        public static void Commit(this TEarthworkBlocking tEarthworkBlocking,DateTime issueTime)
        {
            TransactionHelper.HandleTransactionEvent(SQLiteHelper.GetConnectingString(), (session) =>
            {
                tEarthworkBlocking.IssueDateTime = issueTime.Date;
                //������
                bool isExist;
                isExist = tEarthworkBlocking.CheckExistence(session, issueTime);
                if (!isExist)//����
                {
                    tEarthworkBlocking.DbInsert(session);
                }
                else//����
                {
                    tEarthworkBlocking.DbUpdate(session);
                }
                tEarthworkBlocking.DeleteEarthworkBlock(session);
                foreach (var earthworkBlock in tEarthworkBlocking.EarthworkBlocks)
                {
                    earthworkBlock.Indexer = (short)tEarthworkBlocking.EarthworkBlocks.IndexOf(earthworkBlock);
                    earthworkBlock.IssueDateTime = issueTime;
                    earthworkBlock.DbInsert(session);
                    earthworkBlock.DeleteEarthworkBlockElements(session);
                    earthworkBlock.InsertEarthworkBlockElements(session);
                }
                tEarthworkBlocking.Adds.Clear();
                tEarthworkBlocking.Deletes.Clear();
            });
        }

        /// <summary>
        /// ɾ�� TEarthworkBlocking ������ TEarthworkBlock
        /// </summary>
        /// <param name="tEarthworkBlocking"></param>
        /// <param name="session"></param>
        public static void DeleteEarthworkBlock(this TEarthworkBlocking tEarthworkBlocking, DbSession session)
        {
            var query = session.GetDbQueryBuilder().DeleteBuilder;
            query.ComponentWhere.Add(TEarthworkBlockProperties.IssueDateTime, tEarthworkBlocking.IssueDateTime, LocateType.Equal);
            var @operator = session.GetQueryOperator();
            @operator.Delete<TEarthworkBlock>(query);
        }


        /// <summary>
        /// ��⵱�ڵ�TEarthworkBlocking�Ƿ����
        /// </summary>
        /// <param name="issueTime"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public static bool CheckExistence(this TEarthworkBlocking tEarthworkBlocking, DbSession session, DateTime issueTime)
        {
            bool isExist;
            var query = session.GetDbQueryBuilder().SelectBuilder;
            query.ComponentSelect.Add("1");
            query.ComponentWhere.Add(TEarthworkBlockingProperties.IssueDateTime, issueTime, LocateType.Equal);
            var @operator = session.GetQueryOperator();
            var result = @operator.SelectAsBool<TEarthworkBlocking>(query);
            isExist = result.HasValue ? result.Value : false;
            return isExist;
        }

        /// <summary>
        /// ��ȡ���µ�����ʱ��,��ʱΪnull
        /// </summary>
        /// <returns></returns>
        public static DateTime GetLatestIssueTime(this TEarthworkBlocking tEarthworkBlocking)
        {
            DateTime issueTime = DateTime.MinValue;
            TransactionHelper.HandleTransactionEvent(SQLiteHelper.GetConnectingString(), (session) =>
            {
                var query = session.GetDbQueryBuilder().SelectBuilder;
                query.ComponentSelect.Add($"max(IssueDateTime)");
                var result = session.GetQueryOperator().SelectAsDateTime<TEarthworkBlocking>(query);
                issueTime = result.HasValue ? result.Value : DateTime.MinValue;
            });
            return issueTime;
        }


        /// <summary>
        /// ��ȡ��һ��������ʱ��,��ʱΪ DateTime.MinValue
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNextIssueTime(this TEarthworkBlocking tEarthworkBlocking, DateTime issueDate)
        {
            DateTime issueTime = DateTime.MinValue;
            TransactionHelper.HandleTransactionEvent(SQLiteHelper.GetConnectingString(), (session) =>
            {
                var query = session.GetDbQueryBuilder().SelectBuilder;
                query.ComponentSelect.Add($"min(IssueDateTime)");
                query.ComponentWhere.Add(TEarthworkBlockingProperties.IssueDateTime, issueDate, LocateType.GreatThan);
                var result = session.GetQueryOperator().SelectAsDateTime<TEarthworkBlocking>(query);
                issueTime = result.HasValue ? result.Value : DateTime.MinValue;
            });
            return issueTime;
        }
        /// <summary>
        /// ��ȡ���µ�����ʱ��,��ʱΪ DateTime.MinValue
        /// </summary>
        /// <returns></returns>
        public static DateTime GetPreviousIssueTime(this TEarthworkBlocking tEarthworkBlocking,DateTime issueDate)
        {
            DateTime issueTime = DateTime.MinValue;
            TransactionHelper.HandleTransactionEvent(SQLiteHelper.GetConnectingString(), (session) =>
            {
                var query = session.GetDbQueryBuilder().SelectBuilder;
                query.ComponentSelect.Add($"max(IssueDateTime)");
                query.ComponentWhere.Add(TEarthworkBlockingProperties.IssueDateTime, issueDate, LocateType.LessThan);
                var result = session.GetQueryOperator().SelectAsDateTime<TEarthworkBlocking>(query);
                issueTime = result.HasValue ? result.Value : DateTime.MinValue;
            });
            return issueTime;
        }
    }
}
