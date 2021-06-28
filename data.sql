
USE myCafe;
Go

CREATE TABLE Account
(
	id int IDENTITY(1,1) primary key,
	UserName nvarchar(50) not null,
	PassWord nvarchar(50) not null,
	FullName nvarchar(50) not null,
	Address nvarchar(50) not null,
	Phone int not null,
	idRole int,
	status nvarchar(50),
	foreign key (idRole) references Role
)

CREATE TABLE Role
(
	Role_id int IDENTITY(1,1) primary key,
	RoleName nvarchar(50) not null,
)

CREATE TABLE Bill
(
	Bill_id int IDENTITY(1,1) primary key,
	DateChekIn Date not null,
	DateChekOut Date,
	inTable int  not null,
	idAccount int not null,
	status int not null, --1:thanh toan r, 0:chua thanh toan
	foreign key (idAccount) references Account,
	foreign key (inTable) references TableFood
)

CREATE TABLE BillInfo
(
	BillInfo_id int IDENTITY(1,1) primary key,
	idBill int not null,
	idFood int not null,
	idAccount int,
	idTable int,
	count int not null ,
	foreign key (idAccount) references Account,
	foreign key (idBill) references Bill,
	foreign key (idFood) references Food,
	foreign key (idTable) references TableFood
)

CREATE TABLE TableFood
(
	TableFood_id int IDENTITY(1,1) primary key,
	TableFood_name nvarchar(100) not null,
	status nvarchar(100) not null --Trống || có người
)

CREATE TABLE Food
(
	Food_id int IDENTITY(1,1) primary key,
	Food_name nvarchar(50) not null,
	price int not null,
	idCategory int not null,
	foreign key (idCategory) references FoodCategory,
)


CREATE TABLE FoodCategory
(
	FoodCategory_id int IDENTITY(1,1) primary key,
	FoodCategory_name nvarchar(50) not null
)
