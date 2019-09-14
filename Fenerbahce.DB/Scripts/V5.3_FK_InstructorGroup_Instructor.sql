IF (OBJECT_ID('dbo.FK_InstructorGroup_Instructor', 'F') IS NOT NULL)
BEGIN
    ALTER TABLE [dbo].[InstructorGroup] DROP CONSTRAINT FK_InstructorGroup_Instructor
END
GO

ALTER TABLE [dbo].[InstructorGroup]  WITH CHECK ADD  CONSTRAINT [FK_InstructorGroup_Instructor] FOREIGN KEY([InstructorId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InstructorGroup] CHECK CONSTRAINT [FK_InstructorGroup_Instructor]