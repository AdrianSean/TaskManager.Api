declare @statusId int,
		@taskId int,
		@userId int


if not exists(select * from [User] where Username = 'bhogg')
	INSERT INTO [dbo].[User]([Firstname], [Lastname], [Username])
			VALUES (N'Boss', N'Hogg', N'bhogg')


if not exists(select * from [User] where Username = 'jhob')
	INSERT into [dbo].[User]([Firstname],[Lastname], [Username])
			VALUES (N'Jim', N'Bob', N'jbob')


if not exists (select * from [User] where Username = 'jdoe')
	INSERT INTO [dbo].[User]([Firstname], [Lastname], [Username])
			VALUES (N'John', N'Doe', N'jdoe')

if not exists(select * from dbo.Task where SSubject = 'Test Task')
begin
	select top 1 @statusId = StatusId from Status order by StatusId;
	select top 1 @userId = UserId from [User] order by UserId;

	insert into dbo.task(Subject, StartDate, StatusId, CreatedDate, CreatedUserId)
		values ('Test Task', getdate(), @statusId, getdate(), @userId);

	set @taskId = SCOPE_IDENTITY();

	INSERT [dbo].[taskuser]([taskId], [UserId])
		VALUES(@taskId, @userId)



end

