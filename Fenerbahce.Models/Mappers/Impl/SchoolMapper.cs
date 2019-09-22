using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;

namespace Fenerbahce.Models.Mappers.Impl
{
	public class SchoolMapper : IMapper<SchoolEntity, SchoolDTO>
	{
		public SchoolEntity Map(SchoolDTO source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("Source can not be null");
			}

			return new SchoolEntity
			{
				SchoolId = source.SchoolId,
				SchoolName = source.SchoolName,
				Logo = source.Logo
			};
		}

		public SchoolDTO Map(SchoolEntity source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("Source can not be null");
			}

			return new SchoolDTO
			{
				SchoolId = source.SchoolId,
				SchoolName = source.SchoolName,
				Logo = source.Logo
			};
		}
	}
}
