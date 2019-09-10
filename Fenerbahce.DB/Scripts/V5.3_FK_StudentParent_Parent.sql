IF (OBJECT_ID('dbo.FK_StudentParent_Parent', 'F') IS NOT NULL)
BEGIN
    ALTER TABLE [dbo].[StudentParent] DROP CONSTRAINT FK_StudentParent_Parent
END
GO

ALTER TABLE [dbo].[StudentParent]  WITH CHECK ADD  CONSTRAINT [FK_StudentParent_Parent] FOREIGN KEY([ParentId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE 
GO
ALTER TABLE [dbo].[StudentParent] CHECK CONSTRAINT [FK_StudentParent_Parent]
