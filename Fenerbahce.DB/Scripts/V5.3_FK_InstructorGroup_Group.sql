IF (OBJECT_ID('dbo.FK_InstructorGroup_Group', 'F') IS NOT NULL)
BEGIN
    ALTER TABLE [dbo].[InstructorGroup] DROP CONSTRAINT FK_InstructorGroup_Group
END
GO

ALTER TABLE [dbo].[InstructorGroup]  WITH CHECK ADD  CONSTRAINT [FK_InstructorGroup_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([GroupId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InstructorGroup] CHECK CONSTRAINT [FK_InstructorGroup_Group]