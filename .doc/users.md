[Back to README](../README.md)

### Users
All users preloaded has the same password, the login proccess is email and password

Password: 
```
ev@luAt10n
```

| user / email              | password    | profile       | branch      | customer  |
| -------------             |------------ | ------------- | --------    | --------- |
| developer@mail.com        | ev@luAt10n  | admin         |             |           |
| admin@mail.com            | ev@luAt10n  | admin         |             |           |
| manager@mail.com          | ev@luAt10n  | manager       |             |           |
| branch1user1@mail.com     | ev@luAt10n  | branch        | branch1     |           |
| branch1user2@mail.com     | ev@luAt10n  | branch        | branch1     |           |
| branch2user1@mail.com     | ev@luAt10n  | branch        | branch2     |           |
| customer1user1@mail.com   | ev@luAt10n  | customer      |             | customer1 |
| customer1user2@mail.com   | ev@luAt10n  | customer      |             | customer1 |
| customer2user1@mail.com   | ev@luAt10n  | customer      |             | customer2 |
| customer3user1@mail.com   | ev@luAt10n  | customer      |             | customer3 |


### Users x profiles

There are 4 different types of users who access the system (profile):

- Customer: represents a customer who can make sales purchase order , can create user with customer role (fixed cusomer id)

- Branch: represents a branch employee who can complete sales and list sales by branch (only directed to this branch), can create user with customer role

- Manager: represents an enterprise employee who can complete sales and list sales by branch or not, can create user with customer or branch roles 

- Admin: represents a enterprise employee with priviligied access can alter discounts and create new users

#### customer role 

- represents a customer who can make and view purchase orders, only viewing what is the customer's own

- can create new users for access with a customer profile and a fixed customer ID

- is the lowest level of access

#### branch role 

- he manager works at the branch level, 
he is an employee with a higher level of access within the branch

- in addition to the permissions of the branch profile, he can also create new users with branch and manager profiles

#### admin role 

- This profile has the highest level of access

- has access to all customers and all branches

- It has the permissions of all other profiles

- It can create new administrator users