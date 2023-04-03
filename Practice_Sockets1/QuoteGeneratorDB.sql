create table [Quotes](
	[Id] int not null identity(1,1),
	[Content] nvarchar(1000) not null,

	constraint PK_Quotes_Id primary key([Id]),
	constraint CK_Quotes_Content check([Content] <> '')
);


create table [Clients](
	[Id] int not null identity(1,1),
	[Login] varchar(100) not null unique,
	[Password] varchar(100) not null unique,
	[LimitQuotes] int not null, 

	constraint PK_Clients_Id primary key([Id]),
	constraint CK_Clients_Login check([Login] <> ''),
	constraint CK_Clients_Password check([Password] <> ''),
	constraint CK_Clients_LimitQuotes check([LimitQuotes] > 0)
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


create table [LogQuotesClients](
	[ClientId] int not null,
	[QuoteId] int not null,
	[Date] datetime not null default(GetDate()),

	constraint PK_LogQuotesClients primary key([ClientId], [QuoteId], [Date]),
	constraint FK_LogQuotesClients_ClientId foreign key([ClientId]) references [Clients]([Id]),
	constraint FK_LogQuotesClients_QuoteId foreign key([QuoteId]) references [Quotes]([Id]),
	constraint CK_LogQuotesClients_Date check([Date] <= GetDate())
);


alter proc [AddLogQuoteClient]
    @ClientId int,
    @QuoteId int
as
begin
    set nocount on;
    declare @CurrentDate datetime = GetDate();

    if NOT EXISTS (select 1 from Clients where Id = @ClientId)
    begin
        raiserror('Client with id %d does not exist in the Clients table', 16, 1, @ClientId);
        return;
    end;

    if NOT EXISTS (select 1 from Quotes where Id = @QuoteId)
    begin
        raiserror('Quote with id %d does not exist in the Quotes table', 16, 1, @QuoteId);
        return;
    end;

    insert into LogQuotesClients (ClientId, QuoteId)
    values (@ClientId, @QuoteId);
end


alter proc [AddLogConnection]
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
end


alter proc [AddLogDisconnection]
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
end



insert into [Quotes] values('"There are other ways to see."'), 
('"I’m not seeking penance for what I’ve done, father. I’m asking forgiveness for what I’m about to do."'),
('"How do you know the angel and the devil inside me aren’t the same thing?"'),
('"You don’t get to destroy who I am."'),
('"Take the dare. When justice is blind, it knows no fear. When the streets have gone to Hell - have faith in the Devil. Justice is blind."'),
('"So the question you have to ask yourself is: are you struggling with the fact that you don`t wanna kill this man, but have to? Or that you don`t have to kill him, but want to?"'),
('"Wind blows the hardest the closer you get to the mountain top."'),
('"The wheel constantly turns. We must adapt to its position, or be crushed beneath it."'),
('"Growing to love something is really simply forgetting slowly what you dislike about it."');

insert into [Clients] values('user1', 'user111', 10), ('user2', 'user222', 8);