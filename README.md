# Simple_Web_Shop_Using_ASP.NET

## PajoPhone
A simple web app project using ASP.NET.

## Overview
This is a practical interview question assigned to me at [IAIS](https://iais.ir/). I chose the MVC architecture to develop some kind of online Phone-shop (later, it may become an online shop for any kind of product). I'm leveraging the ASP.NET framework to learn C# and the framework alongside developing. I should note that this is nothing useful but a tutorial kind of project.

## Step-by-Step TODOs
You can see what I've supposed to do and what I've done in the section below:

### Main Tasks

1. [x] **Pre-requisite: learning the basics and setting up the environment**
    - [x] Learning the basics of C#:
        - Fortunately, I was familiar with Java and C. So there was nothing hard for me to struggle with. I used the [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/) for learning C#. I didn't go too deep since I found there's no limit to getting exact and deep. Hopefully, I'll read that deeply someday when I have the time or need to.
    - [x] Setting up the development environment: FUCK WINDOWS
        - As advised by my supervisor, since we need to use SQL Server, it was a good idea to start learning on Windows OS. As a good intern, I tried to follow his advice and started my work on Windows, installing .NET 8, ASP, Rider IDE, etc. It wasn't very bad at first, but when I tried to do some development on the project, I found it near impossible. How am I supposed to do well when there isn't even a good terminal for me? So I did my best, but no, there was no way I could get along with it and do well on Windows. So, as any human being with minimum IQ would do in this situation, I switched to Linux (Ubuntu, as I said, with minimum IQ), and here I am! Got rid of all the shitty Windows troubles. LONG LIVE OPEN SOFTWARE!
        - Installed .NET, ASP, Rider on Ubuntu, and checked everything is OK. I added a [GitHub repository](https://github.com/saamTheSoldier/Simple_Web_Shop_Using_ASP.NET) too. If you can't find it, maybe it's still private.
    - [x] Diving into ASP development:
        - First thing first, the Microsoft MVC web app using ASP.NET documentation is my main source of elementary learning. [Check it out](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-8.0&tabs=visual-studio).

          2. [x] **Phase 1: Implement the main structure of the online shop**
              - [x] Playing with the template:
                  - As I always say, playing with existing structures and messing around with things as amusement is the best way to learn (at least for me). Like when you've learned some mathematical concept, and to become more expert, there is no better way than thinking and solving many related problems. Same thing here. Time to do something real :))
              - [x] Adding Admin panel
                  - [x] Add Phone model
                    - For this I chose to go simple, even for Ids I didn't bother myself and used 
                    int and manually create them. Maybe when I add DB mechanism I change it to a 
                    proper auto Id generating method, for now my DB is a collection of models.
                  - [x] Add view-models for the list page, edit, and create pages
                    - It was not really necessarily. A simple List is my view model for main page of
                    admin panel and other pages simply handled in cshtml view files.
                  - [x] Add Controller for the admin page
                    - Done. But I have to admit sth. As I don't know shit about HTML not hard to tell
                    I don't know what I'm doing with cshtml files. So I use Chat-GPT for help, I hate to
                    use it when I'm about to learn and experience sth new, but what choice did I have??
                    But I ensure you I did my best to understand whatever been done on those shit page.
                      (mostly asked the GPT himself to explain it. Yes I'm guilty of using too modern tech.
                    May souls of great geeks forgive me). Next step would be adding mechanism to handle phone 
                    pictures, then implementing customer side, then struggling with EF and connect this
                    shit to a DB.
                  - [x] Implementing image file showing mechanism
                    - So I added some line of codes to show some pictures I downloaded from some Iranian
                    online shop, [Digikala](https://www.digikala.com/). First I added some Image path attribute
                    to the PhoneModel. Trying to show pictures saved as static files. At that point I realize that
                    the program identify the "~/" path as "/wwwwroot/". So I added a directory and successfully showed
                    pictures placed in that in some pages. Then I feel the need to upload pictures and even edit existing
                    pictures. Using the help of two of my best friends Google and GPT found out I can use IFormFile to handle
                    input file to upload. BTW I had hard time to finally find out I should add last part in this code:
                    ```csharp
                      @using (Html.BeginForm("CreatePost" , "AdminPanel", FormMethod.Post, new { enctype = "multipart/form-data" }))
                    ```
                    in the beginning of my view cshtml file. I mean the ```new { enctype = "multipart/form-data" }``` part. Somehow this
                    make your view able to handle IForm entities like uploaded files.
                    - After adjusting everything I think that this is not good enough, I want to serve files in 
                    what directory I desire. So asking my friends found out there is a way that is quite simple,
                    in configuration at Program.cs in my case, I should make a `staticFileOption` then use it to serve
                    files. So I moved my Image file location to somewhere else. There is much to do to make this
                    better, e.g. adding data validation, adding authentication and authorization etc. But let's make
                    it to a working point then we think about it.
              - [x] Implementing Customer side
                  - [x] Implement the basic structure for the shop page
                    - For this part I just apply some changes in HomeController and
                    its view. I added  a Detail page view that simply showing information of the selected
                    phone.
                  - [x] Add filter options and a search bar maybe?
                    - Not much difficult, add some input in the corresponded method in controller and
                    apply filters on the returning value according to passed input.
              - [x] Connect Project to a DB
                - This was quite a challenge for me. First I had to install proper packages (EF stuff) to handle DB queries
                and migrations etc. After that I added a class in Data directory called ApplicationDdContext. Then creating
                a DB in my postgresql server. I installed proper package for postgres in dotnet and add connection string to
                appsetting.json file and using it in Program.cs to configure connection. Soon I find out running 
                ```bash
                dotnet ef migrations add <migrations_name>
                ```
                I'm able to change DB schemes and create migration file (csharp) in Migration dir.
                also running
                ```bash
                dotnet ef database update
                ```
                will apply changes and send proper sql to my DBSM. I also had to change a few in my model specially
                when it comes to store images in db, changes in both controller and view parts was necessary. Well that was
                it. The phase 1 is done I think.

              - [x] Additional challenges:
                - [x] Filtering challenge:
                  - Besides to have regular price filtering, add an option to input a price(p) and a number(n), then show
                  nearest n product in price comparing to p.
                  - As other filters, not much different for this one, using Abs(target_price - price) for sort parameter
                  then taking n first elements.
                - [x] Selective Colors:
                  - For color attribute add this option to select it from a selectable field.
                  - Defined an enum for this purpose then the change was EF didn't apply proper changes automatically
                  to DB and I have to make changes by my own in the created Migration file, I chose to map each defined
                  color to integers but as you know we can define enum in postgres I think.
                - [x] Best type for defining price:
                  - There are double, decimal, int, float etc. types we can use for the numeric field such as price.
                  In case of Price, which one is better and why?
                  - First of all we should have floating points since price in real life normally has it. So int is
                  not the proper data type, among side the floating point enabled types the decimal cost more memory usage to
                  store but has this advantage avoiding rounding error. For finance material I think we hope to have no rounding error,
                  so it is obvious that decimal is the best choice for price field.
                - [x] Store images in the DB.
                  - Done. Storing it as Byte array.

### What is missing?
 -  The most important thing that we've missed so far is data validation and error handling.
    Don't trust the user or other apps that use your software. Or other developer in your team.
    Or your past version or feature version of yourself. Trust no one. No one will grantee to
    enter correct data types as input. Yes so sas but any way if you doesn't want your software
    to crash or misbehave or random behave always add data validation. But this would not be
    enough. We are not Gods unfortunately, and yes we may make mistakes or be careless about
    some scenarios. So has Error handling mechanism in your code.
 - Next Important feature I wish we had is Authentication and Authorization stuff. No need to
    give you speech about that importance. We should add model for users and mechanism for Auth.

### For Phase2 step by step report see the phase2_report.md file.

## Repository
You can find the full project repository at the following link:

[Project Repository](https://github.com/saamTheSoldier/Simple_Web_Shop_Using_ASP.NET)
