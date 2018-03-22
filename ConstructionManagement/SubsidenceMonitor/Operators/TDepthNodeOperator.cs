﻿using PmSoft.ConstructionManagement.SubsidenceMonitor.Entities;
using PmSoft.ConstructionManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace PmSoft.ConstructionManagement.SubsidenceMonitor.Operators
{
    public static partial class EntityOperator
    {
        #region TDetail
        public static void FetchDepthNodes(this TDetail entity, SQLiteConnection connection)
        {
            var command = connection.CreateCommand();
            var node = new TDepthNode();
            var nodeElement = new TDepthNodeElement();
            string tableSuffix = "n.";
            List<KeyOperatorValue> wheres = new List<KeyOperatorValue>();
            wheres.Add(new KeyOperatorValue(tableSuffix + nameof(entity.Segregation), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(UniqueIdHelper.UniqueIdStr)));
            wheres.Add(new KeyOperatorValue(tableSuffix + nameof(entity.IssueDateTime), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(entity.IssueDateTime)));
            wheres.Add(new KeyOperatorValue(tableSuffix + nameof(entity.IssueType), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString<EIssueType>(entity.IssueType)));
            //0711TODO KO 需增加ElementIds的关联表加载处理
            command.CommandText = SQLiteHelper.GetSQLiteQuery_SelectWithJoin($"n.*,ne.{nameof(nodeElement.ElementIds)}", $"{node.TableName} n left join {nodeElement.TableName} ne on n.{nameof(node.Segregation)}=ne.{nameof(nodeElement.Segregation)} and n.{nameof(node.NodeCode)}=ne.{nameof(nodeElement.NodeCode)} and n.{nameof(node.Depth)}=ne.{nameof(nodeElement.Depth)}", wheres);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                entity.DepthNodes.Add(new TDepthNode(reader));
            }
        }
        #endregion

        #region Methods
        public static bool DbInsert(this TDepthNode entity, SQLiteConnection connection)
        {
            var command = connection.CreateCommand();
            Dictionary<string, string> NameValues = new Dictionary<string, string>();
            NameValues.Add(nameof(entity.Segregation), SQLiteHelper.ToSQLiteString(UniqueIdHelper.UniqueIdStr));
            NameValues.Add(nameof(entity.IssueType), SQLiteHelper.ToSQLiteString<EIssueType>(entity.IssueType));
            NameValues.Add(nameof(entity.IssueDateTime), SQLiteHelper.ToSQLiteString(entity.IssueDateTime));
            NameValues.Add(nameof(entity.NodeCode), SQLiteHelper.ToSQLiteString(entity.NodeCode));
            NameValues.Add(nameof(entity.Depth), SQLiteHelper.ToSQLiteString(entity.Depth));
            NameValues.Add(nameof(entity.Data), SQLiteHelper.ToSQLiteString(entity.Data));
            NameValues.Add(SQLiteHelper.ToSQLiteReservedField(nameof(entity.Index)), SQLiteHelper.ToSQLiteString(entity.Index));
            command.CommandText = SQLiteHelper.GetSQLiteQuery_Insert(entity.TableName, NameValues);
            return command.ExecuteNonQuery() == 1;
        }
        public static bool DbInsert(this List<TDepthNode> entities, SQLiteConnection connection)
        {
            foreach (var entity in entities)
            {
                if (!entity.DbInsert(connection))
                    return false;
            }
            return true;
        }
        public static bool DbUpdate(this TDepthNode entity, SQLiteConnection connection)
        {
            var command = connection.CreateCommand();
            Dictionary<string, string> sets = new Dictionary<string, string>();
            sets.Add(nameof(entity.Data), SQLiteHelper.ToSQLiteString(entity.Data));
            sets.Add(SQLiteHelper.ToSQLiteReservedField(nameof(entity.Index)), SQLiteHelper.ToSQLiteString(entity.Index));
            List<KeyOperatorValue> wheres = new List<KeyOperatorValue>();
            wheres.Add(new KeyOperatorValue(nameof(entity.Segregation), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(UniqueIdHelper.UniqueIdStr)));
            wheres.Add(new KeyOperatorValue(nameof(entity.IssueDateTime), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(entity.IssueDateTime)));
            wheres.Add(new KeyOperatorValue(nameof(entity.IssueType), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString<EIssueType>(entity.IssueType)));
            wheres.Add(new KeyOperatorValue(nameof(entity.NodeCode), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(entity.NodeCode)));
            wheres.Add(new KeyOperatorValue(nameof(entity.Depth), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(entity.Depth)));
            command.CommandText = SQLiteHelper.GetSQLiteQuery_Update(entity.TableName, sets, wheres);
            return command.ExecuteNonQuery() == 1;
        }
        public static bool DbUpdate(this List<TDepthNode> entities, SQLiteConnection connection)
        {
            foreach (var entity in entities)
            {
                if (!entity.DbUpdate(connection))
                    return false;
            }
            return true;
        }
        static int dbDeleteByDetailKey(this TDepthNode entity, SQLiteConnection connection)
        {
            var command = connection.CreateCommand();
            List<KeyOperatorValue> wheres = new List<KeyOperatorValue>();
            wheres.Add(new KeyOperatorValue(nameof(entity.Segregation), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(UniqueIdHelper.UniqueIdStr)));
            wheres.Add(new KeyOperatorValue(nameof(entity.IssueDateTime), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(entity.IssueDateTime)));
            wheres.Add(new KeyOperatorValue(nameof(entity.IssueType), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString<EIssueType>(entity.IssueType)));
            command.CommandText = SQLiteHelper.GetSQLiteQuery_Delete(entity.TableName, wheres);
            return command.ExecuteNonQuery();
        }
        public static int DbDeleteByDetailKey(this TDepthNode entity, SQLiteConnection connection)
        {
            return entity.dbDeleteByDetailKey(connection);
        }
        public static bool DbDeleteByDetailKey(this List<TDepthNode> entities, SQLiteConnection connection)
        {
            return entities.First().dbDeleteByDetailKey(connection) == entities.Count();
        }
        static int dbDelete(this TDepthNode entity, SQLiteConnection connection)
        {
            var command = connection.CreateCommand();
            List<KeyOperatorValue> wheres = new List<KeyOperatorValue>();
            wheres.Add(new KeyOperatorValue(nameof(entity.Segregation), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(UniqueIdHelper.UniqueIdStr)));
            wheres.Add(new KeyOperatorValue(nameof(entity.IssueDateTime), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(entity.IssueDateTime)));
            wheres.Add(new KeyOperatorValue(nameof(entity.IssueType), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString<EIssueType>(entity.IssueType)));
            wheres.Add(new KeyOperatorValue(nameof(entity.NodeCode), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(entity.NodeCode)));
            wheres.Add(new KeyOperatorValue(nameof(entity.Depth), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(entity.Depth)));
            command.CommandText = SQLiteHelper.GetSQLiteQuery_Delete(entity.TableName, wheres);
            return command.ExecuteNonQuery();
        }
        public static bool DbDelete(this TDepthNode entity, SQLiteConnection connection)
        {
            return entity.dbDelete(connection) == 1;
        }
        public static bool DbDelete(this List<TDepthNode> entities, SQLiteConnection connection)
        {
            foreach (var entity in entities)
            {
                if (!entity.DbDelete(connection))
                    return false;
            }
            return true;
        }
        public static List<string> GetDepthsByNodeCode(this TDepthNode node, string nodeCode, SQLiteConnection connection)
        {
            var command = connection.CreateCommand();
            List<string> selects = new List<string>();
            selects.Add(nameof(TDepthNode.Depth));
            List<KeyOperatorValue> wheres = new List<KeyOperatorValue>();
            wheres.Add(new KeyOperatorValue(nameof(TDepthNode.Segregation), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(UniqueIdHelper.UniqueIdStr)));
            wheres.Add(new KeyOperatorValue(nameof(TDepthNode.NodeCode), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(nodeCode)));
            command.CommandText = SQLiteHelper.GetSQLiteQuery_Select(selects, new TDepthNode().TableName, wheres, "distinct");
            var reader = command.ExecuteReader();
            List<string> results = new List<string>();
            while (reader.Read())
                results.Add(reader[nameof(TDepthNode.Depth)].ToString());
            return results;
        }
        public static List<DateTimeValue> GetDateTimeValues(this TDepthNode entity, EIssueType issueType, string nodeCode, string depth, string fieldName, DateTime startTime, int daySpan, SQLiteConnection connection)
        {
            var command = connection.CreateCommand();
            List<string> selects = new List<string>();
            selects.Add(nameof(entity.Data));
            selects.Add(nameof(entity.IssueDateTime));
            List<KeyOperatorValue> wheres = new List<KeyOperatorValue>();
            wheres.Add(new KeyOperatorValue(nameof(entity.Segregation), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(UniqueIdHelper.UniqueIdStr)));
            wheres.Add(new KeyOperatorValue(nameof(entity.IssueType), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString<EIssueType>(issueType)));
            wheres.Add(new KeyOperatorValue(nameof(entity.NodeCode), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(nodeCode)));
            wheres.Add(new KeyOperatorValue(nameof(entity.Depth), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(depth)));
            wheres.Add(new KeyOperatorValue(nameof(entity.IssueDateTime), SQLiteOperater.GTorEq, SQLiteHelper.ToSQLiteString(startTime)));
            wheres.Add(new KeyOperatorValue(nameof(entity.IssueDateTime), SQLiteOperater.LTorEq, SQLiteHelper.ToSQLiteString(startTime.AddDays(daySpan))));
            command.CommandText = SQLiteHelper.GetSQLiteQuery_Select(selects, entity.TableName, wheres);
            var reader = command.ExecuteReader();
            List<DateTimeValue> results = new List<DateTimeValue>();
            switch (fieldName)
            {
                case nameof(SkewBackDataV1.CurrentChange):
                    while (reader.Read())
                    {
                        var time = DateTime.Parse(reader[nameof(entity.IssueDateTime)].ToString());
                        var data = new SkewBackDataV1(nodeCode, depth, reader[nameof(entity.Data)].ToString());
                        double value;
                        if (double.TryParse(data.CurrentChange, out value))
                            results.Add(new DateTimeValue(time, value));
                    }
                    break;
                case nameof(SkewBackDataV1.CurrentSum):
                    while (reader.Read())
                    {
                        var time = DateTime.Parse(reader[nameof(entity.IssueDateTime)].ToString());
                        var data = new SkewBackDataV1(nodeCode, depth, reader[nameof(entity.Data)].ToString());
                        double value;
                        if (double.TryParse(data.CurrentSum, out value))
                            results.Add(new DateTimeValue(time, value));
                    }
                    break;
                case nameof(SkewBackDataV1.PreviousChange):
                    while (reader.Read())
                    {
                        var time = DateTime.Parse(reader[nameof(entity.IssueDateTime)].ToString());
                        var data = new SkewBackDataV1(nodeCode, depth, reader[nameof(entity.Data)].ToString());
                        double value;
                        if (double.TryParse(data.PreviousChange, out value))
                            results.Add(new DateTimeValue(time, value));
                    }
                    break;
                case nameof(SkewBackDataV1.PreviousSum):
                    while (reader.Read())
                    {
                        var time = DateTime.Parse(reader[nameof(entity.IssueDateTime)].ToString());
                        var data = new SkewBackDataV1(nodeCode, depth, reader[nameof(entity.Data)].ToString());
                        double value;
                        if (double.TryParse(data.PreviousSum, out value))
                            results.Add(new DateTimeValue(time, value));
                    }
                    break;
                default:
                    break;
            }
            return results;
        }
        #endregion
    }
}
