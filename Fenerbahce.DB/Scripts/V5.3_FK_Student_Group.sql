IF (OBJECT_ID('dbo.FK_Student_Group', 'F') IS NOT NULL)
BEGIN
    ALTER TABLE [dbo].[Student] DROP CONSTRAINT FK_Student_Group
END
GO

ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([GroupId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Group]