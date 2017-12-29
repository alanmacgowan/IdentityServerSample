using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IdentityServerManager.UI.Infrastructure
{
    public static class MapperExtensions
    {
        public static TDest MapTo<TDest>(this object src)
        {
            return (TDest)Mapper.Map(src, src.GetType(), typeof(TDest));
        }
        public static List<TDest> MapTo<TDest>(this IEnumerable src)
        {
            return src.AsQueryable().ProjectTo<TDest>().ToList();
        }

    }
}
