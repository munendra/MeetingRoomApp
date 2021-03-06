﻿Create Table RoomFacility(
Id			uniqueidentifier default(NewId()) primary key,
RoomID		uniqueidentifier  not null,
Name		varchar(max) not null,
Description varchar(max),
Value		varchar(max),
CreatedAt	datetime default(GetDate()),
ModifiedAt datetime default(GetDate()),
 CONSTRAINT FK_Room_Id_RoomFacility FOREIGN KEY (RoomID)
    REFERENCES Room(Id),
RowVersion rowversion
)