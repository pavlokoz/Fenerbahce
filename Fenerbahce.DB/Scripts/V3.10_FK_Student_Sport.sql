ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Sport] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sport] ([SportId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Sport]