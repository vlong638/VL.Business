
/*==============================================================*/
/* Table: TArea                                                 */
/*==============================================================*/
create table TArea (
   AreaId               uniqueidentifier     not null,
   AreaName             nvarchar(20)         not null,
   AreaLevel            numeric(4)           not null,
   AreaType             numeric(4)           not null,
   Description          nvarchar(100)        not null,
   DescriptionEx        nvarchar(100)        not null,
   constraint PK_TAREA primary key (AreaId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TArea') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TArea' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '地区', 
   'user', @CurrentUser, 'table', 'TArea'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TArea')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AreaId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TArea', 'column', 'AreaId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Id',
   'user', @CurrentUser, 'table', 'TArea', 'column', 'AreaId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TArea')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AreaName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TArea', 'column', 'AreaName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '地区名称',
   'user', @CurrentUser, 'table', 'TArea', 'column', 'AreaName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TArea')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AreaLevel')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TArea', 'column', 'AreaLevel'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '地区等级',
   'user', @CurrentUser, 'table', 'TArea', 'column', 'AreaLevel'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TArea')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AreaType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TArea', 'column', 'AreaType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '地区类型',
   'user', @CurrentUser, 'table', 'TArea', 'column', 'AreaType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TArea')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Description')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TArea', 'column', 'Description'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '地点描述',
   'user', @CurrentUser, 'table', 'TArea', 'column', 'Description'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TArea')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DescriptionEx')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TArea', 'column', 'DescriptionEx'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '地点描述(额外)',
   'user', @CurrentUser, 'table', 'TArea', 'column', 'DescriptionEx'
go

/*==============================================================*/
/* Table: TAreaEvent                                            */
/*==============================================================*/
create table TAreaEvent (
   AreaId               uniqueidentifier     not null,
   EventId              uniqueidentifier     not null,
   RoundNum             numeric(4)           not null,
   constraint PK_TAREAEVENT primary key (AreaId, EventId, RoundNum)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TAreaEvent') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TAreaEvent' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '地区事件', 
   'user', @CurrentUser, 'table', 'TAreaEvent'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TAreaEvent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AreaId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TAreaEvent', 'column', 'AreaId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '地区Id',
   'user', @CurrentUser, 'table', 'TAreaEvent', 'column', 'AreaId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TAreaEvent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EventId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TAreaEvent', 'column', 'EventId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '事件Id',
   'user', @CurrentUser, 'table', 'TAreaEvent', 'column', 'EventId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TAreaEvent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RoundNum')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TAreaEvent', 'column', 'RoundNum'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '回合数',
   'user', @CurrentUser, 'table', 'TAreaEvent', 'column', 'RoundNum'
go

/*==============================================================*/
/* Table: TCreature                                             */
/*==============================================================*/
create table TCreature (
   CreatureId           uniqueidentifier     not null,
   CreatureType         numeric(10)          not null,
   Name                 nvarchar(20)         not null,
   Experience           numeric(20)          not null,
   Level                numeric(10)          not null,
   Profession           numeric(4)           not null,
   constraint PK_TCREATURE primary key (CreatureId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TCreature') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TCreature' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '生物', 
   'user', @CurrentUser, 'table', 'TCreature'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatureId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreature', 'column', 'CreatureId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '标识',
   'user', @CurrentUser, 'table', 'TCreature', 'column', 'CreatureId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatureType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreature', 'column', 'CreatureType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '种族类型',
   'user', @CurrentUser, 'table', 'TCreature', 'column', 'CreatureType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreature', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '名称',
   'user', @CurrentUser, 'table', 'TCreature', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Experience')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreature', 'column', 'Experience'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '经验',
   'user', @CurrentUser, 'table', 'TCreature', 'column', 'Experience'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Level')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreature', 'column', 'Level'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '等级',
   'user', @CurrentUser, 'table', 'TCreature', 'column', 'Level'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Profession')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreature', 'column', 'Profession'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '职业',
   'user', @CurrentUser, 'table', 'TCreature', 'column', 'Profession'
go

/*==============================================================*/
/* Table: TCreatureProperty                                     */
/*==============================================================*/
create table TCreatureProperty (
   CreatureId           uniqueidentifier     not null,
   HitPoint             numeric(10)          not null,
   MagicPoint           numeric(10)          not null,
   Strength             numeric(10)          not null,
   Stamina              numeric(10)          not null,
   Agility              numeric(10)          not null,
   Intelligence         numeric(10)          not null,
   Mentality            numeric(10)          not null,
   constraint PK_TCREATUREPROPERTY primary key (CreatureId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TCreatureProperty') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TCreatureProperty' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '生物能力值', 
   'user', @CurrentUser, 'table', 'TCreatureProperty'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureProperty')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatureId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureProperty', 'column', 'CreatureId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '标识',
   'user', @CurrentUser, 'table', 'TCreatureProperty', 'column', 'CreatureId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureProperty')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'HitPoint')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureProperty', 'column', 'HitPoint'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '生命值',
   'user', @CurrentUser, 'table', 'TCreatureProperty', 'column', 'HitPoint'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureProperty')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MagicPoint')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureProperty', 'column', 'MagicPoint'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '魔法值',
   'user', @CurrentUser, 'table', 'TCreatureProperty', 'column', 'MagicPoint'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureProperty')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Strength')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureProperty', 'column', 'Strength'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '力量',
   'user', @CurrentUser, 'table', 'TCreatureProperty', 'column', 'Strength'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureProperty')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Stamina')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureProperty', 'column', 'Stamina'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '耐力',
   'user', @CurrentUser, 'table', 'TCreatureProperty', 'column', 'Stamina'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureProperty')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Agility')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureProperty', 'column', 'Agility'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '敏捷',
   'user', @CurrentUser, 'table', 'TCreatureProperty', 'column', 'Agility'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureProperty')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Intelligence')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureProperty', 'column', 'Intelligence'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '智力',
   'user', @CurrentUser, 'table', 'TCreatureProperty', 'column', 'Intelligence'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureProperty')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Mentality')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureProperty', 'column', 'Mentality'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '精神',
   'user', @CurrentUser, 'table', 'TCreatureProperty', 'column', 'Mentality'
go

/*==============================================================*/
/* Table: TCreatureQuality                                      */
/*==============================================================*/
create table TCreatureQuality (
   CreatureId           uniqueidentifier     not null,
   FirstLevelQuality    numeric(4)           not null,
   SecondLevelQuality   numeric(4)           not null,
   ThirdLevelQuality    numeric(4)           not null,
   constraint PK_TCREATUREQUALITY primary key (CreatureId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TCreatureQuality') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TCreatureQuality' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '传承品质', 
   'user', @CurrentUser, 'table', 'TCreatureQuality'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureQuality')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatureId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureQuality', 'column', 'CreatureId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '标识',
   'user', @CurrentUser, 'table', 'TCreatureQuality', 'column', 'CreatureId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureQuality')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FirstLevelQuality')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureQuality', 'column', 'FirstLevelQuality'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '一级传承品质',
   'user', @CurrentUser, 'table', 'TCreatureQuality', 'column', 'FirstLevelQuality'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureQuality')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SecondLevelQuality')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureQuality', 'column', 'SecondLevelQuality'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '二级传承品质',
   'user', @CurrentUser, 'table', 'TCreatureQuality', 'column', 'SecondLevelQuality'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureQuality')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ThirdLevelQuality')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureQuality', 'column', 'ThirdLevelQuality'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '三级传承品质',
   'user', @CurrentUser, 'table', 'TCreatureQuality', 'column', 'ThirdLevelQuality'
go

/*==============================================================*/
/* Table: TCreatureSkill                                        */
/*==============================================================*/
create table TCreatureSkill (
   CreatureId           uniqueidentifier     not null,
   SurvivalSkill        varchar(100)         not null,
   WarriorSkills        varchar(100)         not null,
   ExplorerSkills       varchar(100)         not null,
   FarmingSkills        varchar(100)         not null,
   RasingSkills         varchar(100)         not null,
   BowmanSkills         varchar(100)         not null,
   FishingSkills        varchar(100)         not null,
   constraint PK_TCREATURESKILL primary key (CreatureId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TCreatureSkill') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TCreatureSkill' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '技能集合', 
   'user', @CurrentUser, 'table', 'TCreatureSkill'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureSkill')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatureId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureSkill', 'column', 'CreatureId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '标识',
   'user', @CurrentUser, 'table', 'TCreatureSkill', 'column', 'CreatureId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureSkill')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SurvivalSkill')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureSkill', 'column', 'SurvivalSkill'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '基础生存',
   'user', @CurrentUser, 'table', 'TCreatureSkill', 'column', 'SurvivalSkill'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureSkill')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'WarriorSkills')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureSkill', 'column', 'WarriorSkills'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '战士',
   'user', @CurrentUser, 'table', 'TCreatureSkill', 'column', 'WarriorSkills'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureSkill')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExplorerSkills')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureSkill', 'column', 'ExplorerSkills'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '探险家',
   'user', @CurrentUser, 'table', 'TCreatureSkill', 'column', 'ExplorerSkills'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureSkill')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FarmingSkills')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureSkill', 'column', 'FarmingSkills'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '耕作',
   'user', @CurrentUser, 'table', 'TCreatureSkill', 'column', 'FarmingSkills'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureSkill')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RasingSkills')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureSkill', 'column', 'RasingSkills'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '养殖',
   'user', @CurrentUser, 'table', 'TCreatureSkill', 'column', 'RasingSkills'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureSkill')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BowmanSkills')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureSkill', 'column', 'BowmanSkills'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '弓箭手',
   'user', @CurrentUser, 'table', 'TCreatureSkill', 'column', 'BowmanSkills'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TCreatureSkill')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FishingSkills')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TCreatureSkill', 'column', 'FishingSkills'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '钓鱼',
   'user', @CurrentUser, 'table', 'TCreatureSkill', 'column', 'FishingSkills'
go

/*==============================================================*/
/* Table: TEvent                                                */
/*==============================================================*/
create table TEvent (
   AreaId               uniqueidentifier     not null,
   EventId              uniqueidentifier     not null,
   Occurrence           nvarchar(100)        not null,
   constraint PK_TEVENT primary key (EventId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TEvent') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TEvent' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '事件', 
   'user', @CurrentUser, 'table', 'TEvent'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TEvent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AreaId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TEvent', 'column', 'AreaId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '所属地区Id',
   'user', @CurrentUser, 'table', 'TEvent', 'column', 'AreaId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TEvent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EventId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TEvent', 'column', 'EventId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Id',
   'user', @CurrentUser, 'table', 'TEvent', 'column', 'EventId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TEvent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Occurrence')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TEvent', 'column', 'Occurrence'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '出现几率',
   'user', @CurrentUser, 'table', 'TEvent', 'column', 'Occurrence'
go

/*==============================================================*/
/* Table: TPrototypeCreature                                    */
/*==============================================================*/
create table TPrototypeCreature (
   CreatureId           uniqueidentifier     not null,
   CreatureType         numeric(10)          not null,
   CreatureUseType      numeric(10)          not null,
   Name                 nvarchar(20)         not null,
   Level                numeric(10)          not null,
   Profession           numeric(4)           not null,
   Properties           nvarchar(200)        not null,
   Skills               nvarchar(200)        not null,
   Qualities            nvarchar(200)        not null,
   constraint PK_TPROTOTYPECREATURE primary key (CreatureId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TPrototypeCreature') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TPrototypeCreature' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '生物原型', 
   'user', @CurrentUser, 'table', 'TPrototypeCreature'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TPrototypeCreature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatureId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'CreatureId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '标识',
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'CreatureId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TPrototypeCreature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatureType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'CreatureType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '种族类型',
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'CreatureType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TPrototypeCreature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatureUseType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'CreatureUseType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '生物用途分类',
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'CreatureUseType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TPrototypeCreature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '名称',
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TPrototypeCreature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Level')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'Level'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '等级',
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'Level'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TPrototypeCreature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Profession')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'Profession'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '职业',
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'Profession'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TPrototypeCreature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Properties')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'Properties'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '能力',
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'Properties'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TPrototypeCreature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Skills')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'Skills'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '技能',
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'Skills'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TPrototypeCreature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Qualities')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'Qualities'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '品质',
   'user', @CurrentUser, 'table', 'TPrototypeCreature', 'column', 'Qualities'
go

/*==============================================================*/
/* Table: TTeam                                                 */
/*==============================================================*/
create table TTeam (
   TeamId               uniqueidentifier     not null,
   Name                 nvarchar(20)         not null,
   constraint PK_TTEAM primary key (TeamId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TTeam') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TTeam' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '队伍', 
   'user', @CurrentUser, 'table', 'TTeam'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TTeam')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TeamId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TTeam', 'column', 'TeamId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '标识',
   'user', @CurrentUser, 'table', 'TTeam', 'column', 'TeamId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TTeam')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TTeam', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '队伍名',
   'user', @CurrentUser, 'table', 'TTeam', 'column', 'Name'
go

/*==============================================================*/
/* Table: TTeamCreature                                         */
/*==============================================================*/
create table TTeamCreature (
   TeamId               uniqueidentifier     not null,
   CreatureId           uniqueidentifier     not null,
   constraint PK_TTEAMCREATURE primary key (TeamId, CreatureId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TTeamCreature') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TTeamCreature' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '队伍成员', 
   'user', @CurrentUser, 'table', 'TTeamCreature'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TTeamCreature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TeamId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TTeamCreature', 'column', 'TeamId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '队伍标识',
   'user', @CurrentUser, 'table', 'TTeamCreature', 'column', 'TeamId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TTeamCreature')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatureId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TTeamCreature', 'column', 'CreatureId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '生物标识',
   'user', @CurrentUser, 'table', 'TTeamCreature', 'column', 'CreatureId'
go