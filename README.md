# Hack Job, a Hair Cuttery

#### An epicodus project using C# and SQL

#### **By David Wilson**

## Description

This web application will allow the user to add stylists and clients. They will be able to delete and/or edit a client as well.

![alt text](https://github.com/GrapeSalad/Hair-Salon/blob/master/Content/img/barbershop.gif "Barber Of Seville")

#### RESTful Routing
| Behavior | Input | Output |
|---|---|---|
| Home Page | "localhost:5004/" | home.cshtml |
| View Stylists | "localhost:5004/stylists" | stylists.cshtml |
| Add Stylists | "localhost:5004/stylists/new" | stylists_add.cshtml |
| View Clients | "localhost:5004/clients" | clients.cshtml |
| Add Clients | "localhost:5004/clients/new" | clients_add.cshtml |
| View specific stylist | "localhost:5004/stylists/1" | stylist.cshtml |
| View specific client | "localhost:5004/clients/1" | client.cshtml |
| Edit client | "localhost:5004/client/1/edit" | client_edit.cshtml |
| Delete client | "localhost:5004/client/1/delete" | client_delete.cshtml |

### SPECS
1.  List all stylists
2.  List all clients
3.  See Stylists details (name, specialty, list of clients)
4.  Add stylists
5.  Add clients to stylist
6.  Update client information
7.  Delete client information

| Behavior | Input | Output |
|---|---|---|
| User enters a stylist first and last name | "Frannk Fronk" | "Frannk Fronk" |
| User enters stylist specialty | "buzz cuts" | "buzz cuts" |
| User enters client name | "Dwafid" | "Dwafid" |
| User realizes error, needs to edit client name | "David" | "Dwafid" --> "David" |
| User notices client is no longer a patron | Delete "David" | success |

## Setup/Installation Requirements

1.  Go to the Github repository page at https://github.com/GrapeSalad/Hair-Salon
2.  Click the "download or clone" button and copy the link.
3.  In your Microsoft Windows installation location open PowerShell.
4.  In PowerShell navigate to the directory in which you want to store the app files.
5.  Clone using "git clone " and the copied link.
6.  To run the project locally you will need Mono Compiler (http://www.mono-project.com/download/#download-win), Visual Studio 2015 (https://go.microsoft.com/fwlink/?LinkId=532606), and ASP.Net 5 (https://go.microsoft.com/fwlink/?LinkId=627627).
You will also need SSMS (https://go.microsoft.com/fwlink/?linkid=849819).
7.  Setting up the database will occur after installation and downloading. In PowerShell run the command: sqlcmd -S "(localdb)\mssqllocaldb" . Then you will see a 1>. Type CREATE DATABASE hair_salon -> press enter -> type GO. Now type SSMS into your windows search bar and open SQL Server Management Studio.
8.  To connect to the appropriate database type (localdb)\mssqllocaldb into the "server name" field in the popup window.
9.  I have included a few SQL scripts to help you start up your server, they cn be found in the SQL_Queries folder. Double click on them and open them with SSMS, and then execute the one titled Initial_Table_Setup.
10. In SSMS, right click on the hair-salon database -> Tasks -> Backup -> OK. Then right click on hair-salon database again -> Tasks -> Restore -> Database -> rename hair-salon to hair-salon_test -> OK. This will set up a testing environment for the Xunit Tests.
11.  Once those are all installed and the tables are created, restart PowerShell and enter "dnvm upgrade" into the prompt.
12.  Now you can navigate to the directory in which you downloaded the Hair-Salon App, and then into the Hair-Salon home file.
13.  To start the web server necessary for proper app functionality you will need to type in "dnu restore" then "dnx kestrel".
14.  Open a web browser, and type "localhost:5004".
To view the code you can open the files using your editor of choice.
15. If you have the editor path set in your system properties you will be able to open them through PowerShell.

## Known Bugs



## Support and Contact Details

If you have any issues, questions, ideas, concerns, or contribution ideas please contact any of the contributors via Github.

## Technologies used

* C-Sharp
* CSS
* Javascript
* HTML
* Boostrap
* JSON
* DVNM
* PowerShell
* Google Chrome
* Razor
* Nancy
* xUnit
* SQL
* SSMS

### License

This software is licensed under the MIT license.

Copyright (c) 2017 **David Wilson**
