SET IDENTITY_INSERT [dbo].[Entreprise] ON
INSERT INTO [dbo].[Entreprise] ([idEntreprise], [nom], [adr_rue], [adr_numero], [adr_localite], [adr_codePostal], [numTel]) VALUES (2, N'Proximus', N'Rue Saint Jacques', CAST(337 AS Decimal(3, 0)), N'Dinant', CAST(5500 AS Decimal(4, 0)), N'024636881')
INSERT INTO [dbo].[Entreprise] ([idEntreprise], [nom], [adr_rue], [adr_numero], [adr_localite], [adr_codePostal], [numTel]) VALUES (3, N'Cockerill', N'Quai du Halage', CAST(14 AS Decimal(3, 0)), N'Flémalle', CAST(4400 AS Decimal(4, 0)), N'042361111')
INSERT INTO [dbo].[Entreprise] ([idEntreprise], [nom], [adr_rue], [adr_numero], [adr_localite], [adr_codePostal], [numTel]) VALUES (4, N'D''ieteren', N'Parc Industriel', CAST(37 AS Decimal(3, 0)), N'Bruxelles', CAST(1000 AS Decimal(4, 0)), N'023671411')
INSERT INTO [dbo].[Entreprise] ([idEntreprise], [nom], [adr_rue], [adr_numero], [adr_localite], [adr_codePostal], [numTel]) VALUES (5, N'Sibelga', N'Boulevard Emile Jacqmain', CAST(96 AS Decimal(3, 0)), N'Shaerbeek', CAST(1200 AS Decimal(4, 0)), N'025494100')
INSERT INTO [dbo].[Entreprise] ([idEntreprise], [nom], [adr_rue], [adr_numero], [adr_localite], [adr_codePostal], [numTel]) VALUES (6, N'Thomas et Piron', N'Chaussée de Marche', CAST(628 AS Decimal(3, 0)), N'Ciney', CAST(5100 AS Decimal(4, 0)), N'081305643')
SET IDENTITY_INSERT [dbo].[Entreprise] OFF
