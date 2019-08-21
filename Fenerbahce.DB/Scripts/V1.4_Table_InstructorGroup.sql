CREATE TABLE [dbo].[InstructorGroup](
	[InstructorId] [int] NOT NULL,
	[GroupId] [bigint] NOT NULL,
	[Salary] [int] NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_InstructorGroup] PRIMARY KEY CLUSTERED 
(
	[InstructorId] ASC,
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
