Create table Room(
Id				uniqueidentifier default(NewId()) primary key,
Name			varchar(max) not null,
Price			decimal,
SeatingCapacity int,
IsBooked		bit default(0),
CreatedAt		datetime,
ModifiedAt		datetime,
RowVersion		rowversion
)