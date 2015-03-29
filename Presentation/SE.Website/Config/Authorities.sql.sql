
	
	INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'系统设置-账号管理')
	INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'系统设置-短信设置')
	INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'超限统计-统计1')
	INSERT INTO dbo.Authority( AuthorityType, Name ) VALUES  ( 1, N'超限统计-统计2')
insert into Account(LoginName,Password,AccountType) values('admin','123456',1)
		insert into AccountAuthority(AccountId,AuthorityId) select Account.Id AccountId,Authority.Id from Account,Authority where Account.LoginName='admin' and Authority.Name=N'系统设置-账号管理'
			insert into AccountAuthority(AccountId,AuthorityId) select Account.Id AccountId,Authority.Id from Account,Authority where Account.LoginName='admin' and Authority.Name=N'系统设置-短信设置'
			insert into AccountAuthority(AccountId,AuthorityId) select Account.Id AccountId,Authority.Id from Account,Authority where Account.LoginName='admin' and Authority.Name=N'超限统计-统计1'
			insert into AccountAuthority(AccountId,AuthorityId) select Account.Id AccountId,Authority.Id from Account,Authority where Account.LoginName='admin' and Authority.Name=N'超限统计-统计2'
	
	

