use [master]
go

drop database if exists QuickStartDB

Create database QuickStartDB
Go

USE QuickStartDB
GO

Create table Roles 
(
	RoleId int identity(1,1) primary key,
	RoleName varchar(50) not null unique
)
Go

create table Users 
(
	EmailId varchar(50) primary key,
	UserPassword varchar(50) not null,
	RoleId int foreign key references Roles(RoleId) not null,
	Gender char Check(Gender in ('M', 'F')) Not NulL,
	DateOfBirth date not null check(DateOfBirth < getdate()),
	Address varchar(200) not null
)
Go

Create Table Categories 
(
	CategoryId int identity(1,1) primary key,
	CategoryName varchar(50) not null unique
)
Go

Create Table Products 
(
	ProductId char(4) primary key check(ProductId like 'P%'),
	ProductName varchar(50) not null unique,
	CategoryId int foreign key references Categories(CategoryId) not null,
	Price Numeric(8) not null check(Price > 0),
	QuantityAvailable int not null check(QuantityAvailable >= 0)
)
Go

Create Table PurchaseDetails
(
	PurchaseId int identity(1000,1) primary key,
	EmailId varchar(50) foreign key references Users(EmailId) not null,
	ProductId char(4) foreign key references Products(ProductId) not null,
	QuantityPurchased int not null check(QuantityPurchased > 0),
	DateOfPurchase datetime not null check(DateOfPurchase < getdate()) default getdate()
)
Go

Create Table CardDetails
(
	CardNumber numeric(16) primary key,
	NameOnCard varchar(50) not null,
	CardType char(6) check(CardType in ('V', 'M','A')) not null,
	CVVNumber int not null check(CVVNumber between 100 and 999),
	ExpiryDate date not null check(ExpiryDate > getdate()),
	Balance Decimal(10,2) not null check(Balance >= 0)
)
Go


Create Procedure usp_RegisterUser
(
	@EmailId varchar(50),
	@UserPassword varchar(50),
	@Gender char,
	@DateOfBirth date,
	@Address varchar(200)
)
as
begin
	declare @RoleId int
	Begin try
		if (len(@emailid)<4 or len(@emailid)>50 or (@emailid is null))
		return -1
		if (len(@UserPassword)<8 or len(@UserPassword)>15 or (@UserPassword is null))
		return -2
		if ((@Gender not in ('M', 'F')) or (@gender is null))
		return -3
		if ((@DateOfBirth is null) or @DateOfBirth >= cast(getdate() as date))
		return -4
		if DateDiff(d, @DateOfBirth, getdate()) < 6570
		return -5 
		if (len(@Address)>200 or (@Address is null))
		return -6
		Select @RoleId = RoleId from Roles where RoleName = 'Customer'
		Insert into Users Values
		(
			@EmailId,
			@UserPassword,
			@RoleId,
			@Gender,
			@DateOfBirth,
			@Address
		)
		Return 1
	End try
	Begin catch
		Return -99
	End catch
end
Go

Create Procedure usp_AddProduct
(
	@ProductId char(4),
	@ProductName varchar(50),
	@CategoryId int,
	@Price Numeric(8),
	@QuantityAvailable int
)
as
begin
	Begin try
		if (@productid is null)
		return -1
		if (len(@ProductId)<>4 or (@ProductId not like 'P%'))
		return -2
		if (@ProductName is null)
		return -3
		if (@CategoryId is null)
		return -4
		if not exists (select CategoryId from Categories where CategoryId = @CategoryId)
		return -5
		if (@Price is null or @Price <= 0)
		return -6
		if (@QuantityAvailable is null or @QuantityAvailable < 0)
		return -7
		Insert into Products Values
		(
			@ProductId,
			@ProductName,
			@CategoryId,
			@Price,
			@QuantityAvailable
		)
		Return 1
	End try
	begin catch
		Return -99
	end catch
end
Go

create procedure usp_UpdateBalance
(
	@CardNumber int,
	@NameOnCard varchar(50),
	@CardType char(6),
	@CVVNumber int,
	@ExpiryDate date,
	@Price numeric(8)
)
as
begin
     declare @TempUserName varchar(50), @TempCardType char(6), @TempCVVNumber int, @TempExpiryDate date, @Balance numeric(10)
	Begin try
		if (@CardNumber is null)
		return -1
		if not exists (select CardNumber from CartDetails where CardNumber = @CardNumber)
		return -2
		select @TempUserName = NameOnCard, @TempCardType = CardType, @TempCVVNumber = CVVNumber, @TempExpiryDate = ExpiryDate, @Balance = Balance from CartDetails where CardNumber = @CardNumber
		if ((@TempUserName <> @NameOnCard) or (@NameOnCard is null))
		return -3
		if ((@TempCardType <> @CardType) or (@CardType is null))
		return -4
		if ((@TempCVVNumber <> @CVVNumber) or (@CVVNumber is null))
		return -5
		if ((@TempExpiryDate <> @ExpiryDate) or (@ExpiryDate is null))
		return -6
		if ((@Balance is null) or (@Balance < @Price))
		return -7
		Update CartDetails set Balance = Balance - @Price where CardNumber = @CardNumber
		Return 1
	End try
	begin catch
		Return -99
	end catch
end
Go

Create Procedure usp_InsertPurchaseDetails
(
	@EmailId varchar(50),
	@ProductId char(4),
	@QuantityPurchased int,
	@PurchaseId int out
)
As
begin
    set @PurchaseId = 0
	Begin try
		if (@EmailId is null)
		return -1
		if not exists (select EmailId from Users where EmailId = @EmailId)
		return -2
		if (@ProductId is null)
		return -3
		if not exists (select ProductId from Products where ProductId = @ProductId)
		return -4
		if (@QuantityPurchased is null or @QuantityPurchased <= 0)
		return -5
		insert into PurchaseDetails values (@EmailId, @ProductId, @QuantityPurchased,Default)
		select @PurchaseId = PurchaseId from PurchaseDetails where EmailId = @EmailId and ProductId = @ProductId and QuantityPurchased = @QuantityPurchased
		update Products set QuantityAvailable = QuantityAvailable - @QuantityPurchased where ProductId = @ProductId
		Return 1
	End try
	begin catch
		set @PurchaseId = 0
		Return -99
	end catch
end
Go

create function ufn_GenerateProductId()
returns char(4)
as
begin
	declare @ProductId char(4)
	if not exists (select ProductId from Products)
		set @ProductId = 'P001'
	else
		set @ProductId = 'P' + (SELECT RIGHT('000' + CAST(CAST(SUBSTRING(MAX(ProductId), 2, 3) AS INT) + 1 AS VARCHAR(3)), 3) FROM Products)
	return @ProductId
End
Go
