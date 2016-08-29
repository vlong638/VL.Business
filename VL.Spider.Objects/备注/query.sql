-------------------------数据库创建------------------------------------------
if exists (select 1
            from  sysobjects
           where  id = object_id('TGrabList')
            and   type = 'U')
   drop table TGrabList
go
create table TGrabList (
   SpiderId             uniqueidentifier     not null,
   IssueTime            datetime             not null,
   OrderNumber          numeric(16)          not null,
   Title                varchar(200)         not null,
   URL                  varchar(1000)        not null,
   Remark               varchar(2000)        not null,
   constraint PK_TGRABLIST primary key (IssueTime, OrderNumber)
)
go


if exists (select 1
            from  sysobjects
           where  id = object_id('TSpider')
            and   type = 'U')
   drop table TSpider
go

/*==============================================================*/
/* Table: TSpider                                               */
/*==============================================================*/
create table TSpider (
   SpiderId             uniqueidentifier     not null,
   SpiderName           varchar(200)         not null,
   constraint PK_TSPIDER primary key (SpiderId)
)
go

-------------------------数据库查询------------------------------------------
use [VL.Spider]
select * from TSpider;
select * from TGrabList;
delete from TSpider where spiderid='2A17AC6B-69F1-441E-B7BB-966EF4F9B45D';












