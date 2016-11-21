# Technical questions

Please answer the following questions in a markdown file called `Answers to technical questions.md`.

1. How long did you spend on the coding test? What would you add to your solution if you had more time? If you didn't spend much time on the coding test then use this as an opportunity to explain what you would add.
2. What was the most useful feature that was added to the latest version of your chosen language? Please include a snippet of code that shows how you've used it.
3. How would you track down a performance issue in production? Have you ever had to do this?
4. How would you improve the JUST EAT APIs that you just used?
5. Please describe yourself using JSON.

# Technical anwsers

## Question 1

* How long did you spend on the coding test?

This is a Single Page Application developed by using MVC framework, Angular JS, and Web Api. It has been built and developed by applying TDD. Therefore, I have spent 3 days and a half on the coding test. I have tried my best to finish that so I spent my spare time (lunch time, weekend) to work on that. You can see its history from my personal github which is at  https://github.com/doantranthanh/GoRinnoSho
  
* What would you add to your solution if you had more time?

If I had more time, I would add the following features to my solution.

First of all, I will intergrated the Google Maps APIs (https://developers.google.com/maps/) to the front-end which will be used for searching the location of restaurants. 
I have used and applied Google Maps APIs to our website which you can access to the following url https://www.xlntelecom.co.uk/wi-fi/hotspot. So in the frontend I will create
a button called Locate Restaurant next to the . That button will pickup the full address of the restaurant and copies to Search Location bar and return the location of the 
restaurant.

Secondly, I will not use Web API in order to call a request to your public API. I will implement microservice apps which will be used to make a request 
and return the result. Basically, there will be 2 console applications which use RabbitMq to communictate to your public API and my web application.
For example, when user provides postcode and submit the form. A Http request will be made from front-end to web api project. My Web Api project will send a message to 
a console application which will send a http request to your public API. The returned result will be sent as a message back to the Web Api, the Web Api will listen to 
the returned message then consumes that message and return the list of restaurants. The list of restaurant will be display on the page. The reason I want to add this feature because
I want to build a microservice system for my application. That would be better if I can build an application by using ASP.NET Core and bring it to the cloud which is AWS that I am learning.

And finally, I will make the front-end look better and implement the Responsive Web Design, which I use a lot in daily work, to the application.

* If you didn't spend much time on the coding test then use this as an opportunity to explain what you would add.


## Question 2

* What was the most useful feature that was added to the latest version of your chosen language? 

I am using C# at this moment. Also, we are trying to use Microservices and APS.NET core for our projects.  

In terms of C#, there are plenty of new features in the lastest version of C# 6.0 such as 
	+) Null-Conditional Operator
	+) Auto-Property Initializers
	+) Nameof Expressions
	+) Primary Constructors
	+) Expression Bodied Functions and Properties
but for me, I think one of the most important feature comes from C# 5.0 which is Async Feature with two key words async and await. 
I am using that feature a lot in our backend application.

In terms of framework, ASP .NET Core brings a new open-source and cross-platform framework for apps that are built in Microservices Architecture 
and are deployed to the clound or run on-premises. Although, ASP.NET Core is still being developed and not yet mature but I belive it will introduce
a significal redesign of ASP.NET and will be a future framework for building modern cloud application.

## Question 3

* How would you track down a performance issue in production? 

* Have you ever had to do this?

## Question 4 

* How would you improve the JUST EAT APIs that you just used

## Question 5

* Please describe yourself using JSON.