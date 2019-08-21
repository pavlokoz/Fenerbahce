ALTER TABLE [dbo].[InstructorGroup]  WITH CHECK ADD  CONSTRAINT [FK_InstructorGroup_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([GroupId])
GO
ALTER TABLE [dbo].[InstructorGroup] CHECK CONSTRAINT [FK_InstructorGroup_Group]