# ERIS-App
A Telerik Academy team proejct

Web Chat Application

Description:

The Chat App has the following features: 
There are Users with profiles, who can write Posts or Upload Images, Chat with Friends (send messages), Send files to Friends. 
The User Profiles contain information about the user, his/her Profile Picture, his/her Friends and Posts.

How it works?
The user registers and logs in. He/she then sees the individual PostsWall that shows all friends' posts.
The logged in user can see his/her own profile, the profiles of friends and also to search for new Friends and send them Friend Request.
When the Friend Request is approved, there is a new Friendship and the new Friend is added to both Users' friendsList.
Then they can start a chat and send files.

Models:

Users Profiles 
  Information about the User
  Profile Picture
  Friends
  Posts
  
Profile Pictures / or Uploaded Pictures and attribute isProfilePicture??
  Content / File
  User
  
Posts
  Content (can also be file or picture)
  User
  Date
  
Friendships
  First User
  Second User
  Approved
  Date Approval
  Messages
  Files ???
  
Chat Message
  Friendship
  Author (User from the Friendship)
  Content

File ???
  Friendship
  Author
  File/content
  
 ## Proposal model:
  
  Hitman profile:
                 Nickname,
                 RegionsOfOperation (collection of - >eg. Europe/USA..),
                 MurderMethods(eg. Firearm/Poison/Strangling)
                 MurderCount,
                 BitCoinAccountInfo,
                 Images: of weapons or idk dead ppl whatever the hitman wants,
                 Rating
  
  Customer profile:
                 Nickname,
                 Rating
              
  Hitmen can rate customers and vise versa             
                
  Connection:(Like Friendships only its one way -> Customer sends con requiest to Hitman)
            CustomerId,
            HitmanId,
            Deadline,
            Price
            
  Image:
  
  RegionOfOperation: Continents maybe countries aswell
  
  MurderMethod:
  
  Rating: 0-5 star probably
  
  
  

Requirements for the RESTful API

1.Use **ASP.NET WebAPI**
2.Provide a RESTful API: CRUD operations: **POST, GET, PUT and DELETE**
3.Use **Azure**
4.Use a file storage cloud API: Dropbox, Google Drive
5.Use a cloud-based database: **MS SQL**
6.Implement notifications functionality or message queues: PubNub
7.Add Unit and/or integration tests

Requirements for the client application

*Web SPA application using JavaScript
*Windows desktop application using WPF, Windows Forms or the console

Additional Requirements

  Follow the best practices for OO design and High-quality code
  Use a GitHub for source control system
  
Deliverables
  ZIP archive: source code, documentation
  
Demonstrate:
  The application, class diagram, source code, commits
