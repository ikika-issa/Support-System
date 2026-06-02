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
	
- Adjusted Program.cs to read the services in the Service layer