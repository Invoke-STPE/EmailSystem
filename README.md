# EmailSystem
A small project for my self-chosen learning class, where I'm gonna utilies Dependency Injection and Appsettings.json.


## Introduction
Sadly I only had a week to play around with this project, I might revisit in the future and the project is quite in-complete.
However I did get quite a bit of knowledge out of it. Most noticeable I learned how to decouple Entity Framework from the application layer.
Also I did not have the time to play around a lot with appsettings.json, my original thought was to have a regret button, where you could pull back your email.
However I might implement that if I ever get the time to revisit.


## Features
 - You can register and login, this is provided by the default identity individual accounts.
 - Get an overview of your emails.
 - See full details of a selected email.
 - Sadly I only had time to add an reply button.


### Knowledge gained.
 - EntityFramework
    - How to decouple EF core, by extending IServiceCollection.
    - Best pratice for configuring Entities, more specific by implementing IEntityTypeConfiguration<>
    - Some use cases for using fluent API, instead of Attributes as I have been used too.
 - Domain
    - Moving interfaces and Models to a Domain project, is a great way to decouple dependencies.
 - Unit testing.
    - How to make use of InMemoryDatabase to unit test in EF, still not happy about the approach, but I don't really see a better option.
 - Identity
    - How to extend the default IdentityUser class with your own properties.
