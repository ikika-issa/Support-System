# CHANGELOG

## Up until 02-06-2026

### ADDED

DOMAIN LAYER 
----------------------------
- Domain models for:
	1. Ticket --> Domain Model
	2. TicketTasks (one ticket can have multiple tasks) --> Domain Model
	3. TicketStatus --> Domain Model
	4. TicketPriority --> Enum
	5. TicketShare (a relational table for sharing tickets between users) --> Domain Model
	6. TicketViewType (supposed to be a filter for viewing groups of tickets (Pending, Open, Closed etc)) --> Enum (?)
	7. TaskType --> Enum (?) this I think should be a domain model and up to the user (IT) to set up
	8. TaskReminder --> Domain Model
	9. SupportGroup --> Domain Model
	10. Category --> Domain Model
	11. Subcategory --> Domain Model
	12. CategoryItem --> Domain Model
	13. Attachment --> Domain Model
	14. Site --> Domain Model
	15. Note --> Domain Model
	16. NoteInTicket (relational table between Note and Ticket) --> Domain Model
	17. ExportFormat --> Domain Model
	18. EmailMessage --> Domain Model
	19. BaseEntity (to handle the ID for use of one repository interface and implementation) --> Domain Model
		
- DTO:
	1. TicketExportDTO --> to export tickets to a few types of formats

- SupportSystemAppUser -> an identity user added as an extension of IdentityUser with attributes:
	1. First Name
	2. Last Name
	3. List of OpenedTickets
	4. List of AssignedTickets

	
REPOSITORY LAYER
----------------------------
- Repository Interface
- Repository Implementation
- Moved ApplicationDbContext to Repository Layer
- Moved Migrations to Repository Layer


SERVICE LAYER
----------------------------
- Interface and Implementation Services for CRUD operations for:
	1. Category
	2. Subcategory
	3. Note
	4. TicketExport
	5. Ticket

WEB LAYER
----------------------------
- Scaffolded controllers:
	1. Categories
	2. CategoryItem
	3. Notes
	4. Sites
	5. Subcategories
	6. SupportGroups
	7. Tickets
	8. TicketTask

- Added views:
	1. Categories
	2. CategoryItem
	3. Notes
	4. Sites
	5. Subcategories
	6. SupportGroups
	7. Tickets
	8. TicketTask
	
- Scaffolded Identity for Register 

### TO DO:

- Adjust Program.cs to read the services in the Service layer [DONE]
- Adjust Program.cs to read the repository in the Repository layer [DONE]
- Adjust the controllers to use the services instead of ApplicationDbContext directly:
	1. Note [DONE]
	2. Ticket [DONE]
	3. TicketTask [DONE]
	4. Sites [DONE]
	5. Subcategory [DONE]
	6. SupportGroup [DONE]
	7. Category [DONE]
	8. CategoryItem

- Implement the export functionality(TicketExportService) for exporting tickets to different formats (Excel, PDF, CSV etc.)
	- this should be implemented in the TicketService
	- it should be added as an action in the TicketController
- Implement creation of users
- Scaffold Login for User Authentication [DONE]
- Scaffold Logout for User Authentication [DONE]
- Adjust Program.cs to read the Identity services
- Create flexible creation for Roles
	- these should implement editing of the roles to be able to add/remove permissions for each role
- Implement different roles to be added to users (Admin, IT, Employee etc.)


## 03-06-2026 AND 04-06-2026

### ADDED

SERVICE LAYER
----------------------------
- Added a new Service (Interface and Implementation) for Attachments
- Added a new Service (Interface and Implementation) for Sites
- Added a new Service (Interface and Implementation) for SupportGroup
- Added a new Service (Interface and Implementation) for TicketTask
- Added a search function for notes by Ticket ID in the NoteService


WEB LAYER
----------------------------
- Added the services to Program.cs
- Added a new controller for Site 


### FIXED

- Adjusted the controllers to use the services instead of ApplicationDbContext directly:
	1. Note [DONE]
	2. Ticket [DONE]
	3. TicketTask [DONE]
	4. Sites [DONE]
	5. Subcategory [DONE]
	6. SupportGroup [DONE]
- Fixed the Note Service function for insert to insert a note in the DB, but also insert a record in the NoteInTicket table to link the note to the ticket
- Fixed the TicketTask Service function for inserting in the Relational table for Ticket and Task
- Fixed the TicketTask Service function for deleting in the Relational table for Ticket and Task
- Fixed in Tickets Controller to add the drop down menus in the GET Create function


### TO DO:

- Adjust the controllers to use the services instead of ApplicationDbContext directly:
	1. CategoryItem

- Implement the export functionality(TicketExportService) for exporting tickets to different formats (Excel, PDF, CSV etc.)
	- this should be implemented in the TicketService
	- it should be added as an action in the TicketController
- Implement creation of users
- Adjust Program.cs to read the Identity services
- Create flexible creation for Roles
	- these should implement editing of the roles to be able to add/remove permissions for each role
- Implement different roles to be added to users (Admin, IT, Employee etc.)
- Fix all warnings across App (33 warnings)