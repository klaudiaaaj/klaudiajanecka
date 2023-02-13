# Inspections Application

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [External Services](#external-services)
* [Setup](#setup)
* [External Functions](#external-functions)

# General info
Inspections Application is an application made to provide the functionality for inspectors performing controle in company.   
Authors:   
*Klaudia Janecka   
*Jakub Wojciechowski  

# Technologies
Project is created with:
* .NET 6.0
*  Angular 14.2
*  Entity framework 7.0
*  Bootstrap 5
# External services 
* Swagger - open-source software framework for creating, building, and documenting RESTful APIs.
* OAuth 2.0 with google - open-standard authorization protocol that is widely used for allowing users to grant limited access to their protected resources, such as their Google account, without having to reveal their credentials.
* Google AdSense  - program offered by Google that allows website owners to earn money by displaying ads on their websites. With AdSense, website owners can place ad code on their website and Google will display relevant ads based on the content of the website. When a user clicks on one of the ads, the website owner earns a portion of the revenue generated from the click.
# Setup
## Web Client
To run this project, install it locally using npm:

```
$ cd ..\InspectionAPIApp\InspectionsWeb\inspection-web
$ npm install
$ ng serve
```
Application will be opened at the *[PATH](Http://localhost:4200)*


## Web API
```
To run this project, open console  
$ cd ..\InspectionAPIApp\InspectionsWeb
$ dotnet run
```
# Patterns 
## Model-View-Controller (MVC) 
 This pattern separates the application into three main components: the model, which represents the data and the business logic; the view, which is responsible for presenting the data to the user; and the controller, which acts as a bridge between the model and the view. In Angular, the controller is replaced by a component, which is a class that encapsulates the view and the logic required to manage it.

# External Functions

For the inspectors are provided with functionality to 
 * Add inspection pop up window
 
![alt-text-1](https://user-images.githubusercontent.com/56549544/218431454-9f1ee491-607d-478d-8f48-2af3e3485fdc.png)   
with autocomplete for Status and Inspection Type 

![image](https://user-images.githubusercontent.com/56549544/218459563-056000a2-883d-4173-bc14-f349ea7a2aef.png)

![image](https://user-images.githubusercontent.com/56549544/218459508-366386f9-209e-402c-af4f-4e8fb462bada.png)

* List of current inspections  

![alt-text-1](https://user-images.githubusercontent.com/56549544/218433932-99a1e2c8-5768-4df5-94d4-4d5e7ad2db42.png)  
 
* Edit inspection option with pop up window

![alt-text-1](https://user-images.githubusercontent.com/56549544/218434047-b046d1f3-745a-4d48-81ba-85cc9809d8b7.png)  

![image](https://user-images.githubusercontent.com/56549544/218459322-2fc028b4-02d5-494a-9288-c34a1aedeadc.png)


* Delete inspection option 

![image](https://user-images.githubusercontent.com/56549544/218459201-2c5361a8-6f60-4124-9802-4a484fbae245.png)
