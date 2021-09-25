# BikeSharingAPI
 ---
BikeSharing API bir bisiklet kiralama şirketinin kullanıcıları ve bu kullanıcıların bisiklet kullanım kayıtları üzerinde işlem yapılmasına olanak verir.
## Technologies
---
#### EntityFramework
Microsoft.EntityFrameworkCore used as ORM
#### AutoMapper
AutoMapper used for mappings between DTOs and DB Entities v10.1.1
#### SQLite
SQLite is used to store all the data.
#### Dynamic Linq
Dynamic Linq is used for dynamic query parameters.
#### ASP.​Net
.Net 5
## Architecture
---
### Network Layer
---

### Service Layer
---
### Repository Layer
---
Everything related to databases such as connecting to databases, querying databases, creating data models based on data stored in databases are done here.
## Database
---
SQLite is choosen for it's ability to initialize a database from scratch quickly on every build. Database consists of two tables: Users and Sessions. (one-to-many)
## Manual
---
### Headers
---
#### API Key 
Client should include the API Key to be able to use the API. If no key or an unauthorized key is added to the header of the request, the HTTP status code 401 (Unauthorized) is returned.
### Endpoints
---
#### Query Parameters
