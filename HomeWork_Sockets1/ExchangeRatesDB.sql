create table [Clients](
	[Id] int not null identity(1,1),
	[Login] varchar(100) not null unique,
	[Password] varchar(100) not null unique,
	[LimitQueries] int not null, 

	constraint PK_Clients_Id primary key([Id]),
	constraint CK_Clients_Login check([Login] <> ''),
	constraint CK_Clients_Password check([Password] <> ''),
	constraint CK_Clients_LimitQuotes check([LimitQueries] > 0)
);


create table [LogConnections](
	[Id] int not null identity(1,1),
	[ClientId] int not null,
	[Date] datetime not null,

	constraint PK_LogConnections_Id primary key([Id]),
	constraint FK_LogConnections_ClientId foreign key([ClientId]) references [Clients]([Id]),
	constraint CK_LogConnections_Date check([Date] <= GetDate())
);


create table [LogDisconnections](
	[Id] int not null identity(1,1),
	[ClientId] int not null,
	[Date] datetime not null,

	constraint PK_LogDisconnections_Id primary key([Id]),
	constraint FK_LogDisconnections_ClientId foreign key([ClientId]) references [Clients]([Id]),
	constraint CK_LogDisconnections_Date check([Date] <= GetDate())
);


create table [LogClientsQueries](
	[Id] int not null identity(1,1),
	[ClientId] int not null,
	[FromCurrency] varchar(3) not null,
	[ToCurrency] varchar(3) not null,
	[Date] datetime not null default(GetDate()),

	constraint PK_LogClientsQueries_Id primary key([Id]),
	constraint FK_LogClientsQueries_ClientId foreign key([ClientId]) references [Clients]([Id]),
	constraint CK_LogClientsQueries_FromCurrency check([FromCurrency] <> ''),
	constraint CK_LogClientsQueries_ToCurrency check([ToCurrency] <> ''),
	constraint CK_LogClientsQueries_Date check([Date] <= GetDate()),
);


create proc [AddClient]
    @Login varchar(100),
    @Password varchar(100),
    @LimitQueries int
as
begin
    insert into [Clients] ([Login], [Password], LimitQueries)
    values (@Login, @Password, @LimitQueries)
end;


create proc [AddLogConnection]
    @ClientId int,
    @Date datetime
as
begin
    set nocount on;

    if NOT EXISTS (select 1 from Clients where Id = @ClientId)
    begin
        raiserror ('Client with specified ID does not exist.', 16, 1)
        return
    end

    insert into [LogConnections] ([ClientId], [Date])
    values (@ClientId, @Date)
end;


create proc [AddLogDisconnection]
    @ClientId int,
    @Date datetime
as
begin
    set nocount on;

    if NOT EXISTS (select 1 from Clients where Id = @ClientId)
    begin
        raiserror ('Client with specified ID does not exist.', 16, 1)
        return
    end

    insert into [LogDisconnections] ([ClientId], [Date])
    values (@ClientId, @Date)
end;


create proc [AddLogClientsQueries]
    @ClientId int,
    @FromCurrency varchar(3),
    @ToCurrency varchar(3)
as
begin
    set nocount on;

	    if NOT EXISTS (select 1 from Clients where Id = @ClientId)
    begin
        raiserror ('Client with specified ID does not exist.', 16, 1)
        return
    end

    insert into [LogClientsQueries] ([ClientId], [FromCurrency], [ToCurrency])
    values (@ClientId, @FromCurrency, @ToCurrency);
end;

