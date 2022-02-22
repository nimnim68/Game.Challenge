# Game.Challenge
Test for Game Server Engineer

gamigo group

Implement a User Profile API

The Brief

Our product owner has just brought us a project to create a new profile page for the players
of our games. Your responsibility is to design and implement a new microservice with a
RESTful API to serve data to the new profile page. Write it in C# .net and make sure it can be
run locally for testing.
Players want to view the following information in their profile:
• Username
• First Name
• Last Name
• Address (Line 1, Line 2, Line 3, City, Zipcode/Postcode, Country)
• Email
• List of Games that the user is playing with the most recent game played first and
oldest game last. For each game we will need the following info:
o Game ID
o Game Name
o Link to thumbnail image
o When originally registered
o When last played
o Game state (eg. Active, Banned etc)
Players would also like to modify the following information:
• Full Name
• Address
• Email
In addition, our internal customer service team should be able to search for a user, view a
user and edit any info in the selected user profile. Some specific members of our customer
service team should also be able to delete a user profile and block/enable access to specific
games.
Delivery
• Zip your solution and send it to us
• Important: Include a README file with a description of how the reviewer can see
the working solution. Also add any other comments you might have inside that
file. The reviewer will not see the email body, only the code submission.
• Please clarify your technology choices in the readme. We are very interested in the
reasons.
Notes
• This test has a time limit of one week.
• Think about performance, extensibility, scalability and maintainability.
• Your solution should be made with C# .net.
• Document your database design (schema, index, query, relationships)
• Explain your choice of database.
• Document your API design (routes, payload including endpoints, parameters,
responses)
• Implement it as you would implement any other commercial project
Have fun
