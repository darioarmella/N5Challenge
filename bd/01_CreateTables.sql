USE [N5Company]
GO
DELETE FROM [dbo].[Permissions]
GO
DELETE FROM [dbo].[PermissionTypes]
GO
SET IDENTITY_INSERT [dbo].[PermissionTypes] ON 

INSERT [dbo].[PermissionTypes] ([Id], [Description]) VALUES (1, N'TestType')
SET IDENTITY_INSERT [dbo].[PermissionTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Permissions] ON 

INSERT [dbo].[Permissions] ([Id], [EmployeeForename], [EmployeeSurname], [PermissionType], [PermissionDate]) VALUES (1, N'string', N'string', 1, CAST(N'2025-05-16' AS Date))
INSERT [dbo].[Permissions] ([Id], [EmployeeForename], [EmployeeSurname], [PermissionType], [PermissionDate]) VALUES (2, N'string', N'string', 1, CAST(N'2025-05-16' AS Date))
INSERT [dbo].[Permissions] ([Id], [EmployeeForename], [EmployeeSurname], [PermissionType], [PermissionDate]) VALUES (1002, N'string1', N'string1', 1, CAST(N'2025-05-17' AS Date))
SET IDENTITY_INSERT [dbo].[Permissions] OFF
GO
