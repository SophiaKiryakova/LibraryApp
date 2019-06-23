using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Common.Providers
{
    public class MappingProvider : IMappingProvider
    {
        public MappingProvider(IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public TDestination MapTo<TDestination>(object source)
        {
            return this.mapper.Map<TDestination>(source);
        }

        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable<object> source)
        {
            return this.mapper.ProjectTo<TDestination>(source);
        }

        public IEnumerable<TDestination> ProjectTo<TDestination>(IEnumerable<object> source)
        {
            return this.mapper.ProjectTo<TDestination>(source.AsQueryable());
        }

        private readonly IMapper mapper;
    }
}
