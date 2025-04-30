namespace Ambev.DeveloperEvaluation.Domain.Enums;

public enum UserRole
{
    None = 0,
    Customer,   // represents a customer who can make sales purchase order , can create user with customer role (fixed cusomer id)   
    Manager,    // represents an enterprise employee who can complete sales and list sales by branch or not, can create user with customer or branch roles 
    Admin,      // represents a enterprise employee with priviligied access can alter discounts and create new users
    Branch      // represents a branch employee who can complete sales and list sales by branch (only directed to this branch), can create user with customer role
}