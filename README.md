# IdentityServerSample
Sample ASP.NET Core  MVC app, Angular and API using Identity Server 4 and Entity Framework to store Identity tables (Users, Roles, UserRoles, UserClaims, UserLogins, etc) and Identity Server tables (Clients, ClientSecrets, PersistedGrants, IdentityResources, ApiResources, etc)

## Quick start

Just run F5, this will start the Identity Server on https://localhost:44367/, API on https://localhost:44374/, Angular app on https://localhost:44398/ and Web App on https://localhost:44340/. <br/>
First run will initialize the database IdentityServerSample with all the tables and some sample data and Identity Server configuration data.<br/>
Go to Web App -> SignIn, this will redirect to Identity Server. Register if it's first time, accept consent and once logged in can access API resources.<br/>

## Diagram
<img src="https://github.com/alanmacgowan/alanmacgowan.github.io/blob/b4632e3402fd6ae591eaca50493bc289250c2901/identityserverdiagram.jpg" />

## Scenarios Covered

* User Authentication (WebApp)
* User Authentication (AngularApp)
* User Authentication from javascript (oidc-client.js)
* User Authentication with 3rd party provider (Google)
* Call API from C# (WebApp)
* Call API from javascript (WebApp)
* Call API from Angular (AngularApp)
* Long lived API access using refresh tokens (allow requesting new access tokens without user interaction)

## Steps

```
1 - IdentityServer config:

(Config.cs)
    a. Clients:
        i.  MVC application (HybridClientCredentials) ["mvc"]
        ii. SPA application (Implicit) ["Spa"]
    b. Resources:
        i.  Identity (OpenId, Profile)
        ii. Api ["api1"]

(Startup.cs)
    a. AddIdentity
    b. AddIdentityServer
          AddDeveloperSigningCredential
          AddAspNetIdentity
          AddConfigurationStore
          AddOperationalStore
    c. AddAuthentication
          AddGoogle
    
2 - MVC application config:

(Startup.cs)
    a. AddAuthentication
          AddCookie
          AddOpenIdConnect
                          
3 - API config:

(Startup.cs)
    a. AddAuthentication
          AddJwtBearer
    b. AddAuthorization
    c. AddCors     
          
```

## Useful Resources

### Identity Server

* http://identityserver.io/
* https://brockallen.com/
* https://www.scottbrady91.com/Identity-Server/Getting-Started-with-IdentityServer-4
* https://medium.com/@robert.broeckelmann
* https://elanderson.net/2017/05/identity-server-introduction/

### JWT

* https://jwt.io/
* https://medium.com/vandium-software/5-easy-steps-to-understanding-json-web-tokens-jwt-1164c0adfcec
* https://auth0.com/learn/json-web-tokens/
* https://auth0.com/blog/ten-things-you-should-know-about-tokens-and-cookies/

### Pluralsight Courses

* https://app.pluralsight.com/library/courses/asp-dot-net-core-oauth
* https://app.pluralsight.com/library/courses/oauth2-json-web-tokens-openid-connect-introduction
* https://app.pluralsight.com/library/courses/aspnet-core-identity-management-playbook
* https://app.pluralsight.com/library/courses/asp-dotnet-core-oauth2-openid-connect-securing
* https://app.pluralsight.com/library/courses/asp-dot-net-core-security-understanding
