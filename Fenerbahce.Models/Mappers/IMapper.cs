namespace Fenerbahce.Models.Mappers
{
    public interface IMapper<TEntity, TDTO>
        where TEntity : class, new()
        where TDTO : class, new()
    {
        TEntity Map(TDTO source);
        TDTO Map(TEntity source);
    }
}
