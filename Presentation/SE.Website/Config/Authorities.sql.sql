
	
	INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'系统设置-账号管理')
	INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'系统设置-班次设置')
	INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'系统设置-短信接受组管理')
	INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'超限统计-常规超限统计')
	INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'超限统计-专业超限统计')
	INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'常规超限配置-设备管理')
	INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'常规超限配置-部件管理')
	INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'常规超限配置-监控类别管理')
	INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'专业超限配置-部件管理')
	INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 2, N'专业超限配置-专业')
--insert into Account(LoginName,Password,AccountType) values('admin','123456',1)
		insert into AccountAuthority(AccountId,AuthorityId) select Account.Id AccountId,Authority.Id from Account,Authority where Account.LoginName='admin' and Authority.Name=N'系统设置-账号管理'
			insert into AccountAuthority(AccountId,AuthorityId) select Account.Id AccountId,Authority.Id from Account,Authority where Account.LoginName='admin' and Authority.Name=N'系统设置-班次设置'
			insert into AccountAuthority(AccountId,AuthorityId) select Account.Id AccountId,Authority.Id from Account,Authority where Account.LoginName='admin' and Authority.Name=N'系统设置-短信接受组管理'
			insert into AccountAuthority(AccountId,AuthorityId) select Account.Id AccountId,Authority.Id from Account,Authority where Account.LoginName='admin' and Authority.Name=N'超限统计-常规超限统计'
			insert into AccountAuthority(AccountId,AuthorityId) select Account.Id AccountId,Authority.Id from Account,Authority where Account.LoginName='admin' and Authority.Name=N'超限统计-专业超限统计'
			insert into AccountAuthority(AccountId,AuthorityId) select Account.Id AccountId,Authority.Id from Account,Authority where Account.LoginName='admin' and Authority.Name=N'常规超限配置-设备管理'
			insert into AccountAuthority(AccountId,AuthorityId) select Account.Id AccountId,Authority.Id from Account,Authority where Account.LoginName='admin' and Authority.Name=N'常规超限配置-部件管理'
			insert into AccountAuthority(AccountId,AuthorityId) select Account.Id AccountId,Authority.Id from Account,Authority where Account.LoginName='admin' and Authority.Name=N'常规超限配置-监控类别管理'
			insert into AccountAuthority(AccountId,AuthorityId) select Account.Id AccountId,Authority.Id from Account,Authority where Account.LoginName='admin' and Authority.Name=N'专业超限配置-部件管理'
			insert into AccountAuthority(AccountId,AuthorityId) select Account.Id AccountId,Authority.Id from Account,Authority where Account.LoginName='admin' and Authority.Name=N'专业超限配置-专业'
	
	

