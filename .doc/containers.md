[Back to README](../README.md)

## Containers
Database postgreSQL is mandatory to run the application. 
The database is hosted on a container format. 

When docker composer is executed
```
docker composer up
```
it executes a sequence of containers installation and create the same network inside docker environment, to one container communicates with another.

- **ambev_developer_evaluation_database:** contains the database container, database is postgresql (this is mandatory)

- **ambev_developer_evaluation_cache:** create a mongo db database, is responsible for the cache data for all application

- **ambev_developer_evaluation_nosql:** create a mongo db database a NOSQL database

- **ambev_developer_evaluation_webapi:** host the application after build proccess, is hosting a dotnet app, it is not necessary because the application can run local 

- **ambev_developer_evaluation_frontend:** host the angular frontend, is hosting a angular app, it is not necessary because the front can run local 
