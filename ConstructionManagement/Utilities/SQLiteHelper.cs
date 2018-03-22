using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using VL.Common.Logger;

namespace PmSoft.ConstructionManagement.Utilities
{
    public class SQLiteHelper
    {
        static string _DbName;

        public static string DbName
        {
            get
            {
                if (string.IsNullOrEmpty(_DbName))
                {
                    var dllLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    _DbName = Path.Combine(dllLocation.Substring(0, dllLocation.LastIndexOf("\\")), "Subsidence.sqlite");
                }
                return _DbName;
            }
            set { _DbName = value; }
        }

        public static SQLiteConnection Connect()
        {
            return new SQLiteConnection(GetConnectingString());
        }

        public static string GetConnectingString()
        {
            //var logger = new TextLogger("PmLogger.txt", @"D:\");
            //logger.Error("输出到了:" + DbName);
            return $"DataSource={DbName};Version=3;";
        }

        #region PrepareTables
        public static void PrepareTables()
        {
            foreach (var key in TableCreateSQLs.Keys)
            {
                if (!IsTableExist(key))
                {
                    CreateTables(key);
                }
            }
        }
        static Dictionary<string, string> TableCreateSQLs = new Dictionary<string, string>()
        {
            { "TEarthworkBlocking",$@"create table TEarthworkBlocking 
(
   IssueDateTime        datetime                       not null,
   EarthworkBlockMaxId  numeric(16)                    not null,
   ColorForUnsettled    varchar(20)                    not null,
   ColorForSettled      varchar(20)                    not null,
   IsImplementationInfoConflicted numeric(1)                     not null,
   constraint PK_TEARTHWORKBLOCKING primary key (IssueDateTime)
);
"},
            { "TEarthworkBlockElement",$@"create table TEarthworkBlockElement 
(
   IssueDateTime        datetime                       not null,
   Id                   numeric(16)                    not null,
   GroupId              numeric(16)                    not null,
   ElementIds           varchar(1000)                  not null,
   constraint PK_TEARTHWORKBLOCKELEMENT primary key (IssueDateTime, Id, GroupId)
);
"},
            { "TEarthworkBlock",$@"
create table TEarthworkBlock 
(
   IssueDateTime        datetime                       not null,
   Id                   numeric(16)                    not null,
   Indexer              numeric(16)                    not null,
   Name                 varchar(100)                   not null,
   Description          varchar(1000)                  not null,
   CPSettings           varchar(1000)                  not null,
   EarthworkBlockImplementationInfo varchar(1000)                  not null,
   constraint PK_TEARTHWORKBLOCK primary key (IssueDateTime, Id)
);"},
            {"TList", $@"
create table TList 
(
   Segregation          varchar(100)                   not null,
   IssueType            numeric(16)                    not null,
   IssueDate            datetime                       not null,
   DataCount            numeric(16)                    not null,
   Constraint pk_List primary key(Segregation,IssueType,IssueDate)
);"
            },
            { "TDetail",$@"
create table TDetail 
(
   Segregation          varchar(100)                   not null,
   IssueType            numeric(8)                     not null,
   IssueDateTime        datetime                       not null,
   IssueTimeRange       numeric(16)                    not null,
   ReportName           varchar(200)                   not null,
   Contractor           varchar(100)                   not null,
   Supervisor           varchar(100)                   not null,
   Monitor              varchar(100)                   not null,
   InstrumentName       varchar(100)                   not null,
   InstrumentCode       varchar(100)                   not null,
   CloseCTSettings      varchar(500)                   not null,
   OverCTSettings       varchar(500)                   not null,
   ExtraValue1          numeric(16)                    null,
   ExtraValue2          numeric(16)                    null,
   ExtraValue3          numeric(16)                    null,
   constraint PK_TDETAIL primary key (Segregation,IssueType, IssueDateTime)
);
            "},
            {"TNode",  $@"
create table TNode 
(
   Segregation          varchar(100)                   not null,
   IssueType            numeric(8)                     not null,
   IssueDateTime        datetime                       not null,
   NodeCode             varchar(20)                    not null,
   Data                 varchar(1000)                  not null,
   [Index]              numeric(16)                    not null,
   constraint PK_TNODE primary key (Segregation,IssueType,IssueDateTime, NodeCode)
);
            "},
            {"TDepthNode",  $@"
create table TDepthNode 
(
   Segregation          varchar(100)                   not null,
   IssueType            numeric(8)                     not null,
   IssueDateTime        datetime                       not null,
   NodeCode             varchar(20)                    not null,
   Depth             varchar(10)                    not null,
   Data                 varchar(1000)                  not null,
   [Index]              numeric(16)                    not null,
   constraint PK_TNODE primary key (Segregation,IssueType,IssueDateTime, NodeCode,Depth)
);
            "},
            {"TNodeElement",  $@"
create table TNodeElement 
(
   Segregation          varchar(36)                    not null,
   NodeCode             varchar(20)                    not null,
   ElementIds           varchar(2000)                  not null,
   constraint PK_TNODEELEMENT primary key (Segregation,NodeCode)
);
            "},
            {"TDepthNodeElement",  $@"
create table TDepthNodeElement
(
   Segregation          varchar(36)                    not null,
   NodeCode             varchar(20)                    not null,
   Depth                varchar(10)                    not null,
   ElementIds           varchar(2000)                  not null,
   constraint PK_TDEPTHNODEELEMENT primary key (Segregation,NodeCode,Depth)
);
            "},

    };
        static bool IsTableExist(string table)
        {
            bool exits = false;
            using (var connection = Connect())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"select 1 from sqlite_master where name='{table}'";
                var result = command.ExecuteScalar();//注意返回的数值为long,不可强制转换为int
                exits = result != null && (long)result == 1;
                connection.Close();
            }
            return exits;
        }
        static void CreateTables(string key)
        {
            CreateTable(TableCreateSQLs.First(c => c.Key == key).Value);
        }
        static void CreateTable(string createSQL)
        {
            using (var connection = Connect())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = createSQL;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        #endregion

        #region SQLite参数处理
        public static string ToSQLiteReservedField(string input)
        {
            return $"[{input}]";
        }
        public static string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        public static string ToSQLiteString(string input)
        {
            return $"'{input}'";
        }
        public static string ToSQLiteString(IEnumerable<string> input)
        {
            return "(" + string.Join(",", input.Select(c => "'" + c + "'")) + ")";
        }
        public static string ToSQLiteString(DateTime input)
        {
            return $"'{input.ToString(DateTimeFormat)}'";
        }
        public static string ToSQLiteString(int input)
        {
            return input.ToString();
        }
        public static string ToSQLiteString(bool input)
        {
            return Convert.ToInt32(input).ToString();
        }
        public static string ToSQLiteString<T>(Enum input)
        {
            return ((int)Enum.Parse(typeof(T), input.ToString())).ToString();
        }


        public static string ToSQLiteSets(Dictionary<string, string> updateSets)
        {
            return string.Join(",", updateSets.Select(c => c.Key + "=" + c.Value));
        }
        public static string ToSQLiteWheres(List<KeyOperatorValue> wheres)
        {
            return string.Join(" and ", wheres.Select(c => c.Key + c.Operator + c.Value));
        }
        /// <param name="selects">null for *</param>
        /// <param name="tableName"></param>
        /// <param name="wheres"></param>
        /// <returns></returns>
        public static string GetSQLiteQuery_Select(List<string> selects, string tableName, List<KeyOperatorValue> wheres,string prefix="",string suffix="")
        {
            var selectsStr = (selects == null || selects.Count == 0 ? "*" : string.Join(",", selects));
            return $"select {prefix} {selectsStr} from {tableName} where {SQLiteHelper.ToSQLiteWheres(wheres)} {suffix}";
        }
        public static string GetSQLiteQuery_SelectWithJoin(string selects, string tableName, List<KeyOperatorValue> wheres, string prefix = "", string suffix = "")
        {
            return $"select {selects} from {tableName} where {SQLiteHelper.ToSQLiteWheres(wheres)} {suffix}";
        }
        public static string GetSQLiteQuery_Insert(string tableName, Dictionary<string, string> insertSets)
        {
            return $"insert into {tableName}({string.Join(",", insertSets.Keys)}) values({string.Join(",", insertSets.Values)})";
        }
        public static string GetSQLiteQuery_InsertOrReplace(string tableName, Dictionary<string, string> insertSets)
        {
            return $"insert or replace into {tableName}({string.Join(",", insertSets.Keys)}) values({string.Join(",", insertSets.Values)})";
        }
        public static string GetSQLiteQuery_Update(string tableName, Dictionary<string, string> updateSets, List<KeyOperatorValue> wheres)
        {
            return $"update {tableName} set {SQLiteHelper.ToSQLiteSets(updateSets)} where {SQLiteHelper.ToSQLiteWheres(wheres)}";
        }
        public static string GetSQLiteQuery_Delete(string tableName, List<KeyOperatorValue> wheres)
        {
            return  $"delete from {tableName}  where {SQLiteHelper.ToSQLiteWheres(wheres)}";
        }
        #endregion
    }
    public enum SQLiteOperater
    {
        Set,
        Eq,
        GT,
        LT,
        GTorEq,
        LTorEq,
        In,
    }
    public static class SQLiteOperaterEx
    {
        public static string GetSQLiteOperatorString(this SQLiteOperater op)
        {
            switch (op)
            {
                case SQLiteOperater.Set:
                case SQLiteOperater.Eq:
                    return "=";
                case SQLiteOperater.GT:
                    return ">";
                case SQLiteOperater.LT:
                    return "<";
                case SQLiteOperater.GTorEq:
                    return ">=";
                case SQLiteOperater.LTorEq:
                    return "<=";
                case SQLiteOperater.In:
                    return "in";
                default:
                    return null;
            }
        }
    }
    public class KeyOperatorValue
    {
        public string Key;
        public string Operator;
        public string Value;

        public KeyOperatorValue(string key, SQLiteOperater @operator, string value)
        {
            Key = key;
            Operator = @operator.GetSQLiteOperatorString();
            Value = value;
        }
    }
}
