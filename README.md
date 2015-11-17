# ERIS-App
Teamwork project for the course "Web services & cloud" 2015 @ TelerikAcademy.

## Description 
The idea behind our application is to server as a social network for "special" services. The network has two types of user: a hitman or a client.

- Hitmen offer their services to clients via *contracts*.
- Client chooses a hitman and sends a contract offer.
- Once the hitman approves the contract the additional information is discussed in chat.
- When the contract is successful (or not), the client will be given the opportunity to rate the respective hitman.

## Documentation

### Endpoints table

| Endpoint   | Location                                | Method | Parameters                                                   | Explanation                                                                         | Response format |
|------------|-----------------------------------------|--------|--------------------------------------------------------------|-------------------------------------------------------------------------------------|-----------------|
| api/Images | http://{url}:{port}/api/Images          | GET    | –                                                            | Returns a list of images with an id for the respective user.                        | XML/JSON        |
| api/Images | http://{url}:{port}/api/Images/{userId} | GET    | `userId` - the id of the user whose image is to be retrieved | Returns a base64-encoded string which is the image for the   user with id `userId`. | XML/JSON        |
| api/Images | http://{url}:{port}/api/Images/{userId} | POST   | `userId` - the id of the user whose image is to be uploaded  | Saves an `ImageResponseModel` object to Dropbox, linking it to   SQL server.          | XML/JSON        |

### Class diagrams

TODO

### Participants

- Boris Stoyanov ([GitHub](https://github.com/TemplarRei), [TelerikAcademy](http://telerikacademy.com/Users/borisstoyanovv))
  - Web API controllers
  - Web API response models
  - Automapper integration
  - Services
- Ivaylo Arnaudov ([GitHub](https://github.com/arnaudoff), [TelerikAcademy](http://telerikacademy.com/Users/ivaylo.arnaudov))
  - Cloud storage (a service and controller for uploading and downloading Dropbox images)
  - Services
- Ivaylo Rankov ([GitHub](https://github.com/Ivorankov), [TelerikAcademy](http://telerikacademy.com/Users/ivo.rankov.7))
  - WPF client
  - Datebase
  - Web API user management
  - Services
- Stella Valcheva ([GitHub](https://github.com/stellaval), [TelerikAcademy](http://telerikacademy.com/Users/stellaval))
  - Azure deployment
  - Ninject integration
- Toma Nikolov ([GitHub](https://github.com/TomaNikolov), [TelerikAcademy](http://telerikacademy.com/Users/tomasaa))
  - JavaScript web client
