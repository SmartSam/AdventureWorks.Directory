# AdventureWorks.Directory
MVC 5 Employee Directory for Adventure Works


###### Operating System: Windows 7 Home Premium
###### Visual Studio Version: Visual Studio 13 Community Edition
###### SQLServer Version: SQLServer Express 2008
###### DevExpress Suite Version: DevExpressUniversalTrial-20150218

## About:
* This is an ASP.Net MVC 5 application.  This application is an employee directory for Adventure Works.
* This application has custom views for mobile and tablet browsers.

## Install DevExpress Trial:
* This application uses the DevExpess MVC extensions.  
* A free 30-day trial version of this suite can be downloaded from: https://www.devexpress.com/Home/try.xml

## Database:
* This application uses a version of AdventureWorks for SQLServer 2008 (AdventureWorks2008).
* AdventureWorks database can be downloaded from: https://msftdbprodsamples.codeplex.com/releases/view/93587

## Database changes:
* This application uses a custom view to query the employee records.  There is an sql file: CreateDirectoryView.sql that creates this view.
* There are two other sql files to run to setup a table to store employee photos.
  * CreateEmployeePhotoTable.sql creates the HumanResources.EmployeePhoto table.
  * InsertPhotos.sql inserts records and image files into this table.  
* There are only 2 image files that are used.  They are in the folder EmployeePhotos.  You may have to update the file path to these photos in the InsertPhotos.sql.
  

## Mobile Emulators:
* Opera free mobile emulator for non-apple devices: http://www.opera.com/developer/mobile-emulator
* Responsinator has a good online emulator for iPhone 5: http://www.responsinator.com/



