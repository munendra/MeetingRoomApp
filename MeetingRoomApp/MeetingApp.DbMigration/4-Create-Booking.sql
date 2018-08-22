Create Table Booking(
Id uniqueidentifier default(NewId()) primary key,
RoomId uniqueidentifier not null,
EmployeeId uniqueidentifier not null,
StartTime datetime,
EndTime Datetime,
 CONSTRAINT FK_Room_Id_Booking FOREIGN KEY (RoomID)
    REFERENCES Room(Id),
 CONSTRAINT FK_Booking_Employee_Id FOREIGN KEY (EmployeeId)
    REFERENCES Employee(Id),
RowVersion rowversion
)