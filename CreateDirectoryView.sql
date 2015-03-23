USE [AdventureWorks2008]
GO

/****** Object:  View [HumanResources].[vEmployeeDirectory]    Script Date: 03/20/2015 05:23:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [HumanResources].[vEmployeeDirectory]
AS
SELECT     e.BusinessEntityID, p.Title, p.FirstName, p.MiddleName, p.LastName, p.Suffix, e.JobTitle, h.DepartmentID, d.Name AS DepartmentName, pp.PhoneNumber, 
                      pnt.Name AS PhoneNumberType, ea.EmailAddress, p.EmailPromotion, a.AddressLine1, a.AddressLine2, a.City, sp.Name AS StateProvinceName, a.PostalCode, 
                      cr.Name AS CountryRegionName, p.AdditionalContactInfo
FROM         HumanResources.Employee AS e INNER JOIN
                      HumanResources.EmployeeDepartmentHistory AS h ON e.BusinessEntityID = h.BusinessEntityID INNER JOIN
                      HumanResources.Department AS d ON h.DepartmentID = d.DepartmentID INNER JOIN
                      Person.Person AS p ON p.BusinessEntityID = e.BusinessEntityID INNER JOIN
                      Person.BusinessEntityAddress AS bea ON bea.BusinessEntityID = e.BusinessEntityID INNER JOIN
                      Person.Address AS a ON a.AddressID = bea.AddressID INNER JOIN
                      Person.StateProvince AS sp ON sp.StateProvinceID = a.StateProvinceID INNER JOIN
                      Person.CountryRegion AS cr ON cr.CountryRegionCode = sp.CountryRegionCode LEFT OUTER JOIN
                      Person.PersonPhone AS pp ON pp.BusinessEntityID = p.BusinessEntityID LEFT OUTER JOIN
                      Person.PhoneNumberType AS pnt ON pp.PhoneNumberTypeID = pnt.PhoneNumberTypeID LEFT OUTER JOIN
                      Person.EmailAddress AS ea ON p.BusinessEntityID = ea.BusinessEntityID
WHERE     (h.EndDate IS NULL)

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1[50] 4[25] 3) )"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "e"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 214
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "h"
            Begin Extent = 
               Top = 6
               Left = 252
               Bottom = 125
               Right = 421
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "d"
            Begin Extent = 
               Top = 6
               Left = 459
               Bottom = 125
               Right = 619
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p"
            Begin Extent = 
               Top = 6
               Left = 657
               Bottom = 125
               Right = 851
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "bea"
            Begin Extent = 
               Top = 6
               Left = 889
               Bottom = 125
               Right = 1058
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "a"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 205
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "sp"
            Begin Extent = 
               Top = 126
               Left = 243
               Bottom = 245
               Right = 450
            End
            DisplayFlags = 280
            TopColumn = 0
         End
  ' , @level0type=N'SCHEMA',@level0name=N'HumanResources', @level1type=N'VIEW',@level1name=N'vEmployeeDirectory'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'       Begin Table = "cr"
            Begin Extent = 
               Top = 126
               Left = 488
               Bottom = 230
               Right = 674
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "pp"
            Begin Extent = 
               Top = 126
               Left = 712
               Bottom = 245
               Right = 903
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "pnt"
            Begin Extent = 
               Top = 126
               Left = 941
               Bottom = 230
               Right = 1132
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ea"
            Begin Extent = 
               Top = 234
               Left = 488
               Bottom = 353
               Right = 657
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 11
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'HumanResources', @level1type=N'VIEW',@level1name=N'vEmployeeDirectory'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'HumanResources', @level1type=N'VIEW',@level1name=N'vEmployeeDirectory'
GO

