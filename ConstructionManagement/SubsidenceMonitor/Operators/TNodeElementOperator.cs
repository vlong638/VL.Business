using PmSoft.ConstructionManagement.SubsidenceMonitor.Entities;
using PmSoft.ConstructionManagement.Utilities;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace PmSoft.ConstructionManagement.SubsidenceMonitor.Operators
{
    public static partial class EntityOperator
    {
        #region TDetail
        //0711TODO KO 需增加ElementIds的关联表加载处理
        public static void FetchNodeElements(this TDetail entity, SQLiteConnection connection)
        {
            var command = connection.CreateCommand();
            var nodeElement = new TNodeElement();
            List<KeyOperatorValue> wheres = new List<KeyOperatorValue>();
            wheres.Add(new KeyOperatorValue(nameof(entity.Segregation), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(UniqueIdHelper.UniqueIdStr)));
            command.CommandText = SQLiteHelper.GetSQLiteQuery_Select(null, $"{nodeElement.TableName}", wheres);
            //var command = connection.CreateCommand();
            //var node = new TNode();
            //var nodeElement = new TNodeElement();
            //string tableSuffix = "n.";
            //List<KeyOperatorValue> wheres = new List<KeyOperatorValue>();
            //wheres.Add(new KeyOperatorValue(tableSuffix + nameof(entity.Segregation), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(UniqueIdHelper.UniqueIdStr)));
            //wheres.Add(new KeyOperatorValue(tableSuffix + nameof(entity.IssueDateTime), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString(entity.IssueDateTime)));
            //wheres.Add(new KeyOperatorValue(tableSuffix + nameof(entity.IssueType), SQLiteOperater.Eq, SQLiteHelper.ToSQLiteString<EIssueType>(entity.IssueType)));
            //command.CommandText = SQLiteHelper.GetSQLiteQuery_SelectWithJoin("ne.*", $"{node.TableName} n left join {nodeElement.TableName} ne on n.{nameof(node.Segregation)}=ne.{nameof(nodeElement.Segregation)} and n.{nameof(node.NodeCode)}=ne.{nameof(nodeElement.NodeCode)}", wheres);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                nodeElement = new TNodeElement(reader);
                var node = entity.Nodes.FirstOrDefault(c => c.NodeCode == nodeElement.NodeCode);
                if (node != null)
                    node.ElementIds = nodeElement.ElementIds;
            }
        }
        #endregion

        public static bool DbInsertOrReplace(this TNodeElement entity, SQLiteConnection session)
        {
            var command = session.CreateCommand();
            Dictionary<string, string> NameValues = new Dictionary<string, string>();
            NameValues.Add(nameof(entity.Segregation), SQLiteHelper.ToSQLiteString(UniqueIdHelper.UniqueIdStr));
            NameValues.Add(nameof(entity.NodeCode), SQLiteHelper.ToSQLiteString(entity.NodeCode));
            NameValues.Add(nameof(entity.ElementIds), SQLiteHelper.ToSQLiteString(entity.ElementIds));
            command.CommandText = SQLiteHelper.GetSQLiteQuery_InsertOrReplace(entity.TableName, NameValues);
            return command.ExecuteNonQuery() == 1;
        }

        public static bool DbInsertOrReplace(this IEnumerable<TNodeElement> entities, SQLiteConnection connection)
        {
            foreach (var entity in entities)
            {
                if (!entity.DbInsertOrReplace(connection))
                    return false;
            }
            return true;
        }
    }
}
