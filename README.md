# IdentityServerSample
Sample ASP.NET Core  MVC app and API using Identity Server 4 and Entity Framework to store Identity tables (Users, Roles, UserRoles, UserClaims, UserLogins, etc) and Identity Server tables (Clients, ClientSecrets, PersistedGrants, IdentityResources, ApiResources, etc)

## Quick start

Just run F5, this will start the Identity Server on https://localhost:44367/, API on https://localhost:44374/ and Web App on https://localhost:44340/. <br/>
First run will initialize the database IdentityServerSample with all the tables and some sample data and Identity Server configuration data.<br/>
Go to Web App -> SignIn, this will redirect to Identity Server. Register if it's first time, accept consent and once logged in can access API resources.<br/>

## Diagram
<img src="https://github.com/alanmacgowan/alanmacgowan.github.io/blob/master/identityserverdiag.jpg" />
