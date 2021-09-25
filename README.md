# BikeSharingAPI
 ---
BikeSharing API enables to work with data of users of a bike sharing company and their cycling sessions.
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
The application is developed using onion architecture. It is done to lower coupling and make codes cleaner. The application consists of three main layers, the Service layer, wrapped by the Repository layer, and both wrapped by the Network layer. 
### Network Layer.
---
Controllers and Middlewares are the main actors on this layer and they are responsible for routing of requests and responses. They are the first to recieve and map the data from a response and last to return the response.
### Service Layer
---
This is where the data models and main logic of the application takes place. 
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
Client should include the API Key with the Authorization header to be able to use the API. If no key or an unauthorized key is added to the header of the request, the HTTP status code 401 (Unauthorized) is returned.
### Endpoints
---
#### Query Parameters
