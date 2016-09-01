-------------------------选择数据库------------------------------------------
use [VL.Spider]
-------------------------数据库创建------------------------------------------

/*==============================================================*/
/* Table: TGrabList                                             */
/*==============================================================*/
if exists (select 1
            from  sysobjects
           where  id = object_id('TGrabList')
            and   type = 'U')
   drop table TGrabList
go
create table TGrabList (
   ListItemId           uniqueidentifier     not null,
   SpiderId             uniqueidentifier     not null,
   IssueName            varchar(200)         not null,
   OrderNumber          numeric(16)          not null,
   Title                varchar(200)         not null,
   URL                  varchar(1000)        not null,
   Remark               varchar(2000)        not null,
   constraint PK_TGRABLIST primary key (SpiderId, IssueName, OrderNumber)
)
go


/*==============================================================*/
/* Table: TGrabRequest                                          */
/*==============================================================*/
if exists (select 1
            from  sysobjects
           where  id = object_id('TGrabRequest')
            and   type = 'U')
   drop table TGrabRequest
go
create table TGrabRequest (
   RequestId            uniqueidentifier     not null,
   SpiderId             uniqueidentifier     not null,
   GrabType             numeric(16)          not null,
   IssueName            varchar(200)         not null,
   SpiderName           varchar(200)         not null,
   ProcessStatus        numeric(16)          not null,
   Message              varchar(2000)        not null,
   constraint PK_TGRABREQUEST primary key (SpiderId, GrabType, IssueName)
)
go

/*==============================================================*/
/* Table: TSpider                                               */
/*==============================================================*/
if exists (select 1
            from  sysobjects
           where  id = object_id('TSpider')
            and   type = 'U')
   drop table TSpider
go
create table TSpider (
   SpiderId             uniqueidentifier     not null,
   SpiderName           varchar(200)         not null,
   constraint PK_TSPIDER primary key (SpiderId)
)
go
-------------------------数据库查询------------------------------------------
use [VL.Spider]
select * from TSpider;
select * from TGrabRequest;
select * from TGrabList order by SpiderId,IssueName desc,OrderNumber;
delete from TGrabList;
delete from TGrabRequest where issueName='搜狐财经-公司报道-要闻快报1723';

update TGrabRequest set GrabType=1 where RequestId='CB1B4C62-88D1-44D1-98C1-F4AA30AB3A66';





