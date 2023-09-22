Create database Electric 
use Electric

create table Payments(PaymentNo int primary key ,PaymentDate date, CustNo int foreign key references
Customers(CustNo),EmpNo int foreign key references Employees(EmpNo),Locations varchar(50),[Status] varchar(50))

create table Customers(CustNo int primary key, CustName varchar(50))

create table Employees(EmpNo int primary key,EmpName varchar(50))

create table PaymentDetails(PaymentNo int foreign key references Payments(PaymentNo),ItemNo int foreign key
references Items(ItemNo),Qty int,UnitPrice real,Total real)

create table Items(ItemNo int primary key, ItemName varchar(50),Unitprice real)

create table Users(Id int identity primary key,UserName varchar(50),Passwords varchar(50))

insert into Users values('Admin',123)

Drop table Payments
select * from Payments
select * from Customers
select * from Employees
select * from PaymentDetails
select * from Items
select * from Users;