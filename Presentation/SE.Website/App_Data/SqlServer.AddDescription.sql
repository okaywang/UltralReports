EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'רҵId' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'MajorId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��¼��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'LoginName'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'Password'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�˻�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'AccountType'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�ֻ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'PhoneNumber'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'FADateTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'FAUser'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�޸�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'LCDateTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�޸���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Account', @level2type=N'COLUMN',@level2name=N'LCUser'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountAuthority', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�˺�Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountAuthority', @level2type=N'COLUMN',@level2name=N'AccountId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'Ȩ��Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountAuthority', @level2type=N'COLUMN',@level2name=N'AuthorityId'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Authority', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'Ȩ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Authority', @level2type=N'COLUMN',@level2name=N'AuthorityType'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'Ȩ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Authority', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�ڼ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Duty', @level2type=N'COLUMN',@level2name=N'DayId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'���Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Duty', @level2type=N'COLUMN',@level2name=N'TimeId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'ֵ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Duty', @level2type=N'COLUMN',@level2name=N'DutyValue'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DutyTime', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��ʼʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DutyTime', @level2type=N'COLUMN',@level2name=N'StartTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DutyTime', @level2type=N'COLUMN',@level2name=N'EndTime'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'MachineSet'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'MonitorTypeId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'Description'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIData', @level2type=N'COLUMN',@level2name=N'ID'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIData', @level2type=N'COLUMN',@level2name=N'PointKey'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIData', @level2type=N'COLUMN',@level2name=N'Date'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��ֵ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIData', @level2type=N'COLUMN',@level2name=N'Duty'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��ֵ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIData', @level2type=N'COLUMN',@level2name=N'Value'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIItem', @level2type=N'COLUMN',@level2name=N'ID'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIItem', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'λ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIItem', @level2type=N'COLUMN',@level2name=N'PointKay'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KPIItem', @level2type=N'COLUMN',@level2name=N'Remark'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Major', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Major', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Major', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Major', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Major', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MonitorType', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�����������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MonitorType', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PartSms', @level2type=N'COLUMN',@level2name=N'PartId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PartSms', @level2type=N'COLUMN',@level2name=N'GroupId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PartSms', @level2type=N'COLUMN',@level2name=N'Content'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�ָ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PartSms', @level2type=N'COLUMN',@level2name=N'HRecover'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�ָ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PartSms', @level2type=N'COLUMN',@level2name=N'LRecover'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PartSms', @level2type=N'COLUMN',@level2name=N'UltraNum'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'1'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'MachineSet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'2'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'MonitorTypeId' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'3'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'4'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Equipment', @level2type=N'COLUMN',@level2name=N'6'






EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�豸Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'EquipmentId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'DataKey'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��λ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'Unit'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��һ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'L1'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�Ͷ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'L2'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'L3'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��һ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'H1'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�߶���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'H2'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'H3'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'רҵId' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'MajorId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'רҵ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'PH'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'רҵ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'PL'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�Ƿ񷢶���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'SendSms'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'���޴���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'UltraNum'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'FADateTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'FAUserId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�޸�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'LCDateTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�޸���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'LCUserId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�Ƿ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Part', @level2type=N'COLUMN',@level2name=N'Enabled'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtDayData', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtDayData', @level2type=N'COLUMN',@level2name=N'DayTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtDayData', @level2type=N'COLUMN',@level2name=N'PointId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��ֵ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtDayData', @level2type=N'COLUMN',@level2name=N'Value'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtDayData', @level2type=N'COLUMN',@level2name=N'Remark'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthData', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthData', @level2type=N'COLUMN',@level2name=N'Year'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthData', @level2type=N'COLUMN',@level2name=N'Month'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthData', @level2type=N'COLUMN',@level2name=N'PointId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��ֵ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthData', @level2type=N'COLUMN',@level2name=N'Value'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthData', @level2type=N'COLUMN',@level2name=N'Remark'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthTime', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthTime', @level2type=N'COLUMN',@level2name=N'Year'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthTime', @level2type=N'COLUMN',@level2name=N'Month'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��ʼʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthTime', @level2type=N'COLUMN',@level2name=N'StartTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthTime', @level2type=N'COLUMN',@level2name=N'EndTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtMonthTime', @level2type=N'COLUMN',@level2name=N'MachNO'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtPoints', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtPoints', @level2type=N'COLUMN',@level2name=N'PointName'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'λ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtPoints', @level2type=N'COLUMN',@level2name=N'Position'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtPoints', @level2type=N'COLUMN',@level2name=N'TableType'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtPoints', @level2type=N'COLUMN',@level2name=N'MachNO'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtPoints', @level2type=N'COLUMN',@level2name=N'Description'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��λ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RtPoints', @level2type=N'COLUMN',@level2name=N'Unit'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmsGroup', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmsGroup', @level2type=N'COLUMN',@level2name=N'Name'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmsGroupAccount', @level2type=N'COLUMN',@level2name=N'GroupId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�˺�Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmsGroupAccount', @level2type=N'COLUMN',@level2name=N'AccountId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SmsGroupAccount', @level2type=N'COLUMN',@level2name=N'FADateTime'

EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'Id'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'PartId'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��ʼʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'StartTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'EndTime'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�Ƿ���ɱ�־' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'Flag'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��ֵ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'Duty'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'UltraType'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��Сֵ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'MinValue'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'���ֵ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'MaxValue'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'ƽ��ֵ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'AvgValue'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'Remarks'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�Ƿ��б�ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'HasRemarks'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'�Ƿ���רҵ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'IsProRecord'
EXEC sys.sp_addextendedproperty @name=N'ms_description', @value=N'���Ͷ��ű�־' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UltraRecord', @level2type=N'COLUMN',@level2name=N'SmsFlag'






