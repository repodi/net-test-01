# Sales system

This is a sale system build with net framework 8.0 and angular.

A customer places a purchase order. He can open the order himself or he can call a branch and ask them to open a purchase order for him.

When the customer opens the purchase order himself he can enter the branch salesperson code, this code identifies the branch salesperson user.

The branch is responsible for closing the order and transforming the purchase order into a sale.

The branch can also open purchase orders and then close the sale for customers.

There are 4 different types of users who access the system (profile):

- Customer: represents a customer who can make sales purchase order , can create user with customer role (fixed cusomer id)

- Branch: represents a branch employee who can complete sales and list sales by branch (only directed to this branch), can create user with customer role

- Manager: represents an enterprise employee who can complete sales and list sales by branch or not, can create user with customer or branch roles 

- Admin: represents a enterprise employee with priviligied access can alter discounts and create new users


## Details about the flow 

The sequence diagram and the entity relationship diagram of the database showing how the system works can be found at:

See [Flow](/.doc/flow.md)

## Sample data

As a demonstration system, when running the entity framework, it creates an initial load in the tables so that it can be used.

Users are also created for each profile, the relationship can be found at:

See [Users Profile](/.doc/users.md)


## Installation and Developer environment

Aplication needs .net Framework 8.0 to execute, need to install the sdk, is operation system agnostic, can use Linux or Windows. 
This system was built on Linux Manjaro.

### IDE
For development process is recommend you have an IDE, the recommend is Visual Studio Code. 

[Visual Studio Code.](https://code.visualstudio.com/)

Reccomended extensions: 
 - For c# language: C#, C# Dev Kit, .Net Install tool 

### SDK backend

Install .net framework 8.0, install the SDK version.

[.Net Framework 8.0 ](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)


### Docker and docker compose (Not mandatory)

Install docker and docker compose tool.
On linux don't need the desktop client, just the docker engine. 

[Docker and docker composer tool ](https://docs.docker.com/desktop/)

**Note:** This step is not mandatory but if docker is not installed, have to install the database manually and config port and connection string on appsettings in the project. 

### Instalation steps

The steps before has to be done before instalation steps.


**Clone repository:**

```
git clone https://github.com/repodi/net-test-01.git
```

Navigate to base folder, inside the cloned folder:

```
cd template/backend
```

**Build the project:** 

Try build the project using dotnet. 

Restore libraries
```
dotnet restore "./src/Ambev.DeveloperEvaluation.WebApi/Ambev.DeveloperEvaluation.WebApi.csproj"
```

Build
```
dotnet build "./src/Ambev.DeveloperEvaluation.WebApi/Ambev.DeveloperEvaluation.WebApi.csproj"
```

**Up Database:**

For up database (Postgre), the best way is use docker compose to up containers. 

Navigate to base folder, inside the cloned folder:

```
cd template/backend
```

Execute compose

```bash
docker compose up
```

Validate if the containers are successfully installed and are running:

Command
```bash
docker ps --format "table {{.ID}}\t{{.Names}}\t{{.Status}}"
```

or
```bash
docker container list
```

Result

```
CONTAINER ID   NAMES                                 STATUS
076ca49bceda   ambev_developer_evaluation_webapi     Up 8 minutes
5b1e4e48055d   ambev_developer_evaluation_database   Up 8 minutes
a873c42af8c9   ambev_developer_evaluation_cache      Up 8 minutes
bffc89fad8c7   ambev_developer_evaluation_nosql      Up 8 minutes
``` 

See [Containers](/.doc/tech-stack.md)


If the steps have been successfully completed, the next step is create structure and load data to database.
In this point run application will work, the api has connected but fails to write and read from database. 

**Create tables from database:**

To create tables from database is needed to execute entity framework migrations. 

If containers are running database are listening on port 32772, this port is exposed externally by docker, then can be reached on local machine. 

Navigate to base folder webapi, inside the cloned folder:

```
cd template/backend/src/Ambev.DeveloperEvaluation.WebApi
```

Execute migrations to update the database and create tables, and seed data:

```
dotnet ef database update
```

## Tech Stack
This section lists the key technologies used in the project, including the backend, testing, frontend, and database components. 

See [Tech Stack](/.doc/tech-stack.md)

## Project Structure
This section describes the overall structure and organization of the project files and directories. 

See [Project Structure](/.doc/project-structure.md)