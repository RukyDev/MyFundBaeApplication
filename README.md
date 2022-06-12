# MyFundBaeApplication
List of EndPoint and there payload

1.) api/AccountCreation/CreatAccount
{
  "accountName": "string",
  "customerId": 0
}
NOTE: Account Number is auto generated in the system.

2.)/api/AccountCreation/GetAllAccounts

Note: This will only be visible to system admin. This end point return list of all accounts in the system.

3.) /api/AccountCreation/UpdateAccount
{
  "accountName": "string",
  "customerId": 0
}

Note: This endpoint is for cutomer to update their

4.) ​/api​/AccountCreation​/FundAccount
{
  "accountNumber": "string",
  "amount": 0
}
Note: EndPoint For Customer to fund there account

5.) /api/AccountCreation/WithDrawFund
{
  "accountNumber": "string",
  "amount": 0
}
Note: endPoint for customer to withral funds from there account

6.) ​/api​/AccountCreation​/DeletAccount​/{AccountName}
Note: EndPoint to delete a particular account. it accept a parameter of the account name to be deleted

7.) /api/CustomerCreation/SignUp
{
  "id": 0,
  "firstName": "string",
  "lastName": "string",
  "email": "user@example.com",
  "passWord": "string",
  "confirmPassword": "string",
  "stateOfOrigin": "string",
  "lga": "string"
}

Note: EndPoint For Customer Creation

8.)/api/CustomerCreation/Login
{
  "email": "user@example.com",
  "passWord": "string"
}

Note: EndPoint For customers to loginto their account

9.) /api/CustomerCreation/GetUsers

Note: This EndPoint Return List of All customers in the system

10.) /api/CustomerCreation/UpdateUser
{
  "id": 0,
  "firstName": "string",
  "lastName": "string",
  "email": "user@example.com",
  "passWord": "string",
  "confirmPassword": "string",
  "stateOfOrigin": "string",
  "lga": "string"
}

Note: This EndPoint Enable Customer Update there profiles

Procedure to setup the project on local machine.

1. pull the project from github
2. Open With Visual Studio
3. Configure your connectionString using your database credentials
4. Run the application.

List of Tables
1. Account Table
2. ApplicationUser Table (signUp/Customer)

