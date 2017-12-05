/*==============================================================*/
/* DBMS name:      ORACLE Version 11g                           */
/* Created on:     2017/12/5 16:54:08                           */
/*==============================================================*/



-- Type package declaration
create or replace package PDTypes  
as
    TYPE ref_cursor IS REF CURSOR;
end;

-- Integrity package declaration
create or replace package IntegrityPackage AS
 procedure InitNestLevel;
 function GetNestLevel return number;
 procedure NextNestLevel;
 procedure PreviousNestLevel;
 end IntegrityPackage;
/

-- Integrity package definition
create or replace package body IntegrityPackage AS
 NestLevel number;

-- Procedure to initialize the trigger nest level
 procedure InitNestLevel is
 begin
 NestLevel := 0;
 end;


-- Function to return the trigger nest level
 function GetNestLevel return number is
 begin
 if NestLevel is null then
     NestLevel := 0;
 end if;
 return(NestLevel);
 end;

-- Procedure to increase the trigger nest level
 procedure NextNestLevel is
 begin
 if NestLevel is null then
     NestLevel := 0;
 end if;
 NestLevel := NestLevel + 1;
 end;

-- Procedure to decrease the trigger nest level
 procedure PreviousNestLevel is
 begin
 NestLevel := NestLevel - 1;
 end;

 end IntegrityPackage;
/


drop trigger TR_DEPARTMENT
/

drop trigger "tib_dm_cityinfo"
/

drop trigger "tib_dm_logger"
/

drop trigger "tib_dm_mapservices"
/

drop trigger "tib_dm_mxdproperties"
/

drop trigger "tib_dm_server"
/

drop trigger "tib_dm_treenodeinfo"
/

drop trigger TR_FEATUREINFO
/

drop trigger TR_FEATURE_LAYER
/

drop trigger TR_FUNCTIONINFO
/

drop trigger TR_FUNCTIONTYPE
/

drop trigger TR_LAYERINFO
/

drop trigger TR_LOGIN_LOG
/

drop trigger "tib_maplevel"
/

drop trigger TR_METADATAINFO
/

drop trigger TR_RESOURCEINFO
/

drop trigger TR_RESOURCETYPE
/

drop trigger TR_RESVISITLOG
/

drop trigger TR_ROLEINFO
/

drop trigger TR_ROLETYPE
/

drop trigger TR_SCENES
/

drop trigger TR_SYSTEMINFO
/

drop trigger TR_USERINFO
/

drop trigger TR_USERTYPE
/

drop trigger TR_USERDEPARTMENT
/

drop trigger TIB_WORKSPACE
/

alter table DEPARTMENT_FUNCTION
   drop constraint FK_DEPARTME_REFERENCE_DEPARTME
/

alter table DEPARTMENT_FUNCTION
   drop constraint FK_DEPARTME_REFERENCE_FUNCTION
/

alter table DM_SERVER
   drop constraint FK_DM_SERVE_REFERENCE_DM_CITYI
/

alter table FEATURE_LAYER
   drop constraint PK_FEATURELAYER_LAYER
/

alter table FEATURE_LAYER
   drop constraint PK_FEATURELAYER_RESOURCE
/

alter table FUNCTIONINFO
   drop constraint FK_FUNCTIONINFO_FUNCTIONTYPEID
/

alter table LAYERINFO
   drop constraint RESOURCEID
/

alter table RESOURCEINFO
   drop constraint FK_RESOURCEINFO_METADATAID
/

alter table RESOURCEINFO
   drop constraint FK_RESOURCEINFO_RESOURCETYPEID
/

alter table ROLEINFO
   drop constraint FK_ROLEINFO_ROLETYPEID
/

alter table ROLE_FEATURE
   drop constraint FK_ROLEFEATURE_ROLEID
/

alter table ROLE_FUNCTION
   drop constraint FK_ROLEFUNCTION_FUNCTIONID
/

alter table ROLE_FUNCTION
   drop constraint FK_ROLEFUNCTION_ROLEID
/

alter table SYSTEM_FUNCTION
   drop constraint FK_SYSTEM_F_REFERENCE_SYSTEMIN
/

alter table SYSTEM_FUNCTION
   drop constraint FK_SYSTEM_F_REFERENCE_FUNCTION
/

alter table USERINFO
   drop constraint FK_USERINFO_USERTYPEID
/

alter table USERLEVEL
   drop constraint FK_USERLEVE_REFERENCE_USERINFO
/

alter table USERLEVEL
   drop constraint FK_USERLEVE_REFERENCE_MAPLEVEL
/

alter table USER_DEPARTMENT
   drop constraint FK_USERDEPARTMENT_DEPARTMENTID
/

alter table USER_DEPARTMENT
   drop constraint FK_USERDEPARTMENT_USERID
/

alter table USER_FUNCTION
   drop constraint FK_USER_FUN_REFERENCE_USERINFO
/

alter table USER_FUNCTION
   drop constraint FK_USER_FUN_REFERENCE_FUNCTION
/

alter table USER_ROLE
   drop constraint FK_USERROLE_ROLEID
/

alter table USER_ROLE
   drop constraint FK_USERROLE_USERID
/

alter table WORKSPACE
   drop constraint FK_WORKSPAC_REFERENCE_USERINFO
/

drop view PH_TRACEINFO_MAX_PLANSTATUS
/

drop view PH_TRACEINFO_PLANSTATUS
/

drop view FUNCTIONINFO_TYPE
/

drop view FEATURE_RESOURCE_LAYER
/

drop table BUSINESSLAYERDEFINE cascade constraints
/

drop table CONFIG_GLOBALSEARCH cascade constraints
/

drop index UNIQUE_DEPARTMENTNAME
/

drop table DEPARTMENT cascade constraints
/

drop table DEPARTMENT_FUNCTION cascade constraints
/

drop table DM_CITYINFO cascade constraints
/

drop table DM_LOGGER cascade constraints
/

drop table "DM_MapServices" cascade constraints
/

drop table "DM_MxdProperties" cascade constraints
/

drop table DM_SERVER cascade constraints
/

drop table "DM_TreeNodeInfo" cascade constraints
/

drop table FEATUREINFO cascade constraints
/

drop table FEATURE_LAYER cascade constraints
/

drop table FUNCTIONINFO cascade constraints
/

drop table FUNCTIONTYPE cascade constraints
/

drop table GHSJZX_YDLXW cascade constraints
/

drop table LAYERINFO cascade constraints
/

drop table LOGIN_LOG cascade constraints
/

drop table MAPLEVEL cascade constraints
/

drop table METADATAINFO cascade constraints
/

drop table PH_PLANSTATUS cascade constraints
/

drop table PH_TRACEINFO cascade constraints
/

drop table REGION cascade constraints
/

drop index RES_UNIQUE
/

drop table RESOURCEINFO cascade constraints
/

drop table RESOURCETYPE cascade constraints
/

drop table RESOURCE_VISITLOG cascade constraints
/

drop table ROLEINFO cascade constraints
/

drop table ROLETYPE cascade constraints
/

drop table ROLE_FEATURE cascade constraints
/

drop table ROLE_FUNCTION cascade constraints
/

drop table SCENES cascade constraints
/

drop table SX_ITEMINFO cascade constraints
/

drop table SYSTEMINFO cascade constraints
/

drop table SYSTEM_FUNCTION cascade constraints
/

drop table USERINFO cascade constraints
/

drop table USERLEVEL cascade constraints
/

drop table USERTYPE cascade constraints
/

drop table USER_DEPARTMENT cascade constraints
/

drop table USER_FUNCTION cascade constraints
/

drop table USER_ROLE cascade constraints
/

drop table WORKSPACE cascade constraints
/

drop table XM_ITEMINFO cascade constraints
/

drop table XM_XMYZT cascade constraints
/

drop sequence SEQUENCE_1
/

drop sequence SE_CONFIG_GLOBALSEARCH
/

drop sequence SE_DEPARTMENT
/

drop sequence SE_DM_CITYINFO
/

drop sequence SE_DM_LOGGER
/

drop sequence SE_DM_MAPSERVICES
/

drop sequence "SE_DM_MxdProperties"
/

drop sequence SE_DM_SERVER
/

drop sequence SE_DM_TREENODEINFO
/

drop sequence SE_FEATUREINFO
/

drop sequence SE_FEATURETYPE
/

drop sequence SE_FEATURE_LAYER
/

drop sequence SE_FEATURE_RESOURCE
/

drop sequence SE_FUNCTIONINFO
/

drop sequence SE_FUNCTIONTYPE
/

drop sequence SE_LAYERINFO
/

drop sequence SE_LOGIN_LOG
/

drop sequence SE_METADATAINFO
/

drop sequence SE_RESOURCEINFO
/

drop sequence SE_RESOURCESTATUS
/

drop sequence SE_RESOURCETYPE
/

drop sequence SE_RESVISITLOG
/

drop sequence SE_ROLEINFO
/

drop sequence SE_ROLETYPE
/

drop sequence SE_SCENES
/

drop sequence SE_SYSTEMINFO
/

drop sequence SE_USERDEPARTMENT
/

drop sequence SE_USERINFO
/

drop sequence SE_USERTYPE
/

drop sequence SE_WORKSPACE
/

drop sequence "se_maplevel"
/

create sequence SEQUENCE_1
increment by 1
start with 1
 maxvalue 9999999999999999999999999999
 nominvalue
nocycle
noorder
/

create sequence SE_CONFIG_GLOBALSEARCH
increment by 1
start with 141
 maxvalue 99999
 nominvalue
nocycle
noorder
/

create sequence SE_DEPARTMENT
increment by 1
start with 281
 maxvalue 99999
 nominvalue
cycle
noorder
/

create sequence SE_DM_CITYINFO
increment by 1
start with 1
 nomaxvalue
 nominvalue
/

create sequence SE_DM_LOGGER
increment by 1
start with 1
 nomaxvalue
 nominvalue
/

create sequence SE_DM_MAPSERVICES
increment by 1
start with 1
 nomaxvalue
 nominvalue
/

create sequence "SE_DM_MxdProperties"
increment by 1
start with 1
 nomaxvalue
 nominvalue
/

create sequence SE_DM_SERVER
increment by 1
start with 1
 nomaxvalue
 nominvalue
/

create sequence SE_DM_TREENODEINFO
increment by 1
start with 1
 nomaxvalue
 nominvalue
/

create sequence SE_FEATUREINFO
increment by 1
start with 1570
 maxvalue 999999
 nominvalue
cycle
noorder
/

create sequence SE_FEATURETYPE
increment by 1
start with 81
 maxvalue 999999
 nominvalue
cycle
noorder
/

create sequence SE_FEATURE_LAYER
increment by 1
start with 5442
 maxvalue 999999
 nominvalue
cycle
noorder
/

create sequence SE_FEATURE_RESOURCE
increment by 1
start with 101
 maxvalue 999999
 nominvalue
cycle
noorder
/

create sequence SE_FUNCTIONINFO
increment by 1
start with 541
 maxvalue 999999
 nominvalue
cycle
noorder
/

create sequence SE_FUNCTIONTYPE
increment by 1
start with 201
 maxvalue 999999
 nominvalue
cycle
noorder
/

create sequence SE_LAYERINFO
increment by 1
start with 2721
 maxvalue 999999
 nominvalue
cycle
noorder
/

create sequence SE_LOGIN_LOG
increment by 1
start with 11840
 maxvalue 99999
 nominvalue
cycle
noorder
/

create sequence SE_METADATAINFO
increment by 1
start with 21
 maxvalue 999999
 nominvalue
cycle
noorder
/

create sequence SE_RESOURCEINFO
increment by 1
start with 1207
 maxvalue 999999
 nominvalue
cycle
noorder
/

create sequence SE_RESOURCESTATUS
increment by 1
start with 101
 maxvalue 999999
 nominvalue
cycle
noorder
/

create sequence SE_RESOURCETYPE
increment by 1
start with 101
 maxvalue 999999
 nominvalue
cycle
noorder
/

create sequence SE_RESVISITLOG
increment by 1
start with 141
 maxvalue 999999
 nominvalue
cycle
noorder
/

create sequence SE_ROLEINFO
increment by 1
start with 222
 maxvalue 999999
 nominvalue
cycle
noorder
/

create sequence SE_ROLETYPE
increment by 1
start with 21
 maxvalue 999999
 nominvalue
cycle
order
/

create sequence SE_SCENES
increment by 1
start with 1160
 maxvalue 999999
 minvalue 0
nocycle
noorder
/

create sequence SE_SYSTEMINFO
increment by 1
start with 1
 nomaxvalue
/

create sequence SE_USERDEPARTMENT
increment by 1
start with 601
 maxvalue 999999
 nominvalue
cycle
noorder
/

create sequence SE_USERINFO
increment by 1
start with 662
 maxvalue 99999
 nominvalue
cycle
noorder
/

create sequence SE_USERTYPE
increment by 1
start with 521
 maxvalue 999999
 nominvalue
cycle
noorder
/

create sequence SE_WORKSPACE
increment by 1
start with 21
 maxvalue 9999999999999999999999999999
 nominvalue
nocycle
noorder
/

create sequence "se_maplevel"
increment by 1
start with 1
 nomaxvalue
/

/*==============================================================*/
/* Table: BUSINESSLAYERDEFINE                                   */
/*==============================================================*/
create table BUSINESSLAYERDEFINE 
(
   BTMID                VARCHAR2(20)         not null,
   ATMID                VARCHAR2(50)         not null,
   LAYERGIS             VARCHAR2(200),
   LAYERLISTKEY         VARCHAR2(200),
   TEMPLAYERGIS         VARCHAR2(1000),
   TEMPLAYERLISTKEY     VARCHAR2(500),
   SYSKEY               VARCHAR2(50),
   constraint PK_BUSINESSLAYERDEFINE primary key (BTMID, ATMID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table BUSINESSLAYERDEFINE is
'业务红线绑定表'
/

comment on column BUSINESSLAYERDEFINE.BTMID is
'业务模型编号'
/

comment on column BUSINESSLAYERDEFINE.ATMID is
'业务类型编号'
/

comment on column BUSINESSLAYERDEFINE.LAYERGIS is
'对应GIS图'
/

comment on column BUSINESSLAYERDEFINE.LAYERLISTKEY is
'对应专题集'
/

comment on column BUSINESSLAYERDEFINE.TEMPLAYERGIS is
'临时对应GIS图'
/

comment on column BUSINESSLAYERDEFINE.TEMPLAYERLISTKEY is
'临时对应专题集'
/

comment on column BUSINESSLAYERDEFINE.SYSKEY is
'业务类型'
/

/*==============================================================*/
/* Table: CONFIG_GLOBALSEARCH                                   */
/*==============================================================*/
create table CONFIG_GLOBALSEARCH 
(
   ID                   NUMBER               not null,
   RESOURCEID           NUMBER,
   LAYERS               NVARCHAR2(200),
   FIELDS               NVARCHAR2(200),
   NAME                 NVARCHAR2(200),
   constraint CONFIG_GLOBALSEARCH_PRIMARY primary key (ID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 1024K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

/*==============================================================*/
/* Table: DEPARTMENT                                            */
/*==============================================================*/
create table DEPARTMENT 
(
   DEPARTMENTID         NUMBER               not null,
   DEPARTMENTNAME       VARCHAR2(50),
   DESCRIPTION          VARCHAR2(256),
   DEPARTMENTPARENTID   VARCHAR2(50),
   SINDEX               NUMBER,
   EXTRAID              VARCHAR2(50),
   EXTRAPID             VARCHAR2(50),
   constraint PK_DEPARTMENT primary key (DEPARTMENTID)
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table DEPARTMENT is
'部门表'
/

comment on column DEPARTMENT.DEPARTMENTID is
'部门id'
/

comment on column DEPARTMENT.DEPARTMENTNAME is
'部门名称'
/

comment on column DEPARTMENT.DESCRIPTION is
'描述'
/

comment on column DEPARTMENT.DEPARTMENTPARENTID is
'上级部门id'
/

comment on column DEPARTMENT.SINDEX is
'排序索引'
/

comment on column DEPARTMENT.EXTRAID is
'对接ID'
/

comment on column DEPARTMENT.EXTRAPID is
'对接PID'
/

/*==============================================================*/
/* Index: UNIQUE_DEPARTMENTNAME                                 */
/*==============================================================*/
create unique index UNIQUE_DEPARTMENTNAME on DEPARTMENT (
   DEPARTMENTNAME ASC
)
pctfree 10
initrans 2
storage
(
    initial 64K
    next 1024K
    minextents 1
    maxextents unlimited
    buffer_pool default
)
logging
tablespace QLONEMAP1
/

/*==============================================================*/
/* Table: DEPARTMENT_FUNCTION                                   */
/*==============================================================*/
create table DEPARTMENT_FUNCTION 
(
   DEPARTMENTID         NUMBER,
   FUNCTIONID           NUMBER
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace JYONEMAP
logging
 nocompress
 monitoring
 noparallel
/

comment on table DEPARTMENT_FUNCTION is
'机构功能权限表'
/

comment on column DEPARTMENT_FUNCTION.DEPARTMENTID is
'部门id'
/

comment on column DEPARTMENT_FUNCTION.FUNCTIONID is
'功能id'
/

/*==============================================================*/
/* Table: DM_CITYINFO                                           */
/*==============================================================*/
create table DM_CITYINFO 
(
   "CityID"             NUMBER               not null,
   "CityName"           VARCHAR2(200 BYTE),
   "CityCode"           VARCHAR(100),
   "Remark"             VARCHAR(500),
   constraint PK_DM_CITYINFO primary key ("CityID")
)
/

comment on table DM_CITYINFO is
'产业新城明细表'
/

comment on column DM_CITYINFO."CityID" is
'产业新城id--主键'
/

comment on column DM_CITYINFO."CityName" is
'新城名称'
/

comment on column DM_CITYINFO."CityCode" is
'新城编码'
/

comment on column DM_CITYINFO."Remark" is
'备注'
/

/*==============================================================*/
/* Table: DM_LOGGER                                             */
/*==============================================================*/
create table DM_LOGGER 
(
   "LoggerId"           NUMBER               not null,
   "SysName"            VARCHAR(200),
   "UserName"           VARCHAR(200),
   IP                   VARCHAR(100),
   "EventTime"          DATE,
   "EventType"          VARCHAR(200),
   "LogMessage"         VARCHAR(2000),
   "Remark"             VARCHAR(500),
   constraint PK_DM_LOGGER primary key ("LoggerId")
)
/

comment on table DM_LOGGER is
'空间数据库管理系统-日志表
'
/

comment on column DM_LOGGER."LoggerId" is
'主键Id'
/

comment on column DM_LOGGER."SysName" is
'系统名称'
/

comment on column DM_LOGGER."UserName" is
'登录用户'
/

comment on column DM_LOGGER.IP is
'登录Ip'
/

comment on column DM_LOGGER."EventTime" is
'事件时间'
/

comment on column DM_LOGGER."EventType" is
'事件类型'
/

comment on column DM_LOGGER."LogMessage" is
'操作结果信息'
/

comment on column DM_LOGGER."Remark" is
'备注'
/

/*==============================================================*/
/* Table: "DM_MapServices"                                      */
/*==============================================================*/
create table "DM_MapServices" 
(
   "ServerId"           NUMBER               not null,
   "AliasServerName"    VARCHAR(200),
   "ServerName"         VARCHAR(200),
   "Http"               VARCHAR2(500 BYTE),
   "ServerType"         VARCHAR(50),
   "Remark"             VARCHAR(500),
   constraint PK_DM_MAPSERVICES primary key ("ServerId")
)
/

comment on table "DM_MapServices" is
'空间数据库管理系统--地图服务表
用于叠加外部服务'
/

comment on column "DM_MapServices"."ServerId" is
'服务id-主键'
/

comment on column "DM_MapServices"."AliasServerName" is
'服务别名'
/

comment on column "DM_MapServices"."ServerName" is
'服务名称'
/

comment on column "DM_MapServices"."Http" is
'服务地址'
/

comment on column "DM_MapServices"."ServerType" is
'服务类型'
/

comment on column "DM_MapServices"."Remark" is
'备注'
/

/*==============================================================*/
/* Table: "DM_MxdProperties"                                    */
/*==============================================================*/
create table "DM_MxdProperties" 
(
   "MxdId"              NUMBER               not null,
   "NodeId"             NUMBER,
   "LayerName"          VARCHAR(200),
   "FeatureClassName"   VARCHAR(200),
   "LayerProperties"    BLOB,
   "Remark"             VARCHAR(500),
   constraint PK_DM_MXDPROPERTIES primary key ("MxdId")
)
/

comment on table "DM_MxdProperties" is
'空间数据库管理系统--MXD图层属性表'
/

comment on column "DM_MxdProperties"."MxdId" is
'主键ID'
/

comment on column "DM_MxdProperties"."NodeId" is
'节点编号'
/

comment on column "DM_MxdProperties"."LayerName" is
'图层名称'
/

comment on column "DM_MxdProperties"."FeatureClassName" is
'要素名称'
/

comment on column "DM_MxdProperties"."LayerProperties" is
'图层配置属性'
/

comment on column "DM_MxdProperties"."Remark" is
'备注'
/

/*==============================================================*/
/* Table: DM_SERVER                                             */
/*==============================================================*/
create table DM_SERVER 
(
   "ServerId"           NUMBER               not null,
   "CityID"             NUMBER,
   "ServerIP"           VARCHAR(200),
   "Instance"           VARCHAR(200),
   "User"               VARCHAR(200),
   "Password"           VARCHAR(200),
   "Version"            VARCHAR(200),
   "Remark"             VARCHAR(500),
   constraint PK_DM_SERVER primary key ("ServerId")
)
/

comment on table DM_SERVER is
'空间数据库管理系统--服务器资源表（基础表）
用于记录各新城的服务器信息'
/

comment on column DM_SERVER."ServerId" is
'服务器id-主键'
/

comment on column DM_SERVER."CityID" is
'产业新城id--主键'
/

comment on column DM_SERVER."ServerIP" is
'服务器Ip地址'
/

comment on column DM_SERVER."Instance" is
'实例'
/

comment on column DM_SERVER."User" is
'用户名'
/

comment on column DM_SERVER."Password" is
'密码'
/

comment on column DM_SERVER."Version" is
'版本'
/

comment on column DM_SERVER."Remark" is
'备注'
/

/*==============================================================*/
/* Table: "DM_TreeNodeInfo"                                     */
/*==============================================================*/
create table "DM_TreeNodeInfo" 
(
   "NodeId"             NUMBER               not null,
   "NodePid"            NUMBER,
   "NodeName"           VARCHAR2(200),
   "NodeType"           VARCHAR(200),
   "LayerType"          VARCHAR(200),
   "ShowOrder"          NUMBER,
   "IsDataTable"        NUMBER,
   "IsMxd"              NUMBER,
   "IsUpdated"          NUMBER,
   "Map"                BLOB,
   "CurrentStage"       VARCHAR(200),
   "Remark"             VARCHAR(500),
   constraint PK_DM_TREENODEINFO primary key ("NodeId")
)
/

comment on table "DM_TreeNodeInfo" is
'空间数据库管理系统--数据分类信息表'
/

comment on column "DM_TreeNodeInfo"."NodeId" is
'节点Id'
/

comment on column "DM_TreeNodeInfo"."NodePid" is
'父节点ID'
/

comment on column "DM_TreeNodeInfo"."NodeName" is
'节点名称'
/

comment on column "DM_TreeNodeInfo"."NodeType" is
'节点类型'
/

comment on column "DM_TreeNodeInfo"."LayerType" is
'图层类型'
/

comment on column "DM_TreeNodeInfo"."ShowOrder" is
'显示顺序'
/

comment on column "DM_TreeNodeInfo"."IsDataTable" is
'是否有空间数据结构表'
/

comment on column "DM_TreeNodeInfo"."IsMxd" is
'是否导入MXD文件'
/

comment on column "DM_TreeNodeInfo"."IsUpdated" is
'是否更新，更新后存在历史版本'
/

comment on column "DM_TreeNodeInfo"."Map" is
'Map对象'
/

comment on column "DM_TreeNodeInfo"."CurrentStage" is
'当前阶段'
/

comment on column "DM_TreeNodeInfo"."Remark" is
'备注'
/

/*==============================================================*/
/* Table: FEATUREINFO                                           */
/*==============================================================*/
create table FEATUREINFO 
(
   FEATUREID            NUMBER               not null,
   FEATUREPARENTID      NUMBER,
   FEATURENAME          VARCHAR2(50),
   FEATURETYPE          VARCHAR2(50),
   SINDEX               NUMBER,
   FEATUREEXTENT        VARCHAR2(50),
   IMAGENAME            VARCHAR2(50),
   constraint PK_FEATUREINFO primary key (FEATUREID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table FEATUREINFO is
'专题表'
/

comment on column FEATUREINFO.FEATUREID is
'专题id'
/

comment on column FEATUREINFO.FEATUREPARENTID is
'上级专题id'
/

comment on column FEATUREINFO.FEATURENAME is
'专题名称'
/

comment on column FEATUREINFO.FEATURETYPE is
'专题类型'
/

comment on column FEATUREINFO.SINDEX is
'同级排序'
/

comment on column FEATUREINFO.FEATUREEXTENT is
'范围'
/

comment on column FEATUREINFO.IMAGENAME is
'专题图片名称'
/

/*==============================================================*/
/* Table: FEATURE_LAYER                                         */
/*==============================================================*/
create table FEATURE_LAYER 
(
   FEATUREID            NUMBER,
   LAYERID              NUMBER,
   ID                   NUMBER               not null,
   NODEID               NVARCHAR2(50),
   RESOURCEID           NUMBER,
   constraint PK_FEATURE_LAYER primary key (ID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 128K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table FEATURE_LAYER is
'专题图层关联表'
/

comment on column FEATURE_LAYER.FEATUREID is
'专题ID'
/

comment on column FEATURE_LAYER.LAYERID is
'图层ID'
/

comment on column FEATURE_LAYER.ID is
'ID'
/

comment on column FEATURE_LAYER.NODEID is
'节点ID'
/

comment on column FEATURE_LAYER.RESOURCEID is
'资源ID'
/

/*==============================================================*/
/* Table: FUNCTIONINFO                                          */
/*==============================================================*/
create table FUNCTIONINFO 
(
   FUNCTIONID           NUMBER               not null,
   FUNCTIONNAME         VARCHAR2(50),
   DISPLAYNAME          VARCHAR2(50),
   FUNCTIONTYPEID       NUMBER,
   DESCRIPTION          VARCHAR2(256),
   EXECUTE              VARCHAR2(50),
   CLSNAME              VARCHAR2(50),
   SINDEX               NUMBER,
   constraint PK_FUNCTIONINFO primary key (FUNCTIONID)
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table FUNCTIONINFO is
'功能表'
/

comment on column FUNCTIONINFO.FUNCTIONID is
'功能id'
/

comment on column FUNCTIONINFO.FUNCTIONNAME is
'功能名称'
/

comment on column FUNCTIONINFO.DISPLAYNAME is
'显示名称'
/

comment on column FUNCTIONINFO.FUNCTIONTYPEID is
'功能类型id'
/

comment on column FUNCTIONINFO.DESCRIPTION is
'描述'
/

comment on column FUNCTIONINFO.EXECUTE is
'执行函数'
/

comment on column FUNCTIONINFO.CLSNAME is
'样式名称'
/

comment on column FUNCTIONINFO.SINDEX is
'排序'
/

/*==============================================================*/
/* Table: FUNCTIONTYPE                                          */
/*==============================================================*/
create table FUNCTIONTYPE 
(
   FUNCTIONTYPEID       NUMBER               not null,
   FUNCTIONTYPENAME     VARCHAR2(50),
   DESCRIPTION          VARCHAR2(256),
   CLSNAME              VARCHAR2(50),
   SINDEX               NUMBER,
   constraint PK_FUNCTIONTYPE primary key (FUNCTIONTYPEID)
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table FUNCTIONTYPE is
'功能类型表'
/

comment on column FUNCTIONTYPE.FUNCTIONTYPEID is
'功能类型id'
/

comment on column FUNCTIONTYPE.FUNCTIONTYPENAME is
'功能类型名称'
/

comment on column FUNCTIONTYPE.DESCRIPTION is
'描述'
/

comment on column FUNCTIONTYPE.CLSNAME is
'样式'
/

comment on column FUNCTIONTYPE.SINDEX is
'排序'
/

/*==============================================================*/
/* Table: GHSJZX_YDLXW                                          */
/*==============================================================*/
create table GHSJZX_YDLXW 
(
   YDLXBMXL             VARCHAR2(20)         not null,
   YDLXXL               VARCHAR2(50)         not null,
   YDLXBMZL             VARCHAR2(20)         not null,
   YDLXZL               VARCHAR2(50)         not null,
   YDLXBMDL             VARCHAR2(20)         not null,
   YDXZDL               VARCHAR2(50)         not null
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 1024K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on column GHSJZX_YDLXW.YDLXBMXL is
'用地类型编码小类'
/

comment on column GHSJZX_YDLXW.YDLXXL is
'用地性质小类'
/

comment on column GHSJZX_YDLXW.YDLXBMZL is
'用地类型编码中类'
/

comment on column GHSJZX_YDLXW.YDLXZL is
'用地性质中类'
/

comment on column GHSJZX_YDLXW.YDLXBMDL is
'用地类型编码大类'
/

comment on column GHSJZX_YDLXW.YDXZDL is
'用地性质大类'
/

/*==============================================================*/
/* Table: LAYERINFO                                             */
/*==============================================================*/
create table LAYERINFO 
(
   LAYERID              NUMBER,
   LAYERNAME            VARCHAR2(50),
   ADDRESSNAME          VARCHAR2(100),
   SINDEX               NUMBER,
   RESOURCEID           NUMBER,
   constraint LAYERID unique (LAYERID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table LAYERINFO is
'图层信息表'
/

comment on column LAYERINFO.LAYERID is
'图层id'
/

comment on column LAYERINFO.LAYERNAME is
'图层名称'
/

comment on column LAYERINFO.ADDRESSNAME is
'物理图层名'
/

comment on column LAYERINFO.SINDEX is
'图层索引'
/

comment on column LAYERINFO.RESOURCEID is
'资源id'
/

/*==============================================================*/
/* Table: LOGIN_LOG                                             */
/*==============================================================*/
create table LOGIN_LOG 
(
   LOGID                NUMBER               not null,
   VISITTIME            DATE,
   STATUS               VARCHAR2(100),
   EXCEPTION            VARCHAR2(200),
   USERID               VARCHAR2(20),
   USERNAME             VARCHAR2(50),
   DEPARTMENTID         VARCHAR2(20),
   DEPARTMENTNAME       VARCHAR2(50),
   constraint PK_LOGGING primary key (LOGID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 256K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 448K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table LOGIN_LOG is
'登录日志表'
/

comment on column LOGIN_LOG.LOGID is
'登录日记id'
/

comment on column LOGIN_LOG.VISITTIME is
'登录时间'
/

comment on column LOGIN_LOG.STATUS is
'登录状态'
/

comment on column LOGIN_LOG.EXCEPTION is
'异常'
/

comment on column LOGIN_LOG.USERID is
'用户id'
/

comment on column LOGIN_LOG.USERNAME is
'用户名称'
/

comment on column LOGIN_LOG.DEPARTMENTID is
'部门id'
/

comment on column LOGIN_LOG.DEPARTMENTNAME is
'部门名称'
/

/*==============================================================*/
/* Table: MAPLEVEL                                              */
/*==============================================================*/
create table MAPLEVEL 
(
   LEVELID              NUMBER(20)           not null,
   LON                  NUMBER(8,5),
   LAT                  NUMBER(8,5),
   "LEVEL"              INTEGER,
   ALT                  NUMBER(10,5),
   MAPLEVEL             NUMBER(8,5),
   NAME                 VARCHAR2(30),
   constraint PK_MAPLEVEL primary key (LEVELID)
)
/

comment on table MAPLEVEL is
'地图等级表'
/

/*==============================================================*/
/* Table: METADATAINFO                                          */
/*==============================================================*/
create table METADATAINFO 
(
   METADATAID           NUMBER               not null,
   LAYERS               VARCHAR2(100),
   SPATIALEXTENT        VARCHAR2(100),
   SPATIALREFER         VARCHAR2(10),
   constraint PK_METADATAINFO primary key (METADATAID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table METADATAINFO is
'元数据信息表'
/

comment on column METADATAINFO.METADATAID is
'元数据id'
/

comment on column METADATAINFO.LAYERS is
'图层信息'
/

comment on column METADATAINFO.SPATIALEXTENT is
'空间范围'
/

comment on column METADATAINFO.SPATIALREFER is
'空间参考'
/

/*==============================================================*/
/* Table: PH_PLANSTATUS                                         */
/*==============================================================*/
create table PH_PLANSTATUS 
(
   STATUSID             VARCHAR2(20)         not null,
   STATUSNAME           VARCHAR2(50),
   STATUSINDEX          NUMBER,
   constraint PRIMARY_STATUSID primary key (STATUSID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 1024K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table PH_PLANSTATUS is
'批后进度状态表'
/

comment on column PH_PLANSTATUS.STATUSID is
'状态ID'
/

comment on column PH_PLANSTATUS.STATUSNAME is
'状态名称'
/

comment on column PH_PLANSTATUS.STATUSINDEX is
'状态顺序'
/

/*==============================================================*/
/* Table: PH_TRACEINFO                                          */
/*==============================================================*/
create table PH_TRACEINFO 
(
   ID                   NUMBER               not null,
   ITEMID               VARCHAR2(20),
   OLDITEMID            VARCHAR2(20),
   PHPLAN               VARCHAR2(50),
   UPDATEDATE           DATE,
   ISVIOLATION          NUMBER,
   ISDISPOSE            NUMBER,
   MANAGER              VARCHAR2(100),
   constraint PRIMARY_ID primary key (ID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 1024K
    next 1024K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table PH_TRACEINFO is
'批后跟踪信息表'
/

comment on column PH_TRACEINFO.ID is
'ID'
/

comment on column PH_TRACEINFO.ITEMID is
'案件编号'
/

comment on column PH_TRACEINFO.OLDITEMID is
'受理编号'
/

comment on column PH_TRACEINFO.PHPLAN is
'批后进度'
/

comment on column PH_TRACEINFO.UPDATEDATE is
'更新时间'
/

comment on column PH_TRACEINFO.ISVIOLATION is
'是否违规'
/

comment on column PH_TRACEINFO.ISDISPOSE is
'是否处理 1表示存在违法已处理  空值表示未违法 未处理'
/

comment on column PH_TRACEINFO.MANAGER is
'负责人'
/

/*==============================================================*/
/* Table: REGION                                                */
/*==============================================================*/
create table REGION 
(
   REGIONID             VARCHAR2(20)         not null,
   REGIONNAME           VARCHAR2(100),
   constraint PRIMARY_REGIONID primary key (REGIONID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table REGION is
'行政区域编码表'
/

comment on column REGION.REGIONID is
'行政区域编码'
/

comment on column REGION.REGIONNAME is
'行政区域名称'
/

/*==============================================================*/
/* Table: RESOURCEINFO                                          */
/*==============================================================*/
create table RESOURCEINFO 
(
   RESOURCEID           NUMBER               not null,
   RESOURCENAME         VARCHAR2(50),
   RESOURCETYPEID       NUMBER,
   URL                  VARCHAR2(100),
   KEY                  VARCHAR2(100),
   METADATAID           NUMBER,
   DESCRIPTION          VARCHAR2(256),
   PROXYURL             VARCHAR2(100),
   ISLOCKEDOUT          NUMBER(1),
   constraint PK_RESOURCEINFO primary key (RESOURCEID)
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table RESOURCEINFO is
'资源表'
/

comment on column RESOURCEINFO.RESOURCEID is
'资源id'
/

comment on column RESOURCEINFO.RESOURCENAME is
'资源名称'
/

comment on column RESOURCEINFO.RESOURCETYPEID is
'资源类型id'
/

comment on column RESOURCEINFO.URL is
'资源地址'
/

comment on column RESOURCEINFO.KEY is
'资源关键字'
/

comment on column RESOURCEINFO.METADATAID is
'元数据id'
/

comment on column RESOURCEINFO.DESCRIPTION is
'描述'
/

comment on column RESOURCEINFO.PROXYURL is
'代理地址'
/

comment on column RESOURCEINFO.ISLOCKEDOUT is
'是否锁定'
/

/*==============================================================*/
/* Index: RES_UNIQUE                                            */
/*==============================================================*/
create unique index RES_UNIQUE on RESOURCEINFO (
   RESOURCEID ASC,
   RESOURCENAME ASC
)
pctfree 10
initrans 2
storage
(
    initial 64K
    next 1024K
    minextents 1
    maxextents unlimited
    buffer_pool default
)
logging
tablespace QLONEMAP1
/

/*==============================================================*/
/* Table: RESOURCETYPE                                          */
/*==============================================================*/
create table RESOURCETYPE 
(
   RESOURCETYPEID       NUMBER               not null,
   RESOURCETYPENAME     VARCHAR2(50),
   DESCRIPTION          VARCHAR2(256),
   constraint PK_RESOURCETYPE primary key (RESOURCETYPEID)
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table RESOURCETYPE is
'资源类型表'
/

comment on column RESOURCETYPE.RESOURCETYPEID is
'资源类型id'
/

comment on column RESOURCETYPE.RESOURCETYPENAME is
'资源类型名称'
/

comment on column RESOURCETYPE.DESCRIPTION is
'资源类型描述'
/

/*==============================================================*/
/* Table: RESOURCE_VISITLOG                                     */
/*==============================================================*/
create table RESOURCE_VISITLOG 
(
   VISITID              NUMBER               not null,
   VISITTIME            DATE,
   USERID               VARCHAR2(20),
   RESID                NUMBER,
   STATUS               VARCHAR2(100),
   EXCEPTION            VARCHAR2(200),
   USERNAME             VARCHAR2(50),
   RESOURCENAME         VARCHAR2(50),
   DEPARTMENTID         VARCHAR2(20),
   DEPARTMENTNAME       VARCHAR2(50),
   constraint PK_RESVISITLOG primary key (VISITID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table RESOURCE_VISITLOG is
'资源访问情况表'
/

comment on column RESOURCE_VISITLOG.VISITID is
'资源访问id'
/

comment on column RESOURCE_VISITLOG.VISITTIME is
'访问时间'
/

comment on column RESOURCE_VISITLOG.USERID is
'用户id'
/

comment on column RESOURCE_VISITLOG.RESID is
'资源id'
/

comment on column RESOURCE_VISITLOG.STATUS is
'操作状态'
/

comment on column RESOURCE_VISITLOG.EXCEPTION is
'异常信息'
/

comment on column RESOURCE_VISITLOG.USERNAME is
'用户名称'
/

comment on column RESOURCE_VISITLOG.RESOURCENAME is
'资源名称'
/

comment on column RESOURCE_VISITLOG.DEPARTMENTID is
'部门id'
/

comment on column RESOURCE_VISITLOG.DEPARTMENTNAME is
'部门名称'
/

/*==============================================================*/
/* Table: ROLEINFO                                              */
/*==============================================================*/
create table ROLEINFO 
(
   ROLEID               NUMBER               not null,
   ROLEPARENTID         NUMBER,
   ROLENAME             VARCHAR2(50),
   DISPLAYNAME          VARCHAR2(100),
   DESCRIPTION          VARCHAR2(256),
   SINDEX               NUMBER,
   ROLETYPEID           NUMBER,
   constraint PK_ROLEINFO primary key (ROLEID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table ROLEINFO is
'角色信息表'
/

comment on column ROLEINFO.ROLEID is
'角色id'
/

comment on column ROLEINFO.ROLEPARENTID is
'上级角色id'
/

comment on column ROLEINFO.ROLENAME is
'角色名称'
/

comment on column ROLEINFO.DISPLAYNAME is
'显示名称'
/

comment on column ROLEINFO.DESCRIPTION is
'描述'
/

comment on column ROLEINFO.SINDEX is
'同级排序'
/

comment on column ROLEINFO.ROLETYPEID is
'角色类型id'
/

/*==============================================================*/
/* Table: ROLETYPE                                              */
/*==============================================================*/
create table ROLETYPE 
(
   ROLETYPEID           NUMBER               not null,
   ROLETYPENAME         VARCHAR2(50),
   DESCRIPTION          VARCHAR2(256),
   PARENTID             NUMBER,
   SINDEX               NUMBER,
   constraint PK_ROLETYPE primary key (ROLETYPEID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table ROLETYPE is
'角色类型表'
/

comment on column ROLETYPE.ROLETYPEID is
'角色类型id'
/

comment on column ROLETYPE.ROLETYPENAME is
'类型名称'
/

comment on column ROLETYPE.DESCRIPTION is
'类型描述'
/

comment on column ROLETYPE.PARENTID is
'上级角色类型id'
/

comment on column ROLETYPE.SINDEX is
'同级排序'
/

/*==============================================================*/
/* Table: ROLE_FEATURE                                          */
/*==============================================================*/
create table ROLE_FEATURE 
(
   ROLEID               NUMBER               not null,
   FEATUREID            NUMBER               not null,
   constraint PK_ROLEFEATURE primary key (ROLEID, FEATUREID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table ROLE_FEATURE is
'角色专题权限表'
/

comment on column ROLE_FEATURE.ROLEID is
'角色id'
/

comment on column ROLE_FEATURE.FEATUREID is
'专题id'
/

/*==============================================================*/
/* Table: ROLE_FUNCTION                                         */
/*==============================================================*/
create table ROLE_FUNCTION 
(
   ROLEID               NUMBER               not null,
   FUNCTIONID           NUMBER               not null,
   constraint PK_ROLEFUNCTION primary key (ROLEID, FUNCTIONID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table ROLE_FUNCTION is
'角色功能权限表'
/

comment on column ROLE_FUNCTION.ROLEID is
'角色id'
/

comment on column ROLE_FUNCTION.FUNCTIONID is
'功能id'
/

/*==============================================================*/
/* Table: SCENES                                                */
/*==============================================================*/
create table SCENES 
(
   SID                  NUMBER               not null,
   USERID               NUMBER,
   CTIME                DATE,
   SRANDOM              CHAR(10),
   SCENE                CLOB,
   SNAME                CHAR(30),
   constraint PK_SCENES primary key (SID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 1024K
    next 64K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 lob
 (SCENE)
    store as
         basicfile
 (tablespace QLONEMAP1
        chunk 8192
 retention nocache)
/

comment on column SCENES.SID is
'ID'
/

comment on column SCENES.USERID is
'创建者ID'
/

comment on column SCENES.CTIME is
'创建时间'
/

comment on column SCENES.SRANDOM is
'场景编号'
/

comment on column SCENES.SCENE is
'场景信息(JSON)'
/

comment on column SCENES.SNAME is
'场景命名'
/

/*==============================================================*/
/* Table: SX_ITEMINFO                                           */
/*==============================================================*/
create table SX_ITEMINFO 
(
   XMBH                 VARCHAR2(50),
   AJBH                 VARCHAR2(50),
   XMMC                 VARCHAR2(50),
   JSDWMC               VARCHAR2(50),
   ZBKS                 VARCHAR2(50),
   DQBLR                VARCHAR2(50),
   BLSX                 VARCHAR2(50),
   SXQK                 VARCHAR2(50),
   SYSJ                 VARCHAR2(50),
   SZXZQ                VARCHAR2(50),
   XMDZ                 VARCHAR2(50)
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 1024K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table SX_ITEMINFO is
'时限一张图中间表'
/

comment on column SX_ITEMINFO.XMBH is
'项目编号'
/

comment on column SX_ITEMINFO.AJBH is
'案件编号'
/

comment on column SX_ITEMINFO.XMMC is
'项目名称'
/

comment on column SX_ITEMINFO.JSDWMC is
'建设单位名称'
/

comment on column SX_ITEMINFO.ZBKS is
'主办科室'
/

comment on column SX_ITEMINFO.DQBLR is
'当前办理人'
/

comment on column SX_ITEMINFO.BLSX is
'办理事项'
/

comment on column SX_ITEMINFO.SXQK is
'时限情况'
/

comment on column SX_ITEMINFO.SYSJ is
'剩余时间'
/

comment on column SX_ITEMINFO.SZXZQ is
'所在行政区'
/

comment on column SX_ITEMINFO.XMDZ is
'项目地址'
/

/*==============================================================*/
/* Table: SYSTEMINFO                                            */
/*==============================================================*/
create table SYSTEMINFO 
(
   SYSTEMID             NUMBER               not null,
   CLIENTID             VARCHAR2(20),
   CLIENTNAME           VARCHAR2(200),
   FLOW                 VARCHAR2(20),
   CLIENTSECRETS        VARCHAR2(20),
   REDIRECTURIS         VARCHAR2(100),
   ALLOWEDSCOPES        VARCHAR2(100),
   ACCESSTOKENTYPE      VARCHAR2(20),
   DESCRIPTION          VARCHAR2(200),
   CLIENTURI            VARCHAR2(100),
   REQUIRECONSENT       VARCHAR2(20)         default 'false',
   ALLOWREMEMBERCONSENT VARCHAR2(20)         default 'false',
   constraint PK_SYSTEMINFO primary key (SYSTEMID)
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace JYONEMAP
logging
 nocompress
 monitoring
 noparallel
/

comment on table SYSTEMINFO is
'系统信息表（或可叫子系统）'
/

comment on column SYSTEMINFO.SYSTEMID is
'系统ID'
/

comment on column SYSTEMINFO.CLIENTID is
'客户端ID'
/

comment on column SYSTEMINFO.CLIENTNAME is
'客户端名称'
/

comment on column SYSTEMINFO.FLOW is
'流'
/

comment on column SYSTEMINFO.CLIENTSECRETS is
'客户端密钥'
/

comment on column SYSTEMINFO.REDIRECTURIS is
'跳转地址'
/

comment on column SYSTEMINFO.ALLOWEDSCOPES is
'允许声明'
/

comment on column SYSTEMINFO.ACCESSTOKENTYPE is
'访问信息类型'
/

comment on column SYSTEMINFO.DESCRIPTION is
'描述'
/

comment on column SYSTEMINFO.CLIENTURI is
'客户端主页'
/

comment on column SYSTEMINFO.REQUIRECONSENT is
'显示授权页面'
/

comment on column SYSTEMINFO.ALLOWREMEMBERCONSENT is
'允许记住授权页选择'
/

/*==============================================================*/
/* Table: SYSTEM_FUNCTION                                       */
/*==============================================================*/
create table SYSTEM_FUNCTION 
(
   FUNCTIONID           NUMBER,
   SYSTEMID             NUMBER
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace JYONEMAP
logging
 nocompress
 monitoring
 noparallel
/

comment on table SYSTEM_FUNCTION is
'功能所属系统表'
/

comment on column SYSTEM_FUNCTION.FUNCTIONID is
'功能id'
/

comment on column SYSTEM_FUNCTION.SYSTEMID is
'系统id'
/

/*==============================================================*/
/* Table: USERINFO                                              */
/*==============================================================*/
create table USERINFO 
(
   USERID               NUMBER               not null,
   USERNAME             VARCHAR2(50),
   PASSWORD             VARCHAR2(100),
   DISPLAYNAME          VARCHAR2(100),
   SHORTNAME            VARCHAR2(50),
   USERTYPEID           NUMBER,
   CREATETIME           VARCHAR2(100),
   DESCRIPTION          VARCHAR2(256),
   ISLOCKEDOUT          NUMBER(1),
   EMAIL                VARCHAR2(50),
   NICKNAME             VARCHAR2(50),
   UPDATETIME           VARCHAR2(100),
   WEIGHT               NUMBER,
   USERIMAGES           NVARCHAR2(100)       default '/themes/default/images/headimage/gh.jpg',
   SINDEX               NUMBER,
   EXTRAID              VARCHAR2(50),
   constraint PK_USERINFO primary key (USERID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table USERINFO is
'用户信息表'
/

comment on column USERINFO.USERID is
'用户id'
/

comment on column USERINFO.USERNAME is
'用户名称'
/

comment on column USERINFO.PASSWORD is
'用户密码'
/

comment on column USERINFO.DISPLAYNAME is
'显示名称'
/

comment on column USERINFO.SHORTNAME is
'简称'
/

comment on column USERINFO.USERTYPEID is
'用户类型id'
/

comment on column USERINFO.CREATETIME is
'创建时间'
/

comment on column USERINFO.DESCRIPTION is
'描述'
/

comment on column USERINFO.ISLOCKEDOUT is
'是否锁定'
/

comment on column USERINFO.EMAIL is
'邮件'
/

comment on column USERINFO.NICKNAME is
'昵称'
/

comment on column USERINFO.UPDATETIME is
'更新时间'
/

comment on column USERINFO.USERIMAGES is
'用户头像相对地址'
/

comment on column USERINFO.SINDEX is
'排序索引'
/

comment on column USERINFO.EXTRAID is
'对接ID'
/

/*==============================================================*/
/* Table: USERLEVEL                                             */
/*==============================================================*/
create table USERLEVEL 
(
   USERID               NUMBER               not null,
   LEVELID              NUMBER(20)
)
/

comment on table USERLEVEL is
'用户等级表'
/

/*==============================================================*/
/* Table: USERTYPE                                              */
/*==============================================================*/
create table USERTYPE 
(
   USERTYPEID           NUMBER               not null,
   TYPENAME             VARCHAR2(50),
   DESCRIPTION          VARCHAR2(256),
   constraint PK_USERTYPE primary key (USERTYPEID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table USERTYPE is
'用户类型表'
/

comment on column USERTYPE.USERTYPEID is
'用户类型id'
/

comment on column USERTYPE.TYPENAME is
'用户类型名称'
/

comment on column USERTYPE.DESCRIPTION is
'描述'
/

/*==============================================================*/
/* Table: USER_DEPARTMENT                                       */
/*==============================================================*/
create table USER_DEPARTMENT 
(
   ID                   NUMBER               not null,
   USERID               NUMBER,
   DEPARTMENTID         NUMBER,
   EXTRAUSERID          VARCHAR2(50),
   EXTRADEPARTMENTID    VARCHAR2(50),
   constraint PK_USERDEPARTMENT primary key (ID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 1024K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on column USER_DEPARTMENT.ID is
'id'
/

comment on column USER_DEPARTMENT.USERID is
'用户id'
/

comment on column USER_DEPARTMENT.DEPARTMENTID is
'部门id'
/

comment on column USER_DEPARTMENT.EXTRAUSERID is
'对接用户id'
/

comment on column USER_DEPARTMENT.EXTRADEPARTMENTID is
'对接部门id'
/

/*==============================================================*/
/* Table: USER_FUNCTION                                         */
/*==============================================================*/
create table USER_FUNCTION 
(
   USERID               NUMBER,
   FUNCTIONID           NUMBER
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace JYONEMAP
logging
 nocompress
 monitoring
 noparallel
/

comment on table USER_FUNCTION is
'用户功能权限表'
/

comment on column USER_FUNCTION.USERID is
'用户id'
/

comment on column USER_FUNCTION.FUNCTIONID is
'功能id'
/

/*==============================================================*/
/* Table: USER_ROLE                                             */
/*==============================================================*/
create table USER_ROLE 
(
   USERID               NUMBER               not null,
   ROLEID               NUMBER               not null,
   constraint PK_USERROLE primary key (USERID, ROLEID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table USER_ROLE is
'用户角色对应表'
/

comment on column USER_ROLE.USERID is
'用户id'
/

comment on column USER_ROLE.ROLEID is
'角色id'
/

/*==============================================================*/
/* Table: WORKSPACE                                             */
/*==============================================================*/
create table WORKSPACE 
(
   ID                   NUMBER               not null,
   NAME                 VARCHAR2(30),
   USERID               NUMBER,
   SAVEDATE             DATE,
   LON                  NUMBER(8,5),
   LAT                  NUMBER(8,5),
   "LEVEL"              NUMBER,
   ALT                  NUMBER(10,5),
   IMAGE                BLOB,
   constraint PK_WORKSPACE primary key (ID)
         using index pctfree 10
   initrans 2
   storage
   (
       initial 64K
       next 1024K
       minextents 1
       maxextents unlimited
   )
   logging
   tablespace QLONEMAP1
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 1024K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 lob
 (IMAGE)
    store as
         basicfile
 (tablespace QLONEMAP1
        chunk 8192
 retention nocache)
/

comment on table WORKSPACE is
'地图工作空间'
/

/*==============================================================*/
/* Table: XM_ITEMINFO                                           */
/*==============================================================*/
create table XM_ITEMINFO 
(
   ITEMID               NVARCHAR2(50),
   ITEMNAME             VARCHAR2(255),
   UNITNAME             VARCHAR2(255),
   ITEMADD              VARCHAR2(255),
   CASEID               VARCHAR2(20),
   PROJECTSTA           NVARCHAR2(50),
   XMLX                 NVARCHAR2(50),
   XMLX2                NVARCHAR2(50)
)
pctfree 10
initrans 1
storage
(
    initial 192K
    next 8K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table XM_ITEMINFO is
'项目一张图中间表'
/

comment on column XM_ITEMINFO.ITEMID is
'项目编号'
/

comment on column XM_ITEMINFO.ITEMNAME is
'项目名称'
/

comment on column XM_ITEMINFO.UNITNAME is
'单位名称'
/

comment on column XM_ITEMINFO.ITEMADD is
'项目地址'
/

comment on column XM_ITEMINFO.CASEID is
'关联号'
/

comment on column XM_ITEMINFO.PROJECTSTA is
'当前项目状态'
/

comment on column XM_ITEMINFO.XMLX is
'项目类型'
/

comment on column XM_ITEMINFO.XMLX2 is
'项目类型2'
/

/*==============================================================*/
/* Table: XM_XMYZT                                              */
/*==============================================================*/
create table XM_XMYZT 
(
   XMBH                 VARCHAR2(50),
   XMMC                 VARCHAR2(100),
   JSDWMC               VARCHAR2(50),
   XZQ                  VARCHAR2(50),
   XMDZ                 VARCHAR2(50),
   ZBLSX                VARCHAR2(50),
   ZBLR                 VARCHAR2(50),
   XZBH                 VARCHAR2(50),
   YDBH                 VARCHAR2(50),
   GCBH                 VARCHAR2(50),
   YSBH                 VARCHAR2(50),
   XZSJ                 VARCHAR2(50),
   YDSJ                 VARCHAR2(50),
   GCSJ                 VARCHAR2(50),
   YSSJ                 VARCHAR2(50)
)
pctfree 10
initrans 1
storage
(
    initial 64K
    next 1024K
    minextents 1
    maxextents unlimited
)
tablespace QLONEMAP1
logging
 nocompress
 monitoring
 noparallel
/

comment on table XM_XMYZT is
'项目一张图'
/

comment on column XM_XMYZT.XMBH is
'项目编号'
/

comment on column XM_XMYZT.XMMC is
'项目名称'
/

comment on column XM_XMYZT.JSDWMC is
'建设单位名称'
/

comment on column XM_XMYZT.XZQ is
'所在行政区'
/

comment on column XM_XMYZT.XMDZ is
'项目地址'
/

comment on column XM_XMYZT.ZBLSX is
'当前办理事项'
/

comment on column XM_XMYZT.ZBLR is
'当前办理人'
/

comment on column XM_XMYZT.XZBH is
'选址编号'
/

comment on column XM_XMYZT.YDBH is
'用地编号'
/

comment on column XM_XMYZT.GCBH is
'工程编号'
/

comment on column XM_XMYZT.YSBH is
'验收编号'
/

comment on column XM_XMYZT.XZSJ is
'选址时间'
/

comment on column XM_XMYZT.YDSJ is
'用地时间'
/

comment on column XM_XMYZT.GCSJ is
'工程时间'
/

comment on column XM_XMYZT.YSSJ is
'验收时间'
/

/*==============================================================*/
/* View: FEATURE_RESOURCE_LAYER                                 */
/*==============================================================*/
create or replace view FEATURE_RESOURCE_LAYER(ID, FEATUREID, FEATURENAME, RESOURCEID, RESOURCENAME, RESOURCETYPEID, URL, KEY, METADATAID, DESCRIPTION, PROXYURL, ISLOCKEDOUT, LAYERID, LAYERNAME, LAYERINDEX) as
select fl.id as id,f.featureid as featureid,f.featurename as featurename, r."RESOURCEID",r."RESOURCENAME",r."RESOURCETYPEID",r."URL",r."KEY",r."METADATAID",r."DESCRIPTION",r."PROXYURL",r."ISLOCKEDOUT",l.layerid as layerid,
l.layername as layername,l.sindex as layerindex from
feature_layer fl
left join featureinfo f on fl.featureid=f.featureid
left join resourceinfo r on fl.resourceid=r.resourceid
left join layerinfo l on fl.layerid=l.layerid
/

comment on column FEATURE_RESOURCE_LAYER.ID is
'ID'
/

comment on column FEATURE_RESOURCE_LAYER.FEATUREID is
'专题id'
/

comment on column FEATURE_RESOURCE_LAYER.FEATURENAME is
'专题名称'
/

comment on column FEATURE_RESOURCE_LAYER.RESOURCEID is
'资源id'
/

comment on column FEATURE_RESOURCE_LAYER.RESOURCENAME is
'资源名称'
/

comment on column FEATURE_RESOURCE_LAYER.RESOURCETYPEID is
'资源类型id'
/

comment on column FEATURE_RESOURCE_LAYER.URL is
'资源地址'
/

comment on column FEATURE_RESOURCE_LAYER.KEY is
'资源关键字'
/

comment on column FEATURE_RESOURCE_LAYER.METADATAID is
'元数据id'
/

comment on column FEATURE_RESOURCE_LAYER.DESCRIPTION is
'描述'
/

comment on column FEATURE_RESOURCE_LAYER.PROXYURL is
'代理地址'
/

comment on column FEATURE_RESOURCE_LAYER.ISLOCKEDOUT is
'是否锁定'
/

comment on column FEATURE_RESOURCE_LAYER.LAYERID is
'图层id'
/

comment on column FEATURE_RESOURCE_LAYER.LAYERNAME is
'图层名称'
/

comment on column FEATURE_RESOURCE_LAYER.LAYERINDEX is
'图层索引'
/

/*==============================================================*/
/* View: FUNCTIONINFO_TYPE                                      */
/*==============================================================*/
create or replace view FUNCTIONINFO_TYPE(FUNCTIONID, FUNCTIONNAME, DISPLAYNAME, FUNCTIONTYPEID, DESCRIPTION, EXECUTE, CLSNAME, SINDEX, FUNCTIONTYPENAME, TYPE_CLSNAME, TYPE_SINDEX, TYPE_DESCRIPTION) as
select t."FUNCTIONID",t."FUNCTIONNAME",t."DISPLAYNAME",t."FUNCTIONTYPEID",t."DESCRIPTION",t."EXECUTE",t."CLSNAME",t."SINDEX",
  p.functiontypename,p.clsname as type_Clsname,p.sindex as type_sIndex,p.description as type_description from functioninfo t,functiontype p
   where t.functiontypeid=p.functiontypeid
   order by p.sindex
/

comment on column FUNCTIONINFO_TYPE.FUNCTIONID is
'功能id'
/

comment on column FUNCTIONINFO_TYPE.FUNCTIONNAME is
'功能名称'
/

comment on column FUNCTIONINFO_TYPE.DISPLAYNAME is
'显示名称'
/

comment on column FUNCTIONINFO_TYPE.FUNCTIONTYPEID is
'功能类型id'
/

comment on column FUNCTIONINFO_TYPE.DESCRIPTION is
'描述'
/

comment on column FUNCTIONINFO_TYPE.EXECUTE is
'执行函数'
/

comment on column FUNCTIONINFO_TYPE.CLSNAME is
'样式名称'
/

comment on column FUNCTIONINFO_TYPE.SINDEX is
'排序'
/

comment on column FUNCTIONINFO_TYPE.FUNCTIONTYPENAME is
'功能类型名称'
/

comment on column FUNCTIONINFO_TYPE.TYPE_CLSNAME is
'样式'
/

comment on column FUNCTIONINFO_TYPE.TYPE_SINDEX is
'排序'
/

comment on column FUNCTIONINFO_TYPE.TYPE_DESCRIPTION is
'描述'
/

/*==============================================================*/
/* View: PH_TRACEINFO_PLANSTATUS                                */
/*==============================================================*/
create or replace view PH_TRACEINFO_PLANSTATUS as
select t."ID",t."ITEMID",t."OLDITEMID",t."PHPLAN",t."UPDATEDATE",t."ISVIOLATION",t."ISDISPOSE",t."MANAGER",p."STATUSID",p."STATUSNAME",p."STATUSINDEX"
    from Ph_traceInfo t,ph_planstatus p
   where t.phplan=p.statusid
 order by statusindex
/

comment on column PH_TRACEINFO_PLANSTATUS.ID is
'ID'
/

comment on column PH_TRACEINFO_PLANSTATUS.ITEMID is
'案件编号'
/

comment on column PH_TRACEINFO_PLANSTATUS.OLDITEMID is
'受理编号'
/

comment on column PH_TRACEINFO_PLANSTATUS.PHPLAN is
'批后进度'
/

comment on column PH_TRACEINFO_PLANSTATUS.UPDATEDATE is
'更新时间'
/

comment on column PH_TRACEINFO_PLANSTATUS.ISVIOLATION is
'是否违规'
/

comment on column PH_TRACEINFO_PLANSTATUS.ISDISPOSE is
'是否处理 1表示存在违法已处理  空值表示未违法 未处理'
/

comment on column PH_TRACEINFO_PLANSTATUS.MANAGER is
'负责人'
/

comment on column PH_TRACEINFO_PLANSTATUS.STATUSID is
'状态ID'
/

comment on column PH_TRACEINFO_PLANSTATUS.STATUSNAME is
'状态名称'
/

comment on column PH_TRACEINFO_PLANSTATUS.STATUSINDEX is
'状态顺序'
/

/*==============================================================*/
/* View: PH_TRACEINFO_MAX_PLANSTATUS                            */
/*==============================================================*/
create or replace view PH_TRACEINFO_MAX_PLANSTATUS as
select "ID","ITEMID","OLDITEMID","PHPLAN","UPDATEDATE","ISVIOLATION","ISDISPOSE","MANAGER","STATUSID","STATUSNAME","STATUSINDEX" from PH_TRACEINFO_PLANSTATUS t where t.STATUSINDEX=(select max(statusindex) from PH_TRACEINFO_PLANSTATUS  where itemid=t.itemid)
/

alter table DEPARTMENT_FUNCTION
   add constraint FK_DEPARTME_REFERENCE_DEPARTME foreign key (DEPARTMENTID)
      references DEPARTMENT (DEPARTMENTID)
/

alter table DEPARTMENT_FUNCTION
   add constraint FK_DEPARTME_REFERENCE_FUNCTION foreign key (FUNCTIONID)
      references FUNCTIONINFO (FUNCTIONID)
/

alter table DM_SERVER
   add constraint FK_DM_SERVE_REFERENCE_DM_CITYI foreign key ("CityID")
      references DM_CITYINFO ("CityID")
/

alter table FEATURE_LAYER
   add constraint PK_FEATURELAYER_LAYER foreign key (LAYERID)
      references LAYERINFO (LAYERID)
      on delete cascade
      not deferrable
/

alter table FEATURE_LAYER
   add constraint PK_FEATURELAYER_RESOURCE foreign key (RESOURCEID)
      references RESOURCEINFO (RESOURCEID)
      on delete cascade
      not deferrable
/

alter table FUNCTIONINFO
   add constraint FK_FUNCTIONINFO_FUNCTIONTYPEID foreign key (FUNCTIONTYPEID)
      references FUNCTIONTYPE (FUNCTIONTYPEID)
      not deferrable
/

alter table LAYERINFO
   add constraint RESOURCEID foreign key (RESOURCEID)
      references RESOURCEINFO (RESOURCEID)
      on delete cascade
      not deferrable
/

alter table RESOURCEINFO
   add constraint FK_RESOURCEINFO_METADATAID foreign key (METADATAID)
      references METADATAINFO (METADATAID)
      not deferrable
/

alter table RESOURCEINFO
   add constraint FK_RESOURCEINFO_RESOURCETYPEID foreign key (RESOURCETYPEID)
      references RESOURCETYPE (RESOURCETYPEID)
      not deferrable
/

alter table ROLEINFO
   add constraint FK_ROLEINFO_ROLETYPEID foreign key (ROLETYPEID)
      references ROLETYPE (ROLETYPEID)
      not deferrable
/

alter table ROLE_FEATURE
   add constraint FK_ROLEFEATURE_ROLEID foreign key (ROLEID)
      references ROLEINFO (ROLEID)
      on delete cascade
      not deferrable
/

alter table ROLE_FUNCTION
   add constraint FK_ROLEFUNCTION_FUNCTIONID foreign key (FUNCTIONID)
      references FUNCTIONINFO (FUNCTIONID)
      on delete cascade
      not deferrable
/

alter table ROLE_FUNCTION
   add constraint FK_ROLEFUNCTION_ROLEID foreign key (ROLEID)
      references ROLEINFO (ROLEID)
      on delete cascade
      not deferrable
/

alter table SYSTEM_FUNCTION
   add constraint FK_SYSTEM_F_REFERENCE_SYSTEMIN foreign key (SYSTEMID)
      references SYSTEMINFO (SYSTEMID)
/

alter table SYSTEM_FUNCTION
   add constraint FK_SYSTEM_F_REFERENCE_FUNCTION foreign key (FUNCTIONID)
      references FUNCTIONINFO (FUNCTIONID)
/

alter table USERINFO
   add constraint FK_USERINFO_USERTYPEID foreign key (USERTYPEID)
      references USERTYPE (USERTYPEID)
      not deferrable
/

alter table USERLEVEL
   add constraint FK_USERLEVE_REFERENCE_USERINFO foreign key (USERID)
      references USERINFO (USERID)
/

alter table USERLEVEL
   add constraint FK_USERLEVE_REFERENCE_MAPLEVEL foreign key (LEVELID)
      references MAPLEVEL (LEVELID)
/

alter table USER_DEPARTMENT
   add constraint FK_USERDEPARTMENT_DEPARTMENTID foreign key (DEPARTMENTID)
      references DEPARTMENT (DEPARTMENTID)
      on delete cascade
      not deferrable
/

alter table USER_DEPARTMENT
   add constraint FK_USERDEPARTMENT_USERID foreign key (USERID)
      references USERINFO (USERID)
      on delete cascade
      not deferrable
/

alter table USER_FUNCTION
   add constraint FK_USER_FUN_REFERENCE_USERINFO foreign key (USERID)
      references USERINFO (USERID)
/

alter table USER_FUNCTION
   add constraint FK_USER_FUN_REFERENCE_FUNCTION foreign key (FUNCTIONID)
      references FUNCTIONINFO (FUNCTIONID)
/

alter table USER_ROLE
   add constraint FK_USERROLE_ROLEID foreign key (ROLEID)
      references ROLEINFO (ROLEID)
      on delete cascade
      not deferrable
/

alter table USER_ROLE
   add constraint FK_USERROLE_USERID foreign key (USERID)
      references USERINFO (USERID)
      on delete cascade
      not deferrable
/

alter table WORKSPACE
   add constraint FK_WORKSPAC_REFERENCE_USERINFO foreign key (USERID)
      references USERINFO (USERID)
/


create trigger TR_DEPARTMENT before insert
on DEPARTMENT for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "DEPARTMENTID" uses sequence SE_DEPARTMENT
    select SE_DEPARTMENT.NEXTVAL INTO :new.DEPARTMENTID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger "tib_dm_cityinfo" before insert
on DM_CITYINFO for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column ""CityID"" uses sequence SE_DM_CITYINFO
    select SE_DM_CITYINFO.NEXTVAL INTO :new."CityID" from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger "tib_dm_logger" before insert
on DM_LOGGER for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column ""LoggerId"" uses sequence SE_DM_LOGGER
    select SE_DM_LOGGER.NEXTVAL INTO :new."LoggerId" from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger "tib_dm_mapservices" before insert
on "DM_MapServices" for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column ""ServerId"" uses sequence SE_DM_MAPSERVICES
    select SE_DM_MAPSERVICES.NEXTVAL INTO :new."ServerId" from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger "tib_dm_mxdproperties" before insert
on "DM_MxdProperties" for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column ""MxdId"" uses sequence SE_DM_MxdProperties
    select SE_DM_MxdProperties.NEXTVAL INTO :new."MxdId" from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger "tib_dm_server" before insert
on DM_SERVER for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column ""ServerId"" uses sequence SE_DM_SERVER
    select SE_DM_SERVER.NEXTVAL INTO :new."ServerId" from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger "tib_dm_treenodeinfo" before insert
on "DM_TreeNodeInfo" for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column ""NodeId"" uses sequence SE_DM_TREENODEINFO
    select SE_DM_TREENODEINFO.NEXTVAL INTO :new."NodeId" from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TR_FEATUREINFO   before  insert on FEATUREINFO REFERENCING NEW AS NEW OLD AS OLD when (NEW.FEATUREID IS NULL)
BEGIN
  SELECT SE_FEATUREINFO.NEXTVAL INTO:NEW.FEATUREID FROM DUAL;
  END;
/


create trigger TR_FEATURE_LAYER   before  insert on FEATURE_LAYER REFERENCING NEW AS NEW OLD AS OLD when (NEW.ID IS NULL)
BEGIN
  SELECT SE_FEATURE_LAYER.NEXTVAL INTO:NEW.ID FROM DUAL;
  END;
/


create trigger TR_FUNCTIONINFO   before  insert on FUNCTIONINFO REFERENCING NEW AS NEW OLD AS OLD when (NEW.FUNCTIONID IS NULL)
BEGIN
  SELECT SE_FUNCTIONINFO.NEXTVAL INTO:NEW.FUNCTIONID FROM DUAL;
  END;
/


create trigger TR_FUNCTIONTYPE   before  insert on FUNCTIONTYPE REFERENCING NEW AS NEW OLD AS OLD when (NEW.FUNCTIONTYPEID IS NULL)
BEGIN
  SELECT SE_FUNCTIONTYPE.NEXTVAL INTO:NEW.FUNCTIONTYPEID FROM DUAL;
  END;
/


create trigger TR_LAYERINFO   before  insert on LAYERINFO REFERENCING NEW AS NEW OLD AS OLD when (NEW.LAYERID IS NULL)
BEGIN
  SELECT SE_LAYERINFO.NEXTVAL INTO:NEW.LAYERID FROM DUAL;
  END;
/


create trigger TR_LOGIN_LOG   before  insert on LOGIN_LOG REFERENCING NEW AS NEW OLD AS OLD when (NEW.LOGID IS NULL)
BEGIN
  SELECT SE_LOGIN_LOG.NEXTVAL INTO:NEW.LOGID FROM DUAL;
  END;
/


create trigger "tib_maplevel" before insert
on MAPLEVEL for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "LEVELID" uses sequence se_maplevel
    select se_maplevel.NEXTVAL INTO :new.LEVELID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TR_METADATAINFO   before  insert on METADATAINFO REFERENCING NEW AS NEW OLD AS OLD when (NEW.METADATAID IS NULL)
BEGIN
  SELECT SE_METADATAINFO.NEXTVAL INTO:NEW.METADATAID FROM DUAL;
  END;
/


create trigger TR_RESOURCEINFO   before  insert on RESOURCEINFO REFERENCING NEW AS NEW OLD AS OLD when (NEW.RESOURCEID IS NULL)
BEGIN
  SELECT SE_RESOURCEINFO.NEXTVAL INTO:NEW.RESOURCEID FROM DUAL;
  END;
/


create trigger TR_RESOURCETYPE   before  insert on RESOURCETYPE REFERENCING NEW AS NEW OLD AS OLD when (NEW.RESOURCETYPEID IS NULL)
BEGIN
  SELECT SE_RESOURCETYPE.NEXTVAL INTO:NEW.RESOURCETYPEID FROM DUAL;
  END;
/


create trigger TR_RESVISITLOG   before  insert on RESOURCE_VISITLOG REFERENCING NEW AS NEW OLD AS OLD when (NEW.VISITID IS NULL)
BEGIN
  SELECT SE_RESVISITLOG.NEXTVAL INTO:NEW.VISITID FROM DUAL;
  END;
/


create trigger TR_ROLEINFO   before  insert on ROLEINFO REFERENCING NEW AS NEW OLD AS OLD when (NEW.ROLEID IS NULL)
BEGIN
  SELECT SE_ROLEINFO.NEXTVAL INTO:NEW.ROLEID FROM DUAL;
  END;
/


create trigger TR_ROLETYPE   before  insert on ROLETYPE REFERENCING NEW AS NEW OLD AS OLD when (NEW.ROLETYPEID IS NULL)
BEGIN
  SELECT SE_ROLETYPE.NEXTVAL INTO:NEW.ROLETYPEID FROM DUAL;
  END;
/


create trigger TR_SCENES   before  insert on SCENES REFERENCING NEW AS NEW OLD AS OLD when (NEW.sid IS NULL)
BEGIN
  SELECT SE_scenes.NEXTVAL INTO:NEW.sid FROM DUAL;
  END;
/


create trigger TR_SYSTEMINFO before insert
on SYSTEMINFO for each row
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "SYSTEMID" uses sequence SE_SYSTEMINFO
    select SE_SYSTEMINFO.NEXTVAL INTO :new.SYSTEMID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/


create trigger TR_USERINFO   before  insert on USERINFO REFERENCING NEW AS NEW OLD AS OLD when (NEW.userid IS NULL)
BEGIN
  SELECT SE_userinfo.NEXTVAL INTO:NEW.userid FROM DUAL;
  END;
/


create trigger TR_USERTYPE   before  insert on USERTYPE REFERENCING NEW AS NEW OLD AS OLD when (NEW.USERTYPEID IS NULL)
BEGIN
  SELECT SE_USERTYPE.NEXTVAL INTO:NEW.USERTYPEID FROM DUAL;
  END;
/


create trigger TR_USERDEPARTMENT   before  insert on USER_DEPARTMENT REFERENCING NEW AS NEW OLD AS OLD when (NEW.ID IS NULL)
BEGIN
  SELECT SE_USERDEPARTMENT.NEXTVAL INTO:NEW.ID FROM DUAL;
  END;
/


create trigger TIB_WORKSPACE   before  insert on WORKSPACE REFERENCING NEW AS NEW OLD AS OLD
declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    dummy            integer;
    found            boolean;

begin
    --  Column "ID" uses sequence se_workspace
    select se_workspace.NEXTVAL INTO :new.ID from dual;

--  Errors handling
exception
    when integrity_error then
       raise_application_error(errno, errmsg);
end;
/

