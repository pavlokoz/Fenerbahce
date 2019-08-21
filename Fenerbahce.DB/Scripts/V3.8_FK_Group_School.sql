ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_School] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[School] ([SchoolId])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_School]