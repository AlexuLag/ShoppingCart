# Shopping cart for practice purposes


This project was bootstrapped with [Vite](https://vitejs.dev/).

In this repository you will find the implementation of a basic shopping cart using,.net 8.0 as backend framework and react with vite for frontend 

## Backend libraries

#### MediatR
#### FluentValidator
#### Entity Framework core
#### AutoMapper

## Front End libraries

#### React
#### MobX
#### Axios
#### Semantic UI React

This project uses Vite, and sqlserver as Database

## Steps to execute the application:


create a blank database with name test, (with more time we can use a docker image to download sql server )

inside api folder run command:

### `dotnet run`

inside clientApp  folder run command: 

### `npm update`
### `npm run vite`


This project use entity framework migrations for create database objects and seed data.
you can refer to seed class in Persistence Project to see how migration works.
The ER Diagram could be found in the root folder asn SHopingCartER.png
If you want to use SQL scripts to create database and seed it, you can also use DatabaseExport.sql



### `TODO:`

Implement login feature using asp identity.

Implement jwt token validation on each controller endpoint integrated with the login feature.

Add a product functionality to upload products and create stock for each product, also upload images (cloudinary or other service) to storage product image
Add realtime comunication with signal-r, and some message queue like rabbit, to allow users get updates from the server live during order preparation to lock products before taking an order.
Add a mapping profile to allow entity framework to save directly an order with a projection from orderDto

CQRS and mediator pattern may not be the best option for manage the  flow between application and controllers, it was implemented just for demo purposes.













