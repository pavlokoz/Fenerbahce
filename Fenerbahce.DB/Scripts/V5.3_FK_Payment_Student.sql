IF (OBJECT_ID('dbo.FK_Payment_Student', 'F') IS NOT NULL)
BEGIN
    ALTER TABLE [dbo].[Payment] DROP CONSTRAINT FK_Payment_Student
END
GO

ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Student]