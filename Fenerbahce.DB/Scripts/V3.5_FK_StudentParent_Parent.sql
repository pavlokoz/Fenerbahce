ALTER TABLE [dbo].[StudentParent]  WITH CHECK ADD  CONSTRAINT [FK_StudentParent_Parent] FOREIGN KEY([ParentId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[StudentParent] CHECK CONSTRAINT [FK_StudentParent_Parent]
