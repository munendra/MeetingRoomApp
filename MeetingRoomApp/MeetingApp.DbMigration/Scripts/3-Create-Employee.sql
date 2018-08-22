Create table Employee(
Id uniqueidentifier default(NewId()) primary key,
EmpId varchar(max) not null,
FullName varchar(max) not null,
Rowversion rowversion,
CreatedAt		datetime default(getdate()),
ModifiedAt		datetime default(getdate())
)