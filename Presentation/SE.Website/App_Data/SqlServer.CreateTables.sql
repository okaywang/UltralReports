
Create database UltralReportsTest2
go
use UltralReportsTest2

Create table Major
(
	[Id] [int] IDENTITY(1,1) primary key,
	Name nvarchar(50) not null
)

--账号
CREATE TABLE [dbo].[Account](
[Id] [int] IDENTITY(1,1) primary key,
 MajorId int references Major,
[Name] [nvarchar](20) NOT NULL,
[LoginName] [nvarchar](50) NOT NULL unique,
[Password] [nvarchar](50) NOT NULL check(len(password)>=6), 
[AccountType] [int] NOT NULL CHECK(AccountType in (1,2)),--1.admin 2.Other,
PhoneNumber nvarchar(20) not null,

FADateTime datetime default(getdate()),
FAUser nvarchar(20),
LCDateTime datetime,
LCUser nvarchar(20)
)

--权限
create table Authority(
Id int IDENTITY(1,1) primary key,
AuthorityType int not null,
Name nvarchar(20) not null
)

--用户权限
create table AccountAuthority(
Id int IDENTITY(1,1) primary key,
AccountId int not null references Account,
AuthorityId int not null references Authority,
Constraint UQ_Account_Authority unique(AccountId,AuthorityId)
)

--异常日志
create table LogException(
Id int identity(1,1) primary key,
RequestInfo text,
UserName nvarchar(20),
Message nvarchar(500),
StackTrace text,
FADateTime datetime default(getdate())
)

--操作日志
create table LogOperation(
Id int identity(1,1) primary key,
RequestInfo text,
UserName nvarchar(20),
Message nvarchar(200),
FADateTime datetime default(getdate())
)

create table SmsRecipient
(
Id int IDENTITY(1,1) primary key,
Name nvarchar(50) not null,
PhoneNumber varchar(20) not null
)

create table SmsGroup
(
Id int IDENTITY(1,1) primary key,
Name nvarchar(50) not null
)

create table SmsGroupRecipient
(
GroupId int not null references SmsGroup,
RecipientId int not null references SmsRecipient,
Constraint PK_GroupId_RecipientId primary key(GroupId,RecipientId)
)

create table SmsGroupAccount
 (
	GroupId int not null references SmsGroup,
	AccountId int not null references Account,
	FADateTime datetime default(getdate()),
	Constraint PK_GroupId_AccountId primary key(GroupId,AccountId)
 )

create table MonitorType
(
Id int IDENTITY(1,1) primary key,
Name nvarchar(50) not null
)

create table Equipment
(
Id int IDENTITY(1,1) primary key,
MachineSet int not null check(MachineSet in (1,2)),
MonitorTypeId int not null references MonitorType,
Name nvarchar(50) not null,
[Description] nvarchar(200)
)

create table Part
(
Id int IDENTITY(1,1) primary key,
EquipmentId int not null references Equipment,
Name nvarchar(50) not null,
DataKey nvarchar(50) not null,
Unit nvarchar(5) not null,
L1 decimal(10,2) not null,
L2 decimal(10,2) not null,
L3 decimal(10,2) not null,
H1 decimal(10,2) not null,
H2 decimal(10,2) not null,
H3 decimal(10,2) not null,
MajorId int references Major,
PH decimal(10,2),
PL decimal(10,2),
SendSms bit not null default 0,
UltraNum int not null default 0
)

create table UltraRecord
(
Id int IDENTITY(1,1) primary key,
PartId int not null references Part,
StartTime datetime not null,
EndTime datetime,
Flag as cast(CASE WHEN EndTime Is NULL then 0 else 1 end as bit) PERSISTED  not null,--是否完成，1是完成，0是未完成
Duty int not null,
UltraType varchar(2) not null check(UltraType in('L1','L2','L3','H1','H2','H3','PH','PL')),
MinValue decimal(10,2),
MaxValue decimal(10,2),
AvgValue decimal(10,2),
Remarks nvarchar(200),
HasRemarks as cast(case when Remarks is null then 0 else 1 end as bit)  PERSISTED  not null,
IsProRecord as cast(case when UltraType='PH' or UltraType='PL' then 1 else 0 end as bit) PERSISTED  not null
)
create table PartSms
(
	PartId int primary key references Part,
	GroupId int not null references SmsGroup,
	Content nvarchar(300) not null,
	HRecover decimal(10,2) not null,
	LRecover decimal(10,2) not null
)


create table DutyTime
(
	Id int primary key,
	StartTime time(7) not null,
	EndTime time(7) not null 
)

create table Duty
(
	DayId int,
	TimeId int,
	DutyValue int not null,
	CONSTRAINT PK_Duty_DayId_TimeId PRIMARY KEY (DayId,TimeId)
)



insert into MonitorType (Name) values ('温度')
insert into MonitorType (Name) values ('转速')
insert into [Account](Name,LoginName,[Password],[AccountType]) values('张大拿','admin','123456',1)

insert into dutytime values(1,'01:00','08:00')
insert into dutytime values(2,'08:00','17:00')
insert into dutytime values(3,'17:00','01:00')

insert into duty
select 1,1,3 union
select 1,2,1 union
select 1,3,5 union
select 2,1,4 union
select 2,2,1 union
select 2,3,5 union
select 3,1,4 union
select 3,2,2 union
select 3,3,1 union
select 4,1,5 union
select 4,2,2 union
select 4,3,1 union
select 5,1,5 union
select 5,2,3 union
select 5,3,2 union
select 6,1,1 union
select 6,2,3 union
select 6,3,2 union
select 7,1,1 union
select 7,2,4 union
select 7,3,3 union
select 8,1,2 union
select 8,2,4 union
select 8,3,3 union
select 9,1,2 union
select 9,2,5 union
select 9,3,4 union
select 10,1,3 union
select 10,2,5 union
select 10,3,4  

