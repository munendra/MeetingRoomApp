**Apis** <br>
*For Database setup run MeetingApp.DbMigration project first*<br>
> *Booking a meeting room* <br>
Url: localhost:5000/api/v1/meeting-room/booking <br>
Type: Post <br>
Data: {
  "employeeName": "test",
  "EmployeeId": "p6",
  "roomId": "0F18DBD7-57D4-4E2E-808F-24A4429F478P",
  "startDateTime": "2018-08-22T09:00:00",
  "endDateTime": "2018-08-22T10:00:00"
} <br>

> *Get All Rooms* <br>
Url: localhost:5000/api/v1/meeting-room/ <br>
Type: Get <br>

> *Check room available* <br>
Url: localhost:5000/api/v1/meeting-room/availability  <br>
Type: POST <br>
Data: { 
  "roomId": "0F18DBD7-57D4-4E2E-808F-24A4429F4A1B",
  "startDateTime": "2018-08-22T10:00:00",
  "endDateTime": "2018-08-22T12:00:00"
} <br>

> *Get All Available rooms* <br>
Url: localhost:5000/api/v1/meeting-room/available-rooms/2018-08-23 10:00:00.000 <br>
Type:Get <br>

> *Total expense report* <br>
Url: localhost:5000/api/v1/meeting-room/booking/expense <br>
Type: Get <br>

> *Total expense by employee report* <br>
Url: localhost:5000/api/v1/meeting-room/booking/expense/A485AF4B-33CB-47BD-62E2-08D608577CFC <br>
Type: Get <br>

> *Filter* <br>
Url: localhost:5000/api/v1/meeting-room/Search/?SeatingCapacity=50&filters[0][HasLargeDisplayScreen]=1 <br>
Type: Get <br>
