ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_Sport] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sport] ([SportId])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_Sport]