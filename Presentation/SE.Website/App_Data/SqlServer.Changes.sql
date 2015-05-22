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