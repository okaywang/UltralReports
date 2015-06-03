ALTER TABLE Part ALTER COLUMN L2 decimal(10,2) NULL
ALTER TABLE Part ALTER COLUMN L3 decimal(10,2) NULL
ALTER TABLE Part ALTER COLUMN H2 decimal(10,2) NULL
ALTER TABLE Part ALTER COLUMN H3 decimal(10,2) NULL
ALTER TABLE Part ALTER COLUMN UltraNum int NULL

ALTER TABLE UltraRecord Add  SmsFlag bit default(0) not null

go
create procedure SP_UltraTimes(@partId int,@times int output)
as
begin
select @times = COUNT(*) from UltraRecord where PartId=@partId and StartTime>DATEADD(dd,-1,GETDATE())
end
--test
declare @times int
exec SP_UltraTimes 2,@times output
select @times


ALTER TABLE UltraRecord ALTER COLUMN PartId int   

alter table UltraRecord drop constraint FK__UltraReco__PartI__44FF419A 

alter table UltraRecord add constraint FK__UltraRecord__Part
     foreign key (PartId) references Part on delete set null



alter table Part add  FADateTime datetime default(getdate())
alter table Part add  FAUserId  int references Account
alter table Part add  LCDateTime datetime
alter table Part add  LCUserId int references Account

update Part set FAUserId=1
update Part set FADateTime=getdate()


alter table Part alter column FAUserId int not null
alter table Part alter column FADateTime datetime not null

Create table SmsLog
(
	[Id] [int] IDENTITY(1,1) primary key,
	GroupId int not null references SmsGroup,
	SmsType int not null,--1 ³¬ÏÞ or 2 »Ö¸´
	WarningType int,
	Content nvarchar(300) not null,
	IsSuccess bit not null default(1),
	FADateTime datetime not null default(getdate()),
)


alter table PartSms drop constraint FK__PartSms__PartId__4AB81AF0 

alter table PartSms add constraint FK__PartSms__PartId__4AB81AF0
     foreign key (PartId) references Part on delete CASCADE