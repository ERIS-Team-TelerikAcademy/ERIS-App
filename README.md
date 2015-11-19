# ERIS-App
Teamwork project for the course "Web services & cloud" 2015 @ TelerikAcademy.

## Description 
The idea behind our application is to serve as a social network for "special" services. The network has two types of user: a hitman or a client.

- Hitmen offer their services to clients via *contracts*.
- Client chooses a hitman and sends a contract offer.
- Once the hitman approves the contract the additional information is discussed in chat.
- When the contract is successful (or not), the client will be given the opportunity to rate the respective hitman.

## Documentation

### Endpoints table

| Endpoint | Method | Parameters                                                   | Explanation                                                                         
|------------|--------|--------------------------------------------------------------|-------------------------------------------------------------------------------------
| api/Account/Register | POST | `RegisterBindingModel` | Registers a user based on the sent model.
| api/Account/UserInfo | GET | Requires OAuth bearer token | Returns a `UserInfoViewModel` object.
| api/Account/Logout | POST | Requires OAuth bearer token | Logs out the current user.
| api/Account/ChangePassword | POST | Requires OAuth bearer token | Changes the password of the authenticated user.
| api/Contracts/all | GET | - | Returns a `ContractResponseModel` projection of all contracts in the database
| api/Contracts/{contractId} | GET | `contractId` - the id of the contract to retrieve | Returns a `ContractResponseModel`
| api/Contracts/all-for-client/{userId} | `userId` - the id of the client whose contracts are to be retrieved |GET | Returns a list of `ContractResponseModel`
| api/Contracts/all-for-hitman/{userId} | `userId` - the id of the hitman whose contracts are to be retrieved | GET | Returns a list of `ContractResponseModel`
| api/Contracts/new-contract | POST | `ContractResponseModel` in the body of the request | Registers a new contract via a `ContractResponseModel`
| api/Contracts/approve-contract | PUT | `ContractResponseModel` in the body of the request | Updates a contract and returns the id of the updated contract
| api/Countries | GET | - | Returns a list of `CountryResponseModel` projections from the countries in the database
| api/Images          | GET    | –                                                            | Returns a list of `ImageResponseModel` objects.                        
| api/Images/{userId} | GET    | `userId` - the id of the user whose image is to be retrieved | Returns a list of `ImageResponseModel` objects for the user with id `userId`. 
| api/Images/{userId} | POST   | `userId` - the id of the user whose image is to be uploaded  | Saves an `ImageRequestModel` object to Dropbox, linking it to SQL server.          
| api/Images/{imageId}| DELETE | `imageId` - the id of the image to be deleted | Deletes the image with id `imageId` from both SQL server and Dropbox.
| api/Ratings/{hitmanId} | GET | `hitmanId` - the id of the hitman whose ratings to fetch | Returns a collection of `UserRatingResponseModel` projections
| api/Ratings/rate | POST | `UserRatingResponseModel` in the body of the request | Adds a new rating and returns its id
### Class diagrams

![Class diagram](http://puu.sh/lrBij/b1c248857d.png)

### Participants

- Boris Stoyanov ([GitHub](https://github.com/TemplarRei), [TelerikAcademy](http://telerikacademy.com/Users/borisstoyanovv))
  - Web API controllers
  - Web API response models
  - Automapper integration
  - Services
- Ivaylo Arnaudov ([GitHub](https://github.com/arnaudoff), [TelerikAcademy](http://telerikacademy.com/Users/ivaylo.arnaudov))
  - Web API controllers
  - Web API response models
  - Cloud storage (a service and controller for uploading and downloading Dropbox images)
  - Services
- Ivaylo Rankov ([GitHub](https://github.com/Ivorankov), [TelerikAcademy](http://telerikacademy.com/Users/ivo.rankov.7))
  - WPF client
  - Database
  - Web API user management
  - Services
- Stella Valcheva ([GitHub](https://github.com/stellaval), [TelerikAcademy](http://telerikacademy.com/Users/stellaval))
  - Azure deployment
  - Ninject integration
- Toma Nikolov ([GitHub](https://github.com/TomaNikolov), [TelerikAcademy](http://telerikacademy.com/Users/tomasaa))
  - JavaScript web client
