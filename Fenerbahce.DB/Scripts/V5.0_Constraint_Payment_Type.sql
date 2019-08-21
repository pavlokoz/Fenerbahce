ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [CK_Payment] CHECK  (([Type]='M' OR [Type]='F' OR [Type]='E'))
GO

ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [CK_Payment]
GO