EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'自增Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'专业Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'MajorId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'LoginName'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'Password'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'账户类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'AccountType'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'手机号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'PhoneNumber'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'创建日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'FADateTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'FAUser'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'修改日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'LCDateTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'LCUser'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'自增Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountAuthority', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'账号Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountAuthority', @level2type=N'COLUMN',@level2name=N'AccountId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'权限Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountAuthority', @level2type=N'COLUMN',@level2name=N'AuthorityId'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'自增Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Authority', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'权限类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Authority', @level2type=N'COLUMN',@level2name=N'AuthorityType'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'权限名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Authority', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'第几天' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Duty', @level2type=N'COLUMN',@level2name=N'DayId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'班次Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Duty', @level2type=N'COLUMN',@level2name=N'TimeId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'值次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Duty', @level2type=N'COLUMN',@level2name=N'DutyValue'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'班次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DutyTime', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DutyTime', @level2type=N'COLUMN',@level2name=N'StartTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DutyTime', @level2type=N'COLUMN',@level2name=N'EndTime'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'自增Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'机组号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'MachineSet'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'监控类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'MonitorTypeId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'Description'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'自增Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIData', @level2type=N'COLUMN',@level2name=N'ID'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIData', @level2type=N'COLUMN',@level2name=N'PointKey'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIData', @level2type=N'COLUMN',@level2name=N'Date'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'班值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIData', @level2type=N'COLUMN',@level2name=N'Duty'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'数值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIData', @level2type=N'COLUMN',@level2name=N'Value'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'自增Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIItem', @level2type=N'COLUMN',@level2name=N'ID'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIItem', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIItem', @level2type=N'COLUMN',@level2name=N'PointKay'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIItem', @level2type=N'COLUMN',@level2name=N'Remark'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'自增Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Major', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Major', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Major', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'自增Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Major', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Major', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'自增id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MonitorType', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'监控类型名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MonitorType', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'部件Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PartSms', @level2type=N'COLUMN',@level2name=N'PartId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'组Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PartSms', @level2type=N'COLUMN',@level2name=N'GroupId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'短信内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PartSms', @level2type=N'COLUMN',@level2name=N'Content'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'恢复上限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PartSms', @level2type=N'COLUMN',@level2name=N'HRecover'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'恢复下限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PartSms', @level2type=N'COLUMN',@level2name=N'LRecover'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PartSms', @level2type=N'COLUMN',@level2name=N'UltraNum'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'1'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'MachineSet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'2'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'MonitorTypeId' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'3'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'4'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'6'






EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'自增Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'设备Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'EquipmentId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'DataKey'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'Unit'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'低一限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'L1'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'低二限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'L2'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'低三限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'L3'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'高一限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'H1'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'高二限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'H2'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'高三限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'H3'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'专业Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'MajorId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'专业高限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'PH'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'专业低限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'PL'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'是否发短信' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'SendSms'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'超限次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'UltraNum'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'创建日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'FADateTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'FAUserId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'修改日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'LCDateTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'LCUserId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'Enabled'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'自增Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtDayData', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtDayData', @level2type=N'COLUMN',@level2name=N'DayTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'测点' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtDayData', @level2type=N'COLUMN',@level2name=N'PointId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'数值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtDayData', @level2type=N'COLUMN',@level2name=N'Value'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtDayData', @level2type=N'COLUMN',@level2name=N'Remark'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'自增Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthData', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'年' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthData', @level2type=N'COLUMN',@level2name=N'Year'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthData', @level2type=N'COLUMN',@level2name=N'Month'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'测点' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthData', @level2type=N'COLUMN',@level2name=N'PointId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'数值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthData', @level2type=N'COLUMN',@level2name=N'Value'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthData', @level2type=N'COLUMN',@level2name=N'Remark'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'自增Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthTime', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'年' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthTime', @level2type=N'COLUMN',@level2name=N'Year'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthTime', @level2type=N'COLUMN',@level2name=N'Month'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthTime', @level2type=N'COLUMN',@level2name=N'StartTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthTime', @level2type=N'COLUMN',@level2name=N'EndTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'机组号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthTime', @level2type=N'COLUMN',@level2name=N'MachNO'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'自增Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtPoints', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'点名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtPoints', @level2type=N'COLUMN',@level2name=N'PointName'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtPoints', @level2type=N'COLUMN',@level2name=N'Position'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'表格类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtPoints', @level2type=N'COLUMN',@level2name=N'TableType'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'机组号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtPoints', @level2type=N'COLUMN',@level2name=N'MachNO'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtPoints', @level2type=N'COLUMN',@level2name=N'Description'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtPoints', @level2type=N'COLUMN',@level2name=N'Unit'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'自增Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmsGroup', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'组名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmsGroup', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'组Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmsGroupAccount', @level2type=N'COLUMN',@level2name=N'GroupId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'账号Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmsGroupAccount', @level2type=N'COLUMN',@level2name=N'AccountId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'创建日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmsGroupAccount', @level2type=N'COLUMN',@level2name=N'FADateTime'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'自增Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'部件Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'PartId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'StartTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'EndTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'是否完成标志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'Flag'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'班值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'Duty'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'超限类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'UltraType'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'最小值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'MinValue'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'最大值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'MaxValue'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'平均值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'AvgValue'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'Remarks'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'是否有备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'HasRemarks'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'是否是专业超限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'IsProRecord'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'发送短信标志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'SmsFlag'






