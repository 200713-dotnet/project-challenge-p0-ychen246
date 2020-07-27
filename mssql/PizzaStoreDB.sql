create database PizzaStoreDB;
go

use PizzaStoreDB;
go

create schema Pizza;
go

create table Pizza.Pizza
(
	PizzaId int not null primary key,
	PizzaName nvarchar(250),
	Size int not null,
	Price money
)
go

create table Pizza.Topping
(
	ToppingId int not null primary key,
	PizzaId int not null,
	ToppingName nvarchar(250),
)
go

create schema Orders;
go

create table Orders.Orders
(
	OrderId int not null primary key,
	PurchaseDate datetime2(0) not null,
	TotalPrice money not null,
	UserId int not null,
)
go

create table Orders.PizzaOrder
(
	PizzaOrderId int not null primary key,
	PizzaId int not null,
	OrderId int not null,
)
go

create schema Users;
go 

create table Users.Users
(
	UserId int not null primary key,
	FirstName nvarchar(250),
	LastName nvarchar(250),
)
go

create schema Stores;
go 

create table Stores.Stores
(
	StoreId int not null primary key,
	StoreName nvarchar(250),
	StoreAddress nvarchar(500)
)
go

create table Stores.StoreOrders
(
	StoreOrdersId int not null primary key,
	StoreId int not null,
	OrderId int not null,
	Complete bit not null, 
)
go

alter table Pizza.Topping
	add constraint PizzaId foreign key references Pizza.Pizza(PizzaId)

alter table Orders.Orders
	add constraint UserId foreign key references Users.Users(UserId)

alter table Orders.PizzaOrder
	add constraint PizzaId foreign key references Pizzas.Pizzas(PizzaId)

alter table Orders.PizzaOrder
	add constraint OrderId foreign key references Orders.Orders(OrderId)

alter table Stores.StoreOrders 
	add constraint StoreId foreign key references Store.Stores(StoreId)

alter table Stores.StoreOrders
	add constraint OrderId foreign key references Orders.Orders(OrderId)
	