# Alten Hotel Project

Hello! Welcome to my Alten Hotel Project!

This solution was implemented as a test.
From the start i say: i did not do what i was asked. I did more.

And i do not say this with any sign of arrogance. I just think that, in every aspect of my life, i try to do the best i can.
The orientation for the project said that the API did not need to be secured, but i think that the best implementation, in a real case scenario, there is no way
this system could be insecure. So, i made it secure, with username and password authentication.

The use case said that the hotel only has one room. And my implementation works that way.
But, if someday the owner recovers from bankruptcy, it would not take much effort to make my solution work with other rooms and even other hotels.

So, to the solution.

I left everything ready to start. You only need to open the Package Manager Console, run the 'Update-Database' command (this will create the database and populate the first data).

As i said before, this solution uses authentication. But, like a real world booking application, you can perform some actions without authentication.
That is the case of the method availability, in the controller Booking.

In order to make it easier for everyone to test, i implemented this API using Swagger UI. It is very easy to use.

Continuing, the availability check can be performed without username and password.
But, if you want to book a day, well, you will need to register.

The first user that i populate in the database has an "admin" role. This role allows the user to do some things that a "client" user can not (those are the 2 role profiles that i thought about for this solution).

So, to register a new user, you will need to use the admin user.

The username is: 'batman'
The password is: 'batman'

The passwords are stored in the database encrypted. I used SHA256 to do the encryption and i think that is enough for now.

When you try to access the methods that require authentication, you will receive a code 401, unauthorized. 
If you are authenticated but you do not have the admin permission to run a method, you will receive a 403 code.

Once you are authenticated, you can book a day in the hotel, you can list all of your reservations (if you are only a client and not an admin. Admins can listAll the reservations).
You can still get the info on a reservation, using the bookingNumber, you can cancel a reservation, delete or alter it.

I did not implement a lot of validation but i did a few. For example, if you do not provide a GUID as bookingNumber in the CreateBooking event, one will be provided for you. 
But, if you try to alter the user id on your own booking, the system will allow you to.

I will write some comments inside the code in order to make it easier to anyone to understand what i was thinking, but, it is very simple code.

I hope you like it. I look forward on discussing this with you guys.

See you!

