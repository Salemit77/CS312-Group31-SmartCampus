# Smart Campus - GUI Only

A simplified WinForms university project built with standard controls and in-memory demo data.

The application includes five screens:

- Students
- Rooms
- Campus Map
- Attendance
- Notifications

There is no database, no server, no TCP connection, and no external NuGet package.

## Run

```powershell
dotnet run --project SmartCampus_GUI_Only.csproj
```

Or open `SmartCampus_GUI_Only.sln` in Visual Studio and press F5.

## Demo accounts

| Role | Username | Password |
|---|---|---|
| Admin | admin | admin123 |
| Staff | staff | staff123 |

The Admin account can perform all actions. The Staff account can manage students, rooms, and attendance, but cannot delete students or rooms or edit and delete notifications.

## Requirements

- Windows 10 or 11
- .NET 10 SDK

No SQL Server, LocalDB, database setup, or server process is required.

## Project structure

```text
SmartCampus_GUI_Only/
  SmartCampus_GUI_Only.sln
  SmartCampus_GUI_Only.csproj
  Program.cs
  Forms/
    LoginForm.cs
    MainForm.cs
    Pages/
      CampusPage.cs
      StudentsPage.cs
      RoomsPage.cs
      CampusMapPage.cs
      AttendancePage.cs
      NotificationsPage.cs
    Dialogs/
      StudentDialog.cs
      RoomDialog.cs
      AttendanceDialog.cs
      NotificationDialog.cs
  Services/
    ICampusDataService.cs
    InMemoryCampusDataService.cs
    CampusDataChange.cs
    ClientLog.cs
  Models/
    Entities.cs
    Dtos.cs
    Enums.cs
  Validation/
    ValidationResult.cs
    Validators.cs
  Helpers/
    FormHelper.cs
    BufferedPanel.cs
```

## Implementation notes

- The main form uses a MenuStrip, standard header panel, TabControl, DataGridView, GroupBox, and StatusStrip.
- The StatusStrip timer updates the clock and unread notification count, and data changes update the live status text.
- All CRUD actions use a small in-memory service. Data is reset when the application closes.
- Demo data includes realistic student names and room codes such as CS301, Lab 4B, Hall 102, and Hall 201.
- Students are filtered in real time by the search box and by department, room, and status combo boxes.
- Selecting a student row loads the record into the inline editor for updating or deleting.
- The student and room dialogs use KeyPress/Validating handlers with ErrorProvider validation.
- The Campus Map tab uses two double-buffered Panels. The map draws rooms with GDI+ and responds to MouseClick, while the chart draws a live attendance bar chart.
- Both GDI+ panels are invalidated when room, student, or attendance data changes.
- Notifications are stored and filtered in memory. New notification events update the status bar and refresh the list.
- The original full client/server project in `C:\Users\acer\Desktop\222` is unchanged.
