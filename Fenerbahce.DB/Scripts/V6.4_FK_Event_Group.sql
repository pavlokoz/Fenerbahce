ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([GroupId])
GO

ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Group]
GO