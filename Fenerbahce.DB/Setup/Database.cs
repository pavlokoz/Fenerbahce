using DbUp;
using System.Reflection;

namespace Fenerbahce.DB.Setup
{
	public class Database
	{
		public static void Setup(string connectionString)
		{
			EnsureDatabase.For.SqlDatabase(connectionString);

			var upgrader = DeployChanges.To
			.SqlDatabase(connectionString)
			.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
			.LogToConsole()
			.Build();

			var result = upgrader.PerformUpgrade();
		}
	}
}
