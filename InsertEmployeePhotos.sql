USE [AdventureWorks2008]
GO

insert into HumanResources.EmployeePhoto (BusinessEntityID) select BusinessEntityID from HumanResources.Employee

select * from HumanResources.EmployeePhoto

GO

Update HumanResources.EmployeePhoto set 
  Photo =
(SELECT  *  
      FROM OPENROWSET  
      ( BULK 'C:\AdventureWorks.Directory\AdventureWorks.Directory\AdventureWorks.Directory\EmployeePhotos\walmart-employee.jpg',SINGLE_BLOB)LP)

where BusinessEntityID IN (SELECT BusinessEntityID FROM HumanResources.Employee WHERE Gender = 'F')

GO

Update HumanResources.EmployeePhoto set 
  Photo =
(SELECT  *  
      FROM OPENROWSET  
      ( BULK 'C:\AdventureWorks.Directory\AdventureWorks.Directory\AdventureWorks.Directory\EmployeePhotos\EmployeePhoto.jpg',SINGLE_BLOB)LP)

where BusinessEntityID IN (SELECT BusinessEntityID FROM HumanResources.Employee WHERE Gender = 'M')

GO
