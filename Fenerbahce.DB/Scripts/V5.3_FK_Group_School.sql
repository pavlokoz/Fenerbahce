IF (OBJECT_ID('dbo.FK_Group_School', 'F') IS NOT NULL)
BEGIN
    ALTER TABLE [dbo].[Group] DROP CONSTRAINT FK_Group_School
END
GO

ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_School] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[School] ([SchoolId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_School]
GO