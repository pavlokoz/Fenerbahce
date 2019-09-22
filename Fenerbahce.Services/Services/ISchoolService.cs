using Fenerbahce.Models.EntityModels;

namespace Fenerbahce.Services.Services
{
	public interface ISchoolService : IService<SchoolEntity>
	{
		byte[] GetLogoById(long schoolId);
	}
}
