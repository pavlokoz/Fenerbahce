ALTER TABLE [dbo].[Event] ADD  CONSTRAINT [DF_Event_Active]  DEFAULT ((1)) FOR [Active]
GO