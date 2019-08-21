ALTER TABLE [dbo].[InstructorGroup]  WITH CHECK ADD  CONSTRAINT [CK_InstructorGroup] CHECK  (([Type]='M' OR [Type]='L'))
GO

ALTER TABLE [dbo].[InstructorGroup] CHECK CONSTRAINT [CK_InstructorGroup]
GO