# Hardvare
a hardware store project with just the basics for now.

# Setup
## Required Software

- [Visual Studio Community](https://visualstudio.microsoft.com/vs/community/) 
- [SQL Server (Developer Edition)](https://www.microsoft.com/en-gb/sql-server/sql-server-downloads?rtc=1)
- [SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?redirectedfrom=MSDN&view=sql-server-ver15)
- [Github for Desktop](https://desktop.github.com/)

During installation of Visual Studio, make sure to check Data Storage and Processing, as well as ASP.Net and web development.
During installation of SQL Server, you can use the basic setup option, as it will cover our needs.

# Project Setup

Once you have downloaded and installed both Visual Studio, and SQL Server Management Studio, we can now clone the repo onto your local machine, and start with the initial project setup. 

First up, we need to clone the repo down from github. With Github for Desktop open, you will click on Clone from the internet, and follow the instructions. Remember where you store the Repo, as we will need this for the next step.  

Next, we will want to open Visual Studio. You will be prompted with options when opening Visual Studio for the first time, with the one we want being to open a project or solution. Here, we will navigate to the repo directory (where we saved the repo in the first step), and open the solution file. This may take some time, especially if you hav installed Visual studio for the first time, as it will need to collect and download all the project dependancies.

With the project open, we now have access to the projects and their files. To ensure everything is in working order, we will press CTRL + B, to start a build. We can now start the next section of the setup, Sql Server.

We can now open Sql Server Management Studio, and create our Database for the application. Do do this, we need to log in. For this, we can use a '.' for the server name, as this is our local server.

![Screenshot 2021-03-24 213141](https://user-images.githubusercontent.com/12593689/112372359-5cabdb00-8ce8-11eb-8253-1cd978df457e.png)

Next, we will be creating a new Database, and be sure to name it Hardvare, as this is the Database that our application will be looking for.

![Screenshot 2021-03-24 213345](https://user-images.githubusercontent.com/12593689/112372690-c6c48000-8ce8-11eb-80f5-8dcd35f06dd9.png)

![Screenshot 2021-03-24 213451](https://user-images.githubusercontent.com/12593689/112372699-ca580700-8ce8-11eb-976c-0bca04631a0b.png)

The last step in setting up our database will be done in Visual Studio. Here, we want to open the Package Manager Console, like so:

![Screenshot 2021-03-24 213907](https://user-images.githubusercontent.com/12593689/112373204-5c600f80-8ce9-11eb-8169-65272542bf96.png)

With the package manager open (usually a window at the bottom of the screen), we can do the initial Database Migrations. To do this, select Hardvare.Database from the Default Project, enter the following code, and hit enter:

**update-database -verbose**

![Screenshot 2021-03-24 214207](https://user-images.githubusercontent.com/12593689/112373584-caa4d200-8ce9-11eb-9a11-8533bcb862bb.png)

With this step done, its now time to run our API. To do this, hit the F5 key.

The API is setup to use SSL, so when you run it for the first time, you will be prompted to generate a self signed certificate for IIS Express. Select "Yes" here. When prompted again, select "yes" once more. 

With that last step out of the way, you may now interact with the Swagger links for the Hardvare store!

*Jeg håper du syntes denne guiden var nyttig, og håper du liker oppholdet ditt. Takk for tiden din!*
