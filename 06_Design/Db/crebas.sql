/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     2018/5/2 星期三 21:50:37                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('GoodInfo') and o.name = 'FK_GOODINFO_REFERENCE_SHIPINFO')
alter table GoodInfo
   drop constraint FK_GOODINFO_REFERENCE_SHIPINFO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('OrderDetail') and o.name = 'FK_ORDERDET_REFERENCE_ORDERINF')
alter table OrderDetail
   drop constraint FK_ORDERDET_REFERENCE_ORDERINF
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SynchronizationConfig') and o.name = 'FK_SYNCHRON_REFERENCE_SYSUSER2')
alter table SynchronizationConfig
   drop constraint FK_SYNCHRON_REFERENCE_SYSUSER2
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.SysLoginToken') and o.name = 'FK_SYSLOGIN_REFERENCE_SYSUSER2')
alter table dbo.SysLoginToken
   drop constraint FK_SYSLOGIN_REFERENCE_SYSUSER2
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.SysMenuPermission') and o.name = 'FK_SYSMENUP_REFERENCE_SYSMENU')
alter table dbo.SysMenuPermission
   drop constraint FK_SYSMENUP_REFERENCE_SYSMENU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.SysUserMenu') and o.name = 'FK_SYSUSERM_REF-SYS-M_SYSUSER2')
alter table dbo.SysUserMenu
   drop constraint "FK_SYSUSERM_REF-SYS-M_SYSUSER2"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.SysUserMenu') and o.name = 'FK_SYSUSERM_REFERENCE_SYSMENU')
alter table dbo.SysUserMenu
   drop constraint FK_SYSUSERM_REFERENCE_SYSMENU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.SysUserPermission') and o.name = 'FK_SYSUSERP_REFERENCE_SYSUSER2')
alter table dbo.SysUserPermission
   drop constraint FK_SYSUSERP_REFERENCE_SYSUSER2
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.SysUserPermission') and o.name = 'FK_SYSUSERP_REFERENCE_SYSMENUP')
alter table dbo.SysUserPermission
   drop constraint FK_SYSUSERP_REFERENCE_SYSMENUP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.SysUserPermission') and o.name = 'FK_SYSUSERP_REFERENCE_SYSMENU')
alter table dbo.SysUserPermission
   drop constraint FK_SYSUSERP_REFERENCE_SYSMENU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.SysUserSession') and o.name = 'FK_SYSUSERS_REFERENCE_SYSUSER2')
alter table dbo.SysUserSession
   drop constraint FK_SYSUSERS_REFERENCE_SYSUSER2
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('WayBillInfo') and o.name = 'FK_WAYBILLI_REFERENCE_ORDERINF')
alter table WayBillInfo
   drop constraint FK_WAYBILLI_REFERENCE_ORDERINF
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('WayBillTraceInfo') and o.name = 'FK_WAYBILLT_REFERENCE_WAYBILLI')
alter table WayBillTraceInfo
   drop constraint FK_WAYBILLT_REFERENCE_WAYBILLI
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ComplaintInfo')
            and   type = 'U')
   drop table ComplaintInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GoodInfo')
            and   type = 'U')
   drop table GoodInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GoodMonitorTopN')
            and   type = 'U')
   drop table GoodMonitorTopN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MonitorIndicator')
            and   type = 'U')
   drop table MonitorIndicator
go

if exists (select 1
            from  sysobjects
           where  id = object_id('OrderDetail')
            and   type = 'U')
   drop table OrderDetail
go

if exists (select 1
            from  sysobjects
           where  id = object_id('OrderInfo')
            and   type = 'U')
   drop table OrderInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ShipInfo')
            and   type = 'U')
   drop table ShipInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SynchronizationConfig')
            and   type = 'U')
   drop table SynchronizationConfig
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysDistrict')
            and   type = 'U')
   drop table dbo.SysDistrict
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysExceptionLog')
            and   type = 'U')
   drop table dbo.SysExceptionLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysLoginLog')
            and   type = 'U')
   drop table dbo.SysLoginLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysLoginToken')
            and   type = 'U')
   drop table dbo.SysLoginToken
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysMenu')
            and   type = 'U')
   drop table dbo.SysMenu
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysMenuPermission')
            and   type = 'U')
   drop table dbo.SysMenuPermission
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysOperationLog')
            and   type = 'U')
   drop table dbo.SysOperationLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysUser2')
            and   type = 'U')
   drop table dbo.SysUser2
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysUserMenu')
            and   type = 'U')
   drop table dbo.SysUserMenu
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysUserPermission')
            and   type = 'U')
   drop table dbo.SysUserPermission
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SysUserSession')
            and   type = 'U')
   drop table dbo.SysUserSession
go

if exists (select 1
            from  sysobjects
           where  id = object_id('WayBillInfo')
            and   type = 'U')
   drop table WayBillInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('WayBillTraceInfo')
            and   type = 'U')
   drop table WayBillTraceInfo
go


/*==============================================================*/
/* User: dbo                                                    */
/*==============================================================*/
go

/*==============================================================*/
/* Table: ComplaintInfo                                         */
/*==============================================================*/
create table ComplaintInfo (
   Id                   int                  identity,
   UserId               int                  not null,
   StoreId              int                  null,
   OrderId              int                  null,
   WaybillId            int                  null,
   [Description]        nvarchar(4000)       null,
   ComplaintType        int                  null,
   [Status]               int                  null,
   Result               nvarchar(4000)       null,
   EditDate             date                 null,
   Remark               nvarchar(2000)       null,
   constraint PK_COMPLAINTINFO primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ComplaintInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'ComplaintInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '投诉信息表', 
   'user', @CurrentUser, 'table', 'ComplaintInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ComplaintInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ComplaintType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ComplaintInfo', 'column', 'ComplaintType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '0 网上 2 电话  3 线下',
   'user', @CurrentUser, 'table', 'ComplaintInfo', 'column', 'ComplaintType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ComplaintInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Status')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ComplaintInfo', 'column', 'Status'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '0 未处理   1  处理中  2 已完成 ',
   'user', @CurrentUser, 'table', 'ComplaintInfo', 'column', 'Status'
go

/*==============================================================*/
/* Table: GoodInfo                                              */
/*==============================================================*/
create table GoodInfo (
   Id                   int                  identity,
   Name                 nvarchar(200)        null,
   Code                 nvarchar(200)        null,
   StoreId              int                  null,
   Remark               nvarchar(500)        null,
   constraint PK_GOODINFO primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('GoodInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'GoodInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '商品信息', 
   'user', @CurrentUser, 'table', 'GoodInfo'
go

/*==============================================================*/
/* Table: GoodMonitorTopN                                       */
/*==============================================================*/
create table GoodMonitorTopN (
   Id                   int                  identity,
   指标名称                 nvarchar(500)        null,
   ShortName            nvarchar(100)        null,
   value                decimal              null,
   Unit                 nvarchar(500)        null,
   StatisDate           date                 null,
   StatisType           nvarchar(200)        null,
   StatisPeriodType     int                  null,
   Remark               nvarchar(500)        null,
   constraint PK_GOODMONITORTOPN primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('GoodMonitorTopN') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'GoodMonitorTopN' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '首页监控指标信息', 
   'user', @CurrentUser, 'table', 'GoodMonitorTopN'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('GoodMonitorTopN')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StatisType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'GoodMonitorTopN', 'column', 'StatisType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '参考 静态指标   类目枚举',
   'user', @CurrentUser, 'table', 'GoodMonitorTopN', 'column', 'StatisType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('GoodMonitorTopN')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StatisPeriodType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'GoodMonitorTopN', 'column', 'StatisPeriodType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '0: 最近7天  1: 最近30天   2: 最近90天',
   'user', @CurrentUser, 'table', 'GoodMonitorTopN', 'column', 'StatisPeriodType'
go

/*==============================================================*/
/* Table: MonitorIndicator                                      */
/*==============================================================*/
create table MonitorIndicator (
   Id                   int                  identity,
   指标名称                 nvarchar(500)        null,
   ShortName            nvarchar(100)        null,
   value                decimal              null,
   StatisDate           date                 null,
   mom                  decimal(8,2)         null,
   yoy                  decimal(8,2)         null,
   Unit                 nvarchar(500)        null,
   Remark               nvarchar(500)        null,
   constraint PK_MONITORINDICATOR primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('MonitorIndicator') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'MonitorIndicator' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '首页监控指标信息', 
   'user', @CurrentUser, 'table', 'MonitorIndicator'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MonitorIndicator')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'mom')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MonitorIndicator', 'column', 'mom'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '环比',
   'user', @CurrentUser, 'table', 'MonitorIndicator', 'column', 'mom'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MonitorIndicator')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'yoy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MonitorIndicator', 'column', 'yoy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '同比指数',
   'user', @CurrentUser, 'table', 'MonitorIndicator', 'column', 'yoy'
go

/*==============================================================*/
/* Table: OrderDetail                                           */
/*==============================================================*/
create table OrderDetail (
   Id                   int                  not null,
   OrderId              int                  null,
   GoodCode             nvarchar(200)        null,
   GoodName             nvarchar(200)        null,
   Num                  int                  null,
   Price                decimal              null,
   GiftPoint            decimal              null,
   Remark               nvarchar(2000)       null,
   constraint PK_ORDERDETAIL primary key (Id)
)
go

/*==============================================================*/
/* Table: OrderInfo                                             */
/*==============================================================*/
create table OrderInfo (
   Id                   int                  identity,
   OrderCode            nvarchar(200)        null,
   OrderDate            date                 null,
   Status               int                  null,
   SaleId               int                  null,
   buyerId              int                  null,
   GoodNum              int                  null,
   GoodFee              decimal              null,
   DeliveryType         int                  null,
   EndDate              int                  null,
   Remark               nvarchar(200)        null,
   constraint PK_ORDERINFO primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('OrderInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'OrderInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '订单信息', 
   'user', @CurrentUser, 'table', 'OrderInfo'
go

/*==============================================================*/
/* Table: ShipInfo                                              */
/*==============================================================*/
create table ShipInfo (
   Id                   int                  not null,
   UserId               int                  null,
   Code                 nvarchar(100)        null,
   Plat                 int                  null,
   Name                 nvarchar(300)        null,
   Description          nvarchar(2000)       null,
   InDate               date                 null,
   Status               int                  null,
   AppKey               nvarchar(1000)       null,
   AppSecret            nvarchar(1000)       null,
   DeliveryAddress      nvarchar(1000)       null,
   Remark               nvarchar(2000)       null,
   Photo                nvarchar(50)         null,
   constraint PK_SHIPINFO primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ShipInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'ShipInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '店铺信息', 
   'user', @CurrentUser, 'table', 'ShipInfo'
go

/*==============================================================*/
/* Table: SynchronizationConfig                                 */
/*==============================================================*/
create table SynchronizationConfig (
   ID                   int                  identity,
   UserId               int                  null,
   PlatId               int                  null,
   StoreIds             nvarchar(2000)       null,
   SyncPeriod           int                  null,
   SyncUnit             nvarchar(50)         null,
   EditDate             date                 null,
   Remark               nvarchar(2000)       null,
   constraint PK_SYNCHRONIZATIONCONFIG primary key (ID)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SynchronizationConfig')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PlatId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SynchronizationConfig', 'column', 'PlatId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '0 阿里  1 京东  ',
   'user', @CurrentUser, 'table', 'SynchronizationConfig', 'column', 'PlatId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SynchronizationConfig')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StoreIds')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SynchronizationConfig', 'column', 'StoreIds'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '店铺的id  多个之间用逗号隔开',
   'user', @CurrentUser, 'table', 'SynchronizationConfig', 'column', 'StoreIds'
go

/*==============================================================*/
/* Table: SysDistrict                                           */
/*==============================================================*/
create table dbo.SysDistrict (
   Id                   int                  not null,
   DistrictName         nvarchar(60)         collate Chinese_PRC_CI_AS null,
   Pinyin               nvarchar(100)        collate Chinese_PRC_CI_AS null,
   DistrictType         int                  null,
   DistrictSort         int                  null,
   DistrictDescription  nvarchar(200)        collate Chinese_PRC_CI_AS null,
   DistrictRemark       nvarchar(300)        collate Chinese_PRC_CI_AS null,
   DistrictFatherIId    int                  null,
   DistrictLevel        int                  null,
   DistrictPath         nvarchar(500)        collate Chinese_PRC_CI_AS null,
   DistrictCountry      int                  null,
   DistrictPost         nvarchar(10)         collate Chinese_PRC_CI_AS null,
   FullName             nvarchar(500)        collate Chinese_PRC_CI_AS null,
   Enabled              int                  null constraint DF__SysDistri__Enabl__0C85DE4D default (1),
   InUser               int                  null,
   InDate               datetime             null constraint DF__SysDistri__InDat__0D7A0286 default getdate(),
   EditUser             int                  null,
   EditDate             datetime             null constraint DF__SysDistri__EditD__0E6E26BF default getdate(),
   DelUser              int                  null,
   DelState             int                  null constraint DF__SysDistri__DelSt__10566F31 default (0),
   DelDate              datetime             null constraint DF__SysDistri__DelDa__0F624AF8 default getdate(),
   constraint PK_SYSDISTRICT primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.SysDistrict') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'SysDistrict' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '行政地区信息', 
   'user', 'dbo', 'table', 'SysDistrict'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'Id'

end


execute sp_addextendedproperty 'MS_Description', 
   '行政地区Id',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DistrictName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictName'

end


execute sp_addextendedproperty 'MS_Description', 
   '行政地区名称',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Pinyin')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'Pinyin'

end


execute sp_addextendedproperty 'MS_Description', 
   '拼音名',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'Pinyin'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DistrictType')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictType'

end


execute sp_addextendedproperty 'MS_Description', 
   '行政地区类型0国家 1.省级、2.市级（地区）、3.县级、4乡镇',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DistrictSort')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictSort'

end


execute sp_addextendedproperty 'MS_Description', 
   '排序',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictSort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DistrictDescription')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictDescription'

end


execute sp_addextendedproperty 'MS_Description', 
   '说明描述',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictDescription'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DistrictRemark')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictRemark'

end


execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictRemark'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DistrictFatherIId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictFatherIId'

end


execute sp_addextendedproperty 'MS_Description', 
   '行政地区父ID 所属区域',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictFatherIId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DistrictLevel')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictLevel'

end


execute sp_addextendedproperty 'MS_Description', 
   '级数',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictLevel'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DistrictPath')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictPath'

end


execute sp_addextendedproperty 'MS_Description', 
   '路径',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictPath'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DistrictCountry')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictCountry'

end


execute sp_addextendedproperty 'MS_Description', 
   '国家',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictCountry'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DistrictPost')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictPost'

end


execute sp_addextendedproperty 'MS_Description', 
   '邮政编码',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DistrictPost'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FullName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'FullName'

end


execute sp_addextendedproperty 'MS_Description', 
   '行政区域全称',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'FullName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Enabled')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'Enabled'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否有效  0 无效  1 有效',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'Enabled'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'InUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '录入人员',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'InUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'InDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '录入日期',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'InDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EditUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'EditUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '修改人员',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'EditUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EditDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'EditDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '修改日期',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'EditDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DelUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '删除人员',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DelUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelState')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DelState'

end


execute sp_addextendedproperty 'MS_Description', 
   '标识该行数据是否被删除 0未删除 1已删除',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DelState'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysDistrict')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DelDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', 'dbo', 'table', 'SysDistrict', 'column', 'DelDate'
go

/*==============================================================*/
/* Table: SysExceptionLog                                       */
/*==============================================================*/
create table dbo.SysExceptionLog (
   Id                   bigint               identity(1, 10),
   AccessChannelId      int                  null,
   UserId               int                  null,
   CustomerId           int                  null,
   ExceptionDate        datetime             null constraint DF__SysExcept__Excep__7A521F79 default getdate(),
   ExceptionFunction    nvarchar(500)        collate Chinese_PRC_CI_AS null,
   ExceptionVersions    nvarchar(60)         collate Chinese_PRC_CI_AS null,
   ExceptionSource      nvarchar(Max)        collate Chinese_PRC_CI_AS null,
   ExceptionDescription nvarchar(Max)        collate Chinese_PRC_CI_AS null,
   ExceptionStackTrace  nvarchar(Max)        collate Chinese_PRC_CI_AS null,
   ExceptionType        nvarchar(20)         collate Chinese_PRC_CI_AS null,
   ExceptionTargetSite  nvarchar(Max)        collate Chinese_PRC_CI_AS null,
   ExceptionTypeName    nvarchar(200)        collate Chinese_PRC_CI_AS null,
   ExceptionIP          nvarchar(20)         collate Chinese_PRC_CI_AS null,
   IPNum                int                  null,
   ComputerName         nvarchar(100)        collate Chinese_PRC_CI_AS null,
   ExploreName          nvarchar(60)         collate Chinese_PRC_CI_AS null,
   ExplorerVersions     nvarchar(80)         collate Chinese_PRC_CI_AS null,
   SourceEquipment      nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Enabled              int                  null constraint DF__SysExcept__Enabl__7B4643B2 default (1),
   InUser               int                  null,
   InDate               datetime             null constraint DF__SysExcept__InDat__7C3A67EB default getdate(),
   DeleteState          int                  null constraint DF__SysExcept__Delet__7D2E8C24 default (0),
   DeleteUser           int                  null,
   DeleteDate           datetime             null,
   constraint PK_SYSEXCEPTIONLOG primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.SysExceptionLog') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'SysExceptionLog' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '系统异常错误日志', 
   'user', 'dbo', 'table', 'SysExceptionLog'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'Id'

end


execute sp_addextendedproperty 'MS_Description', 
   '日志Id',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AccessChannelId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'AccessChannelId'

end


execute sp_addextendedproperty 'MS_Description', 
   '渠道Id',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'AccessChannelId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'UserId'

end


execute sp_addextendedproperty 'MS_Description', 
   '用户Id',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'UserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CustomerId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'CustomerId'

end


execute sp_addextendedproperty 'MS_Description', 
   '客户Id',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'CustomerId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExceptionDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '发生时间',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExceptionFunction')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionFunction'

end


execute sp_addextendedproperty 'MS_Description', 
   '功能模块',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionFunction'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExceptionVersions')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionVersions'

end


execute sp_addextendedproperty 'MS_Description', 
   '版本号',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionVersions'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExceptionSource')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionSource'

end


execute sp_addextendedproperty 'MS_Description', 
   '来源',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionSource'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExceptionDescription')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionDescription'

end


execute sp_addextendedproperty 'MS_Description', 
   '详细描述',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionDescription'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExceptionStackTrace')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionStackTrace'

end


execute sp_addextendedproperty 'MS_Description', 
   '堆栈',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionStackTrace'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExceptionType')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionType'

end


execute sp_addextendedproperty 'MS_Description', 
   '日志类型  1Api  2后台',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExceptionTargetSite')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionTargetSite'

end


execute sp_addextendedproperty 'MS_Description', 
   '引发异常方法',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionTargetSite'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExceptionTypeName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionTypeName'

end


execute sp_addextendedproperty 'MS_Description', 
   '日志类型名称',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionTypeName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExceptionIP')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionIP'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP地址',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExceptionIP'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IPNum')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'IPNum'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP数值',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'IPNum'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ComputerName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ComputerName'

end


execute sp_addextendedproperty 'MS_Description', 
   '机器名',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ComputerName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExploreName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExploreName'

end


execute sp_addextendedproperty 'MS_Description', 
   '浏览器名称',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExploreName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExplorerVersions')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExplorerVersions'

end


execute sp_addextendedproperty 'MS_Description', 
   '浏览器版本',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'ExplorerVersions'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SourceEquipment')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'SourceEquipment'

end


execute sp_addextendedproperty 'MS_Description', 
   '来源设备',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'SourceEquipment'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Enabled')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'Enabled'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否有效  0 无效  1 有效',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'Enabled'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'InUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '录入人员',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'InUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'InDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '录入日期',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'InDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteState')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'DeleteState'

end


execute sp_addextendedproperty 'MS_Description', 
   '删除状态 0未删除 1删除',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'DeleteState'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'DeleteUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '删除人员',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'DeleteUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'DeleteDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '删除日期',
   'user', 'dbo', 'table', 'SysExceptionLog', 'column', 'DeleteDate'
go

/*==============================================================*/
/* Table: SysLoginLog                                           */
/*==============================================================*/
create table dbo.SysLoginLog (
   Id                   bigint               identity(1, 10),
   AccessChannelId      int                  null,
   UserId               int                  null,
   UserName             nvarchar(200)        collate Chinese_PRC_CI_AS null,
   LogDate              datetime             null constraint DF__SysLoginL__LogDa__7E22B05D default getdate(),
   Token                nvarchar(200)        collate Chinese_PRC_CI_AS null,
   LogOutDate           datetime             null,
   ClientIpAddress      nvarchar(200)        collate Chinese_PRC_CI_AS null,
   ClientName           nvarchar(200)        collate Chinese_PRC_CI_AS null,
   OnlineDate           nvarchar(20)         collate Chinese_PRC_CI_AS null,
   IsSucceed            int                  null,
   LogReason            nvarchar(200)        collate Chinese_PRC_CI_AS null,
   SessionId            nvarchar(60)         collate Chinese_PRC_CI_AS null,
   InUserType           int                  null constraint DF__SysLoginL__InUse__7F16D496 default (1),
   IPNum                int                  null,
   Enabled              int                  null constraint DF__SysLoginL__Enabl__000AF8CF default (1),
   DelUser              int                  null,
   DelState             int                  null constraint DF__SysLoginL__DelSt__2A164134 default (0),
   DelDate              datetime             null constraint DF__SysLoginL__DelDa__01F34141 default getdate(),
   constraint PK_SYSLOGINLOG primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.SysLoginLog') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'SysLoginLog' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '记录登录日志信息', 
   'user', 'dbo', 'table', 'SysLoginLog'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'Id'

end


execute sp_addextendedproperty 'MS_Description', 
   '登录日志Id',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AccessChannelId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'AccessChannelId'

end


execute sp_addextendedproperty 'MS_Description', 
   '程序渠道Id',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'AccessChannelId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'UserId'

end


execute sp_addextendedproperty 'MS_Description', 
   '登录用户',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'UserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'UserName'

end


execute sp_addextendedproperty 'MS_Description', 
   '用户名称',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'UserName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LogDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'LogDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '登录时间',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'LogDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Token')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'Token'

end


execute sp_addextendedproperty 'MS_Description', 
   '登录Token',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'Token'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LogOutDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'LogOutDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '退出时间',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'LogOutDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ClientIpAddress')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'ClientIpAddress'

end


execute sp_addextendedproperty 'MS_Description', 
   '客户端Ip地址',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'ClientIpAddress'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ClientName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'ClientName'

end


execute sp_addextendedproperty 'MS_Description', 
   '客户端名称',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'ClientName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OnlineDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'OnlineDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '在线时间',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'OnlineDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsSucceed')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'IsSucceed'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否成功',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'IsSucceed'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LogReason')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'LogReason'

end


execute sp_addextendedproperty 'MS_Description', 
   '失败原因',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'LogReason'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SessionId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'SessionId'

end


execute sp_addextendedproperty 'MS_Description', 
   '用户SessionId',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'SessionId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InUserType')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'InUserType'

end


execute sp_addextendedproperty 'MS_Description', 
   '0 客户  1员工',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'InUserType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IPNum')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'IPNum'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP数值',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'IPNum'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Enabled')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'Enabled'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否有效  0 无效  1 有效',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'Enabled'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'DelUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '删除人员',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'DelUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelState')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'DelState'

end


execute sp_addextendedproperty 'MS_Description', 
   '标识该行数据是否被删除 0未删除 1已删除',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'DelState'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'DelDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', 'dbo', 'table', 'SysLoginLog', 'column', 'DelDate'
go

/*==============================================================*/
/* Table: SysLoginToken                                         */
/*==============================================================*/
create table dbo.SysLoginToken (
   Id                   int                  identity(1, 10),
   UserId               int                  null,
   CustomerId           int                  null,
   Token                varchar(100)         collate Chinese_PRC_CI_AS null,
   CustomerUser         int                  null,
   AccessChannelId      int                  null,
   ExpriedTime          datetime             null,
   InDate               datetime             null constraint DF__SysLoginT__InDat__02E7657A default getdate(),
   constraint PK_SYSLOGINTOKEN primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.SysLoginToken') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'SysLoginToken' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '登录Token', 
   'user', 'dbo', 'table', 'SysLoginToken'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginToken')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginToken', 'column', 'Id'

end


execute sp_addextendedproperty 'MS_Description', 
   '登录TokenId',
   'user', 'dbo', 'table', 'SysLoginToken', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginToken')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginToken', 'column', 'UserId'

end


execute sp_addextendedproperty 'MS_Description', 
   '用户Id',
   'user', 'dbo', 'table', 'SysLoginToken', 'column', 'UserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginToken')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CustomerId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginToken', 'column', 'CustomerId'

end


execute sp_addextendedproperty 'MS_Description', 
   '客户Id',
   'user', 'dbo', 'table', 'SysLoginToken', 'column', 'CustomerId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginToken')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Token')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginToken', 'column', 'Token'

end


execute sp_addextendedproperty 'MS_Description', 
   '登录Token',
   'user', 'dbo', 'table', 'SysLoginToken', 'column', 'Token'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginToken')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CustomerUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginToken', 'column', 'CustomerUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '用户客户  0用户  1客户',
   'user', 'dbo', 'table', 'SysLoginToken', 'column', 'CustomerUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginToken')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AccessChannelId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginToken', 'column', 'AccessChannelId'

end


execute sp_addextendedproperty 'MS_Description', 
   '程序渠道Id',
   'user', 'dbo', 'table', 'SysLoginToken', 'column', 'AccessChannelId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginToken')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExpriedTime')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginToken', 'column', 'ExpriedTime'

end


execute sp_addextendedproperty 'MS_Description', 
   '过期时间',
   'user', 'dbo', 'table', 'SysLoginToken', 'column', 'ExpriedTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysLoginToken')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysLoginToken', 'column', 'InDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '录入日期',
   'user', 'dbo', 'table', 'SysLoginToken', 'column', 'InDate'
go

/*==============================================================*/
/* Table: SysMenu                                               */
/*==============================================================*/
create table dbo.SysMenu (
   Id                   int                  not null,
   MenuCode             nvarchar(200)        collate Chinese_PRC_CI_AS null,
   MenuName             nvarchar(200)        collate Chinese_PRC_CI_AS null,
   MenuState            int                  null constraint DF__SysMenu__MenuSta__2EDAF651 default (1),
   FatherId             int                  null,
   PageUrl              nvarchar(200)        collate Chinese_PRC_CI_AS null,
   MenuControllerKey    varchar(100)         collate Chinese_PRC_CI_AS null,
   ApplicationName      nvarchar(200)        collate Chinese_PRC_CI_AS null,
   ApplicationId        int                  null,
   MenuActionKey        varchar(100)         collate Chinese_PRC_CI_AS null,
   MenuDescription      nvarchar(500)        collate Chinese_PRC_CI_AS null,
   MenuSort             int                  null,
   IsFunction           int                  null,
   IsRoseShow           int                  null,
   IsShow               int                  null,
   HeadPage             nvarchar(200)        collate Chinese_PRC_CI_AS null,
   PictureUrl           nvarchar(200)        collate Chinese_PRC_CI_AS null,
   NoteLevel            int                  null,
   FatherIDPath         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   MenuIsEvent          int                  null,
   DevFframework        int                  null,
   IsOperatingMenu      int                  null,
   Target               nvarchar(300)        collate Chinese_PRC_CI_AS null,
   AllowButton          int                  null,
   AllowView            int                  null,
   AllowForm            int                  null,
   Authority            int                  null,
   DataScope            int                  null,
   MenuLevel            int                  null,
   Isexpand             int                  null,
   MenuClass            nvarchar(50)         collate Chinese_PRC_CI_AS null,
   IconCSS              nvarchar(300)        collate Chinese_PRC_CI_AS null,
   NavgateUrl           nvarchar(500)        collate Chinese_PRC_CI_AS null,
   FormName             nvarchar(100)        collate Chinese_PRC_CI_AS null,
   AssemblyName         nvarchar(100)        collate Chinese_PRC_CI_AS null,
   OperatingNumber      nvarchar(500)        collate Chinese_PRC_CI_AS null,
   DataAccessRange      nvarchar(500)        collate Chinese_PRC_CI_AS null,
   InUser               int                  null,
   InDate               datetime             null constraint DF__SysMenu__InDate__2FCF1A8A default getdate(),
   EditUser             int                  null,
   EditDate             datetime             null constraint DF__SysMenu__EditDat__30C33EC3 default getdate(),
   DelUser              int                  null,
   DelState             int                  null constraint DF__SysMenu__DelStat__31B762FC default (0),
   DelDate              datetime             null constraint DF__SysMenu__DelDate__32AB8735 default getdate(),
   SubWeb               int                  null,
   constraint PK_SYSMENU primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.SysMenu') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'SysMenu' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '系统功能菜单信息', 
   'user', 'dbo', 'table', 'SysMenu'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'Id'

end


execute sp_addextendedproperty 'MS_Description', 
   '模块Id',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuCode')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuCode'

end


execute sp_addextendedproperty 'MS_Description', 
   '模块Code',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuName'

end


execute sp_addextendedproperty 'MS_Description', 
   '模块名称',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuState')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuState'

end


execute sp_addextendedproperty 'MS_Description', 
   '0  无效    1有效',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuState'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FatherId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'FatherId'

end


execute sp_addextendedproperty 'MS_Description', 
   '父模块Id',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'FatherId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PageUrl')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'PageUrl'

end


execute sp_addextendedproperty 'MS_Description', 
   '模块对应的页面路径，即打开页面路径',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'PageUrl'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuControllerKey')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuControllerKey'

end


execute sp_addextendedproperty 'MS_Description', 
   '控制器Key',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuControllerKey'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ApplicationName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'ApplicationName'

end


execute sp_addextendedproperty 'MS_Description', 
   '应用程序Name',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'ApplicationName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ApplicationId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'ApplicationId'

end


execute sp_addextendedproperty 'MS_Description', 
   '应用程序Id',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'ApplicationId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuActionKey')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuActionKey'

end


execute sp_addextendedproperty 'MS_Description', 
   '操作Key',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuActionKey'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuDescription')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuDescription'

end


execute sp_addextendedproperty 'MS_Description', 
   '功能模块详细说明',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuDescription'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuSort')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuSort'

end


execute sp_addextendedproperty 'MS_Description', 
   '展现顺序',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuSort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsFunction')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'IsFunction'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否系统功能菜单 0 不是 1 是',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'IsFunction'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsRoseShow')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'IsRoseShow'

end


execute sp_addextendedproperty 'MS_Description', 
   '角色选择是否显； 0 不显示  1显示',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'IsRoseShow'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsShow')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'IsShow'

end


execute sp_addextendedproperty 'MS_Description', 
   '功能节点里面是否显示；0 不显示  1显示',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'IsShow'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'HeadPage')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'HeadPage'

end


execute sp_addextendedproperty 'MS_Description', 
   '仅对顶级模块',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'HeadPage'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PictureUrl')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'PictureUrl'

end


execute sp_addextendedproperty 'MS_Description', 
   '图片路径',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'PictureUrl'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NoteLevel')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'NoteLevel'

end


execute sp_addextendedproperty 'MS_Description', 
   '第几级节点',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'NoteLevel'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FatherIDPath')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'FatherIDPath'

end


execute sp_addextendedproperty 'MS_Description', 
   '父模块编号路径',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'FatherIDPath'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuIsEvent')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuIsEvent'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否事件',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuIsEvent'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DevFframework')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'DevFframework'

end


execute sp_addextendedproperty 'MS_Description', 
   '开发框架 0.WebFrom 1 Mvc',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'DevFframework'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsOperatingMenu')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'IsOperatingMenu'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否操作权限 0 否  1 是',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'IsOperatingMenu'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Target')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'Target'

end


execute sp_addextendedproperty 'MS_Description', 
   '目标',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'Target'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AllowButton')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'AllowButton'

end


execute sp_addextendedproperty 'MS_Description', 
   '动态按钮',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'AllowButton'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AllowView')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'AllowView'

end


execute sp_addextendedproperty 'MS_Description', 
   '动态视图',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'AllowView'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AllowForm')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'AllowForm'

end


execute sp_addextendedproperty 'MS_Description', 
   '动态表单',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'AllowForm'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Authority')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'Authority'

end


execute sp_addextendedproperty 'MS_Description', 
   '访问权限',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'Authority'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DataScope')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'DataScope'

end


execute sp_addextendedproperty 'MS_Description', 
   '数据范围',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'DataScope'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuLevel')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuLevel'

end


execute sp_addextendedproperty 'MS_Description', 
   '级别层级',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuLevel'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Isexpand')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'Isexpand'

end


execute sp_addextendedproperty 'MS_Description', 
   '展开',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'Isexpand'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuClass')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuClass'

end


execute sp_addextendedproperty 'MS_Description', 
   '菜单分类',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'MenuClass'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IconCSS')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'IconCSS'

end


execute sp_addextendedproperty 'MS_Description', 
   '一个css样式来显示一个16*16 的icon',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'IconCSS'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NavgateUrl')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'NavgateUrl'

end


execute sp_addextendedproperty 'MS_Description', 
   '导航地址',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'NavgateUrl'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FormName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'FormName'

end


execute sp_addextendedproperty 'MS_Description', 
   '针对WinForm结构。',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'FormName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AssemblyName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'AssemblyName'

end


execute sp_addextendedproperty 'MS_Description', 
   '针对WinForm结构。',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'AssemblyName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OperatingNumber')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'OperatingNumber'

end


execute sp_addextendedproperty 'MS_Description', 
   '操作权限编号',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'OperatingNumber'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DataAccessRange')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'DataAccessRange'

end


execute sp_addextendedproperty 'MS_Description', 
   '数据权限范围',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'DataAccessRange'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'InUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '录入人员',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'InUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'InDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '录入日期',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'InDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EditUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'EditUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '修改人员',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'EditUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EditDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'EditDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '修改日期',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'EditDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'DelUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '删除人员',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'DelUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelState')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'DelState'

end


execute sp_addextendedproperty 'MS_Description', 
   '标识该行数据是否被删除 0未删除 1已删除',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'DelState'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenu', 'column', 'DelDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', 'dbo', 'table', 'SysMenu', 'column', 'DelDate'
go

/*==============================================================*/
/* Table: SysMenuPermission                                     */
/*==============================================================*/
create table dbo.SysMenuPermission (
   Id                   int                  not null,
   MenuId               int                  null,
   ActionName           nvarchar(20)         collate Chinese_PRC_CI_AS null,
   ActionKey            varchar(100)         collate Chinese_PRC_CI_AS null,
   ControllerKey        varchar(100)         collate Chinese_PRC_CI_AS null,
   ActionControlId      nvarchar(60)         collate Chinese_PRC_CI_AS null,
   ActionType           nvarchar(200)        collate Chinese_PRC_CI_AS null,
   ActionParentId       int                  null,
   ActionFatherIDPath   nvarchar(200)        collate Chinese_PRC_CI_AS null,
   ApplicationId        int                  null,
   ApplicationName      nvarchar(200)        collate Chinese_PRC_CI_AS null,
   JsEvent              varchar(100)         collate Chinese_PRC_CI_AS null,
   ActionEvent          varchar(100)         collate Chinese_PRC_CI_AS null,
   ActionCode           varchar(100)         collate Chinese_PRC_CI_AS null,
   ActionIcon           varchar(100)         collate Chinese_PRC_CI_AS null,
   Category             varchar(100)         collate Chinese_PRC_CI_AS null,
   ActionSplit          int                  null,
   Description          nvarchar(300)        collate Chinese_PRC_CI_AS null,
   ActionSort           int                  null,
   Enabled              int                  null constraint DF__SysMenuPe__Enabl__336AA144 default (1),
   InUser               int                  null,
   InDate               datetime             null constraint DF__SysMenuPe__InDat__345EC57D default getdate(),
   EditUser             int                  null,
   EditDate             datetime             null constraint DF__SysMenuPe__EditD__3552E9B6 default getdate(),
   DelUser              int                  null,
   DelState             int                  null constraint DF__SysMenuPe__DelSt__36470DEF default (0),
   DelDate              datetime             null constraint DF__SysMenuPe__DelDa__373B3228 default getdate(),
   constraint PK_SYSMENUPERMISSION primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.SysMenuPermission') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'SysMenuPermission' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '功能操作权限', 
   'user', 'dbo', 'table', 'SysMenuPermission'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'Id'

end


execute sp_addextendedproperty 'MS_Description', 
   '功能操作Id',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'MenuId'

end


execute sp_addextendedproperty 'MS_Description', 
   '模块Id',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'MenuId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ActionName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionName'

end


execute sp_addextendedproperty 'MS_Description', 
   '操作名称',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ActionKey')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionKey'

end


execute sp_addextendedproperty 'MS_Description', 
   '操作Key',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionKey'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ControllerKey')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ControllerKey'

end


execute sp_addextendedproperty 'MS_Description', 
   '控制器Key',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ControllerKey'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ActionControlId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionControlId'

end


execute sp_addextendedproperty 'MS_Description', 
   '操作控件Id',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionControlId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ActionType')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionType'

end


execute sp_addextendedproperty 'MS_Description', 
   '操作类型 1.按钮 2.选项卡',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ActionParentId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionParentId'

end


execute sp_addextendedproperty 'MS_Description', 
   '父级主键',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionParentId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ActionFatherIDPath')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionFatherIDPath'

end


execute sp_addextendedproperty 'MS_Description', 
   '父级主键路径',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionFatherIDPath'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ApplicationId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ApplicationId'

end


execute sp_addextendedproperty 'MS_Description', 
   '应用程序Id',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ApplicationId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ApplicationName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ApplicationName'

end


execute sp_addextendedproperty 'MS_Description', 
   '应用程序Name',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ApplicationName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'JsEvent')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'JsEvent'

end


execute sp_addextendedproperty 'MS_Description', 
   'js事件方法',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'JsEvent'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ActionEvent')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionEvent'

end


execute sp_addextendedproperty 'MS_Description', 
   'Action事件地址',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionEvent'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ActionCode')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionCode'

end


execute sp_addextendedproperty 'MS_Description', 
   '编码',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ActionIcon')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionIcon'

end


execute sp_addextendedproperty 'MS_Description', 
   '图标',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionIcon'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Category')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'Category'

end


execute sp_addextendedproperty 'MS_Description', 
   '分类',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'Category'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ActionSplit')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionSplit'

end


execute sp_addextendedproperty 'MS_Description', 
   '分开线',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionSplit'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Description')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'Description'

end


execute sp_addextendedproperty 'MS_Description', 
   '操作说明',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'Description'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ActionSort')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionSort'

end


execute sp_addextendedproperty 'MS_Description', 
   '排序次序',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'ActionSort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Enabled')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'Enabled'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否有效  0 无效  1 有效',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'Enabled'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'InUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '录入人员',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'InUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'InDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '录入日期',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'InDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EditUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'EditUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '修改人员',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'EditUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EditDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'EditDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '修改日期',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'EditDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'DelUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '删除人员',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'DelUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelState')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'DelState'

end


execute sp_addextendedproperty 'MS_Description', 
   '标识该行数据是否被删除 0未删除 1已删除',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'DelState'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysMenuPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'DelDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', 'dbo', 'table', 'SysMenuPermission', 'column', 'DelDate'
go

/*==============================================================*/
/* Table: SysOperationLog                                       */
/*==============================================================*/
create table dbo.SysOperationLog (
   Id                   bigint               not null,
   AccessChannelId      int                  null,
   UserId               int                  null,
   CustomerId           int                  null,
   ClientIpAddress      nvarchar(200)        collate Chinese_PRC_CI_AS null,
   MenuName             nvarchar(100)        collate Chinese_PRC_CI_AS null,
   MenuId               int                  null,
   MenuActionId         int                  null,
   MenuActionName       nvarchar(100)        collate Chinese_PRC_CI_AS null,
   ServiceName          nvarchar(300)        collate Chinese_PRC_CI_AS null,
   FunctionController   nvarchar(200)        collate Chinese_PRC_CI_AS null,
   MethodAction         nvarchar(500)        collate Chinese_PRC_CI_AS null,
   Parameters           nvarchar(Max)        collate Chinese_PRC_CI_AS null,
   ExecutionTime        datetime             null,
   ExecutionDuration    int                  null,
   ClientName           nvarchar(200)        collate Chinese_PRC_CI_AS null,
   BrowserInfo          nvarchar(2000)       collate Chinese_PRC_CI_AS null,
   Exception            nvarchar(Max)        collate Chinese_PRC_CI_AS null,
   Description          nvarchar(2000)       collate Chinese_PRC_CI_AS null,
   SourceEquipment      nvarchar(200)        collate Chinese_PRC_CI_AS null,
   CustomData           nvarchar(2000)       collate Chinese_PRC_CI_AS null,
   IPNum                int                  null,
   Token                nvarchar(200)        collate Chinese_PRC_CI_AS null,
   Navigator            nvarchar(500)        collate Chinese_PRC_CI_AS null,
   RequestUri           nvarchar(500)        collate Chinese_PRC_CI_AS null,
   UrlReferrer          nvarchar(500)        collate Chinese_PRC_CI_AS null,
   RequestType          int                  null,
   Enabled              int                  null constraint DF__SysOperat__Enabl__0D64F3ED default (1),
   InUser               int                  null,
   InDate               datetime             null constraint DF__SysOperat__InDat__0E591826 default getdate(),
   DelUser              int                  null,
   DelState             int                  null constraint DF__SysOperat__DelSt__3A4CA8FD default (0),
   DelDate              datetime             null constraint DF__SysOperat__DelDa__10416098 default getdate(),
   constraint PK_SYSOPERATIONLOG primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.SysOperationLog') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'SysOperationLog' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '操作日志', 
   'user', 'dbo', 'table', 'SysOperationLog'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'Id'

end


execute sp_addextendedproperty 'MS_Description', 
   '操作日志Id',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AccessChannelId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'AccessChannelId'

end


execute sp_addextendedproperty 'MS_Description', 
   '程序渠道Id',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'AccessChannelId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'UserId'

end


execute sp_addextendedproperty 'MS_Description', 
   '用户Id',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'UserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CustomerId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'CustomerId'

end


execute sp_addextendedproperty 'MS_Description', 
   '客户Id',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'CustomerId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ClientIpAddress')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'ClientIpAddress'

end


execute sp_addextendedproperty 'MS_Description', 
   '客户端Ip地址',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'ClientIpAddress'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'MenuName'

end


execute sp_addextendedproperty 'MS_Description', 
   '模块名称',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'MenuName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'MenuId'

end


execute sp_addextendedproperty 'MS_Description', 
   '模块Id',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'MenuId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuActionId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'MenuActionId'

end


execute sp_addextendedproperty 'MS_Description', 
   '功能操作Id',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'MenuActionId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuActionName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'MenuActionName'

end


execute sp_addextendedproperty 'MS_Description', 
   '功能操作名称',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'MenuActionName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ServiceName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'ServiceName'

end


execute sp_addextendedproperty 'MS_Description', 
   '服务名称',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'ServiceName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FunctionController')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'FunctionController'

end


execute sp_addextendedproperty 'MS_Description', 
   '功能模块',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'FunctionController'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MethodAction')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'MethodAction'

end


execute sp_addextendedproperty 'MS_Description', 
   '方法名称',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'MethodAction'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Parameters')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'Parameters'

end


execute sp_addextendedproperty 'MS_Description', 
   '参数',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'Parameters'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExecutionTime')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'ExecutionTime'

end


execute sp_addextendedproperty 'MS_Description', 
   '执行时间',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'ExecutionTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExecutionDuration')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'ExecutionDuration'

end


execute sp_addextendedproperty 'MS_Description', 
   '执行耗时',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'ExecutionDuration'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ClientName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'ClientName'

end


execute sp_addextendedproperty 'MS_Description', 
   '客户端名称',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'ClientName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BrowserInfo')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'BrowserInfo'

end


execute sp_addextendedproperty 'MS_Description', 
   '浏览器信息',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'BrowserInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Exception')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'Exception'

end


execute sp_addextendedproperty 'MS_Description', 
   '操作内容',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'Exception'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Description')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'Description'

end


execute sp_addextendedproperty 'MS_Description', 
   '类的说明',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'Description'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SourceEquipment')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'SourceEquipment'

end


execute sp_addextendedproperty 'MS_Description', 
   '来源设备',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'SourceEquipment'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CustomData')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'CustomData'

end


execute sp_addextendedproperty 'MS_Description', 
   '自定义信息',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'CustomData'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IPNum')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'IPNum'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP数值',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'IPNum'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Token')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'Token'

end


execute sp_addextendedproperty 'MS_Description', 
   '登录Token',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'Token'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Navigator')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'Navigator'

end


execute sp_addextendedproperty 'MS_Description', 
   '浏览器代理',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'Navigator'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RequestUri')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'RequestUri'

end


execute sp_addextendedproperty 'MS_Description', 
   '浏览地址',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'RequestUri'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UrlReferrer')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'UrlReferrer'

end


execute sp_addextendedproperty 'MS_Description', 
   '上次请求地址',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'UrlReferrer'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RequestType')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'RequestType'

end


execute sp_addextendedproperty 'MS_Description', 
   '请求类型 0请求前 1请求后',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'RequestType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Enabled')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'Enabled'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否有效  0 无效  1 有效',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'Enabled'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'InUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '录入人员',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'InUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'InDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '录入日期',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'InDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'DelUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '删除人员',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'DelUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelState')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'DelState'

end


execute sp_addextendedproperty 'MS_Description', 
   '标识该行数据是否被删除 0未删除 1已删除',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'DelState'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysOperationLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'DelDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', 'dbo', 'table', 'SysOperationLog', 'column', 'DelDate'
go

/*==============================================================*/
/* Table: SysUser2                                              */
/*==============================================================*/
create table dbo.SysUser2 (
   Id                   int                  not null,
   Sys_Id               int                  null,
   UserName             nvarchar(50)         collate Chinese_PRC_CI_AS null,
   LoginName            nvarchar(50)         collate Chinese_PRC_CI_AS null,
   PassWord             nvarchar(200)        collate Chinese_PRC_CI_AS null,
   LastPassword         nvarchar(200)        collate Chinese_PRC_CI_AS null,
   UserExtent           int                  null,
   Enabled              int                  null constraint DF__SysUser__Enabled__3D14070F default (1),
   UserIsFreeze         int                  null constraint DF__SysUser__UserIsF__3E082B48 default (0),
   UserIsManage         int                  null constraint DF__SysUser__UserIsM__3EFC4F81 default (0),
   UserRemark           nvarchar(300)        collate Chinese_PRC_CI_AS null,
   BeginDate            datetime             null,
   ExpireDade           datetime             null,
   IsExpireDate         int                  null constraint DF__SysUser__IsExpir__3FF073BA default (0),
   PartitionFalg        int                  null constraint DF__SysUser__Partiti__40E497F3 default (1),
   FlowDepId            int                  null,
   FlowTypeCode         int                  null,
   UserType             int                  null,
   UserPosition         int                  null,
   UserCustomerId       int                  null,
   PlaneNumber          nvarchar(50)         collate Chinese_PRC_CI_AS null,
   WhetherDog           int                  null,
   Securitylevel        int                  null,
   DistrictId           int                  null,
   DataGroupId          int                  null,
   InUser               int                  null,
   InDate               datetime             null constraint DF__SysUser__InDate__41D8BC2C default getdate(),
   EditUser             int                  null,
   EditDate             datetime             null constraint DF__SysUser__EditDat__42CCE065 default getdate(),
   DelState             int                  null constraint DF__SysUser__DelStat__43C1049E default (0),
   DelUser              int                  null,
   DelDate              datetime             null constraint DF__SysUser__DelDate__44B528D7 default getdate(),
   constraint PK_SYSUSER primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.SysUser2') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'SysUser2' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '用户帐号', 
   'user', 'dbo', 'table', 'SysUser2'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'Id'

end


execute sp_addextendedproperty 'MS_Description', 
   '用户Id',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sys_Id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'Sys_Id'

end


execute sp_addextendedproperty 'MS_Description', 
   '员工Id',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'Sys_Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'UserName'

end


execute sp_addextendedproperty 'MS_Description', 
   '用户名称',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'UserName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LoginName')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'LoginName'

end


execute sp_addextendedproperty 'MS_Description', 
   '登录名称',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'LoginName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PassWord')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'PassWord'

end


execute sp_addextendedproperty 'MS_Description', 
   '登录密码',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'PassWord'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LastPassword')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'LastPassword'

end


execute sp_addextendedproperty 'MS_Description', 
   '上次密码',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'LastPassword'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserExtent')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'UserExtent'

end


execute sp_addextendedproperty 'MS_Description', 
   '0 不可分配权限 1 可以分配权限',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'UserExtent'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Enabled')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'Enabled'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否有效  0 无效  1 有效',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'Enabled'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserIsFreeze')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'UserIsFreeze'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否冻结 0未冻结 1冻结',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'UserIsFreeze'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserIsManage')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'UserIsManage'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否系统帐号0 否 1是',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'UserIsManage'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserRemark')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'UserRemark'

end


execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'UserRemark'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BeginDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'BeginDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '起始有效日期',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'BeginDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExpireDade')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'ExpireDade'

end


execute sp_addextendedproperty 'MS_Description', 
   '终止有效期',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'ExpireDade'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsExpireDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'IsExpireDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否启用有效日期 0不启用 1启用',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'IsExpireDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PartitionFalg')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'PartitionFalg'

end


execute sp_addextendedproperty 'MS_Description', 
   '分区标识，插入表分区的标识',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'PartitionFalg'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FlowDepId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'FlowDepId'

end


execute sp_addextendedproperty 'MS_Description', 
   '流程部门Id',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'FlowDepId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FlowTypeCode')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'FlowTypeCode'

end


execute sp_addextendedproperty 'MS_Description', 
   '流程审核级别编号',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'FlowTypeCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserType')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'UserType'

end


execute sp_addextendedproperty 'MS_Description', 
   '员工客户0员工 1客户2厂家',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'UserType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserPosition')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'UserPosition'

end


execute sp_addextendedproperty 'MS_Description', 
   '职位',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'UserPosition'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserCustomerId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'UserCustomerId'

end


execute sp_addextendedproperty 'MS_Description', 
   '客户Id',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'UserCustomerId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PlaneNumber')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'PlaneNumber'

end


execute sp_addextendedproperty 'MS_Description', 
   '座机号码',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'PlaneNumber'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'WhetherDog')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'WhetherDog'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否启用电子狗 0 否 1 是',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'WhetherDog'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Securitylevel')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'Securitylevel'

end


execute sp_addextendedproperty 'MS_Description', 
   '安全级别',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'Securitylevel'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DistrictId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'DistrictId'

end


execute sp_addextendedproperty 'MS_Description', 
   '行政地区Id',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'DistrictId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DataGroupId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'DataGroupId'

end


execute sp_addextendedproperty 'MS_Description', 
   '数据组Id',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'DataGroupId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'InUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '录入人员',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'InUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'InDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '录入日期',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'InDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EditUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'EditUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '修改人员',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'EditUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EditDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'EditDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '修改日期',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'EditDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelState')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'DelState'

end


execute sp_addextendedproperty 'MS_Description', 
   '标识该行数据是否被删除 0未删除 1已删除',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'DelState'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'DelUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '删除人员',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'DelUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUser2')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUser2', 'column', 'DelDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', 'dbo', 'table', 'SysUser2', 'column', 'DelDate'
go

/*==============================================================*/
/* Table: SysUserMenu                                           */
/*==============================================================*/
create table dbo.SysUserMenu (
   Id                   int                  not null,
   MenuId               int                  null,
   UserId               int                  null,
   CheckBoxState        int                  null constraint DF__SysUserMe__Check__7755B73D default (0),
   Enabled              int                  null constraint DF__SysUserMe__Enabl__7849DB76 default (1),
   InUser               int                  null,
   InDate               datetime             null constraint DF__SysUserMe__InDat__793DFFAF default getdate(),
   constraint PK_SYSUSERMENU primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.SysUserMenu') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'SysUserMenu' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '用户功能', 
   'user', 'dbo', 'table', 'SysUserMenu'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUserMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUserMenu', 'column', 'Id'

end


execute sp_addextendedproperty 'MS_Description', 
   '用户功能Id',
   'user', 'dbo', 'table', 'SysUserMenu', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUserMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUserMenu', 'column', 'MenuId'

end


execute sp_addextendedproperty 'MS_Description', 
   '模块Id',
   'user', 'dbo', 'table', 'SysUserMenu', 'column', 'MenuId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUserMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUserMenu', 'column', 'UserId'

end


execute sp_addextendedproperty 'MS_Description', 
   '主键 用户Id',
   'user', 'dbo', 'table', 'SysUserMenu', 'column', 'UserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUserMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CheckBoxState')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUserMenu', 'column', 'CheckBoxState'

end


execute sp_addextendedproperty 'MS_Description', 
   '复选框状态 0虚状态  1实状态',
   'user', 'dbo', 'table', 'SysUserMenu', 'column', 'CheckBoxState'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUserMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Enabled')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUserMenu', 'column', 'Enabled'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否有效  0 无效  1 有效',
   'user', 'dbo', 'table', 'SysUserMenu', 'column', 'Enabled'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUserMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUserMenu', 'column', 'InUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '录入人员',
   'user', 'dbo', 'table', 'SysUserMenu', 'column', 'InUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUserMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUserMenu', 'column', 'InDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '录入日期',
   'user', 'dbo', 'table', 'SysUserMenu', 'column', 'InDate'
go

/*==============================================================*/
/* Table: SysUserPermission                                     */
/*==============================================================*/
create table dbo.SysUserPermission (
   Id                   int                  not null,
   MenuActionId         int                  null,
   MenuId               int                  null,
   UserId               int                  null,
   CheckBoxState        int                  null constraint DF__SysUserPe__Check__7814D14C default (0),
   Enabled              int                  null constraint DF__SysUserPe__Enabl__7908F585 default (1),
   InUser               int                  null,
   InDate               datetime             null constraint DF__SysUserPe__InDat__79FD19BE default getdate(),
   constraint PK_SYSUSERPERMISSION primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.SysUserPermission') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'SysUserPermission' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '用户操作权限', 
   'user', 'dbo', 'table', 'SysUserPermission'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUserPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUserPermission', 'column', 'Id'

end


execute sp_addextendedproperty 'MS_Description', 
   '用户功能操作',
   'user', 'dbo', 'table', 'SysUserPermission', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUserPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuActionId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUserPermission', 'column', 'MenuActionId'

end


execute sp_addextendedproperty 'MS_Description', 
   '功能操作Id',
   'user', 'dbo', 'table', 'SysUserPermission', 'column', 'MenuActionId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUserPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUserPermission', 'column', 'MenuId'

end


execute sp_addextendedproperty 'MS_Description', 
   '模块Id',
   'user', 'dbo', 'table', 'SysUserPermission', 'column', 'MenuId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUserPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUserPermission', 'column', 'UserId'

end


execute sp_addextendedproperty 'MS_Description', 
   '用户Id',
   'user', 'dbo', 'table', 'SysUserPermission', 'column', 'UserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUserPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CheckBoxState')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUserPermission', 'column', 'CheckBoxState'

end


execute sp_addextendedproperty 'MS_Description', 
   '复选框状态 0虚状态  1实状态',
   'user', 'dbo', 'table', 'SysUserPermission', 'column', 'CheckBoxState'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUserPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Enabled')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUserPermission', 'column', 'Enabled'

end


execute sp_addextendedproperty 'MS_Description', 
   '是否有效  0 无效  1 有效',
   'user', 'dbo', 'table', 'SysUserPermission', 'column', 'Enabled'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUserPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InUser')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUserPermission', 'column', 'InUser'

end


execute sp_addextendedproperty 'MS_Description', 
   '录入人员',
   'user', 'dbo', 'table', 'SysUserPermission', 'column', 'InUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.SysUserPermission')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InDate')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'SysUserPermission', 'column', 'InDate'

end


execute sp_addextendedproperty 'MS_Description', 
   '录入日期',
   'user', 'dbo', 'table', 'SysUserPermission', 'column', 'InDate'
go

/*==============================================================*/
/* Table: SysUserSession                                        */
/*==============================================================*/
create table dbo.SysUserSession (
   ID                   int                  identity(1, 1),
   用户id                 int                  not null,
   Session名称            nvarchar(30)         collate Chinese_PRC_CI_AS not null,
   值                    nvarchar(500)        collate Chinese_PRC_CI_AS null,
   constraint PK_SYSUSERSESSION primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('dbo.SysUserSession') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'user', 'dbo', 'table', 'SysUserSession' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   'SysUserSession', 
   'user', 'dbo', 'table', 'SysUserSession'
go

/*==============================================================*/
/* Table: WayBillInfo                                           */
/*==============================================================*/
create table WayBillInfo (
   Id                   int                  identity,
   OrderId              int                  null,
   OrderCode            nvarchar(200)        null,
   ShipperCode          nvarchar(200)        null,
   LogisticCode         nvarchar(200)        null,
   State                int                  null,
   Success              int                  null,
   Reason               nvarchar(2000)       null,
   DeliveryAddress      nvarchar(200)        null,
   MailingAddress       nvarchar(200)        null,
   SyncDate             date                 null,
   Remark               nvarchar(200)        null,
   constraint PK_WAYBILLINFO primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('WayBillInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'WayBillInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '运单信息', 
   'user', @CurrentUser, 'table', 'WayBillInfo'
go

/*==============================================================*/
/* Table: WayBillTraceInfo                                      */
/*==============================================================*/
create table WayBillTraceInfo (
   Id                   int                  identity,
   LogisticId           int                  null,
   AcceptTime           nvarchar(200)        null,
   AcceptStation        nvarchar(200)        null,
   SyncDate             date                 null,
   Remark               nvarchar(200)        null,
   constraint PK_WAYBILLTRACEINFO primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('WayBillTraceInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'WayBillTraceInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '物流跟踪信息', 
   'user', @CurrentUser, 'table', 'WayBillTraceInfo'
go

alter table GoodInfo
   add constraint FK_GOODINFO_REFERENCE_SHIPINFO foreign key (StoreId)
      references ShipInfo (Id)
go

alter table OrderDetail
   add constraint FK_ORDERDET_REFERENCE_ORDERINF foreign key (OrderId)
      references OrderInfo (Id)
go

alter table SynchronizationConfig
   add constraint FK_SYNCHRON_REFERENCE_SYSUSER2 foreign key (UserId)
      references dbo.SysUser2 (Id)
go

alter table dbo.SysLoginToken
   add constraint FK_SYSLOGIN_REFERENCE_SYSUSER2 foreign key (UserId)
      references dbo.SysUser2 (Id)
go

alter table dbo.SysMenuPermission
   add constraint FK_SYSMENUP_REFERENCE_SYSMENU foreign key (MenuId)
      references dbo.SysMenu (Id)
go

alter table dbo.SysUserMenu
   add constraint "FK_SYSUSERM_REF-SYS-M_SYSUSER2" foreign key (UserId)
      references dbo.SysUser2 (Id)
go

alter table dbo.SysUserMenu
   add constraint FK_SYSUSERM_REFERENCE_SYSMENU foreign key (MenuId)
      references dbo.SysMenu (Id)
go

alter table dbo.SysUserPermission
   add constraint FK_SYSUSERP_REFERENCE_SYSUSER2 foreign key (UserId)
      references dbo.SysUser2 (Id)
go

alter table dbo.SysUserPermission
   add constraint FK_SYSUSERP_REFERENCE_SYSMENUP foreign key (MenuActionId)
      references dbo.SysMenuPermission (Id)
go

alter table dbo.SysUserPermission
   add constraint FK_SYSUSERP_REFERENCE_SYSMENU foreign key (MenuId)
      references dbo.SysMenu (Id)
go

alter table dbo.SysUserSession
   add constraint FK_SYSUSERS_REFERENCE_SYSUSER2 foreign key (用户id)
      references dbo.SysUser2 (Id)
go

alter table WayBillInfo
   add constraint FK_WAYBILLI_REFERENCE_ORDERINF foreign key (OrderId)
      references OrderInfo (Id)
go

alter table WayBillTraceInfo
   add constraint FK_WAYBILLT_REFERENCE_WAYBILLI foreign key (LogisticId)
      references WayBillInfo (Id)
go

