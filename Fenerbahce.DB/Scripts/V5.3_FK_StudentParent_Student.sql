IF (OBJECT_ID('dbo.FK_StudentParent_Student', 'F') IS NOT NULL)
BEGIN
    ALTER TABLE [dbo].[StudentParent] DROP CONSTRAINT FK_StudentParent_Student
END
GO

ALTER TABLE [dbo].[StudentParent]  WITH CHECK ADD  CONSTRAINT [FK_StudentParent_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentParent] CHECK CONSTRAINT [FK_StudentParent_Student]
