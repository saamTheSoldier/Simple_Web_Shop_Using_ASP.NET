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

2. [ ] **Phase 1: Implement the main structure of the online shop**
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
    - [ ] Implementing Customer side
        - [ ] Implement the basic structure for the shop page
        - [ ] Add filter options and a search bar maybe?
    - [ ] Connect Project to a DB

    - [ ] Additional challenges:
      - [ ] Filtering challenge:
        - Besides to have regular price filtering, add an option to input a price(p) and a number(n), then show
        nearest n product in price comparing to p.
      - [ ] Selective Colors:
        - For color attribute add this option to select it from a selectable field.
      - [ ] Best type for defining price:
        - There are double, decimal, int, float etc. types we can use for the numeric field such as price.
        In case of Price, which one is better and why?
      - [x] Store images in the DB.

3. [ ] **Phase 2: Make the web app more general**
    - [ ] Design the features and complete this file :_))

## Repository
You can find the full project repository at the following link:

[Project Repository](https://github.com/saamTheSoldier/Simple_Web_Shop_Using_ASP.NET)
