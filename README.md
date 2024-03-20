# Gist
+ An ASP.NET Core MVC web application with search functionality to retrieve the most relevant posts (Q&A) based on a keyword(s), similar to Stack Overflow, leveraging the public StackOverflow2010 database.
  + Tech Stack: C#, ASP.NET Core MVC, Docker, MSSQL, Azure Data Studio.
+ Users can easily retrieve posts with keyword searches, view paginated results with relevant details like question titles, answer descriptions, number of answers and their votes, authors’ information (their usernames, reputation scores and badge count) and get notified for ongoing searches (via a push notification feature).
+ NOTE: This project works on a Mac (Intel chip). Not sure if it's compatible with M1/M2. It's not compatible with Windows.

# Prerequisites
+ Before you begin, ensure you have the following installed on your Mac (Intel chip) [Kindly go through the "Setup" section for smooth installation]:
  1. [Docker](https://www.docker.com/products/docker-desktop/) (Select the "Download for Mac-Intel Chip" from the dropdown "Download for Mac - Apple Chip)
  2. [Visual Studio for Mac 2022](https://visualstudio.microsoft.com/vs/mac/). Please tick the dotnet package while installing
  3. [Azure Data Studio](https://learn.microsoft.com/en-us/azure-data-studio/download-azure-data-studio?tabs=macOS-install%2Cwin-user-install%2Credhat-install%2Cwindows-uninstall%2Credhat-uninstall#download-azure-data-studio) (Again download the .zip that says "Intel Chip")
  4. Dotnet SDK (You can directly install it via the terminal)
  5. The StackOverflow2010 database (Download it from [here](https://www.brentozar.com/archive/2015/10/how-to-download-the-stack-overflow-database-via-bittorrent/))
 
# Setup
+ Kindly follow the steps in the given link - [Setup Instructions](https://builtin.com/software-engineering-perspectives/sql-server-management-studio-mac).

# Approach
+ To leverage Entity Framework Core's ability to automate model and DbContext creation, I opted for the database-first approach. This involved scaffolding the models and DbContext directly from the existing database, saving me significant development time.

# Running the application
1. Place the database in the path /var/opt/mssql/data/ inside Azure Data Studio. Kindly follow this link for smooth setup - https://sqlblog.org/2020/03/15/attaching-restoring-databases-inside-a-container. Once the database is uploaded, please connect to the server. For connection, please use the following:
    + Server: localhost
    + Username: sa (You should use the same username that you used while setup)
    + Password: dockerStrongPwd123 (You should use the same password that you used while setup)
    + Authentication Type: SQL Login
    + Trust Server Certificate: True
 2. Clone this repository into local or download ZIP.
 3. Open Visual Studio for Mac and Click on Open and navigate to the project file "StackOverflowLikeWeb.csproj" via the path StackOverflowLike/StackOverflowLikeWeb/StackOverflowLikeWeb.csproj (wherever you've stored the project folder in your local).
 4. In the menu bar, navigate to "Project", click on "Manage Nuget Packages..." and check if the following packages are installed:
    + Microsoft.EntityFrameworkCore.Sqlite 7.0.16
    + Microsoft.EntityFrameworkCore.SqlServer 7.0.16 
    + Microsoft.EntityFrameworkCore.Tools 7.0.16
    + Microsoft.Extensions.Configuration 7.0.0
    + Microsoft.VisualStudio.Web.CodeGeneration.Design 7.0.12
  5. If not, please install them and add them to the project.
  6. I've added 2 indexes to the database - one for the column "Type" in the table "PostTypes" and one for the column "Name" in the table "VoteTypes". You can also check the migration files in the project folder by navigating to StackOverflowLikeWeb/Migrations/20240223114915_AddingIndexesMigration. In order to reflect these changes to the database, please open the terminal tab down in Visual Studio, navigate to the project folder StackOverflowLikeWeb and run "dotnet ef database update". Once it's done, verify these updates in Azure Data Studio.
  7. In the menu bar of Visual Studio, navigate to "Build" and in the dropdown, click on "Clean all".
  8. Once the clean is successful, navigate to "Build" and in the dropdown, click on "Rebuild Solution" and wait for successful build.
  9. On the top-left, click on the play icon to run the project (You can also use "command + return") and wait for 2-3 seconds.
  10. On the browser, click on "Posts" and then search for any keyword(s). For example, you can type "the difference between" and click on "Search".
  11. You'll get notified (via a push notification) for the ongoing search.
  12. Click on "OK" and wait for 3-5 seconds.
  13. The most relevant posts with the required information as mentioned in "Brief description" will be displayed.
  14. You can again click on "Posts" to search for another keyword(s).

# Features
+ Indexing:
  + I've added 2 indexes to the database - one for the column "Type" in the table "PostTypes" and one for the column "Name" in the table "VoteTypes" for query optimization.
+ Search bar:
  + The user can search for keyword(s) to fetch posts.
  + I've included a "Back to Search" button which helps the user navigate to the search page.
+ Push notification:
  + The user gets notified for ongoing searches.
+ Pagination (10 posts per page):
  + The user has the options to either go to the previous page or next page or first page or last page or a page number of his or her choice.
  + The first and previous pages are disabled when the user is on page 1.
  + The next and last pages are disabled when the user is on the last page.
 
# Assumptions
1. I've assumed that the search keyword(s) is a string.

# Limitations
1. Lacks exception handling and progressive/lazy loading.
2. Minimal front-end.
3. Not a complete StackOverflow clone.
4. Isn't deployed. So, it can be tested only locally for now. However, you can always deploy it and test it. It should work. 


