#  Flashcards
This repo consists of implementation of flashcards projects on different platforms and languages. The aim of these projects is to use the common project idea and implement using variety of technologies and frameworks in order to gain experience and build solid understanding.

# Projects
[Project 1 - Flashcards Mobile App: ReactNative](#user-content-project-1---flashcards-mobile-app-reactnative)

[Project 2 - Flashcards for Web: .NET Core 3.0 MVC, EF Core, SQL Server](#user-content-project-2-flashcards-for-web---implementation-using-net-core-30-mvc-ef-core-and-sql-server)

[Project 3 - Flashcards Restful APIs using .NET Core 3.0, EF Core, SQLite3](#user-content-project-3-flashcards-restful-apis---implementation-using-net-core-30-mvc-ef-core-and-sqlite-db)

# Project 1 - Flashcards Mobile App: ReactNative
## Foldername: mobile-flashcards-reactnative
This is the 3rd Project as part of Udacity React Nanodegree. It is about creating a React Native app for Mobile flashcards. 
App is designed with a purpose to help students to prepare for exams via creating flashcards and quizzing themselves. 
App can create and hold multiple decks of different cards.

## How to run the project
- Clone the project to your local
- cd to your root directory of the project
- run `npm install`
- run `npm start`
- if you want to run on physical device, then just scan the QR code using the phone camera. make sure you have installed latest version of expo from the app store

## Testing
This project is tested using iPhone 6 Plus and also with iPhone 10 simulator.

## Skills used
- JavaScript / ES6
- React
- Redux
- React Native & Expo
- Working with mobile device & debugging

## Screenshots

|  <img src="https://github.com/dilipagheda/flashcards/blob/master/mobile-flashcards-reactnative/screenshots/IMG_1951.PNG" width=300 height=500 /> |  <img src="https://github.com/dilipagheda/flashcards/blob/master/mobile-flashcards-reactnative/screenshots/IMG_1953.PNG" width=300 height=500 /> |
  <img src="https://github.com/dilipagheda/flashcards/blob/master/mobile-flashcards-reactnative/screenshots/IMG_1954.PNG" width=300 height=500 /> |
  <img src="https://github.com/dilipagheda/flashcards/blob/master/mobile-flashcards-reactnative/screenshots/IMG_1955.PNG" width=300 height=500 /> |
  <img src="https://github.com/dilipagheda/flashcards/blob/master/mobile-flashcards-reactnative/screenshots/IMG_1956.PNG" width=300 height=500 /> |
  <img src="https://github.com/dilipagheda/flashcards/blob/master/mobile-flashcards-reactnative/screenshots/IMG_1957.PNG" width=300 height=500 /> |
  <img src="https://github.com/dilipagheda/flashcards/blob/master/mobile-flashcards-reactnative/screenshots/IMG_1958.PNG" width=300 height=500 /> |

# Project-2: Flashcards for Web - Implementation using .NET Core 3.0 MVC, EF Core and SQL Server
## Foldername: web-flashcards-dotnet-mvc
This project is the web implementation of Flashcards using .NET Core 3.0 MVC. It uses MVC pattern and generates pages through Razor templating engine. The project has two implementations of DbContext. a) In Memory and b) SQL Server. Simply, switching the object in Dependancy injection container will make it use either of it.

## How to run this project
- You need to install VS studio, SQL server and .NET Core Runtime as a pre-requisite
- Once Installed, simply open the project and run it by pressing 'play' button in VS Studio
- From command line, you can run `dotnet watch run` to run the project using Krestrel web server.

More detailed instructions are on Wiki
https://github.com/dilipagheda/flashcards/wiki/How-to-Run-the-.Net-Core-Web-application

If you are on MacOS, Try VS Studio for MAC. It's amazing. For SQL server on MAC, refer to this article: 
https://www.quackit.com/sql_server/mac/install_sql_server_on_a_mac.cfm

## Skills used
- .NET Core 3.0 MVC
- C#
- Entity Framework Core
- SQL Server
- Dependancy Injection
- Razor Views and MVC pattern
- HTML/CSS/JS/Bootstrap/jQuery

## Testing
- Unit Testing is done through xUnit
- E2E Testing is done through Cypress

## Screenshots

### Login screen
<img src="https://github.com/dilipagheda/flashcards/blob/master/screenshots/mvc/login.png"/> 

### Login screen - login failed
<img src="https://github.com/dilipagheda/flashcards/blob/master/screenshots/mvc/loginerror1.png" /> 

### Login screen - mandatory fields
<img src="https://github.com/dilipagheda/flashcards/blob/master/screenshots/mvc/loginerror2.png" /> 

### Add New Deck
<img src="https://github.com/dilipagheda/flashcards/blob/master/screenshots/mvc/adddeck.png"  /> 

### Add New Card to a given deck
<img src="https://github.com/dilipagheda/flashcards/blob/master/screenshots/mvc/addnewcard.png"  /> 

### Deck Detail View
<img src="https://github.com/dilipagheda/flashcards/blob/master/screenshots/mvc/deckdetail.png" w /> 

### Home page - Shows list of Decks
<img src="https://github.com/dilipagheda/flashcards/blob/master/screenshots/mvc/home.png"  /> 

### Quiz page - User quizes based on a card in a deck - Implemented in client side JavaScript
<img src="https://github.com/dilipagheda/flashcards/blob/master/screenshots/mvc/quiz.png"  /> 

### Quiz Result page
<img src="https://github.com/dilipagheda/flashcards/blob/master/screenshots/mvc/quizresult.png"  /> 


# Project-3: Flashcards Restful APIs - Implementation using .NET Core 3.0 MVC, EF Core and SQLite Db
## Foldername: api-flashcards-dotnet
The aim of this project is to build Restful APIs using .NET Core 3.0 MVC, EF Core and SQLite Db. It is using standard pattern of MVC using .Net Core 3.0.

Postman collection is also included in the project for running locally.

At the moment, there are below APIs.
- POST /user/login
  Returns JWT token if user is valid
  
- POST /user/register
  Creates the user in database
  
- GET /decks
  
  get all decks
  
- POST /decks
  
  create new deck. it supports only one deck at a  time.
  
- GET /decks/{id}
  
  get a deck by deckId
  
- POST /decks/{id}/cards
  
  create a new card for a specific deck
  
- GET /decks/{id}/cards
  
  get all cards for a specific deck
  
- GET /decks/{id}/Cards/{id}
  
  get a specific card for a specific deck

## How to run this project
- You need to install VS studio, SQLite3 and .NET Core Runtime as a pre-requisite
- Once Installed, simply open the project and run it by pressing 'play' button in VS Studio
- From command line, you can run `dotnet watch run` to run the project using Krestrel web server.

## Skills used
- .NET Core 3.0 MVC
- Authentication & Authorisation with Cookie Based Authentication in Web App and JWT token based in API
- C#
- Entity Framework Core
- SQLite3
- Dependancy Injection
- Automapper
- xUnit
- Integration testing using In-memory localhost and db

## Screenshots

<img src="https://github.com/dilipagheda/flashcards/blob/master/screenshots/api/1.png"  /> 

<img src="https://github.com/dilipagheda/flashcards/blob/master/screenshots/api/2.png"  /> 

<img src="https://github.com/dilipagheda/flashcards/blob/master/screenshots/api/3.png"  /> 


