My Just Eat Testing
==================================

Thank you for getting there.

This is a guidance for publishing my just eat testing sites. 

This application has been developed by using .NET Framework 4.5.1, MVC, WebApi and AngularJS.

I also applied TDD during the development process.

## Prerequisite

* .NET Framework 4.5.1
* IIS 7
* Visual Studio 2015 
* Web Server

Please refer to the following link https://www.asp.net/mvc/overview/deployment/visual-studio-web-deployment/deploying-to-iis

### Set up IIS Website 



In order to run my just eat testing (jet) sucessfully, please follow the below steps

1. Clone my jet from https://github.com/doantranthanh/GoRinnoSho.git
2. Add the new local host name to hosts file, for i.e 
   127.0.0.1       gorinnosho.jet 
3. Add a new web site in IIS v7 named for i.e gorinnosho.jet
4. Change the new application pools which is for i.e gorinnosho.jet from .NET Framwork v2. to .NET Framework v4
5. On new web site in IIS, binding the physical path to my published JET.Web location (clone from git in step 1).
6. On new web site in IIS, creating a new application and named it as justeatapi (the application name must be justeatapi). 
After that binding the physical path to my published JET.WebApi location (clone from git in step 1).
7. Create a self-signed certificate and name it as gorinnosho.jet
8. On gorinnosho.jet website in IIS, adding https site bindings with gorinnosho.jet SSL certificate and port 449 (or any port you want).
9. Restart IIS.

Then enjoy my jet.

####Thanks for your time

