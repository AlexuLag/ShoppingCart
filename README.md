# Shopping cart for practice purposes

In this repository you will find the implementation of a basic shopping cart using,.net 8.0 as backend framework and react with vite for frontend 

## Backend libraries

#### MediatR
#### FluentValidator
#### Entity Framework core
#### AutoMapper

## Front End libraries

#### React
#### MobX
#### Formik
#### Axios
#### Semantic UI React

This project uses Vite, and sqlserver as Database

## Steps to execute the application:


create a blank database with name test, (with more time we can use a docker image to download sql server )

inside api folder run:

dotnet run

inside clientApp  folder run: 

npm update
npm run vite


This project use entity framework migrations for create database objects and seed data.
you can refer to seed class in Persistence Project to see how migration works

TO DO:

Implement login feature using asp identity.
add a product functionality to upload products and create stock for each product, also upload images (cloudinary or other service) to storage product image

implement de checkout functionality to create the order
implement local storage to persist sesion while user play with shopping cart without doing a process order
CQRS and mediator pattern maybe is not the best option for manage the application and domain, it was implemented just for demo purposes


The ER Diagram could be found int the root foolder asn SHopingCartER.png
if you want to use SQL scripts to create database and seed it, you can also use DatabaseExport.sql












