USE [GraphServiceDatabase]
GO

INSERT INTO [dbo].[Users] ([Email], [IsActive]) VALUES ('test@test.com', 1)
GO

INSERT [dbo].[CryptoAssets] ([Name], [Abbreviation], [CoinGeckoAbbreviation]) VALUES (N'bitcoin', N'btc', N'bitcoin')
GO
INSERT [dbo].[CryptoAssets] ([Name], [Abbreviation], [CoinGeckoAbbreviation]) VALUES (N'ethereum', N'eth', N'ethereum')
GO
INSERT [dbo].[CryptoAssets] ([Name], [Abbreviation], [CoinGeckoAbbreviation]) VALUES (N'ripple', N'xrp', N'ripple')
GO
INSERT [dbo].[CryptoAssets] ([Name], [Abbreviation], [CoinGeckoAbbreviation]) VALUES (N'polkadot', N'dot', N'polkadot')
GO
INSERT [dbo].[CryptoAssets] ([Name], [Abbreviation], [CoinGeckoAbbreviation]) VALUES (N'near protocol', N'near', N'near')
GO
INSERT [dbo].[CryptoAssets] ([Name], [Abbreviation], [CoinGeckoAbbreviation]) VALUES (N'stellar', N'xlm', N'stellar')
GO
INSERT [dbo].[CryptoAssets] ([Name], [Abbreviation], [CoinGeckoAbbreviation]) VALUES (N'umee', N'umee', N'umee')
GO
INSERT [dbo].[CryptoAssets] ([Name], [Abbreviation], [CoinGeckoAbbreviation]) VALUES (N'chia', N'xch', N'chia')
GO

INSERT INTO [dbo].[Portfolios] ([Name], [UserId]) VALUES ('Test Portfolio', 1)
GO

INSERT INTO [dbo].[UsersFollowingCryptoAssets] ([UserId], [CryptoAssetId]) VALUES (1, 1)
GO
INSERT INTO [dbo].[UsersFollowingCryptoAssets] ([UserId], [CryptoAssetId]) VALUES (1, 2)
GO
INSERT INTO [dbo].[UsersFollowingCryptoAssets] ([UserId], [CryptoAssetId]) VALUES (1, 3)
GO
INSERT INTO [dbo].[UsersFollowingCryptoAssets] ([UserId], [CryptoAssetId]) VALUES (1, 4)
GO
INSERT INTO [dbo].[UsersFollowingCryptoAssets] ([UserId], [CryptoAssetId]) VALUES (1, 5)
GO
INSERT INTO [dbo].[UsersFollowingCryptoAssets] ([UserId], [CryptoAssetId]) VALUES (1, 6)
GO
INSERT INTO [dbo].[UsersFollowingCryptoAssets] ([UserId], [CryptoAssetId]) VALUES (1, 7)
GO
INSERT INTO [dbo].[UsersFollowingCryptoAssets] ([UserId], [CryptoAssetId]) VALUES (1, 8)
GO
