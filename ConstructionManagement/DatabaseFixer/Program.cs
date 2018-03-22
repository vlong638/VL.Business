using PmSoft.ConstructionManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFixer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = SQLiteHelper.Connect())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandText = @"
drop table TDepthNodeElement;
create table TDepthNodeElement
(
   Segregation          varchar(36)                    not null,
   NodeCode             varchar(20)                    not null,
   Depth                varchar(10)                    not null,
   ElementIds           varchar(2000)                  not null,
   constraint PK_TDEPTHNODEELEMENT primary key (Segregation,NodeCode,Depth)
);";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("数据库已成功修复");

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("数据库修复出现异常,"+ex.ToString());
                }
                connection.Close();
                Console.ReadLine();
            }
        }
    }
}
