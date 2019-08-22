using System.Collections.Generic;
using System.Linq;

namespace Library.Common.Providers
{
    public interface IMappingProvider
    {
        TDestination MapTo<TDestination>(object source);

        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);

        IQueryable<TDestination> ProjectTo<TDestination>(IQueryable<object> source);

        IEnumerable<TDestination> ProjectTo<TDestination>(IEnumerable<object> source);
    }
}
