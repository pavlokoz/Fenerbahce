ALTER TABLE [dbo].[InstructorGroup]  WITH CHECK ADD  CONSTRAINT [FK_InstructorGroup_Instructor] FOREIGN KEY([InstructorId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[InstructorGroup] CHECK CONSTRAINT [FK_InstructorGroup_Instructor]