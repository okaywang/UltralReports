
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
Message nvarchar(200),
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
MinValue decimal(10,2) not null,
MaxValue decimal(10,2) not null,
AvgValue decimal(10,2) not null,
Remarks nvarchar(200),
HasRemarks as cast(case when Remarks is null then 0 else 1 end as bit)  PERSISTED  not null,
IsProRecord as cast(case when UltraType='PH' or UltraType='PL' then 1 else 0 end as bit) PERSISTED  not null
)

--班次
create table Shift
(
	Id int IDENTITY(1,1) primary key,
	ShiftType int not null,
	StartTime time not null,
	EndTime time not null
)

--排班
create table Schedule
(
	Id int IDENTITY(1,1) primary key,
	[Date] date not null,
	ShiftType int not null,
	Duty int not null
)


insert into MonitorType (Name) values ('温度')
insert into MonitorType (Name) values ('转速')
insert into [Account](Name,LoginName,[Password],[AccountType]) values('张大拿','admin','123456',1)



