ALTER TABLE [dbo].[VisitorLog]  WITH CHECK ADD  CONSTRAINT [FK_VisitorLog_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[VisitorLog] CHECK CONSTRAINT [FK_VisitorLog_Student]