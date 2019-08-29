using Fenerbahce.Models.DTOModels;
using Fenerbahce.Models.EntityModels;
using System;

namespace Fenerbahce.Models.Mappers.Impl
{
    public class SportMapper : IMapper<SportEntity, SportDTO>
    {
        public SportEntity Map(SportDTO source)
        {
            if (source == null)
            {
                throw new ArgumentException("Source can not be null");
            }

            return new SportEntity
            {
                SportId = source.SportId,
                SportName = source.SportName
            };
        }

        public SportDTO Map(SportEntity source)
        {
            if (source == null)
            {
                throw new ArgumentException("Source can not be null");
            }

            return new SportDTO
            {
                SportId = source.SportId,
                SportName = source.SportName
            };
        }
    }
}
